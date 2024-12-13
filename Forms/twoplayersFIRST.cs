using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hangman
{
    public partial class twoplayersFIRST : Form
    {

        twoplayersSECOND tps;

        public twoplayersFIRST()
        {

            InitializeComponent();
        }





        //кнопка В меню
        private void buttonback1_Click(object sender, EventArgs e)
        {
            this.Close();
            mainmenu menuwidnow = new mainmenu();
            menuwidnow.Show();
        }


        //кнопка старта не нажмется пока пустое одно из двух текстбоксов
        private void textBoxCategory_TextChanged(object sender, EventArgs e)
        {
            if ((textBoxCategory.Text.Length == 0) || (textBoxWord.Text.Length == 0) || (textBoxFirstName.Text.Length == 0) || (textBoxSecondName.Text.Length == 0)) buttonStart.Enabled = false;
            else buttonStart.Enabled = true;
        }


        //кнопка старта не нажмется пока пустое одно из двух текстбоксов
        private void textBoxWord_TextChanged(object sender, EventArgs e)
        {
            if ((textBoxCategory.Text.Length == 0) || (textBoxWord.Text.Length == 0) || (textBoxFirstName.Text.Length == 0) || (textBoxSecondName.Text.Length == 0)) buttonStart.Enabled = false;
            else buttonStart.Enabled = true;
        }



        //пользователь может ввести только русские буквы и бэкспейс
        private void textBoxCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !((c >= 'а' && c <= 'я') || c == 'ё' || (c >= 'А' && c <= 'Я') || c == 'Ё' || c == 8);
        }

        //пользователь может ввести только русские буквы и бэкспейс
        private void textBoxWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !((c >= 'а' && c <= 'я') || c == 'ё' || (c >= 'А' && c <= 'Я') || c == 'Ё' || c == 8);
        }




        //нажата кнопка начала игры
        private void buttonStart_Click(object sender, EventArgs e)
        {

            DateBank.Name1 = textBoxFirstName.Text;
            DateBank.Name2 = textBoxSecondName.Text;



            //проверка первого игрока в базе данных
            SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM Users WHERE name = N'{DateBank.Name1}'", sqlConnection);
            int count = (int)command.ExecuteScalar();

            if (count > 0)
            {
                // Пользователь существует, увеличиваем games_played
                UpdateGamesPlayed(DateBank.Name1, sqlConnection);
            }
            else
            {
                // Пользователь не существует, добавляем нового пользователя
                AddNewUser(DateBank.Name1, sqlConnection);
            }

            //проверка второго игрока в базе данных
            SqlCommand command2 = new SqlCommand($"SELECT COUNT(*) FROM Users WHERE name = N'{DateBank.Name2}'", sqlConnection);
            int count2 = (int)command2.ExecuteScalar();

            if (count2 > 0)
            {
                // Пользователь существует, увеличиваем games_played
                UpdateGamesPlayed(DateBank.Name2, sqlConnection);
            }
            else
            {
                // Пользователь не существует, добавляем нового пользователя
                AddNewUser(DateBank.Name2, sqlConnection);
            }



            DateBank.ChoosenCategory = textBoxCategory.Text;//передаем категорию от первого игрока второму игроку
            DateBank.HiddenWord = textBoxWord.Text.ToLower();//передаем слово от первого игрока второму игроку


            DateBank.HiddenWordLettersCount = DateBank.HiddenWord.Length;// количество букв в загаданном слове


            //открываем вторую форму = переходим к форме twoplayersSECOND
            tps = new twoplayersSECOND();
            tps.Show();
            this.Close();


        }


        //функция добавления нового пользователя 
        private void AddNewUser(string userName, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand($"INSERT INTO Users (name, games_played, score) VALUES (N'{DateBank.Name}', 1, 0)", connection);
            command.ExecuteNonQuery();
        }



        //функция прибавления ещё одного отыгрыша уже существующему человеку 
        private void UpdateGamesPlayed(string userName, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand($"UPDATE Users SET games_played = games_played + 1 WHERE name = N'{DateBank.Name}'", connection);
            command.ExecuteNonQuery();
        }






        public SqlConnection sqlConnection = null;

        private void twoplayersFIRST_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["hangmanDB"].ConnectionString);
            sqlConnection.Open();
        }
    }



    
}

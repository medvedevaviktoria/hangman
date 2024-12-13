using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Permissions;
using hangman.Properties;
using System.Configuration;
using System.Data.SqlClient;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using static System.Data.Entity.Infrastructure.Design.Executor;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Information;


namespace hangman
{
    public partial class oneplayer : Form
    {
        
        public oneplayer()
        {
            InitializeComponent();
        }


        //кнопка В меню
        private void buttonback_Click(object sender, EventArgs e)
        {

            if (Exit == true )
            {
                if (MessageBox.Show("Вы уверены, что хотите вернуться в меню? При выходе будет засчитано автоматическое поражение(с вашего счёта в рейтинге снимутся баллы, а игра не покажет Вам загаданное слово).", "Выход в меню", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCommand command = new SqlCommand($"UPDATE Users SET score = CASE WHEN score - {DateBank.Grade} < 0 THEN 0 ELSE score - {DateBank.Grade} END WHERE name = N'{DateBank.Name}'", sqlConnection);
                    command.ExecuteNonQuery();
                    this.Close();
                    mainmenu menuwidnow = new mainmenu();
                    menuwidnow.Show();

                }
            }
            else
            {
                this.Close();
                mainmenu menuwidnow = new mainmenu();
                menuwidnow.Show();
            }    

            
        }



        //кнопка выбора категории
        private void choosecategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateBank.ChoosenCategory = choosecategory.Text; // вписываем категорию которую выбрал пользователь
            DateBank.HiddenWord = GetRandomWord(DateBank.ChoosenCategory);
            //кнопка старт становится доступной
            if (DateBank.HiddenWord == null) buttonStart.Enabled = false;
            else buttonStart.Enabled = true;

        }


        //функция выбора слова из базы данных
        private string GetRandomWord(string category)
        {
            string query = "SELECT word FROM Words";
            if (category != "Случайная категория")
            {
                query += $" WHERE theme = N'{category}'";
            }


            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<string> words = new List<string>();
                    while (reader.Read())
                    {
                        words.Add(reader.GetString(0));
                    }

                    if (words.Count > 0)
                    {
                        Random random = new Random();
                        return words[random.Next(words.Count)];
                    }
                    else
                    {
                        MessageBox.Show("В выбранной категории нет слов. Выберите другую категорию.");
                        return null; // Или другое значение по умолчанию
                    }
                }


            }
        }


        private int GetWordGrade(string word)
        {
            SqlCommand command = new SqlCommand($"SELECT grade FROM Words WHERE word = N'{word}'", sqlConnection);
            return (int)command.ExecuteScalar();
        }




        public bool Exit = false;

        //кнопка запуска игры
        private void buttonStart_Click(object sender, EventArgs e)
        {
            hiddenword_label.Text = "";
            DateBank.ChoosenCategory = choosecategory.Text; // вписываем категорию которую выбрал пользователь


            //функция рандома слова из базы данных

            DateBank.HiddenWord = GetRandomWord(DateBank.ChoosenCategory);


            Console.WriteLine(DateBank.HiddenWord);


            //функция нахождения количества баллов за слово
            DateBank.Grade = GetWordGrade(DateBank.HiddenWord);




            DateBank.HiddenWordLettersCount = DateBank.HiddenWord.Length;// количество букв в загаданном слове


            //в первый раз в hiddenword_label записываем слово используя андерскоры

            for (DateBank.Index = 0; DateBank.Index < DateBank.HiddenWordLettersCount; DateBank.Index++)
            {
                DateBank.HiddenWordLettersArray[DateBank.Index] = '_';
                hiddenword_label.Text = hiddenword_label.Text + "   " + DateBank.HiddenWordLettersArray[DateBank.Index];
            }

            for (DateBank.Index = 0; DateBank.Index < DateBank.HiddenWordLettersCount; DateBank.Index++)
            {
                DateBank.HiddenWordLettersShowArray[DateBank.Index] = DateBank.HiddenWord[DateBank.Index];
            }

            labelcategory.Text = "Категория:  " + DateBank.ChoosenCategory;
            choosecategory.Visible = false;
            choosecategory.Enabled = false;
            labelEnter.Visible = true;
            userGuessLetter.Visible = true;
            buttonGuess.Visible = true;
            buttonStart.Visible = false;
            pictureBox1.Visible = true;
            hiddenword_label.Visible = true;

            Exit = true;


            SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM Users WHERE name = N'{DateBank.Name}'", sqlConnection);
            int count = (int)command.ExecuteScalar();

            if (count > 0)
            {
                // Пользователь существует, увеличиваем games_played
                UpdateGamesPlayed(DateBank.Name, sqlConnection);
            }
            else
            {
                // Пользователь не существует, добавляем нового пользователя
                AddNewUser(DateBank.Name, sqlConnection);
            }



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




        //кнопка угадвания не работает пока поле с буквой не заполнено
        private void userGuessLetter_TextChanged(object sender, EventArgs e)
        {
            if (userGuessLetter.Text.Length == 0) buttonGuess.Enabled = false;
            else buttonGuess.Enabled = true;

        }


        //пользователь может писать только русские строчные буквы и бэкспейс
        private void userGuessLetter_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !((c >= 'а' && c <= 'я') || c == 'ё' || (c >= 'А' && c <= 'Я') || c == 'Ё' || c == 8);
        }



        //при нажатии кнопки угадывания буквы
        private void buttonGuess_Click(object sender, EventArgs e)
        {
            DateBank.ErrorLetterCheck = 0;
            hiddenword_label.Text = "";


            DateBank.GuessLetter = userGuessLetter.Text.ToLower().ToCharArray()[0];


            //int errorLetterCheck = 0;
            //сравниваем букву введённую пользователем 
            //принцип такой: если буква введённая пользователем равна той же букве в загаданном слове, то errorLetterCheck инкрементируется,
            //далее проверяется условие равна ли эта переменная 0. 
            //да = значит мы ошиблись с буквой errorLetter инкрементируется как счётчик ошибок
            //нет = значит мы не ошиблись с буквой errorLetter не инкрементируется
            for (DateBank.Index = 0; DateBank.Index < DateBank.HiddenWordLettersCount; DateBank.Index++)
            {
                if (DateBank.GuessLetter == DateBank.HiddenWordLettersShowArray[DateBank.Index])
                {
                    DateBank.HiddenWordLettersArray[DateBank.Index] = DateBank.HiddenWordLettersShowArray[DateBank.Index];
                    DateBank.ErrorLetterCheck++;
                }
            }
            if (DateBank.ErrorLetterCheck == 0)
                DateBank.ErrorLetter++;
                
            //проверка колва ошибок для изображения

            switch (DateBank.ErrorLetter)
            {
                case 1:
                    pictureBox1.Image = hangman.Properties.Resources.Img1;
                    
                    break;
                case 2:
                    pictureBox1.Image = hangman.Properties.Resources.Img2;
                    break;
                case 3:
                    pictureBox1.Image = hangman.Properties.Resources.Img3;
                    break;
                case 4:
                    pictureBox1.Image = hangman.Properties.Resources.Img4;
                    break;
                case 5:
                    pictureBox1.Image = hangman.Properties.Resources.Img5; 
                    break;
                case 6:
                    pictureBox1.Image = hangman.Properties.Resources.Img6; 
                    break;

            }


            //слово показывается пользователю после всех проверок со всеми отгаданными и неотгаданными буквами
            for (DateBank.Index = 0; DateBank.Index < DateBank.HiddenWordLettersCount; DateBank.Index++)
            {
                hiddenword_label.Text = hiddenword_label.Text + "   " + DateBank.HiddenWordLettersArray[DateBank.Index];
            }
            userGuessLetter.Text = String.Empty;

            DateBank.RightLetter = 0;
            for (DateBank.Index = 0; DateBank.Index < DateBank.HiddenWordLettersCount; DateBank.Index++)
            {
                if (DateBank.HiddenWordLettersArray[DateBank.Index] != '_')
                {
                    DateBank.RightLetter++;
                }

            }

            //сообщения о проигрыше либо выигрыше
            if (DateBank.RightLetter == DateBank.HiddenWordLettersCount)
            {

                SqlCommand command = new SqlCommand($"UPDATE Users SET score = score + {DateBank.Grade} WHERE name = N'{DateBank.Name}'", sqlConnection);
                command.ExecuteNonQuery();

                this.Close();
                win1p win1pWindow = new win1p();
                win1pWindow.Show();
            }

            if (DateBank.ErrorLetter == 6)
            {
                
                SqlCommand command = new SqlCommand($"UPDATE Users SET score = CASE WHEN score - {DateBank.Grade} < 0 THEN 0 ELSE score - {DateBank.Grade} END WHERE name = N'{DateBank.Name}'", sqlConnection);
                command.ExecuteNonQuery();


                this.Close();
                lose1p lose1pWindow = new lose1p();
                lose1pWindow.Show();
            }
        }

        public SqlConnection sqlConnection = null;

        private void oneplayer_Load(object sender, EventArgs e)
        {
            DateBank.ErrorLetter = 0;//сколько раз пользователь угадал букву

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["hangmanDB"].ConnectionString);
            sqlConnection.Open();

            

        }
    }
    
}
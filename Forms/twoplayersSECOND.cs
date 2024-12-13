﻿using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hangman
{
    public partial class twoplayersSECOND : Form
    {


        public twoplayersSECOND()
        {
            InitializeComponent();
        }


        //кнопка В меню
        private void buttonback2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите вернуться в меню? При выходе будет засчитано автоматическое поражение человеку, угадывающему слово(баллы снимутся со счёта угадывающего человека и добавятся человеку, загадавшему слово, а игра не покажет загаданное слово).", "Выход в меню", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand command = new SqlCommand($"UPDATE Users SET score = CASE WHEN score - {DateBank.Grade} < 0 THEN 0 ELSE score - {DateBank.Grade} END WHERE name = N'{DateBank.Name}'", sqlConnection);
                command.ExecuteNonQuery();
                this.Close();
                mainmenu menuwidnow = new mainmenu();
                menuwidnow.Show();

            }
            
        }



        public SqlConnection sqlConnection = null;


        //Действия при загрузке формы
        private void twoplayersSECOND_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["hangmanDB"].ConnectionString);
            sqlConnection.Open();


            DateBank.ErrorLetter = 0;
            hiddenword_label.Text = "";
            label2Category.Text = "Категория:  " + DateBank.ChoosenCategory;
            Console.WriteLine(DateBank.HiddenWord);


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
            hiddenword_label.Text = "";


            DateBank.GuessLetter = userGuessLetter.Text.ToCharArray()[0];




            DateBank.ErrorLetterCheck = 0;
            //сравниваем букву введённую пользователем 
            //принцип такой: если буква введённая пользователем равна любой букве в загаданном слове, то ErrorLetterCheck инкрементируется,
            //далее проверяется условие равна ли эта переменная 0. 
            //да = значит мы ошиблись с буквой ErrorLetterCheck инкрементируется как счётчик ошибок
            //нет = значит мы не ошиблись с буквой ErrorLetterCheck не инкрементируется
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




            //меняем изображение при ошибках
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

            // вписать слово в лэйбл после проверки буквы
            for (DateBank.Index = 0; DateBank.Index < DateBank.HiddenWordLettersCount; DateBank.Index++)
            {
                hiddenword_label.Text = hiddenword_label.Text + "   " + DateBank.HiddenWordLettersArray[DateBank.Index];
            }
            userGuessLetter.Text = String.Empty;



            //проверка колва правильных букв
            DateBank.RightLetter = 0;
            for (DateBank.Index = 0; DateBank.Index < DateBank.HiddenWordLettersCount; DateBank.Index++)
            {
                if (DateBank.HiddenWordLettersArray[DateBank.Index] != '_')
                {
                    DateBank.RightLetter++;
                }

            }

            //проверки на то угадал ли пользователь слово
            if (DateBank.RightLetter == DateBank.HiddenWordLettersCount)
            {
                this.Close();
                win2p win1pWindow = new win2p();
                win1pWindow.Show();
            }

            if (DateBank.ErrorLetter == 6)
            {
                this.Close();
                lose2p lose2pWindow = new lose2p();
                lose2pWindow.Show();
            }

        }
    }
}

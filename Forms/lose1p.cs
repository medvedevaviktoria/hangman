﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hangman
{
    public partial class lose1p : Form
    {
        public lose1p()
        {
            InitializeComponent();
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            oneplayer oneplayerwindow = new oneplayer();

            oneplayerwindow.Show();
            this.Hide();
        }

        private void buttonchange_Click(object sender, EventArgs e)
        {
            this.Close();
            oneplayer oneplayerwindow = new oneplayer();
            oneplayerwindow.Close();
            mainmenu menuwidnow = new mainmenu();
            menuwidnow.Show();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lose1p_Load(object sender, EventArgs e)
        {
            label2.Text = "К сожалению, Вы не угадали!\r\nЗагаданным словом было <" + DateBank.HiddenWord + ">.\r\nПопробуете ещё разок? :)";
        }
    }
}

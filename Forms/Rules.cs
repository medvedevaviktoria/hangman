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
    public partial class Rules : Form
    {
        public Rules()
        {
            InitializeComponent();
        }

        private void buttonback_Click(object sender, EventArgs e)
        {
            this.Close();
            mainmenu menuwidnow = new mainmenu();
            menuwidnow.Show();
        }
    }
}

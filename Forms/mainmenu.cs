using hangman.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

//содержание



namespace hangman
{
    public partial class mainmenu : Form
    {
        public mainmenu()
        {
            InitializeComponent();
        }

        private void button1player_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            Entry1p Entry1playerwindow = new Entry1p();
            Entry1playerwindow.Show();

        }

        private void buttonexit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button2players_Click(object sender, EventArgs e)
        {
            this.Hide();
            twoplayersFIRST twoplayerswindow1 = new twoplayersFIRST();
            twoplayerswindow1.Show();
        }

        private void buttonRules_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rules rulesWindow = new Rules();
            rulesWindow.Show();
        }

        private void buttonTop_Click(object sender, EventArgs e)
        {
            leaderboard leaderboardwindow = new leaderboard();
            leaderboardwindow.Show();
        }


    

        public void mainmenu_Load(object sender, EventArgs e)
        {
           
            
        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlClient;


namespace hangman.Forms
{
    public partial class Entry1p : Form
    {

        //UserContext db;

        public Entry1p()
        {
            InitializeComponent();

            //db = new UserContext();
        }

        private void buttonback_Click(object sender, EventArgs e)
        {
            this.Close();
            mainmenu menuwidnow = new mainmenu();
            menuwidnow.Show();
        }



        public SqlConnection sqlConnection = null;

        private void Entry1p_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["hangmanDB"].ConnectionString);
            sqlConnection.Open();

            
        }



        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.Hide();

            oneplayer oneplayerwindow = new oneplayer();
            oneplayerwindow.Show();

            DateBank.Name = textBoxName.Text;


        }




        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length == 0) buttonStart.Enabled = false;
            else buttonStart.Enabled = true;
        }
    }
}

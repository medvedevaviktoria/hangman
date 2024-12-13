
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;

namespace hangman.Forms
{
    public partial class leaderboard : Form
    {
        public SqlConnection sqlConnection = null;

        private void leaderboard_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["hangmanDB"].ConnectionString);
            sqlConnection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                "SELECT * FROM Users",
                sqlConnection);

            DataSet dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            leaderboardTop.DataSource = dataSet.Tables[0];


        }
        public leaderboard()
        {
            InitializeComponent();


        }



    }
}

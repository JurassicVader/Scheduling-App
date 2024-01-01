using MySql.Data.MySqlClient;
using SpencerProject.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpencerProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            MySqlConnection c = DBConnection.conn;
            if (c.State == ConnectionState.Open)
            {
                MessageBox.Show("Connection Open");
            } else { MessageBox.Show("Connection Closed"); }
        }
    }
}

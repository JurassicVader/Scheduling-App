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
            Application.Exit();
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string username, password;
                username = username_txtbox.Text;
                password = Password_txtBox.Text;

                // A SQL statement that is fetching a username and password match from the strings above.
                string query = "SELECT * FROM user WHERE username = '" + username + "' AND password = '" + password + "'";
                MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    HomePage homePage = new HomePage();
                    homePage.Show();
                    this.Hide();
                }
                else
                {
                    incorrect_txt.Visible = true;
                }
                reader.Close();

                /*
                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + "--" + reader[1]);
                }
                */


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            /*MySqlConnection c = DBConnection.conn;
            if (c.State == ConnectionState.Open)
            {
                MessageBox.Show("Connection Open");
            } else { MessageBox.Show("Connection Closed"); }
            */
        }
    }
}

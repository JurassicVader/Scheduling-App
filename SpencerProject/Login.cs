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
using System.Globalization;

namespace SpencerProject
{
    public partial class Login : Form
    {
        private string username;
        private string password;

        public Login()
        {
            InitializeComponent();
            
        }


        /* This only checks if the region is United States or Italy. 
         * Changes only take effect if the region is changed in Control Panel
         * Changes are immediate and work in app.
        */
        static string CurrentRegion()
        {
            try
            {
                CultureInfo.CurrentCulture.ClearCachedData();
                if (RegionInfo.CurrentRegion.DisplayName == "Italy")
                {
                    
                    return "Italy";
                }
                else if (RegionInfo.CurrentRegion.DisplayName == "United States")
                {
                    return "United States";
                } else
                {
                    return "Not Available";
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "None";
            }
            
            /*
            // Ensure the current user's region is set to US.
            System.Diagnostics.Debug.Assert(RegionInfo.CurrentRegion.DisplayName == "United States");
            */
        }            

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            try
            {

                // A SQL statement that is fetching a username and password match from the strings above.
                string query = "SELECT * FROM user WHERE username = '" + username_txtbox.Text + "' AND password = '" + Password_txtBox.Text + "'";
                MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    username = username_txtbox.Text;
                    password = Password_txtBox.Text;
                    HomePage homePage = new HomePage(username);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(CurrentRegion());
        }
    }
}

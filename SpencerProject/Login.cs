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
using System.Threading;
using System.Windows.Forms;
using System.Globalization;
using Org.BouncyCastle.Asn1.Cmp;
using System.Runtime.CompilerServices;

namespace SpencerProject
{
    public partial class Login : Form
    {
        private string currentLang; // Current language set on the Login Screen
        private string windowsLang; // What the windows language is set to.
        private string username;
        private string password;
        
        

        public Login()
        {
            InitializeComponent();
            Console.WriteLine("Language: " + CurrentRegion());
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en")
            {
                currentLang = "en";
                Change_To_EN();
            }
            else if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "it")
            {
                currentLang = "it";
                Change_To_IT();
            } 
            else
            {
                currentLang = "en";
                Change_To_EN();
            }
            
            
            
        }
        

        
        private void Language_Checker() // Function that checks for language change
        {
            try
            {
                windowsLang = CurrentRegion();
                if (windowsLang != currentLang)
                {
                    if (windowsLang == "it")
                    {
                        Change_To_IT();
                        currentLang = "it";

                    }
                    else
                    {
                        Change_To_EN();
                        currentLang = "en";
                    }
                    //sleep(1);
                }
                else
                {
                    //sleep(1);
                }
            } 
            catch
            {
                Console.WriteLine("Language Checker Crashed");
            }
        }

        
        


        /* This only checks if the region is United States or Italy. 
         * Changes only take effect if the region is changed in Control Panel
         * Changes are immediate and work in app.
        */
        private static string CurrentRegion()
        {
            try
            {
                CultureInfo.CurrentCulture.ClearCachedData();
                if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en") // en for English
                {
                    return "en"; // English
                } else if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "it") // it for Italian
                {

                    return "it"; // Italian
                }
                else
                {
                    return CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
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
        
        private void Change_To_EN() // Changes the Login page to English
        {
            title_txt.Text = "User Login Form";
            incorrect_txt.Text = "Invalid Username or Password";
            username_lbl.Text = "Username:";
            password_lbl.Text = "Password:";
            login_btn.Text = "Login";
            exit_btn.Text = "Exit";
            this.Text = "User Login";
        }

        
        private void Change_To_IT() // Changes the Login page to Italian
        {
            title_txt.Text = "Modulo di Accesso Utente";
            incorrect_txt.Text = "Nome untente o password errati";
            username_lbl.Text = "Nome utente:";
            password_lbl.Text = "parola d'ordine:";
            login_btn.Text = "Login";
            exit_btn.Text = "Uscita";
            this.Text = "Login Utente";
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


        private void Timer_ticks_Tick(object sender, EventArgs e)
        {
            Language_Checker();
        }
    }
}

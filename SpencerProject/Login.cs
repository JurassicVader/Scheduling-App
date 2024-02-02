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
using System.IO;
using System.Security.Policy;

namespace SpencerProject
{
    public partial class Login : Form
    {
        private string currentLang; // Current language set on the Login Screen
        private string windowsLang; // What the windows language is set to.
        private string username;
        string filePath = Environment.CurrentDirectory+"\\Login_History.txt";
        
        string loginDetails = "";
        public Login()
        {
            InitializeComponent();
            Console.WriteLine(filePath);
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
            /* This function uses the CurrentRegion to check if the PCs language changed.
             * If it did, then the form will update.
             */
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
                }
            } 
            catch
            {
                Console.WriteLine("Language Checker Crashed");
            }
        }

        private static string CurrentRegion()
        {
            // This function finds what region the PC is set to.
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
            incorrect_txt.Text = "Nome utente o password errati";
            username_lbl.Text = "Nome utente:";
            password_lbl.Text = "Password:";
            login_btn.Text = "Login";
            exit_btn.Text = "Esci";
            this.Text = "Accesso Utente";
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {

            try
            {
                bool success = false;
                // A SQL statement that is fetching a username and password match from the strings above.
                string query = "SELECT * FROM user WHERE username = '" + username_txtbox.Text + "' AND password = '" + Password_txtBox.Text + "'";
                MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    success = true;
                }
                else
                {
                    incorrect_txt.Visible = true;
                    loginDetails = "Username: " + username_txtbox.Text + "\t login attempt Failed --- TimeStamp(UTC): " + DateTime.UtcNow.ToString();
                    using (StreamWriter fs = File.AppendText(filePath))
                    {
                        fs.WriteLine(loginDetails);
                        Console.WriteLine("Content succesfully written to the file.");
                    }
                }
                reader.Close();
                if (success == true)
                { 
                    username = username_txtbox.Text;
                    loginDetails = "Username: "+username + "\t login Success --- TimeStamp(UTC): " + DateTime.UtcNow.ToString();

                    using (StreamWriter fs = File.AppendText(filePath))
                    {
                        fs.WriteLine(loginDetails);
                        Console.WriteLine("Content succesfully written to the file.");
                    }


                    HomePage homePage = new HomePage(username);
                    homePage.Show();
                    this.Hide();
                }
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
            // Using this to check if the language has changed.
            Language_Checker();
        }
    }
}

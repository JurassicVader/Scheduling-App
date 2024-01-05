using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpencerProject.DataBase
{
    public class DBConnection
    {
        public static MySqlConnection conn { get; set; }

        public static void startConnection() 
        {
            try
            {
                // Using the Part II Video as a guide for connecting to the DB.
                // Naming the connection string constr and getting the data from App.config
                string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;

                // Setting the connection variable to the constr variable. constr var holds the connection data.
                conn = new MySqlConnection(constr);

                // Open the connection 
                conn.Open();
                Console.WriteLine("Connection to database Successful. \nDatabase Connection Open");
                //new HomePage().ShowDialog(); // Testing the reroute
            }
            catch (MySqlException ex)
            {
                // If the connection fails, popup a message box.
                MessageBox.Show("Connection Failed: ", ex.Message);
                Console.WriteLine("Connection Failed: ", ex.Message);
            }
        }

        public static void closeConnection()
        {
            try
            {
                //Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
                conn = null;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

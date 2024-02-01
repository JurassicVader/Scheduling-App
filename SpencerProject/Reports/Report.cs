using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using SpencerProject.DataBase;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpencerProject
{
    public partial class Report : Form
    {
        DataTable dt = new DataTable();

        List<string> ID = new List<string>();
        List<string> UserName = new List<string>();
        List<DateTime> StartTime = new List<DateTime>();
        List<string> Type = new List<string>();
        

        public Report(int id)
        {
            InitializeComponent();
            string query = "";
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
            
            try
            {

                switch (id)
                {
                    case 1: // Running the sort appointment type by month EX. January\Scrum, Test 
                        DataRow type = null;
                        DataRow start = null;
                        string typeVal = null;
                        title_txt.Text = "Report: Sort Appointment Types(By Month)";
                        desc_txt.Text = "Report Information:\nSorting all of the appointment types by month.";
                        //Report to run**
                        query = "SELECT type AS 'Type', start AS 'Start' FROM appointment;"; // Change this to reflect something like: January: scrum ?
                        
                        using (MySqlDataAdapter values = new MySqlDataAdapter(query, DBConnection.conn))
                        {
                            values.Fill(dt);
                        }

                        foreach (DataRow row in dt.Rows)
                        {
                            //if
                        }

                        break;


                    case 2:

                        title_txt.Text = "Report: Schedule for each user";
                        desc_txt.Text = "Report Information:\nGetting the schedule for each user.";
                        // report to run**
                        query = "SELECT user.userName AS 'Username', appointment.title AS 'Title' FROM user LEFT JOIN appointment ON user.userId = appointment.userId;";
                        using (MySqlDataAdapter values = new MySqlDataAdapter(query, DBConnection.conn))
                        {
                            values.Fill(dt);
                        }

                        //lambda => sort through and seperate usernames into individual columns.

                        data_txt.Text = "Lambda results";
                        break;
                    case 3:

                        title_txt.Text = "Report: Sort # of Appointments per Month";
                        desc_txt.Text = "Report Information:\nGetting the number of appointments per month this year";
                        List<string> start = new List<string>();
                        List<int> count = new List<int>();
                        // report to run**
                        query = "SELECT MONTH(start) AS 'Start' FROM appointment WHERE YEAR(start) = YEAR(UTC_time());";
                        cmd.CommandText = query;
                        MySqlDataReader rdr3 = cmd.ExecuteReader();
                        while (rdr3.Read())
                        {
                            start.Add(rdr3["Start"].ToString());
                        }
                        rdr3.Close();
                        int[] months = Array.ConvertAll(start.ToArray(), s => int.Parse(s)); // This lambda is a part of the ConvertAll Method in the array class. It takes each of the values in the array and converts them to integers.
                        Func<int[], int, int> countMonths = (arr, num) => arr.Count(x => x == num); // There are two lambdas in this custom method I created called countMonths. In countMonths, it takes two parameters, in those parameters it accepts an array and a number. The number is the month value(1 = january, 2 = february, etc..) It counts through how many numbers are in the array that match the num parameter. 
                        for (int i = 1; i <= 12; i++)
                        {
                            count.Add(countMonths(months, i));
                        }
                        data_txt.Text = "January: " + count[0] + "\nFebruary: " + count[1] + "\nMarch: " + count[2] + "\nApril: " + count[3] + "\nMay: " + count[4] + "\nJune: " + count[5] + "\nJuly: " + count[6] + "\nAugust: " + count[7] + "\nSeptember: " + count[8] + "\nOctober: " + count[9] + "\nNovember: " + count[10] + "\nDecember: " + count[11];
                        break;
                    default:
                        MessageBox.Show("Something went wrong");
                        Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}

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
                        title_txt.Text = "Report: Sort Appointment Types(By Month)";
                        desc_txt.Text = "Report Information:\nSorting all of the appointment types by month.";

                        List<string> start1 = new List<string>(); List<string> type = new List<string>(); List<string> jan = new List<string>(); List<string> feb = new List<string>(); List<string> mar = new List<string>(); List<string> apr = new List<string>(); List<string> may = new List<string>(); List<string> june = new List<string>(); List<string> jul = new List<string>(); List<string> aug = new List<string>(); List<string> sept = new List<string>(); List<string> oct = new List<string>(); List<string> nov = new List<string>(); List<string> dec = new List<string>();

                        query = "SELECT type AS 'Type', MONTH(start) AS 'Start' FROM appointment;"; // Change this to reflect something like: January: scrum ?
                        cmd.CommandText = query;
                        MySqlDataReader rdr1 = cmd.ExecuteReader();
                        while (rdr1.Read())
                        {
                            start1.Add(rdr1["Start"].ToString());
                            type.Add(rdr1["Type"].ToString());
                        }
                        rdr1.Close();
                        int[] months1 = Array.ConvertAll(start1.ToArray(), s => int.Parse(s)); // This lambda is a part of the ConvertAll Method in the array class. It takes each of the values in the array and converts them to integers.


                        foreach (var x in months1.Select((value, i) => new { i, value })) // Using a lambda method to help keep track of the index for the months1 list. The index variable name is "i"
                        {
                            var Value = x.value;
                            var index = x.i;

                            switch (Value)
                            {
                                case 1:
                                    jan.Add(type[index]);
                                    break;
                                case 2:
                                    feb.Add(type[index]);
                                    break;
                                case 3:
                                    mar.Add(type[index]);
                                    break;
                                case 4:
                                    apr.Add(type[index]);
                                    break;
                                case 5:
                                    may.Add(type[index]);
                                    break;
                                case 6:
                                    june.Add(type[index]);
                                    break;
                                case 7:
                                    jul.Add(type[index]);
                                    break;
                                case 8:
                                    aug.Add(type[index]);
                                    break;
                                case 9:
                                    sept.Add(type[index]);
                                    break;
                                case 10:
                                    oct.Add(type[index]);
                                    break;
                                case 11:
                                    nov.Add(type[index]);
                                    break;
                                case 12:
                                    dec.Add(type[index]);
                                    break;
                            }

                        }
                        string[] Jan = jan.ToArray(); string[] Feb = feb.ToArray(); string[] Mar = mar.ToArray(); string[] Apr = apr.ToArray(); string[] May = may.ToArray(); string[] Jun = june.ToArray(); string[] Jul = jul.ToArray(); string[] Aug = aug.ToArray(); string[] Sept = sept.ToArray(); string[] Oct = oct.ToArray(); string[] Nov = nov.ToArray(); string[] Dec = dec.ToArray();

                        data_txt.Text = TypeCounts("January", Jan) + '\n' + TypeCounts("February", Feb) + '\n' + TypeCounts("March", Mar) + '\n' + TypeCounts("April", Apr) + '\n' + TypeCounts("May", May) + '\n' + TypeCounts("June", Jun) + '\n' + TypeCounts("July", Jul) + '\n' + TypeCounts("August", Aug) + '\n' + TypeCounts("September", Sept) + '\n' + TypeCounts("October", Oct) + '\n' + TypeCounts("November", Nov) + '\n' + TypeCounts("December", Dec);
                        break;
                    case 2:
                        schedule_gridView.Visible = true;
                        data_txt.Visible = false;
                        title_txt.Text = "Report: Schedule for each user";
                        desc_txt.Text = "Report Information:\nGetting the schedule for each user.";
                        // report to run**
                        Func<string, string, string, string> lambdaFunc = (qtype, query_statement, table_name) => qtype + " " + query_statement + " FROM " + table_name + ";";
                        query = lambdaFunc("SELECT", "user.userName AS 'Username', appointment.title AS 'Title', appointment.start AS 'Start Time'", "user LEFT JOIN appointment ON user.userId = appointment.userId ORDER BY user.username, appointment.start");
                        //query = "SELECT user.userName AS 'Username', appointment.title AS 'Title', appointment.start AS 'Start Time' FROM user LEFT JOIN appointment ON user.userId = appointment.userId;";
                        cmd.CommandText = query;
                        MySqlDataReader rdr2 = cmd.ExecuteReader();
                        while (rdr2.Read())
                        {
                            var scheduleTable = new BindingSource();
                            scheduleTable.DataSource = rdr2;
                            schedule_gridView.DataSource = scheduleTable;
                        }
                        rdr2.Close();
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

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        static string TypeCounts(string month, string[] types)
        {
            Dictionary<string, int> typeCount = new Dictionary<string, int>();
            foreach (string type in types)
            {
                if (typeCount.ContainsKey(type))
                {
                    typeCount[type]++;
                }
                else
                {
                    typeCount[type] = 1;
                }
            }
            string result = $"{month}: " + string.Join(" / ", typeCount.Select(x => $"{x.Key}: {x.Value}"));
            Console.WriteLine(result);
            return result;
        }

    }
}

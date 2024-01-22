using MySql.Data.MySqlClient;
using SpencerProject.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SpencerProject.Appointments
{
    public partial class Appointment : Form
    {
        bool Update = false;
        string AppointmentId;
        public Appointment(string apptId, string userId, string title, string type, string customerId, string time, string time_end, string date, string desc, bool update)
        {
            
            InitializeComponent();
            timePicker.Format = DateTimePickerFormat.Custom;
            timePicker.CustomFormat = "HH:mm";
            end_timePicker.Format = DateTimePickerFormat.Custom;
            end_timePicker.CustomFormat = "HH:mm";
            datePicker.Value = DateTime.Now.Date;
            Get_UserIds();
            Get_customerIds();
            uId_combo.Text = userId;
            AppointmentId = apptId;
            Console.WriteLine(TimeZoneConvert());
            if (update == true)
            {

                title_lbl.Text = "Appointment Update";
                create_btn.Text = "Update";
                type_txtbox.Text = type;
                cId_combo.Text = customerId;
                title_txtbox.Text = title;
                timePicker.Text = time;
                datePicker.Text = date;
                end_timePicker.Text = time_end;
                desc_txtbox.Text = desc;
                Update = true;
            }
        }
        private bool ApptCheck() // Checks if appointment times overlap and if the appointment times are not appropriate
        {
            string query;
            bool readerVal = false;
            if (Update == true)
            {
                query = "SELECT * FROM appointment WHERE appointmentId <> " + AppointmentId.ToString() + " AND start BETWEEN Convert_TZ('" + datePicker.Value.ToString("yyyy-MM-dd") + " " + timePicker.Value.ToString("HH:mm") + ":00" + "', '" + TimeZoneConvert() + "', '+00:00') AND Convert_TZ('" + datePicker.Value.ToString("yyyy-MM-dd") + " " + end_timePicker.Value.ToString("HH:mm") + ":00" + "', '" + TimeZoneConvert() + "', '+00:00') AND userId = " + uId_combo.Text + ";"; // Checks if appointment overlaps with any existing appointments.
            } else
            {
                query = "SELECT * FROM appointment WHERE start BETWEEN Convert_TZ('" + datePicker.Value.ToString("yyyy-MM-dd") + " " + timePicker.Value.ToString("HH:mm") + ":00" + "', '" + TimeZoneConvert() + "', '+00:00') AND Convert_TZ('" + datePicker.Value.ToString("yyyy-MM-dd") + " " + end_timePicker.Value.ToString("HH:mm") + ":00" + "', '" + TimeZoneConvert() + "', '+00:00') AND userId = " + uId_combo.Text + ";"; // Checks if appointment overlaps with any existing appointments.
            }
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) // Checks if the appointment time overlaps with an existing appointment time(For the user)
            {
                
                readerVal = true;
            }
            reader.Close();

            if (timePicker.Value >= end_timePicker.Value) // Checks if the start time is later than the end time
            {
                MessageBox.Show("The appointment start time is \ngreater than the appointment end time.");
                return false;
            } else if (readerVal == true)
            {
                MessageBox.Show("The appointment overlaps with an existing User Appointment");
                return false;
            }
            else if (datePicker.Value.DayOfWeek == DayOfWeek.Saturday || datePicker.Value.DayOfWeek == DayOfWeek.Sunday)
            {

                MessageBox.Show("Please Schedule your appointment Monday - Friday");
                return false;
            } else if (DateTime.Parse(timePicker.Value.ToUniversalTime().ToString("HH:mm")) < DateTime.Parse("14:00")) // Checks if the scheduled appt times are outside of work hours (9:00AM - 5:00PM) Est
            {
                Console.WriteLine("Start Picker: " + (DateTime.Parse(timePicker.Value.ToUniversalTime().ToString("HH:mm")) + "\nComparison Night:" + DateTime.Parse("22:00")));
                Console.WriteLine("Start Time: " + (DateTime.Parse(timePicker.Value.ToUniversalTime().ToString("HH:mm")) <= DateTime.Parse("14:00")));
                MessageBox.Show("Please Schedule the appointment between the times 9:00AM - 5:00PM Eastern Standard Time.\nCheck Start Time");
                return false;
            } else if (DateTime.Parse(end_timePicker.Value.ToUniversalTime().ToString("HH:mm")) > DateTime.Parse("22:00"))
            {
                Console.WriteLine("End_time Picker: " + (DateTime.Parse(end_timePicker.Value.ToUniversalTime().ToString("HH:mm")) + "\nComparison Day: " + DateTime.Parse("22:00")));
                Console.WriteLine("End Time: " + (DateTime.Parse(end_timePicker.Value.ToUniversalTime().ToString("HH:mm")) > DateTime.Parse("22:00")));
                MessageBox.Show("Please Schedule the appointment between the times 9:00AM - 5:00PM Eastern Standard Time.\nCheck End Time");
                return false;
            }
            return true;
        }
        private string TimeZoneConvert() // returns the time difference from machine to UTC. OUTPUT EX. +10:00
        {
            TimeZone localZone = TimeZone.CurrentTimeZone;
            DateTime currentDate = DateTime.Now;
            TimeSpan currentOffset = localZone.GetUtcOffset(currentDate);
            if (currentOffset.Hours >= 0)
            {
                if (currentOffset.Hours >= 10)
                {
                    return "+" + currentOffset.Hours + ":" + "00";
                }
                return "+0" + currentOffset.Hours + ":" + "00";
            } else
            {
                if (currentOffset.Hours <= -10)
                {
                    return currentOffset.Hours + ":" + "00";
                }
                return "-0" + Math.Abs(currentOffset.Hours) + ":" + "00";

            }
            
        }
        private void cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (uId_combo.Text != "" && type_txtbox.Text != "" && cId_combo.Text != "" && title_txtbox.Text != "" && timePicker.Text != "" && end_timePicker.Text != "" && datePicker.Text != "")
                {
                    if (ApptCheck())
                    {
                        string query = "";
                        MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                        if (Update == true)
                        {
                            query = "UPDATE appointment SET customerId = '" + cId_combo.Text + "', userId = '" + uId_combo.Text + "', title = '" + title_txtbox.Text + "', description = '" + desc_txtbox.Text + "', type = '" + type_txtbox.Text + "', start = Convert_TZ('"+ datePicker.Value.ToString("yyyy-MM-dd") + ' ' + timePicker.Value.ToString("HH:mm:ss") + "', '" +TimeZoneConvert()+ "', '+00:00') , end = Convert_TZ('" + datePicker.Value.ToString("yyyy-MM-dd") + ' ' + end_timePicker.Value.ToString("HH:mm:ss") + "', '" + TimeZoneConvert() + "', '+00:00'), lastUpdate = UTC_TIMESTAMP() WHERE appointmentId = '" +AppointmentId +"';";
                        }
                        else
                        {
                            query = "INSERT INTO appointment(customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES("+cId_combo.Text+", "+uId_combo.Text+", '"+title_txtbox.Text+"', '" + desc_txtbox.Text + "', 'N/A', 'N/A', '" + type_txtbox.Text + "', 'N/A', Convert_TZ('" + datePicker.Value.ToString("yyyy-MM-dd") + ' ' + timePicker.Value.ToString("HH:mm:ss") + "', '" + TimeZoneConvert() + "', '+00:00'), Convert_TZ('" + datePicker.Value.ToString("yyyy-MM-dd") + ' ' + end_timePicker.Value.ToString("HH:mm:ss") + "', '" + TimeZoneConvert() + "', '+00:00'), utc_timestamp(), 'test', utc_timestamp(), 'test');";
                        }
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Executed Command");
                        
                        Close();
                    }
              
                } else
                {
                    MessageBox.Show("One or more of the fields are empty. \nPlease fully fill out the form.");
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Get_UserIds() // Populates the UserId comboBox.
        {
            //gather all of the userIds from the database
            MySqlCommand cmd = new MySqlCommand("SELECT userId FROM user ORDER BY userId", DBConnection.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                uId_combo.Items.Add(rdr[0]);
            }
            rdr.Close();
        }

        private void Get_customerIds() // Populates the CustomerId comboBox
        {
            //gather all of the customerIDs from the database
            MySqlCommand cmd = new MySqlCommand("SELECT customerId FROM customer ORDER BY customerId", DBConnection.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                cId_combo.Items.Add(rdr[0]);
            }
            rdr.Close();
        }

    }
}

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
            timePicker.CustomFormat = "HH:mm"; // Only allows hours and minutes
            //end_timePicker.CustomFormat = "HH:mm";
            Get_UserIds();
            Get_customerIds();
            uId_combo.Text = userId;
            AppointmentId = apptId;
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
            bool success = true;
            if (timePicker.Value > end_timePicker.Value) // Checks if the start time is later than the end time
            {
                MessageBox.Show("The appointment start time is \ngreater than the appointment end time.");
                success = false;
            }

            string query = "SELECT * FROM appointment WHERE appointmentId <> "+AppointmentId+" AND start BETWEEN Convert_TZ('" + datePicker.Value.ToString("yyyy-MM-dd") + ' ' + timePicker.Value.ToString("HH:mm:ss") + "', '" + TimeZoneConvert() + "', '+00:00') AND Convert_TZ('" + datePicker.Value.ToString("yyyy-MM-dd") + ' ' + end_timePicker.Value.ToString("HH:mm:ss") + "', '" + TimeZoneConvert() + "', '+00:00') AND userId = " + uId_combo.Text + ";"; // Checks if appointment overlaps with any existing appointments.
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) // Checks if the appointment time overlaps with an existing appointment time(For the user)
            {
                MessageBox.Show("The appointment overlaps with an existing User Appointment");
                success = false;
            }
            reader.Close();

            query = "SELECT * FROM appointment WHERE appointmentId <> " + AppointmentId + " AND start BETWEEN Convert_TZ('" + datePicker.Value.ToString("yyyy-MM-dd") + ' ' + timePicker.Value.ToString("HH:mm:ss") + "', '" + TimeZoneConvert() + "', '+00:00') AND Convert_TZ('" + datePicker.Value.ToString("yyyy-MM-dd") + ' ' + end_timePicker.Value.ToString("HH:mm:ss") + "', '" + TimeZoneConvert() + "', '+00:00') AND customerId = " + cId_combo.Text + ";"; // Checks if appointment overlaps with any existing appointments
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();
            if (reader.Read()) // Checks if the appointment time overlaps with an existing appointment time(for the customer)
            {
                MessageBox.Show("The appointment overlaps with an existing User Appointment");
                success = false;
            }
            reader.Close();

            if (datePicker.Value.DayOfWeek == DayOfWeek.Saturday || datePicker.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                success = false;
                MessageBox.Show("Please Schedule your appointment Monday - Friday");
            }
            if (DateTime.Parse(timePicker.Value.ToUniversalTime().ToString("HH:mm")) > DateTime.Parse("14:00") && DateTime.Parse(timePicker.Value.ToUniversalTime().ToString("HH:mm")) < DateTime.Parse("22:00") && DateTime.Parse(end_timePicker.Value.ToUniversalTime().ToString("HH:mm")) > DateTime.Parse("14:00") && DateTime.Parse(end_timePicker.Value.ToUniversalTime().ToString("HH:mm")) < DateTime.Parse("22:00")) // Checks if the scheduled appt times are outside of work hours (9:00AM - 5:00PM) Est
            {
                MessageBox.Show("Please Schedule the appointment between the times 9:00AM - 5:00PM Eastern Standard Time.");
                success = false;
            }

            return success;
        }
        private string TimeZoneConvert() // returns the time difference from machine to UTC. OUTPUT EX. +10:00
        {
            TimeZone localZone = TimeZone.CurrentTimeZone;
            DateTime currentDate = DateTime.Now;
            TimeSpan currentOffset = localZone.GetUtcOffset(currentDate);
            if (currentOffset.Hours >= 0)
            {
                return "+" + currentOffset.Hours + ":" + currentOffset.Minutes;
            }
            return currentOffset.Hours + ":" + currentOffset.Minutes;
        }
        private void cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine(datePicker.Value.ToString("yyyy-MM-dd"));
                if (uId_combo.Text != "" && type_txtbox.Text != "" && cId_combo.Text != "" && title_txtbox.Text != "" && timePicker.Text != "" && end_timePicker.Text != "" && datePicker.Text != "")
                {
                    if (ApptCheck())
                    {
                        string query = "";
                        MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                        if (Update == true)
                        {
                            query = "UPDATE appointment SET customerId = '" + cId_combo.Text + "', userId = '" + uId_combo.Text + "', title = '" + title_txtbox.Text + "', description = '" + desc_txtbox.Text + "', type = '" + type_txtbox.Text + "', start = Convert_TZ('"+ datePicker.Value.ToString("yyyy-MM-dd") + ' ' + timePicker.Value.ToString("HH:mm:ss") + "', '" +TimeZoneConvert()+ "', '+00:00') , end = Convert_TZ('" + end_timePicker.Value.ToString("yyyy-MM-dd") + ' ' + end_timePicker.Value.ToString("HH:mm:ss") + "', '" + TimeZoneConvert() + "', '+00:00'), lastUpdate = UTC_TIMESTAMP() WHERE appointmentId = '" +AppointmentId +"';";
                        }
                        else
                        {
                            // Time Zone calculations here ---
                            query = "INSERT INTO appointment(customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES("+cId_combo.Text+", "+uId_combo.Text+", '"+title_txtbox.Text+"', '" + desc_txtbox.Text + "', 'N/A', 'N/A', '" + type_txtbox.Text + "', 'N/A', Convert_TZ('" + datePicker.Value.ToString("yyyy-MM-dd") + ' ' + timePicker.Value.ToString("HH:mm:ss") + "', '" + TimeZoneConvert() + "', '+00:00'), Convert_TZ('" + end_timePicker.Value.ToString("yyyy-MM-dd") + ' ' + end_timePicker.Value.ToString("HH:mm:ss") + "', '" + TimeZoneConvert() + "', '+00:00'), utc_timestamp(), 'test', utc_timestamp(), 'test');";
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
                Console.WriteLine(rdr[0]);
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
                Console.WriteLine(rdr[0]);
                cId_combo.Items.Add(rdr[0]);
            }
            rdr.Close();
        }

    }
}

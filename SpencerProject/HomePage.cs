using MySql.Data.MySqlClient;
using SpencerProject.Appointments;
using SpencerProject.DataBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpencerProject
{
    public partial class HomePage : Form
    {
        string customerId, name, phone, address, city, country; // Variables for the customer Form.
        string appt_id, userId, appt_title, appt_type, appt_customerId, appt_time, appt_end, appt_date, appt_desc; // variables for the appointment Form.
        DateTime cal_date; // date for the calendar
        private void view_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            refresh();
        }
        public HomePage(string username)
        {
            InitializeComponent();
            view_combo.SelectedIndex = 1; // This sets the appointments Calendar view to Month.(0 = week, 1 = month, 2 = all)
            Console.WriteLine("TimeZone Converted: " + TimeZoneConvert());
            customers_gridView.RowHeadersVisible = false;
            appointments_gridview.RowHeadersVisible = false;
            //calendar.MaxSelectionCount = 1;
            try
            {
                // Populates the customers gridview table.
                MySqlCommand cmd = new MySqlCommand("SELECT customer.customerId AS ID, customer.customerName AS Customer_Name, address.phone AS Phone_Number, address.address AS Address, city.city AS City, country.country AS Country FROM customer JOIN address ON customer.addressId = address.addressId JOIN city ON address.cityId = city.cityId JOIN country ON city.countryId = country.countryId;", DBConnection.conn);
                MySqlDataReader rdr1 = cmd.ExecuteReader();

                if (rdr1.HasRows)
                {
                    var customerTable = new BindingSource();
                    customerTable.DataSource = rdr1;
                    customers_gridView.DataSource = customerTable;
                }
                rdr1.Close();

                // Gets the userId for the appointment section.
                cmd.CommandText = "SELECT userId FROM user WHERE userName = '" + username +"';";
                MySqlDataReader rdr2 = cmd.ExecuteReader();
                while (rdr2.Read())
                {
                    userId = rdr2[0].ToString();
                    Console.WriteLine("User ID is: " + userId);
                }
                rdr2.Close();

                // Populates the schedule gridview table
                cmd.CommandText = "SELECT appointmentId AS ID, customerId AS 'Customer ID', userId AS 'User ID', title AS Title, type AS Type, appointment.description AS 'Description', CONCAT(HOUR(Convert_TZ(appointment.start, '+00:00', '"+TimeZoneConvert() + "')), ':', MINUTE(Convert_TZ(appointment.start, '+00:00', '"+TimeZoneConvert() +"'))) AS 'Start Time', CONCAT(HOUR(Convert_TZ(end, '+00:00', '"+TimeZoneConvert() + "')), ':', MINUTE(Convert_TZ(end, '+00:00', '"+TimeZoneConvert() +"'))) AS 'End Time', CONCAT(TIMESTAMPDIFF(MINUTE, start, end), ' Minutes') AS 'Appointment Length',CONCAT(MONTH(start), '/', DAY(start), '/',YEAR(start)) AS 'Date'FROM appointment WHERE MONTH(start) = MONTH(CURRENT_DATE()) AND YEAR(start) = YEAR(CURRENT_DATE());";
                MySqlDataReader rdr3 = cmd.ExecuteReader();
                if (rdr3.HasRows)
                {
                    var apptTable = new BindingSource();
                    apptTable.DataSource = rdr3;
                    appointments_gridview.DataSource = apptTable;
                }
                rdr3.Close();
                alert();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            welcome_txt.Text = "Welcome Back, " + username + "\nUser ID: " + userId;
        }
        private void alert()
        {
            string query = "SELECT appointmentId FROM appointment WHERE userId = "+ userId +" AND start BETWEEN UTC_time() AND DATE_ADD(UTC_time(), INTERVAL 15 MINUTE);";
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read() == true)
            {
                MessageBox.Show("Check your upcoming appointments.\nYou have an appointment in 15 minutes or less!", "ALERT: UPCOMING APPOINTMENT", MessageBoxButtons.OK);
            }
            reader.Close();
        }
        private void appointments_gridview_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //appt_id, userId, appt_type, appt_customerId, appt_time, appt_date, appt_desc;
            // ORDER: ID[0], CustomerId[1], userId[2], Title[3], tpye[4], desc[5], start time[6], end time[7], appointment length[8], date[9]

            appt_id = appointments_gridview.CurrentRow.Cells[0].Value.ToString();
            appt_customerId = appointments_gridview.CurrentRow.Cells[1].Value.ToString();
            userId = appointments_gridview.CurrentRow.Cells[2].Value.ToString();
            appt_title = appointments_gridview.CurrentRow.Cells[3].Value.ToString();
            appt_type = appointments_gridview.CurrentRow.Cells[4].Value.ToString();
            appt_desc = appointments_gridview.CurrentRow.Cells[5].Value.ToString();
            appt_time = appointments_gridview.CurrentRow.Cells[6].Value.ToString();
            appt_end = appointments_gridview.CurrentRow.Cells[7].Value.ToString();
            appt_date = appointments_gridview.CurrentRow.Cells[9].Value.ToString();
        }
        private void DeleteAppt_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM appointment WHERE appointmentId = " + appt_id + ";";
                if (appt_id != null)
                {
                    DialogResult confirmMessage = MessageBox.Show("Deleting this appointment is permanent: \nCustomer ID: " + appt_customerId + "\nUser ID: " + userId + "\nTitle: " + appt_title + "\nDescription: " + appt_desc + "\nTime: " + appt_time + "\n\n Please confirm if you wanted this appointment deleted?", "Confirm Appointment Deletion", MessageBoxButtons.YesNo);
                    if (confirmMessage == DialogResult.Yes)
                    {
                        // Delete User
                        MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Appointment deleted");
                        refresh();
                    }
                    else if (DialogResult == DialogResult.No)
                    {
                        // Pass
                        Console.WriteLine("Appointment not deleted");
                        refresh();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select an Appointment.");
                    refresh();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void deleteUser_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM customer WHERE customerId = " + customerId + ";";
                if (customerId != null)
                {
                    DialogResult confirmMessage = MessageBox.Show("Deleting this customer is permanent: \n" + name + "\n" + phone + "\n" + address + "\n" + city +"\n" + country +"\n\n Please confirm if you wanted this customer deleted?" , "Confirm Customer Deletion", MessageBoxButtons.YesNo);
                    if (confirmMessage == DialogResult.Yes)
                    {
                        // Delete User
                        MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("User deleted");
                        refresh();
                    }
                    else if (DialogResult == DialogResult.No)
                    {
                        // Pass
                        Console.WriteLine("User not deleted");
                        refresh();
                    }
                } else
                {
                    MessageBox.Show("Please Select a Customer.");
                    refresh();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
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
            return currentOffset.Hours +":"+currentOffset.Minutes;
        }
        private void refresh()
        {
            string query = "";
            try
            {
                // Content for the customer section.
                MySqlCommand cmd = new MySqlCommand("SELECT customer.customerId AS ID, customer.customerName AS Customer_Name, address.phone AS Phone_Number, address.address AS Address, city.city AS City, country.country AS Country FROM customer JOIN address ON customer.addressId = address.addressId JOIN city ON address.cityId = city.cityId JOIN country ON city.countryId = country.countryId ORDER BY customer.customerId;", DBConnection.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                var customerTable = new BindingSource();
                customerTable.DataSource = rdr;
                Console.WriteLine("Updated GridView");
                customers_gridView.DataSource = customerTable;
                rdr.Close();

                // Content for the Schedule section

                appointments_gridview.Rows.Clear();
                if (view_combo.SelectedIndex == 0) // Selected view is Week
                {
                    query = "SELECT appointmentId AS ID, customerId AS 'Customer ID', userId AS 'User ID', title AS Title, type AS Type, appointment.description AS 'Description', CONCAT(HOUR(Convert_TZ(appointment.start, '+00:00', '"+TimeZoneConvert() + "')), ':', MINUTE(Convert_TZ(appointment.start, '+00:00', '"+TimeZoneConvert() +"'))) AS 'Start Time', CONCAT(HOUR(Convert_TZ(end, '+00:00', '"+TimeZoneConvert() + "')), ':', MINUTE(Convert_TZ(end, '+00:00', '"+TimeZoneConvert() +"'))) AS 'End Time',  CONCAT(TIMESTAMPDIFF(MINUTE, start, end), ' Minutes') AS 'Appointment Length',CONCAT(MONTH(start), '/', DAY(start), '/',YEAR(start)) AS 'Date'FROM appointment WHERE YEARWEEK(appointment.start) = YEARWEEK(curdate());";
                } 
                else if (view_combo.SelectedIndex == 1) // Selected view is Month
                {
                    query = "SELECT appointmentId AS ID, customerId AS 'Customer ID', userId AS 'User ID', title AS Title, type AS Type, appointment.description AS 'Description', CONCAT(HOUR(Convert_TZ(appointment.start, '+00:00', '"+TimeZoneConvert() + "')), ':', MINUTE(Convert_TZ(appointment.start, '+00:00', '"+TimeZoneConvert() +"'))) AS 'Start Time', CONCAT(HOUR(Convert_TZ(end, '+00:00', '"+TimeZoneConvert() + "')), ':', MINUTE(Convert_TZ(end, '+00:00', '"+TimeZoneConvert() +"'))) AS 'End Time',CONCAT(TIMESTAMPDIFF(MINUTE, start, end), ' Minutes') AS 'Appointment Length',CONCAT(MONTH(start), '/', DAY(start), '/',YEAR(start)) AS 'Date'FROM appointment WHERE MONTH(start) = MONTH(CURRENT_DATE()) AND YEAR(start) = YEAR(CURRENT_DATE());";
                } 
                else if (view_combo.SelectedIndex == 2) // Selected view is All
                {
                    query = "SELECT appointmentId AS ID, customerId AS 'Customer ID', userId AS 'User ID', title AS Title, type AS Type, appointment.description AS 'Description', CONCAT(HOUR(Convert_TZ(appointment.start, '+00:00', '"+TimeZoneConvert() + "')), ':', MINUTE(Convert_TZ(appointment.start, '+00:00', '"+TimeZoneConvert() +"'))) AS 'Start Time', CONCAT(HOUR(Convert_TZ(end, '+00:00', '"+TimeZoneConvert() + "')), ':', MINUTE(Convert_TZ(end, '+00:00', '"+TimeZoneConvert() +"'))) AS 'End Time',CONCAT(TIMESTAMPDIFF(MINUTE, start, end), ' Minutes') AS 'Appointment Length',CONCAT(MONTH(start), '/', DAY(start), '/',YEAR(start)) AS 'Date'FROM appointment;";               
                }
                else if (view_combo.SelectedIndex == 3) // Select Specific day and pull up calendar
                {
                    FormCalendar fc = new FormCalendar();
                    fc.ShowDialog();
                    cal_date = fc.GetDT;
                    if (fc.GetDT != null)
                    {
                        query = "SELECT appointmentId AS ID, customerId AS 'Customer ID', userId AS 'User ID', title AS Title, type AS Type, appointment.description AS 'Description', CONCAT(HOUR(Convert_TZ(appointment.start, '+00:00', '" + TimeZoneConvert() + "')), ':', MINUTE(Convert_TZ(appointment.start, '+00:00', '" + TimeZoneConvert() + "'))) AS 'Start Time', CONCAT(HOUR(Convert_TZ(end, '+00:00', '" + TimeZoneConvert() + "')), ':', MINUTE(Convert_TZ(end, '+00:00', '" + TimeZoneConvert() + "'))) AS 'End Time',CONCAT(TIMESTAMPDIFF(MINUTE, start, end), ' Minutes') AS 'Appointment Length',CONCAT(MONTH(start), '/', DAY(start), '/',YEAR(start)) AS 'Date'FROM appointment WHERE DATE(start) = DATE('" + cal_date.Year + "-" + cal_date.Month + "-" + cal_date.Day + "');";
                    } else
                    {
                        query = "";
                        view_combo.SelectedIndex = 1;
                    }
                }
                if (query != "")
                {
                    cmd.CommandText = query;
                    MySqlDataReader rdr2 = cmd.ExecuteReader();
                    if (rdr2.HasRows)
                    {
                        var apptTable = new BindingSource();
                        apptTable.DataSource = rdr2;
                        appointments_gridview.DataSource = apptTable;
                    }
                    rdr2.Close();

                } else
                {
                    MessageBox.Show("There was an error populating the scheduling Table");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Data was not able to be refreshed. Please try again or restart application");
            }
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void scheduleAppt_btn_Click(object sender, EventArgs e)
        {
            Appointment appt = new Appointment(appt_id, userId, "none", "none", "none", "none", "none", "none", "none", false);
            appt.ShowDialog();
            refresh();
        }

        private void updateAppt_btn_Click(object sender, EventArgs e)
        {
            if (appt_id != null)
            {
                Appointment appt = new Appointment(appt_id, userId, appt_title, appt_type, appt_customerId, appt_time, appt_end, appt_date, appt_desc, true);
                appt.ShowDialog();
                refresh();
            } else
            {
                MessageBox.Show("Please Select an Appointment to Update");
            }

        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void createCustomer_btn_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer("none", "none", "none", "none", "none", "none", "create");
            customer.ShowDialog();
            refresh();
        }

        private void updateUser_btn_Click(object sender, EventArgs e)
        {

            // This same form but with the customer tab filled in.
            if (customerId != null)
            {
                
                Customer customer = new Customer(customerId, name, phone, address, city, country, "update");
                customer.ShowDialog();
                refresh();
            } else
            {
                MessageBox.Show("Please Select a User to Update");
            }

        }

        private void HomePage_Load(object sender, EventArgs e)
        {



        }

        private void customers_gridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            customerId = customers_gridView.CurrentRow.Cells[0].Value.ToString();
            name = customers_gridView.CurrentRow.Cells[1].Value.ToString();
            phone = customers_gridView.CurrentRow.Cells[2].Value.ToString();
            address = customers_gridView.CurrentRow.Cells[3].Value.ToString();
            city = customers_gridView.CurrentRow.Cells[4].Value.ToString();
            country = customers_gridView.CurrentRow.Cells[5].Value.ToString();

        }
    }
}

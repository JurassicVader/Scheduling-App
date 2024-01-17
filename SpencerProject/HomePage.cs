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
        string userId, appt_type, appt_customerId, appt_time, appt_date, appt_desc; // variables for the appointment Form.
        
        public HomePage(string username)
        {
            InitializeComponent();
            welcome_txt.Text = "Welcome Back, " + username;
            
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
                cmd.CommandText = "SELECT appointmentId AS ID, customerId AS 'Customer ID', userId AS 'User ID', title AS Title, appointment.description AS 'Description', CONCAT(HOUR(start), ':', MINUTE(start)) AS 'Start Time', CONCAT(TIMESTAMPDIFF(MINUTE, start, end), ' Minutes') AS 'Appointment Length',CONCAT(DAY(start) , '/', MONTH(start), '/', YEAR(start)) AS 'Date'FROM appointment;";
                MySqlDataReader rdr3 = cmd.ExecuteReader();
                if (rdr3.HasRows)
                {
                    var apptTable = new BindingSource();
                    apptTable.DataSource = rdr3;
                    appointments_gridview.DataSource = apptTable;
                }
                rdr1.Close();

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

        private void refresh()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT customer.customerId AS ID, customer.customerName AS Customer_Name, address.phone AS Phone_Number, address.address AS Address, city.city AS City, country.country AS Country FROM customer JOIN address ON customer.addressId = address.addressId JOIN city ON address.cityId = city.cityId JOIN country ON city.countryId = country.countryId ORDER BY customer.customerId;", DBConnection.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                var customerTable = new BindingSource();
                customerTable.DataSource = rdr;
                Console.WriteLine("Updated GridView");
                customers_gridView.DataSource = customerTable;
                rdr.Close();
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
            Appointment appt = new Appointment(userId, "none", "none", "none", "none", "none", false);
            appt.ShowDialog();
        }

        private void updateAppt_btn_Click(object sender, EventArgs e)
        {
            Appointment appt = new Appointment(userId, appt_type, appt_customerId, appt_time, appt_date, appt_desc, true);
            appt.ShowDialog();
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

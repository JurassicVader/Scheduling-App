using MySql.Data.MySqlClient;
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
        string userId, name, phone, address, city, country;

        public HomePage(string username)
        {
            InitializeComponent();
            welcome_txt.Text = "Welcome Back, " + username;
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void createCustomer_btn_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer("none", "none", "none", "none", "none", "none", "create");
            customer.Show();
        }

        private void updateUser_btn_Click(object sender, EventArgs e)
        {

            // This same form but with the customer tab filled in.
            if (userId != null)
            {
                Console.WriteLine(userId);
                Customer customer = new Customer(userId, name, phone, address, city, country, "update");
                customer.Show();
            } else
            {
                MessageBox.Show("Please Select a User to Update");
            }

        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT customer.customerId AS ID, customer.customerName AS Customer_Name, address.phone AS Phone_Number, address.address AS Address, city.city AS City, country.country AS Country FROM customer JOIN address ON customer.addressId = address.addressId JOIN city ON address.cityId = city.cityId JOIN country ON city.countryId = country.countryId;", DBConnection.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    var customerTable = new BindingSource();
                    customerTable.DataSource = rdr;
                    customers_gridView.DataSource = customerTable;
                    
                    //customers_gridView.DataSource = rdr;
                    //customers_gridView.DataBind();
                }
                rdr.Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void customers_gridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            userId = customers_gridView.CurrentRow.Cells[0].Value.ToString();
            name = customers_gridView.CurrentRow.Cells[1].Value.ToString();
            phone = customers_gridView.CurrentRow.Cells[2].Value.ToString();
            address = customers_gridView.CurrentRow.Cells[3].Value.ToString();
            city = customers_gridView.CurrentRow.Cells[4].Value.ToString();
            country = customers_gridView.CurrentRow.Cells[5].Value.ToString();

        }
    }
}

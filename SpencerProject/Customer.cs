using MySql.Data.MySqlClient;
using SpencerProject.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpencerProject
{
    public partial class Customer : Form
    {
        bool update = false;
        bool country_change = false;
        string Country = "";
        string ID;

        public Customer(string id, string name, string phone, string address, string city, string country, string type)
        {
            InitializeComponent();
            // Checks to see if the customer is being created or updated
            if (type == "update")
            {
                Country = country;
                GetCountries();

                ID = id;
                update = true;
                // Edit the form text
                title_lbl.Text = "Customer Update";
                create_btn.Text = "Update";
                //Fill the form with customer data
                name_txtbox.Text = name;
                address_txtbox.Text = address;
                phone_txtbox.Text = phone;
                country_combo.Text = country;
                GetCities(country);
                city_combo.Text = city;




            } else
            {
                GetCountries();
                city_combo.Enabled = false;
            }
            
            
        }


        // Closes this form
        private void cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            try
            {
                   
                if (update == true)
                {
                    string query = "UPDATE customer LEFT JOIN address ON customer.addressId = address.addressId LEFT JOIN city ON address.cityId = city.cityId LEFT JOIN country ON city.countryId = country.countryId SET customer.customerName = '" + name_txtbox.Text +"', address.Phone= '" + phone_txtbox.Text.ToString() +"', address.address= '" + address_txtbox.Text +"', address.cityId = (SELECT cityId FROM city WHERE city = '"+city_combo.Text+"') WHERE customer.customerId = 12;";
                    MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Executed Command");
                    Close();

                } 
                else
                {
                    bool activeAddress = false;
                    string query = "SELECT * FROM address WHERE address = '" + address_txtbox.Text+"';";
                    MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read() == true)
                    {
                        activeAddress = true;
                    }
                    reader.Close();

                    if (activeAddress == true)
                    {
                        string query3 = "UPDATE address SET phone = '" + phone_txtbox.Text.ToString() + "', cityId = (SELECT cityId FROM city WHERE city = '" + city_combo.Text + "') WHERE address = '" + address_txtbox.Text + "';";
                        string query2 = "INSERT INTO customer(customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES('" + name_txtbox.Text + "', (SELECT addressId FROM address WHERE address = '" + address_txtbox.Text + "') , 1, CURRENT_TIMESTAMP(), 'Spencer', CURRENT_TIMESTAMP(), 'Spencer');";
                        MySqlCommand cmd = new MySqlCommand(query2, DBConnection.conn);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = query3;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        string query1 = "INSERT INTO address(address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES('" + address_txtbox.Text + "', '', (SELECT cityId FROM city WHERE city = '" + city_combo.Text + "'), 11111, " + phone_txtbox.Text.ToString() + ", CURRENT_TIMESTAMP(), 'Spencer', CURRENT_TIMESTAMP(), 'Spencer');";
                        string query2 = "INSERT INTO customer(customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES('" + name_txtbox.Text + "', (SELECT addressId FROM address WHERE address = '" + address_txtbox.Text + "') , 1, CURRENT_TIMESTAMP(), 'Spencer', CURRENT_TIMESTAMP(), 'Spencer');";
                        MySqlCommand cmd = new MySqlCommand(query1, DBConnection.conn);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = query2;
                        cmd.ExecuteNonQuery();
                    }

                    Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public void GetCountries()
        {
            //gather all of the countries from the database
            MySqlCommand cmd = new MySqlCommand("SELECT country FROM country", DBConnection.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr[0]);
                country_combo.Items.Add(rdr[0]);
            }
            rdr.Close();
        }

        public void GetCities(string country)
        {
            // Gather all of the cities associated with the country.
            //gather all of the countries from the database
            MySqlCommand cmd = new MySqlCommand("SELECT city.city FROM city JOIN country ON city.countryId = country.countryId WHERE country = '" + country + "';", DBConnection.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr[0]);
                city_combo.Items.Add(rdr[0]);
            }
            rdr.Close();
        }

        private void page_tick_Tick(object sender, EventArgs e)
        {
            try
            {
                
                if (Country == "" && country_combo.Text != "")
                {
                    Country = country_combo.Text;
                    Console.WriteLine("Country has been selected: " + country_combo.Text);
                    city_combo.Enabled = true;
                    country_change = true;
                } else if (Country != country_combo.Text)
                {

                    Console.WriteLine("Country has been changed: " + country_combo.Text);
                    Country = country_combo.Text;
                    country_change = true;
                }
                

                if (country_change == true)
                {
                    city_combo.Text = "";
                    city_combo.Items.Clear();
                    Console.WriteLine("Running GetCities");
                    GetCities(Country);
                    country_change = false;
                }
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

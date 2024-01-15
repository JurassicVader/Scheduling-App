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

        private static readonly char[] SpecialChars =
       {
                '\\', '|', '!', '#', '$', '%', '&', '/', '(', ')',
                    '=', '?', '»', '«', '@', '£', '§', '€', '{', '}',
                        '.', '-', ';', '\'', '<', '>', '_', ',', '*', '+'
};

        public static bool HasSpecialChar(string input) => input != null && input.IndexOfAny(SpecialChars) != -1;

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
                string PhoneNum = phone_txtbox.Text;

                Console.WriteLine(PhoneNum);
                if (update == true)
                {
                    string query = "UPDATE customer JOIN address ON customer.addressId = address.addressId LEFT JOIN city ON address.cityId = city.cityId LEFT JOIN country ON city.countryId = country.countryId SET customer.customerName = '" + name_txtbox.Text.Trim() + "', address.Phone= '" + PhoneNum + "', address.address= '" + address_txtbox.Text.Trim() + "', address.cityId = (SELECT cityId FROM city WHERE city = '"+city_combo.Text.Trim() + "') WHERE customer.customerId ="+ ID +";";
                    MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                    if (HasSpecialChar(name_txtbox.Text) || HasSpecialChar(address_txtbox.Text) || HasSpecialChar(city_combo.Text) || phone_txtbox.Text == "" || HasSpecialChar(country_combo.Text))
                    {
                        MessageBox.Show("One or more of the fields are empty or has a special character. \nPlease remove all special characters and fully fill out the form. \n(Phone Number field accepts \"-\")");
                        
                    } else if (long.TryParse(PhoneNum.Replace("-", ""), out _) == false)
                    {
                        MessageBox.Show("The phone number field only accepts digits and dashes.");
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Executed Command");
                        Close();
                    }
                    

                } 
                else
                {
                    bool activeAddress = false;
                    string query = "SELECT * FROM address WHERE address = '" + address_txtbox.Text.Trim()+"';";
                    MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read() == true)
                    {
                        activeAddress = true;
                    }
                    reader.Close();
                    if (HasSpecialChar(name_txtbox.Text) || HasSpecialChar(address_txtbox.Text) || HasSpecialChar(city_combo.Text) || phone_txtbox.Text == "" || HasSpecialChar(country_combo.Text))
                    {
                        MessageBox.Show("One or more of the fields are empty or has a special character. \nPlease remove all special characters and fully fill out the form. \n(Phone Number field accepts \"-\")");
                    }
                    else if (long.TryParse(PhoneNum.Replace("-", ""), out _) == false)
                    {
                        MessageBox.Show("The phone number field only accepts digits and dashes.");
                    }
                    else
                    {
                        if (activeAddress == true)
                        {
                            string query3 = "UPDATE address SET phone = '" + PhoneNum + "', cityId = (SELECT cityId FROM city WHERE city = '" + city_combo.Text.Trim() + "') WHERE address = '" + address_txtbox.Text.Trim() + "';";
                            string query2 = "INSERT INTO customer(customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES('" + name_txtbox.Text.Trim() + "', (SELECT addressId FROM address WHERE address = '" + address_txtbox.Text.Trim() + "') , 1, CURRENT_TIMESTAMP(), 'Spencer', CURRENT_TIMESTAMP(), 'Spencer');";
                            MySqlCommand cmd = new MySqlCommand(query2, DBConnection.conn);
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = query3;
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            string query1 = "INSERT INTO address(address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES('" + address_txtbox.Text.Trim() + "', '', (SELECT cityId FROM city WHERE city = '" + city_combo.Text.Trim() + "'), 11111, '" + PhoneNum + "', CURRENT_TIMESTAMP(), 'Spencer', CURRENT_TIMESTAMP(), 'Spencer');";
                            string query2 = "INSERT INTO customer(customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES('" + name_txtbox.Text.Trim() + "', (SELECT addressId FROM address WHERE address = '" + address_txtbox.Text.Trim() + "') , 1, CURRENT_TIMESTAMP(), 'Spencer', CURRENT_TIMESTAMP(), 'Spencer');";
                            MySqlCommand cmd = new MySqlCommand(query1, DBConnection.conn);
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = query2;
                            cmd.ExecuteNonQuery();
                        }

                        Close();
                    }
                    
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " \nCreation failed.");

            }
            
        }

        public void GetCountries()
        {
            //gather all of the countries from the database
            MySqlCommand cmd = new MySqlCommand("SELECT country FROM country ORDER BY country", DBConnection.conn);
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
            MySqlCommand cmd = new MySqlCommand("SELECT city.city FROM city JOIN country ON city.countryId = country.countryId WHERE country = '" + country + "' ORDER BY city.city;", DBConnection.conn);
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

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

        public Customer(string name, string phone, string address, string city, string country, string type)
        {
            InitializeComponent();
            // Checks to see if the customer is being created or updated
            if (type == "update")
            {
                update = true;
                // Edit the form text
                title_lbl.Text = "Customer Update";
                create_btn.Text = "Update";
                //Fill the form with customer data
                name_txtbox.Text = name;
                address_txtbox.Text = address;
                phone_txtbox.Text = phone;
                city_combo.Text = city;
                country_combo.Text = country;
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
                MySqlCommand cmd = new MySqlCommand("", DBConnection.conn);
                
                if (update == true)
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}

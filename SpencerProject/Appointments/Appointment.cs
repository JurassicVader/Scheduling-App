using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SpencerProject.Appointments
{
    public partial class Appointment : Form
    {
        public Appointment(string userId, string type, string customerId, string time, string date, string desc, bool update)
        {
            InitializeComponent();
            timePicker.CustomFormat = "HH:mm"; // Only allows hours and minutes
            uId_txtbox.Text = userId;
            if (update == true)
            {
                type_txtbox.Text = type;
                cId_combo.Text = customerId;
                timePicker.Text = time;
                datePicker.Text = date;
                desc_txtbox.Text = desc;
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

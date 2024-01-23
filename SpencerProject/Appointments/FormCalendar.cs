using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpencerProject.Appointments
{
    public partial class FormCalendar : Form
    {
        public FormCalendar()
        {
            InitializeComponent();
        }

        public DateTime GetDT
        {
            get
            {
                return monthCalendar1.SelectionStart;
            }
        }

        private void Select_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

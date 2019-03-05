using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchedulingApp
{
    public partial class AddAppointmentForm : SchedulingAppBaseForms.AppointmentForm
    {
        public static MainForm mainForm = null;

        public AddAppointmentForm()
        {
            InitializeComponent();
        }

        private void appointmentCancelButton_Click(object sender, EventArgs e)
        {
            DataInterface.DBClose();
            MainForm.addAppointmentForm = this;
            mainForm.Show();
            MainForm.addAppointmentForm.Close();
        }
    }
}

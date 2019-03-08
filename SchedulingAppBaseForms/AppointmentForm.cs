using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchedulingAppBaseForms
{
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
            appointmentStartDate.Format = DateTimePickerFormat.Custom;
            appointmentStartDate.CustomFormat = "MM-dd-yyyy hh:mm:ss";
            appointmentEndDate.Format = DateTimePickerFormat.Custom;
            appointmentEndDate.CustomFormat = "MM-dd-yyyy hh:mm:ss";
            //appointmentStartDate.CustomFormat = "MM/DD/YYYY HH:MM:SS";
        }
    }
}

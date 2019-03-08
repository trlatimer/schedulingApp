using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace SchedulingApp
{
    public partial class MainForm : Form
    {
        public static LoginForm loginForm = null;
        public static CustomerMainForm customerForm = null;
        public static AddAppointmentForm addAppointmentForm = null;
        private static TimeZone currentTimeZone = TimeZone.CurrentTimeZone;
        private static DateTime currentTime = DateTime.Now;
        private static string offset = currentTimeZone.GetUtcOffset(currentTime).ToString();
        private static Dictionary<string, object> appointment = new Dictionary<string, object>();
        

        public MainForm()
        {
            InitializeComponent();
            try
            {
                DataInterface.createAppointmentTable();
            }
            catch (System.Data.DuplicateNameException)
            {
                Console.WriteLine("Appointment Table already created");
            }
            
            DataInterface.displayAppointments(appointmentsDGV);
        }

        

        private DateTime convertToLocal(string time)
        {
            DateTime utcDateTime = DateTime.Parse(time);
            DateTime localDateTime = utcDateTime.ToLocalTime();
            return localDateTime;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mainWelcomeLabel.Text = $"Welcome, {DataInterface.getCurrentUserName()}!";
        }

        private void mainExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mainLogoutButton_Click(object sender, EventArgs e)
        {
            DataInterface.appointmentTable.Clear();
            MainForm mainform = this;
            loginForm.Show();
            this.Hide();

        }

        private void mainCustomerButton_Click(object sender, EventArgs e)
        {
            CustomerMainForm customerForm = new CustomerMainForm();
            CustomerMainForm.mainForm = this;
            this.Hide();
            customerForm.Show();
        }

        private void mainAddButton_Click(object sender, EventArgs e)
        {
            DataInterface.DBClose();
            AddAppointmentForm appointmentForm = new AddAppointmentForm();
            AddAppointmentForm.mainForm = this;
            appointmentForm.Show();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            appointmentsDGV.Refresh();
            DataInterface.displayAppointments(appointmentsDGV);
        }
    }
}

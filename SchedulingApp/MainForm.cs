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
        public static string currentTZ;
        
        public MainForm()
        {
            InitializeComponent();
        }

        public void displayAppointments()
        {
            String query = "";
            currentTZ = TimeZoneInfo.Local.BaseUtcOffset.ToString();
            DateTime selectedDate = appointmentCalendar.SelectionRange.Start.ToUniversalTime();
            DateTime sunday = selectedDate.AddDays(-(int)selectedDate.DayOfWeek).ToUniversalTime();
            DateTime saturday = selectedDate.AddDays(-(int)selectedDate.DayOfWeek + (int)DayOfWeek.Saturday).ToUniversalTime();
            DataTable appointmentsDT = new DataTable();
            if (dgvViewMonthRadioButton.Checked)
            {
                query = $"SELECT a.appointmentId AS ID, c.customerName AS 'Customer Name', a.title AS Title, a.start AS Start, a.end AS End FROM appointment AS a, customer AS c WHERE c.customerId = a.customerId AND MONTH(a.start) = '{appointmentCalendar.SelectionStart.Month}' AND YEAR(a.start) = '{appointmentCalendar.SelectionStart.Year}'";
            }
            else if (dgvViewWeekRadioButton.Checked)
            {
                query = $"SELECT a.appointmentId AS ID, c.customerName AS 'Customer Name', a.title AS Title, a.start AS Start, a.end AS End FROM appointment AS a, customer AS c WHERE c.customerId = a.customerId AND a.start >= '{sunday.ToString("yyyy-MM-dd hh:MM:ss")}' - INTERVAL 3 MINUTE AND a.start < '{saturday.AddHours(24).ToString("yyyy-MM-dd hh:MM:ss")}' - INTERVAL 3 MINUTE";
            }
            else if (dgvViewDayRadioButton.Checked)
            {
                query = $"SELECT a.appointmentId AS ID, c.customerName AS 'Customer Name', a.title AS Title, a.start AS Start, a.end AS End FROM appointment AS a, customer AS c WHERE c.customerId = a.customerId AND a.start >= '{selectedDate.ToString("yyyy-MM-dd hh:MM:ss")}' - INTERVAL 3 MINUTE AND a.start < '{selectedDate.AddHours(24).ToString("yyyy-MM-dd hh:MM:ss")}' - INTERVAL 3 MINUTE";
            }
            DataInterface.DBOpen();
            MySqlDataAdapter adp = new MySqlDataAdapter(query, DataInterface.conn);
            MySqlCommandBuilder cmd = new MySqlCommandBuilder(adp);
            adp.Fill(appointmentsDT);

            DataInterface.convertToLocal(appointmentsDT, "Start");
            DataInterface.convertToLocal(appointmentsDT, "End");

            appointmentsDGV.DataSource = appointmentsDT;
            appointmentsDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataInterface.DBClose();
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
            displayAppointments();
        }

        private void dgvViewWeekRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            displayAppointments();
        }

        private void dgvViewDayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            displayAppointments();
        }

        private void dgvViewMonthRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            displayAppointments();
        }

        private void appointmentCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            displayAppointments();
        }
    }
}

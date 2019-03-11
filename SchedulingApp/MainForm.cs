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
        public static UpdateAppointmentForm updateAppointmentForm = null;
        public static int selectedAppointmentID = -1;
        public static DataGridViewRow selectedRow;
        public static DataTable appointmentsDT = new DataTable();
        
        public MainForm()
        {
            InitializeComponent();
            displayAppointments();
            checkForReminders();
        }

        public void displayAppointments()
        {
            appointmentsDT.Clear();
            String query = "";
            DateTime selectedDate = appointmentCalendar.SelectionRange.Start.ToUniversalTime();
            DateTime sunday = selectedDate.AddDays(-(int)selectedDate.DayOfWeek).ToUniversalTime();
            DateTime saturday = selectedDate.AddDays(-(int)selectedDate.DayOfWeek + (int)DayOfWeek.Saturday).ToUniversalTime();
            if (dgvViewMonthRadioButton.Checked)
            {
                query = $"SELECT a.appointmentId AS ID, c.customerName AS 'Customer Name', a.title AS Title, a.start AS Start, a.end AS End FROM appointment AS a, customer AS c WHERE c.customerId = a.customerId AND MONTH(a.start) = '{appointmentCalendar.SelectionStart.Month}' AND YEAR(a.start) = '{appointmentCalendar.SelectionStart.Year}' AND a.createdBy = '{DataInterface.getCurrentUserName()}' ORDER BY a.start";
            }
            else if (dgvViewWeekRadioButton.Checked)
            {
                query = $"SELECT a.appointmentId AS ID, c.customerName AS 'Customer Name', a.title AS Title, a.start AS Start, a.end AS End FROM appointment AS a, customer AS c WHERE c.customerId = a.customerId AND a.start >= '{sunday.ToString("yyyy-MM-dd hh:MM:ss")}' - INTERVAL 3 MINUTE AND a.start < '{saturday.AddHours(24).ToString("yyyy-MM-dd hh:MM:ss")}' - INTERVAL 3 MINUTE AND a.createdBy = '{DataInterface.getCurrentUserName()}' ORDER BY a.start";
            }
            else if (dgvViewDayRadioButton.Checked)
            {
                query = $"SELECT a.appointmentId AS ID, c.customerName AS 'Customer Name', a.title AS Title, a.start AS Start, a.end AS End FROM appointment AS a, customer AS c WHERE c.customerId = a.customerId AND a.start >= '{selectedDate.ToString("yyyy-MM-dd hh:MM:ss")}' - INTERVAL 3 MINUTE AND a.start < '{selectedDate.AddHours(24).ToString("yyyy-MM-dd hh:MM:ss")}' - INTERVAL 3 MINUTE AND a.createdBy = '{DataInterface.getCurrentUserName()}' ORDER BY a.start";
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

        public static void checkForReminders()
        {
            foreach(DataRow row in appointmentsDT.Rows)
            {
                DateTime startTime = DateTime.Parse(row["Start"].ToString());
                DateTime currentTime = DateTime.Parse(DataInterface.getCurrentDateTime());
                TimeSpan reminderMark = new TimeSpan(0, 15, 0);
                TimeSpan appointmentPassed = new TimeSpan(0, 0, 0);
                TimeSpan difference = startTime.Subtract(currentTime);
                if (difference <= reminderMark && difference > appointmentPassed)
                {
                    MessageBox.Show($"The event, {row["Title"].ToString()}, with customer, {row["Customer Name"].ToString()}, is starting soon.");
                }
            }
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

        private void mainEditButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataInterface.DBClose();
                updateAppointmentForm = new UpdateAppointmentForm();
                UpdateAppointmentForm.mainForm = this;
                updateAppointmentForm.Show();
            }
            catch (DataNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void appointmentsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = appointmentsDGV.CurrentCell.RowIndex;
            selectedRow = appointmentsDGV.Rows[rowIndex];
            selectedAppointmentID = Convert.ToInt32(selectedRow.Cells[0].Value);
        }

        private void mainDeleteButton_Click(object sender, EventArgs e)
        {
            if (selectedAppointmentID != -1)
            {
                DataInterface.deleteAppoinment(selectedAppointmentID);
            }
            else
            {
                MessageBox.Show("Please select a customer to delete and try again.");
            }
            displayAppointments();
        }
    }

    public class DataNotFoundException : Exception
    {
        public DataNotFoundException()
        {
        }

        public DataNotFoundException(string message)
            : base(message)
        {
        }

        public DataNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

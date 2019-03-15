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
        // Variables for navigation references
        public static LoginForm loginForm = null;
        public static CustomerMainForm customerForm = null;
        public static AddAppointmentForm addAppointmentForm = null;
        public static EditAppointmentForm updateAppointmentForm = null;
        public static MonthReportForm monthReport = null;
        public static CustomerReportForm customerReport = null;
        public static ConsultantReportForm consultantReport = null;
        // Set selectedAppointmentID to -1 to ensure valid appointment is selected and ID obtained
        public static int selectedAppointmentID = -1;
        // Variable to hold data within selected row
        public static DataGridViewRow selectedRow;
        // DataTable to hold appointments for view
        public static DataTable appointmentsDT = new DataTable();
        
        // Form Constructor
        public MainForm()
        {
            InitializeComponent();
            // Populate DataGridView with data depending on view selected and user logged in
            displayAppointments();
            // Check if any appointments are within 15 minutes
            checkForReminders();
        }

        // Populate DataGridView with appointment data
        public void displayAppointments()
        {
            // Clear DataTable of any prior information
            appointmentsDT.Clear();
            String query = "";
            // Obtain selected date from MonthCalendar
            DateTime selectedDate = appointmentCalendar.SelectionRange.Start.ToUniversalTime();
            // Determine sunday and saturday for week view, convert to universal time for accurate comparison to DB values
            DateTime sunday = selectedDate.AddDays(-(int)selectedDate.DayOfWeek).ToUniversalTime();
            DateTime saturday = selectedDate.AddDays(-(int)selectedDate.DayOfWeek + (int)DayOfWeek.Saturday).ToUniversalTime();

            // Check which view is selected and query data accordingly
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

            // Execute query and fill DataTable
            DataInterface.DBOpen();
            MySqlDataAdapter adp = new MySqlDataAdapter(query, DataInterface.conn);
            MySqlCommandBuilder cmd = new MySqlCommandBuilder(adp);
            adp.Fill(appointmentsDT);

            // Convert start and end times to local time
            DataInterface.convertToLocal(appointmentsDT, "Start");
            DataInterface.convertToLocal(appointmentsDT, "End");

            // Set DataSource for DataGridView to display data within DataTable
            appointmentsDGV.DataSource = appointmentsDT;
            appointmentsDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataInterface.DBClose();
        }

        // Check if any appointments are within 15 minutes of occurring
        public static void checkForReminders()
        {
            // Iterate through appointments in DataTable
            foreach(DataRow row in appointmentsDT.Rows)
            {
                // Obtain start time for each appointment
                DateTime startTime = DateTime.Parse(row["Start"].ToString());
                // Obtain the current time
                DateTime currentTime = DateTime.Parse(DataInterface.getCurrentDateTime());
                // Set 15 minute mark for comparison
                TimeSpan reminderMark = new TimeSpan(0, 15, 0);
                TimeSpan appointmentPassed = new TimeSpan(0, 0, 0);
                // Obtain difference between start time and the current time
                TimeSpan difference = startTime.Subtract(currentTime);
                // If difference is less than 15 minutes but has not passed the current time, display reminder
                if (difference <= reminderMark && difference > appointmentPassed)
                {
                    MessageBox.Show($"The event, {row["Title"].ToString()}, with customer, {row["Customer Name"].ToString()}, is starting soon.");
                }
            }
        }

        // Form Closing
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // Form Load
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Display welcome text
            mainWelcomeLabel.Text = $"Welcome, {DataInterface.getCurrentUserName()}!";
        }

        // Exit Button Click
        private void mainExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Logout Button Click
        private void mainLogoutButton_Click(object sender, EventArgs e)
        {
            MainForm mainform = this;
            loginForm.Show();
            this.Hide();
        }

        // Customer Button Click
        private void mainCustomerButton_Click(object sender, EventArgs e)
        {
            // Open CustomerMainForm, hide this form, show CustomerMainForm
            CustomerMainForm customerForm = new CustomerMainForm();
            CustomerMainForm.mainForm = this;
            this.Hide();
            customerForm.Show();
        }

        // Add Button Click
        private void mainAddButton_Click(object sender, EventArgs e)
        {
            DataInterface.DBClose();
            AddAppointmentForm appointmentForm = new AddAppointmentForm();
            AddAppointmentForm.mainForm = this;
            appointmentForm.Show();
        }

        // Form Activiated
        private void MainForm_Activated(object sender, EventArgs e)
        {
            // Refresh DataGridView and DataTable to reflect current data
            appointmentsDGV.Refresh();
            displayAppointments();
        }

        // Checked Changed for View Radio Buttons
        private void dgvViewWeekRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Refresh data
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

        // DateChanged Event
        private void appointmentCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Refresh Data to reflect date selected
            displayAppointments();
        }

        // Edit Button Click
        private void mainEditButton_Click(object sender, EventArgs e)
        {
            // Attempt to selected row
            try
            {
                DataInterface.DBClose();
                updateAppointmentForm = new EditAppointmentForm();
                EditAppointmentForm.mainForm = this;
                updateAppointmentForm.Show();
            }
            // If unable to locate Appointment Data, display Exception message
            catch (DataNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        // DataGridView Cell Click
        private void appointmentsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Set row index and obtain selected row
            int rowIndex = appointmentsDGV.CurrentCell.RowIndex;
            selectedRow = appointmentsDGV.Rows[rowIndex];
            // Obtain appointmentID for selected row
            selectedAppointmentID = Convert.ToInt32(selectedRow.Cells[0].Value);
        }

        // Delete Button Click
        private void mainDeleteButton_Click(object sender, EventArgs e)
        {
            // Check that selected row is valid
            if (selectedAppointmentID != -1)
            {
                // Delete appointment
                DataInterface.deleteAppoinment(selectedAppointmentID);
            }
            else
            {
                // If not valid, display message
                MessageBox.Show("Please select a customer to delete and try again.");
            }
            // Refresh appointment data
            displayAppointments();
        }

        // Month Report Button Click
        private void button1_Click(object sender, EventArgs e)
        {
            // Open new MonthReportForm
            DataInterface.DBClose();
            monthReport = new MonthReportForm();
            MonthReportForm.mainForm = this;
            monthReport.Show();
        }

        // Consultant Report Button Click
        private void consultantReportButton_Click(object sender, EventArgs e)
        {
            // Open new Consultant Report Form
            DataInterface.DBClose();
            consultantReport = new ConsultantReportForm();
            ConsultantReportForm.mainForm = this;
            consultantReport.Show();
        }

        // Customer Report Button Click
        private void customerReportButton_Click(object sender, EventArgs e)
        {
            // Open new Customer Report
            DataInterface.DBClose();
            customerReport = new CustomerReportForm();
            CustomerReportForm.mainForm = this;
            customerReport.Show();
        }
    }
    
    // Exception for when data cannot be found in the database
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

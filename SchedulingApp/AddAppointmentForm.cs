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
    // Declare delegate
    delegate bool doesOverlap(DateTime time);

    // Appointment form class
    public partial class AddAppointmentForm : SchedulingAppBaseForms.AppointmentForm
    {
        // Initialize variables
        // Hold instance to return to mainForm
        public static MainForm mainForm = null;
        // Variables for form ata
        private int appointmentID;
        private int customerID;
        private string title;
        private string description;
        private string location;
        private string contact;
        private string url;
        private string start;
        private string end;
        private string currentUser = DataInterface.getCurrentUserName();
        private int selectedCustomerID;
        // Delegate
        private static doesOverlap overlaps;

        // Form constructor
        public AddAppointmentForm()
        {
            InitializeComponent();
            // Populate ComboBox with customers
            DataInterface.populateComboBox(appointmentCustomerComboBox);
        }

        // Validate inputs before saving
        private bool inputValidation()
        {
            // Variable determining if inputs are valid
            bool isValid = true;
            // Obtain current DateTime for comparing
            DateTime currentDateTime = DateTime.Parse(DataInterface.getCurrentDateTime());

            // Check if required fields contain text
            if (string.IsNullOrWhiteSpace(appointmentCustomerComboBox.Text))
            {
                // If invalid, change BackColor, prompt user, and set isValid to false
                appointmentCustomerComboBox.BackColor = Color.Salmon;
                MessageBox.Show("Customer field cannot be empty. Please select a customer and try again.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(appointmentTitleTextBox.Text))
            {
                appointmentTitleTextBox.BackColor = Color.Salmon;
                MessageBox.Show("Title field cannot be empty. Please enter a title and try again.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(appointmentDescriptionTextBox.Text))
            {
                appointmentDescriptionTextBox.BackColor = Color.Salmon;
                MessageBox.Show("Description field cannot be empty. Please enter a description and try again.");
                isValid = false;
            }
            if (appointmentStartDate.Value < currentDateTime || appointmentEndDate.Value < currentDateTime)
            {
                MessageBox.Show("Start and end dates/times must occur after the current date/time.");
                isValid = false;
            }
            if (appointmentEndDate.Value < appointmentStartDate.Value)
            {
                MessageBox.Show("End time must be after start time.");
                isValid = false;
            }
            // return bool to show validity -- true is valid, false is not valid
            return isValid;
        }

        // Check if times are within local business hours
        public static bool checkBusinessHours(DateTime start, DateTime end)
        {
            // Obtain local business hours
            DateTime businessStart = DateTime.Today.AddHours(8);
            DateTime businessEnd = DateTime.Today.AddHours(17);

            // Check if start time is before or after business hours
            if (start.TimeOfDay < businessStart.TimeOfDay || start.TimeOfDay > businessEnd.TimeOfDay || end.TimeOfDay < businessStart.TimeOfDay || end.TimeOfDay > businessEnd.TimeOfDay)
            {
                // If outside, prompt user to approve continuing
                DialogResult result = MessageBox.Show("The start or end time is outside of business hours. Continue?", "Outside Business Hours", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // If yes is selected, add appointment anyways
                    return true;
                }
                else
                {
                    // If no is selected, don't add appointment
                    return false;
                }
            }
            else
            {
                // If within business hours, add appointment
                return true;
            }
        }

        // Check if times overlap any existing appointments
        public static bool checkForOverlap(DateTime start, DateTime end)
        {
            // Bool returned to show if overlap exists
            bool overlap = false;
            // Create DataTable containing appointments
            DataTable appointments = DataInterface.getAppointments(DataInterface.getCurrentUserName());
            // Iterate through DataTable
            foreach (DataRow row in appointments.Rows)
            {
                // Obtain start and end times
                DateTime appointmentStart = DateTime.Parse(row["start"].ToString()).ToLocalTime();
                DateTime appointmentEnd = DateTime.Parse(row["end"].ToString()).ToLocalTime();
                // Lambda expression to check if provided time is within start and end times of appointment being evaluated
                overlaps = (time) => { return (time <= appointmentEnd && time >= appointmentStart); };

                // Use lambda to check if the provided start and end times in the form overlap appointment being evaluated
                if (overlaps(start) || overlaps(end))
                { 
                    // if either start or end are within an existing appointment, set overlap to true to indicate overlap
                    overlap = true;
                }
            }

            // return state of overlap -- true indicates overlap, false indicates no overlap
            return overlap;
        }

        // Cancel Button - Return to MainForm
        private void appointmentCancelButton_Click(object sender, EventArgs e)
        {
            // Close database, set MainForms form to this form, show MainForm again, close this form
            DataInterface.DBClose();
            MainForm.addAppointmentForm = this;
            mainForm.Show();
            MainForm.addAppointmentForm.Close();
        }

        // Save Button click
        private void appointmentSaveButton_Click(object sender, EventArgs e)
        {
            // If inputs are valid, continue
            if (inputValidation())
            {
                // If appointment is within business hours or user clicked 'Yes', continue
                if (checkBusinessHours(appointmentStartDate.Value, appointmentEndDate.Value))
                {
                    // Store data within form
                    appointmentID = DataInterface.getNextID("appointmentId", "appointment", DataInterface.getAppointmentIDList());
                    customerID = selectedCustomerID;
                    title = appointmentTitleTextBox.Text;
                    description = appointmentDescriptionTextBox.Text;
                    location = appointmentLocationTextBox.Text;
                    contact = appointmentContactTextBox.Text;
                    url = appointmentURLTextBox.Text;
                    start = appointmentStartDate.Value.ToUniversalTime().ToString("u");
                    end = appointmentEndDate.Value.ToUniversalTime().ToString("u");

                    // Check if appointment being created overlaps an existing appointment
                    if (checkForOverlap(DateTime.Parse(start), DateTime.Parse(end)) == true)
                    {
                        // If there is overlap, prompt user and cancel save
                        MessageBox.Show("The appointment you are trying to add overlaps an existing appointment." +
                            "\n\nPlease correct and try again.");
                        return;
                    }
                    // If no overlap, continue with save
                    else
                    {
                        // Use DataInterface method to pass data to query for creating new appointment
                        DataInterface.createAppointment(customerID, title, description, location, contact, url, start, end, currentUser);
                        // Set MainForms form to this form, show mainForm again, close this form
                        MainForm.addAppointmentForm = this;
                        mainForm.Show();
                        MainForm.addAppointmentForm.Close();
                    }
                }
            }
            // If inputs are not valid or user chose to not allow it outside business hours, cancel save
            return;
        }

        // Selected Customer changes
        private void appointmentCustomerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if ComboBox has text and set color accordingly
            AddCustomerForm.checkTextChanged(appointmentCustomerComboBox);
            // create DataRowView of selected row
            DataRowView drv = (DataRowView)appointmentCustomerComboBox.SelectedItem;
            // Set customer ID to ID stored in DataRow
            selectedCustomerID = Convert.ToInt32(drv[0]);
        }

        // Text changed events in required boxes
        private void appointmentTitleTextBox_TextChanged(object sender, EventArgs e)
        {
            AddCustomerForm.checkTextChanged(appointmentTitleTextBox);
        }

        private void appointmentDescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            AddCustomerForm.checkTextChanged(appointmentTitleTextBox);
        }
    }
}

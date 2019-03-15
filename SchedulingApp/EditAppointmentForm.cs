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
    public partial class EditAppointmentForm : SchedulingAppBaseForms.AppointmentForm
    {
        // Variable for reference to MainForm
        public static MainForm mainForm = null;
        // Dictionary containing information about selectedAppointment
        private Dictionary<string, string> selectedAppointment;
        // Variables for data from form
        private int appointmentID;
        private int customerID;
        private string title;
        private string description;
        private string location;
        private string contact;
        private string url;
        private string start;
        private string end;
        private int selectedCustomerID;

        // Form Constructor
        public EditAppointmentForm()
        {
            InitializeComponent();
            // Populate controls with data of selected appointment
            populateData();
        }

        // Populate form with existing data
        private void populateData()
        {
            // Obtain dictionary of appointment information
            selectedAppointment = DataInterface.getAppointmentInfo(MainForm.selectedAppointmentID);

            // Populate customer ComboBox
            DataInterface.populateComboBox(appointmentCustomerComboBox);

            // Obtain data from form needed to update appointment
            appointmentIDTextBox.Text = selectedAppointment["ID"];
            appointmentCustomerComboBox.SelectedValue = Convert.ToInt32(selectedAppointment["customerID"]);
            appointmentTitleTextBox.Text = selectedAppointment["Title"];
            appointmentLocationTextBox.Text = selectedAppointment["Location"];
            appointmentContactTextBox.Text = selectedAppointment["Contact"];
            appointmentURLTextBox.Text = selectedAppointment["URL"];
            appointmentStartDate.Value = DateTime.Parse(selectedAppointment["Start"]);
            appointmentEndDate.Value = DateTime.Parse(selectedAppointment["End"]);
            appointmentDescriptionTextBox.Text = selectedAppointment["Description"];
        }

        // Valide inputs
        private bool inputValidation()
        {
            // Bool to return indicating if inputs are valid
            bool isValid = true;
            // Obtain current DateTime for comparison
            DateTime currentDateTime = DateTime.Parse(DataInterface.getCurrentDateTime());
            // Check if required TextBoxes are empty
            if (string.IsNullOrWhiteSpace(appointmentCustomerComboBox.Text))
            {
                // If empty, change background color to salmon, display message, and indicate inputs are not valid
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
            // Check if appointment is before the current time
            if (appointmentStartDate.Value < currentDateTime || appointmentEndDate.Value < currentDateTime)
            {
                // If appointment is before current time, display message and set inputs to invalid
                MessageBox.Show("Start and end dates/times must occur after the current date/time.");
                isValid = false;
            }
            if (appointmentEndDate.Value < appointmentStartDate.Value)
            {
                MessageBox.Show("End time must be after start time.");
                isValid = false;
            }

            // Return whether inputs are valid or not -- True is valid, false is not valid
            return isValid;
        }

        // Cancel Button Click
        private void appointmentCancelButton_Click(object sender, EventArgs e)
        {
            // Show MainForm again, close this form
            DataInterface.DBClose();
            MainForm.updateAppointmentForm = this;
            mainForm.Show();
            MainForm.updateAppointmentForm.Close();
        }

        // Save Button Click
        private void appointmentSaveButton_Click(object sender, EventArgs e)
        {
            // Check if inputs are valid, if so, continue
            if (inputValidation())
            {
                // Check if edited times are within business hours or approved by user, if so, continue
                if (AddAppointmentForm.checkBusinessHours(appointmentStartDate.Value, appointmentEndDate.Value))
                {
                    // Set data from form to variables
                    appointmentID = MainForm.selectedAppointmentID;
                    customerID = selectedCustomerID;
                    title = appointmentTitleTextBox.Text;
                    description = appointmentDescriptionTextBox.Text;
                    location = appointmentLocationTextBox.Text;
                    contact = appointmentContactTextBox.Text;
                    url = appointmentURLTextBox.Text;
                    start = appointmentStartDate.Value.ToUniversalTime().ToString("u");
                    end = appointmentEndDate.Value.ToUniversalTime().ToString("u");

                    // Check if there is overlap with times provided
                    if (AddAppointmentForm.checkForOverlap(DateTime.Parse(start), DateTime.Parse(end)) == true)
                    {
                        // If there is overlap, display message and cancel save
                        MessageBox.Show("The appointment you are trying to add overlaps an existing appointment." +
                            "\n\nPlease correct and try again.");
                        return;
                    }
                    else
                    {
                        // If no overlap, call update method to update appointment, pass variables obtained from form
                        DataInterface.updateAppointment(appointmentID, customerID, title, description, location, contact, url, start, end);
                        MainForm.updateAppointmentForm = this;
                        mainForm.Show();
                        MainForm.updateAppointmentForm.Close();
                    }
                }
            }
        }

        // Index Changed on ComboBox
        private void appointmentCustomerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if background color needs to change
            AddCustomerForm.checkTextChanged(appointmentCustomerComboBox);
            // Create a DataRowView to obtain data from selection
            DataRowView drv = (DataRowView)appointmentCustomerComboBox.SelectedItem;
            // Set customerID by ID from selected row
            selectedCustomerID = Convert.ToInt32(drv[0]);
        }

        // Text Changed events for required TextBoxes, check if background color needs to change
        private void appointmentTitleTextBox_TextChanged(object sender, EventArgs e)
        {
            AddCustomerForm.checkTextChanged(appointmentTitleTextBox);
        }

        private void appointmentDescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            AddCustomerForm.checkTextChanged(appointmentDescriptionTextBox);
        }
    }
}

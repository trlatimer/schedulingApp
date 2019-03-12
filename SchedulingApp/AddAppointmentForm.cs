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
    public partial class AddAppointmentForm : SchedulingAppBaseForms.AppointmentForm
    {
        // TODO ADD INPUT VALIDATION FOR APPOINTMENT FORMS
        public static MainForm mainForm = null;
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

        public AddAppointmentForm()
        {
            InitializeComponent();
            DataInterface.populateComboBox(appointmentCustomerComboBox);
        }

        private bool inputValidation()
        {
            bool isValid = true;
            DateTime currentDateTime = DateTime.Parse(DataInterface.getCurrentDateTime());
            if (string.IsNullOrWhiteSpace(appointmentCustomerComboBox.Text))
            {
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
            return isValid;
        }

        private bool checkBusinessHours(DateTime start, DateTime end)
        {
            DateTime businessStart = DateTime.Today.AddHours(8);
            DateTime businessEnd = DateTime.Today.AddHours(17);
            if (start.TimeOfDay < businessStart.TimeOfDay || start.TimeOfDay > businessEnd.TimeOfDay || end.TimeOfDay < businessStart.TimeOfDay || end.TimeOfDay > businessEnd.TimeOfDay)
            {
                DialogResult result = MessageBox.Show("The start or end time is outside of business hours. Continue?", "Outside Business Hours", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }

        }

        private void appointmentCancelButton_Click(object sender, EventArgs e)
        {
            DataInterface.DBClose();
            MainForm.addAppointmentForm = this;
            mainForm.Show();
            MainForm.addAppointmentForm.Close();
        }

        private void appointmentSaveButton_Click(object sender, EventArgs e)
        {
            if (inputValidation())
            {
                if (checkBusinessHours(appointmentStartDate.Value, appointmentEndDate.Value))
                {
                    appointmentID = DataInterface.getNextID("appointmentId", "appointment", DataInterface.getAppointmentIDList());
                    customerID = selectedCustomerID;
                    title = appointmentTitleTextBox.Text;
                    description = appointmentDescriptionTextBox.Text;
                    location = appointmentLocationTextBox.Text;
                    contact = appointmentContactTextBox.Text;
                    url = appointmentURLTextBox.Text;
                    start = appointmentStartDate.Value.ToUniversalTime().ToString("u");
                    end = appointmentEndDate.Value.ToUniversalTime().ToString("u");

                    DataInterface.createAppointment(customerID, title, description, location, contact, url, start, end, currentUser);
                    MainForm.addAppointmentForm = this;
                    mainForm.Show();
                    MainForm.addAppointmentForm.Close();
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
            
        }

        private void appointmentCustomerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddCustomerForm.checkTextChanged(appointmentCustomerComboBox);
            DataRowView drv = (DataRowView)appointmentCustomerComboBox.SelectedItem;
            selectedCustomerID = Convert.ToInt32(drv[0]);
        }

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

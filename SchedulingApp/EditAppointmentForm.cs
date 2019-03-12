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
        public static MainForm mainForm = null;
        private Dictionary<string, string> selectedAppointment;
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

        public EditAppointmentForm()
        {
            InitializeComponent();
            populateData();
        }

        private void populateData()
        {
            selectedAppointment = DataInterface.getAppointmentInfo(MainForm.selectedAppointmentID);

            DataInterface.populateComboBox(appointmentCustomerComboBox);

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

        private void appointmentCancelButton_Click(object sender, EventArgs e)
        {
            DataInterface.DBClose();
            MainForm.updateAppointmentForm = this;
            mainForm.Show();
            MainForm.updateAppointmentForm.Close();
        }

        private void appointmentSaveButton_Click(object sender, EventArgs e)
        {
            if (inputValidation())
            {
                if (AddAppointmentForm.checkBusinessHours(appointmentStartDate.Value, appointmentEndDate.Value))
                {
                    appointmentID = MainForm.selectedAppointmentID;
                    customerID = selectedCustomerID;
                    title = appointmentTitleTextBox.Text;
                    description = appointmentDescriptionTextBox.Text;
                    location = appointmentLocationTextBox.Text;
                    contact = appointmentContactTextBox.Text;
                    url = appointmentURLTextBox.Text;
                    start = appointmentStartDate.Value.ToUniversalTime().ToString("u");
                    end = appointmentEndDate.Value.ToUniversalTime().ToString("u");

                    if (AddAppointmentForm.checkForOverlap(DateTime.Parse(start), DateTime.Parse(end)) == true)
                    {
                        MessageBox.Show("The appointment you are trying to add overlaps an existing appointment." +
                            "\n\nPlease correct and try again.");
                        return;
                    }
                    else
                    {
                        DataInterface.updateAppointment(appointmentID, customerID, title, description, location, contact, url, start, end);
                        MainForm.updateAppointmentForm = this;
                        mainForm.Show();
                        MainForm.updateAppointmentForm.Close();
                    }
                }
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
            AddCustomerForm.checkTextChanged(appointmentDescriptionTextBox);
        }
    }
}

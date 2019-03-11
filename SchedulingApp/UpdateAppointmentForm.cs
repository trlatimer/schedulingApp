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
    public partial class UpdateAppointmentForm : SchedulingAppBaseForms.AppointmentForm
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

        public UpdateAppointmentForm()
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

        private void appointmentCancelButton_Click(object sender, EventArgs e)
        {
            DataInterface.DBClose();
            MainForm.updateAppointmentForm = this;
            mainForm.Show();
            MainForm.updateAppointmentForm.Close();
        }

        private void appointmentSaveButton_Click(object sender, EventArgs e)
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

            DataInterface.updateAppointment(appointmentID, customerID, title, description, location, contact, url, start, end);
            MainForm.updateAppointmentForm = this;
            mainForm.Show();
            MainForm.updateAppointmentForm.Close();
        }

        private void appointmentCustomerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)appointmentCustomerComboBox.SelectedItem;
            selectedCustomerID = Convert.ToInt32(drv[0]);
        }
    }
}

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
    public partial class CustomerReportForm : SchedulingAppBaseForms.ReportForm
    {
        // Reference to main form
        public static MainForm mainForm = null;

        // Form constructor
        public CustomerReportForm()
        {
            InitializeComponent();
            // Populate textbox with report information
            generateReport();
        }

        // Close Button click
        private void reportCloseButton_Click(object sender, EventArgs e)
        {
            // Show main form and close this form
            DataInterface.DBClose();
            mainForm.Show();
            MainForm.customerReport.Close();
        }

        // Obtain data and append text into TextBox
        private void generateReport()
        {
            // Obtain datatable from getAppointments
            DataTable appointments = DataInterface.getAppointments();
            // Create DataView to query
            DataView view = new DataView(appointments);
            // Create new distinct DataTable for customers
            DataTable customers = view.ToTable(true, "customerId");
            // Iterate through customers
            foreach (DataRow customer in customers.Rows)
            {
                // Add Customer ID to textbox
                reportTextBox.AppendText($"Customer ID: {customer["customerId"].ToString()}\n\n");
                // Create array of DataRows for appointments associated with customer
                DataRow[] appointmentArray = appointments.Select($"customerId = '{customer["customerId"].ToString()}'");
                // Iterate through appointments
                foreach (DataRow row in appointmentArray)
                {
                    // Append data for each appointment to TextBox
                    reportTextBox.AppendText($"    ID: {row["appointmentId"]}");
                    reportTextBox.AppendText($"    Title: {row["title"]}");
                    reportTextBox.AppendText($"    Start: {row["start"]}");
                    reportTextBox.AppendText($"    End: {row["end"]}\n\n");
                }
            }
        }
    }
}

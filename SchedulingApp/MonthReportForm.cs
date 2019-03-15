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
    public partial class MonthReportForm : SchedulingAppBaseForms.ReportForm
    {
        // Reference to main form
        public static MainForm mainForm = null;

        // Form Constructor
        public MonthReportForm()
        {
            InitializeComponent();
            // Create async lambda for Load event
            this.Load += async (sender, e) => // async lambda to help with load time for report
            {  
                // Display text when loading
                reportTextBox.AppendText("Obtaining data...");
                // Asynchronously load data to report
                await generateReport();
            };
        }

        // Close Button Click
        private void reportCloseButton_Click(object sender, EventArgs e)
        {
            // Show main form, close this form
            DataInterface.DBClose();
            mainForm.Show();
            MainForm.monthReport.Close();
        }

        // Generate text for report - asynchronous task
        async Task generateReport()
        {
            // Clear previous text
            reportTextBox.Clear();
            await Task.Delay(120);
            // Append text for columns
            reportTextBox.AppendText("MONTH\t\tAPPOINTMENTS\n\n");
            // Create list of Month names
            List<string> monthNames = new List<string>() { "January", "February", "March", "April", "May", "Juny", "July", "August", "September", "October", "November", "December" };
            // Create list of month numbers
            List<int> months = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            // Iterate through integer month values
            foreach (int month in months)
            {
                // For each month, append Month name and corresponding number of appointments within
                reportTextBox.AppendText($"{monthNames[month - 1]}:");
                reportTextBox.AppendText($"\n\t\t{DataInterface.getAppointmentsByMonth(month).Count}\n\n");
            }
        }
    }
}

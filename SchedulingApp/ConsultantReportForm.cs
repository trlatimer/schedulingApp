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
    public partial class ConsultantReportForm : SchedulingAppBaseForms.ReportForm
    {
        public static MainForm mainForm = null;

        // Form constructor
        public ConsultantReportForm()
        {
            InitializeComponent();
            // Trigger function to populate data into TextBox
            generateReport();
        }

        // Close Button Click
        private void reportCloseButton_Click(object sender, EventArgs e)
        {
            DataInterface.DBClose();
            mainForm.Show();
            MainForm.consultantReport.Close();
        }

        // Obtain and populate textbox with data
        private void generateReport()
        {
            // Obtain DataTable returned by getAppointments()
            DataTable appointments = DataInterface.getAppointments();
            // Create view to query
            DataView view = new DataView(appointments);
            // Create distinct table of consultants
            DataTable consultants = view.ToTable(true, "createdBy");
            
            // Iterate through consultants
            foreach (DataRow consultant in consultants.Rows)
            {
                // Add Consultant Name to text box
                reportTextBox.AppendText($"Consultant: {consultant["createdBy"].ToString()}\n\n");

                // Create array of DataRows containing appointments for consultant being iterated
                DataRow[] appointmentArray = appointments.Select($"createdBy = '{consultant["createdBy"].ToString()}'");
                // Iterate through appointments associated with this consultant
                foreach (DataRow row in appointmentArray)
                {
                    // Append text detailing information about appointments
                    reportTextBox.AppendText($"    ID: {row["appointmentId"]}");
                    reportTextBox.AppendText($"    Title: {row["title"]}");
                    reportTextBox.AppendText($"    CustomerID: {row["customerId"]}");
                    reportTextBox.AppendText($"    Start: {row["start"]}");
                    reportTextBox.AppendText($"    End: {row["end"]}\n\n");
                }
            }
        }
    }
}

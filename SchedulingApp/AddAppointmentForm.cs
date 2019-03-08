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
        public static MainForm mainForm = null;
        private int appointmentID;
        private int customerID;
        private string title;
        private string description;
        private string location;
        private string contact;
        private string url;
        private DateTime startDateTime;
        private DateTime endDateTime;
        private string currentUser = DataInterface.getCurrentUserName();
        private int selectedCustomerID;

        public AddAppointmentForm()
        {
            InitializeComponent();
            populateComboBox();
        }

        private void appointmentCancelButton_Click(object sender, EventArgs e)
        {
            DataInterface.DBClose();
            MainForm.addAppointmentForm = this;
            mainForm.Show();
            MainForm.addAppointmentForm.Close();
        }

        private void populateComboBox()
        {
            String query = "SELECT customerId, customerName FROM customer";
            DataInterface.DBOpen();
            MySqlDataAdapter adp = new MySqlDataAdapter(query, DataInterface.conn);
            DataTable dt = new DataTable("Customer");
            adp.Fill(dt);
            appointmentCustomerComboBox.DataSource = dt;
            appointmentCustomerComboBox.DisplayMember = "customerName";
            appointmentCustomerComboBox.ValueMember = "customerId";


            //MySqlCommand cmd = new MySqlCommand(query, DataInterface.conn);
            //MySqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    //appointmentCustomerComboBox.Items.Add(reader.GetString("customerName"));\
            //    //Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString());
            //    appointmentCustomerComboBox.Items.Insert((int)reader[0], reader.GetString("customerName"));
            //}
            //reader.Close();
            DataInterface.DBClose();
        }

        private void appointmentSaveButton_Click(object sender, EventArgs e)
        {
            appointmentID = DataInterface.getNextID("appointmentId", "appointment", DataInterface.getAppointmentIDList());
            customerID = selectedCustomerID;
            title = appointmentTitleTextBox.Text;
            description = appointmentDescriptionTextBox.Text;
            location = appointmentLocationTextBox.Text;
            contact = appointmentContactTextBox.Text;
            url = appointmentURLTextBox.Text;
            startDateTime = appointmentStartDate.Value.ToUniversalTime();
            endDateTime = appointmentEndDate.Value.ToUniversalTime();
            string start = startDateTime.ToString("u");
            string end = endDateTime.ToString("u");
            // Parse endDateTime
            //date = appointmentEndDate.Value.ToString("yyyy-mm-dd");
            //time = appointmentEndTime.Value.ToString("HH:MM:ss");

            DataInterface.createAppointment(customerID, title, description, location, contact, url, start, end, currentUser);
            MainForm.addAppointmentForm = this;
            mainForm.Show();
            MainForm.addAppointmentForm.Close();

        }

        private void appointmentCustomerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)appointmentCustomerComboBox.SelectedItem;
            selectedCustomerID = Convert.ToInt32(drv[0]);
        }
    }
}

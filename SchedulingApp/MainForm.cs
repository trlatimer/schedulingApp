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

namespace SchedulingApp
{
    public partial class MainForm : Form
    {
        public static LoginForm loginForm = null;
        public static CustomerMainForm customerForm = null;
        public static AddAppointmentForm addAppointmentForm = null;
        

        public MainForm()
        {
            InitializeComponent();
            displayAppointments();
        }

        private void displayAppointments()
        {
            DataInterface.DBOpen();

            String query = "SELECT appointmentId, customerId, title, contact, start, end FROM appointment";
            DataInterface.displayDGV(query, appointmentsDGV);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mainWelcomeLabel.Text = $"Welcome, {DataInterface.getCurrentUserName()}!";
        }

        private void mainExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mainLogoutButton_Click(object sender, EventArgs e)
        {
            MainForm mainform = this;
            loginForm.Show();
            this.Hide();

        }

        private void mainCustomerButton_Click(object sender, EventArgs e)
        {
            CustomerMainForm customerForm = new CustomerMainForm();
            CustomerMainForm.mainForm = this;
            this.Hide();
            customerForm.Show();
        }

        private void mainAddButton_Click(object sender, EventArgs e)
        {
            DataInterface.DBClose();
            AddAppointmentForm appointmentForm = new AddAppointmentForm();
            AddAppointmentForm.mainForm = this;
            appointmentForm.Show();
        }
    }
}

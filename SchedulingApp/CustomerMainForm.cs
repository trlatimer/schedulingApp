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
    public partial class CustomerMainForm : Form
    {
        public static MainForm mainForm = null;
        public static AddCustomerForm addCustomer = null;

        public CustomerMainForm()
        {
            InitializeComponent();

            displayCustomers();
        }

        private void displayCustomers()
        {
            DataInterface.DBOpen();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM customer", DataInterface.conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            customersDGV.DataSource = dt;
            customersDGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void customersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void customerBackButton_Click(object sender, EventArgs e)
        {
            DataInterface.DBClose();
            MainForm.customerForm = this;
            mainForm.Show();
            MainForm.customerForm.Close();
        }

        private void customerAddButton_Click(object sender, EventArgs e)
        {
            DataInterface.DBClose();
            addCustomer = new AddCustomerForm();
            AddCustomerForm.customerForm = this;
            addCustomer.Show();
        }

        private void CustomerMainForm_Activated(object sender, EventArgs e)
        {
            customersDGV.Refresh();
            displayCustomers();
        }
    }
}

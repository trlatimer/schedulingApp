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
        public static EditCustomerForm editCustomer = null;
        public static int rowIndex = -1;
        public static DataGridViewRow selectedRow;
        public static int selectedCustomerID;

        public CustomerMainForm()
        {
            InitializeComponent();

            displayCustomers();
        }

        private void displayCustomers()
        {
            DataInterface.DBOpen();

            String query = "SELECT c.customerId AS ID, c.customerName AS Name, c.active AS Active, a.address AS Address, a.address2 AS Address2, a.city AS City, a.postalCode AS 'Postal Code', a.country AS Country, a.phone AS Phone " +
                "FROM customer AS c, (SELECT address.addressId, address.address, address.address2, address.postalCode, address.phone, city.city, country.country FROM address, city, country WHERE address.cityId = city.cityId AND city.countryId = country.countryId) AS a " +
                "WHERE c.addressId = a.addressId";
            DataInterface.displayDGV(query, customersDGV);
        }

        private void customersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = customersDGV.CurrentCell.RowIndex;
            selectedRow = customersDGV.Rows[rowIndex];
            selectedCustomerID = Convert.ToInt32(selectedRow.Cells[0].Value);
            Console.WriteLine("Customer ID: " + selectedCustomerID);
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

        private void customerEditButton_Click(object sender, EventArgs e)
        {
            DataInterface.DBClose();
            editCustomer = new EditCustomerForm();
            EditCustomerForm.customerForm = this;
            editCustomer.Show();
        }

        private void customersDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = customersDGV.CurrentCell.RowIndex;
            selectedRow = customersDGV.Rows[rowIndex];
            selectedCustomerID = Convert.ToInt32(selectedRow.Cells[0].Value);
            Console.WriteLine("Customer ID: " + selectedCustomerID);
        }

        private void customerDeleteButton_Click(object sender, EventArgs e)
        {
            if (selectedCustomerID != -1)
            {
                DataInterface.deleteCustomer(selectedCustomerID);
            }
            else
            {
                MessageBox.Show("Please select a customer to delete and try again.");
            }
            customersDGV.Refresh();
            displayCustomers();
        }
    }
}

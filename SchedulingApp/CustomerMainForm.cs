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
        // Initialize variables
        // Variables for reference back to mainForm, Add form, and edit form
        public static MainForm mainForm = null;
        public static AddCustomerForm addCustomer = null;
        public static EditCustomerForm editCustomer = null;
        // Set the DGV index to -1 by default
        public static int rowIndex = -1;
        // Variable for storing the row currently selected
        public static DataGridViewRow selectedRow;
        // Variable for storing the ID returned by the row selected
        public static int selectedCustomerID;

        // Form constructor
        public CustomerMainForm()
        {
            InitializeComponent();
            // Dispaly customers in DataGridView
            displayCustomers();
        }

        // Function to obtain data and populate in DataGridView
        private void displayCustomers()
        {
            DataInterface.DBOpen();
            // Query to select desired information to display
            String query = "SELECT c.customerId AS ID, c.customerName AS Name, c.active AS Active, a.address AS Address, a.address2 AS Address2, a.city AS City, a.postalCode AS 'Postal Code', a.country AS Country, a.phone AS Phone " +
                "FROM customer AS c, (SELECT address.addressId, address.address, address.address2, address.postalCode, address.phone, city.city, country.country FROM address, city, country WHERE address.cityId = city.cityId AND city.countryId = country.countryId) AS a " +
                "WHERE c.addressId = a.addressId";
            // Pass query and desired DGV to function to obtain data and populate
            DataInterface.displayDGV(query, customersDGV);
        }

        // DataGridView Selection Event Handler
        private void customersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtain the index of the selected row
            int rowIndex = customersDGV.CurrentCell.RowIndex;
            // Obtain the information from the selected row
            selectedRow = customersDGV.Rows[rowIndex];
            // Set customerID returned by selected Row
            selectedCustomerID = Convert.ToInt32(selectedRow.Cells[0].Value);
        }

        // Back Button Click
        private void customerBackButton_Click(object sender, EventArgs e)
        {
            // Return to main form, close this form
            DataInterface.DBClose();
            MainForm.customerForm = this;
            mainForm.Show();
            MainForm.customerForm.Close();
        }

        // Add Button Click
        private void customerAddButton_Click(object sender, EventArgs e)
        {
            // open add customer form
            DataInterface.DBClose();
            addCustomer = new AddCustomerForm();
            AddCustomerForm.customerForm = this;
            addCustomer.Show();
        }

        // Form activated event handler
        private void CustomerMainForm_Activated(object sender, EventArgs e)
        {
            // refresh DGV with current data
            customersDGV.Refresh();
            displayCustomers();
        }

        // Edit Button Click
        private void customerEditButton_Click(object sender, EventArgs e)
        {
            // Open new edit customer form and set reference
            DataInterface.DBClose();
            editCustomer = new EditCustomerForm();
            EditCustomerForm.customerForm = this;
            editCustomer.Show();
        }

        // Click in DataGridView
        private void customersDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Set index to clicked row
            rowIndex = customersDGV.CurrentCell.RowIndex;
            // Obtain data from selected row and customerID
            selectedRow = customersDGV.Rows[rowIndex];
            selectedCustomerID = Convert.ToInt32(selectedRow.Cells[0].Value);
        }

        // Delect Button Click
        private void customerDeleteButton_Click(object sender, EventArgs e)
        {
            // If selected ID is valid
            if (selectedCustomerID != -1)
            {
                // Delete customer
                DataInterface.deleteCustomer(selectedCustomerID);
            }
            else
            {
                // If not valid, display message
                MessageBox.Show("Please select a customer to delete and try again.");
            }
            // Re-display data
            customersDGV.Refresh();
            displayCustomers();
        }
    }
}

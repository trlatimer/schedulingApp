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
    public partial class AddCustomerForm : SchedulingAppBaseForms.CustomerForm
    {
        // Initialize variables
        // Variable for referencing CustomerMainForm
        public static CustomerMainForm customerForm = null;
        // Variables for data obtained from form
        private int ID;
        private string name;
        private string address;
        private string address2;
        private string city;
        private string zipCode;
        private string country;
        private string phone;
        bool active;
        private string currentUser = DataInterface.getCurrentUserName();

        // Form constructor
        public AddCustomerForm()
        {
            InitializeComponent();
        }

        // Save Button click
        private void customerSaveButton_Click(object sender, EventArgs e)
        {
            // Check if inputs are valid
            if (validateInputs())
            {
                // If valid, obtain data from form controls
                ID = DataInterface.getNextID("customerId", "customer", DataInterface.getCustomerIDList());
                name = customerNameTextBox.Text;
                address = customerAddressTextBox.Text;
                address2 = customerAddress2TextBox.Text;
                city = customerCityTextBox.Text;
                zipCode = customerZipCodeTextBox.Text;
                country = customerCountryTextBox.Text;
                phone = customerPhoneTextBox.Text;
                active = customerActiveCheckBox.Checked;

                // Send data to DataInterface to create new customer
                DataInterface.createCustomer(name, address, city, country, zipCode, phone, active, currentUser, address2);
                // Set CustomerMainForm's reference to this form, show CustomerMainForm, close this form
                CustomerMainForm.addCustomer = this;
                customerForm.Show();
                CustomerMainForm.addCustomer.Close();
            }
        }

        // Check if inputs are valid
        private bool validateInputs()
        {
            // Bool to return if true/false
            bool valid = true;
            // iterate through controls
            foreach (Control control in Controls)
            {
                // Ensure control is not Address2 (not required) and if it contains data
                if (control.Name != customerAddress2TextBox.Name && String.IsNullOrWhiteSpace(control.Text))
                {
                    // If control is empty, change BackColor, display a message, and set valid to false
                    control.BackColor = Color.Salmon;
                    MessageBox.Show("All fields are required. Please try again.");
                    valid = false;
                }
            }

            // Check if ZipCode input is a number
            int result = 0;
            int.TryParse(customerZipCodeTextBox.Text, out result);
            if (result == 0)
            {
                // If not, display message, change color and set valid to false
                MessageBox.Show("Zip code must be a 5-digit number. Please try again.");
                customerZipCodeTextBox.BackColor = Color.Salmon;
                valid = false;
            }

            // Indicate if inputs are valid or not
            return valid;
        }

        // Check if text in control has changed
        public static void checkTextChanged(Control control)
        {
            // If it is now empty/null, change background color to red
            if (String.IsNullOrWhiteSpace(control.Text))
            {
                control.BackColor = Color.Salmon;
            }
            // If it now has text, change back to white
            else
            {
                control.BackColor = Color.White;
            }
        }

        // Cancel Button Click
        private void customerCancelButton_Click(object sender, EventArgs e)
        {
            // Show CustomerMainForm and close this form
            CustomerMainForm.addCustomer = this;
            customerForm.Show();
            CustomerMainForm.addCustomer.Close();
        }

        // Event handlers for text changes in required inputs
        private void customerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            checkTextChanged(customerNameTextBox);
        }

        private void customerAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            checkTextChanged(customerAddressTextBox);
        }

        private void customerAddress2TextBox_TextChanged(object sender, EventArgs e)
        {
            checkTextChanged(customerAddress2TextBox);
        }

        private void customerCityTextBox_TextChanged(object sender, EventArgs e)
        {
            checkTextChanged(customerCityTextBox);
        }

        private void customerZipCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            checkTextChanged(customerZipCodeTextBox);
        }

        private void customerCountryTextBox_TextChanged(object sender, EventArgs e)
        {
            checkTextChanged(customerCountryTextBox);
        }

        private void customerPhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            checkTextChanged(customerPhoneTextBox);
        }
    }
}

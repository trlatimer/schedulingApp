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
        public static CustomerMainForm customerForm = null;
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

        public AddCustomerForm()
        {
            InitializeComponent();
        }

        private void customerSaveButton_Click(object sender, EventArgs e)
        {
            if (validateInputs())
            {
                ID = DataInterface.getNextID("customerId", "customer", DataInterface.getCustomerIDList());
                name = customerNameTextBox.Text;
                address = customerAddressTextBox.Text;
                address2 = customerAddress2TextBox.Text;
                city = customerCityTextBox.Text;
                zipCode = customerZipCodeTextBox.Text;
                country = customerCountryTextBox.Text;
                phone = customerPhoneTextBox.Text;
                active = customerActiveCheckBox.Checked;

                DataInterface.createCustomer(name, address, city, country, zipCode, phone, active, currentUser, address2);
                CustomerMainForm.addCustomer = this;
                customerForm.Show();
                CustomerMainForm.addCustomer.Close();
            }
        }

        private bool validateInputs()
        {
            bool valid = true;
            foreach (Control control in Controls)
            {
                if (control.Name != customerAddress2TextBox.Name && String.IsNullOrWhiteSpace(control.Text))
                {
                    control.BackColor = Color.Salmon;
                    MessageBox.Show("All fields are required. Please try again.");
                    valid = false;
                }
            }

            int result = 0;
            int.TryParse(customerZipCodeTextBox.Text, out result);
            if (result == 0)
            {
                MessageBox.Show("Zip code must be a 5-digit number. Please try again.");
                customerZipCodeTextBox.BackColor = Color.Salmon;
                valid = false;
            }

            return valid;
        }

        public static void checkTextChanged(Control control)
        {
            if (String.IsNullOrWhiteSpace(control.Text))
            {
                control.BackColor = Color.Salmon;
            }
            else
            {
                control.BackColor = Color.White;
            }
        }

        private void customerCancelButton_Click(object sender, EventArgs e)
        {
            CustomerMainForm.addCustomer = this;
            customerForm.Show();
            CustomerMainForm.addCustomer.Close();
        }

        private void AddCustomerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            customerForm.Focus();
        }

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

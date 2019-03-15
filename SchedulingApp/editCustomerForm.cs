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
    public partial class EditCustomerForm : SchedulingAppBaseForms.CustomerForm
    {
        // Set reference to CustomerMainForm
        public static CustomerMainForm customerForm;
        // Dictionary for information of selected customer
        private Dictionary<string, object> selectedCustomer;

        // Form Constructor
        public EditCustomerForm()
        {
            InitializeComponent();
            // Set TextBoxes to existing customer data
            setTextBoxText();
        }

        // Ensure that inputs are valid
        private bool validateInputs()
        {
            // bool to return to indicate whether inputs are valid
            bool valid = true;
            // Iterate through controls on form
            foreach (Control control in Controls)
            {
                // if control is required and empty
                if (control.Name != customerAddress2TextBox.Name && String.IsNullOrWhiteSpace(control.Text))
                {
                    // Change background color, display message, and indicate input is not valid
                    control.BackColor = Color.Salmon;
                    MessageBox.Show("All fields are required. Please try again.");
                    valid = false;
                }
            }
            
            // Check if ZipCode can be parsed into a number
            int result = 0;
            int.TryParse(customerZipCodeTextBox.Text, out result);
            if (result == 0)
            {
                // if not, display message, set background color, and set valid to false
                MessageBox.Show("Zip code must be a 5-digit number. Please try again.");
                customerZipCodeTextBox.BackColor = Color.Salmon;
                valid = false;
            }

            // return value indicating if inputs are valid or not
            return valid;
        }


        // Populate form with existing data
        private void setTextBoxText()
        {
            // Get Dictionary containing data for specific customer selected
            selectedCustomer = DataInterface.getCustomerInfo(CustomerMainForm.selectedCustomerID);

            // Set the values of each control to the corresponding data
            customerIDTextBox.Text = selectedCustomer["ID"].ToString();
            customerNameTextBox.Text = selectedCustomer["Name"].ToString();
            customerAddressTextBox.Text = selectedCustomer["Address"].ToString();
            customerAddress2TextBox.Text = selectedCustomer["Address2"].ToString();
            customerZipCodeTextBox.Text = selectedCustomer["ZipCode"].ToString();
            customerPhoneTextBox.Text = selectedCustomer["Phone"].ToString();
            customerCityTextBox.Text = selectedCustomer["City"].ToString();
            customerCountryTextBox.Text = selectedCustomer["Country"].ToString();
            customerActiveCheckBox.Checked = (bool) selectedCustomer["Active"];
        }

        // Cancel Button click
        private void customerCancelButton_Click(object sender, EventArgs e)
        {
            // Show CustomerMainForm, close this form
            DataInterface.DBClose();
            CustomerMainForm.editCustomer = this;
            customerForm.Show();
            CustomerMainForm.editCustomer.Close();
        }

        // Save Button Click
        private void customerSaveButton_Click(object sender, EventArgs e)
        {
            // Check if inputs are valid
            if (validateInputs())
            {
                // attempt to save update customer entry
                try
                {
                    // Pass data from form to update customer query
                    DataInterface.updateCustomer(
                        Convert.ToInt32(customerIDTextBox.Text),
                        customerNameTextBox.Text,
                        customerAddressTextBox.Text,
                        customerCityTextBox.Text,
                        customerCountryTextBox.Text,
                        customerZipCodeTextBox.Text,
                        customerPhoneTextBox.Text,
                        customerActiveCheckBox.Checked,
                        customerAddress2TextBox.Text);
                    DataInterface.DBClose();
                    CustomerMainForm.editCustomer = this;
                    customerForm.Show();
                    CustomerMainForm.editCustomer.Close();
                }
                // Display message and cancel save if an exception rises
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                
            }
            
        }

        // Text Changed for required fields
        // Check if empty or contains text
        private void customerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            AddCustomerForm.checkTextChanged(customerNameTextBox);
        }

        private void customerAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            AddCustomerForm.checkTextChanged(customerAddressTextBox);
        }

        private void customerAddress2TextBox_TextChanged(object sender, EventArgs e)
        {
            AddCustomerForm.checkTextChanged(customerAddress2TextBox);
        }

        private void customerCityTextBox_TextChanged(object sender, EventArgs e)
        {
            AddCustomerForm.checkTextChanged(customerCityTextBox);
        }

        private void customerZipCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            AddCustomerForm.checkTextChanged(customerZipCodeTextBox);
        }

        private void customerCountryTextBox_TextChanged(object sender, EventArgs e)
        {
            AddCustomerForm.checkTextChanged(customerCountryTextBox);
        }

        private void customerPhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            AddCustomerForm.checkTextChanged(customerPhoneTextBox);
        }
    }
}

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
        public static CustomerMainForm customerForm;
        private Dictionary<string, object> selectedCustomer;

        public EditCustomerForm()
        {
            InitializeComponent();
            setTextBoxText();
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

        private void setTextBoxText()
        {
            selectedCustomer = DataInterface.getCustomerInfo(CustomerMainForm.selectedCustomerID);

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

        private void customerCancelButton_Click(object sender, EventArgs e)
        {
            DataInterface.DBClose();
            CustomerMainForm.editCustomer = this;
            customerForm.Show();
            CustomerMainForm.editCustomer.Close();
        }

        private void customerSaveButton_Click(object sender, EventArgs e)
        {
            if (validateInputs())
            {
                try
                {
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                
            }
            
        }

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

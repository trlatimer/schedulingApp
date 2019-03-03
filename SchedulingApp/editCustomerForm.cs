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
        private Dictionary<string, string> selectedCustomer;

        public EditCustomerForm()
        {
            InitializeComponent();
            setTextBoxText();
        }

        private void setTextBoxText()
        {
            
            selectedCustomer = DataInterface.getCustomerInfo(CustomerMainForm.selectedCustomerID);

            customerIDTextBox.Text = selectedCustomer["ID"];
            customerNameTextBox.Text = selectedCustomer["Name"];
            customerAddressTextBox.Text = selectedCustomer["Address"];
            customerAddress2TextBox.Text = selectedCustomer["Address2"];
            customerZipCodeTextBox.Text = selectedCustomer["ZipCode"];
            customerPhoneTextBox.Text = selectedCustomer["Phone"];
            customerCityTextBox.Text = selectedCustomer["City"];
            customerCountryTextBox.Text = selectedCustomer["Country"];
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
            // TODO Add input validation

            DataInterface.updateCustomer(
                Convert.ToInt32(customerIDTextBox.Text),
                customerNameTextBox.Text,
                customerAddressTextBox.Text,
                customerCityTextBox.Text,
                customerCountryTextBox.Text,
                customerZipCodeTextBox.Text,
                customerPhoneTextBox.Text,
                1,
                customerAddress2TextBox.Text);
            DataInterface.DBClose();
            CustomerMainForm.editCustomer = this;
            customerForm.Show();
            CustomerMainForm.editCustomer.Close();
        }
    }
}

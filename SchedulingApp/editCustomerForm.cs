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
        public static CustomerMainForm customerForm = null;
        private int selectedCustomerID;
        private string selectedCustomerName;
        private string selectedCustomerAddress;
        private string selectedCustomerAddress2;
        private string selectedCustomerCity;
        private string selectedCustomerZip;
        private string selectedCustomerCountry;
        private string selectedCustomerPhone;
        private Dictionary<string, string> selectedCustomer;

        public EditCustomerForm()
        {
            InitializeComponent();


        }

        private void setTextBoxText()
        {
            selectedCustomerID = Convert.ToInt32(customerForm.selectedRow.Cells[0].Value);
            selectedCustomer = DataInterface.getCustomerInfo(selectedCustomerID);

            selectedCustomer.TryGetValue("Name", out selectedCustomerName);
            selectedCustomer.TryGetValue("Address", out selectedCustomerAddress);
            selectedCustomer.TryGetValue("Address2", out selectedCustomerAddress2);
            selectedCustomer.TryGetValue("ZipCode", out selectedCustomerZip);
            selectedCustomer.TryGetValue("Phone", out selectedCustomerPhone);
            selectedCustomer.TryGetValue("City", out selectedCustomerCity);
            selectedCustomer.TryGetValue("Country", out selectedCustomerCountry);
        }
    }
}

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
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void displayCustomers()
        {
            foreach(int customerID in DataInterface.getCustomerIDList())
            {
                DataInterface.getCustomerInfo(customerID);
            }
        }

        private void customersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

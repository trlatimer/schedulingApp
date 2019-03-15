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
    public partial class NewUserForm : Form
    {
        // Reference to login form
        public static LoginForm loginForm = null;
        // Variables for data in form
        private static string username;
        private static string password;
        private static string passwordConfirm;
        private static string creator;

        // Form Constructor
        public NewUserForm()
        {
            InitializeComponent();
        }

        // Form Close
        private void NewUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Display login form
            loginForm.Show();
        }

        // Cancel Button Click
        private void createUserCancelButton_Click(object sender, EventArgs e)
        {
            // Close this form, return to login form
            this.Close();
            loginForm.Show();
        }

        // Create Button Click
        private void createUserCreateButton_Click(object sender, EventArgs e)
        {
            // Obtain data from textboxes
            username = createUserUserNameTextBox.Text;
            password = createUserPasswordTextBox.Text;
            passwordConfirm = createUserConfirmTextBox.Text;
            creator = createUserCreatorTextBox.Text;

            // Iterate over controls
            foreach (Control control in Controls)
            {
                // Check if control is empty
                if (String.IsNullOrWhiteSpace(control.Text))
                {
                    // If empty, change background color, display message, and cancel save
                    control.BackColor = Color.Salmon;
                    MessageBox.Show("All fields are required. Please try again.");
                    return;
                }
            }

            // If passwords don't match, show message and cancel save
            if (password != passwordConfirm)
            {
                MessageBox.Show("The password do not match. Please try again.");
                return;
            }
            
            // Pass data from form to create a new user
            DataInterface.createUser(username, password, 1, creator);
            // Display message confirming user was created
            MessageBox.Show("Successfully created user. Please log in to continue.");
            this.Close();
            loginForm.Show();
        }

        // Text Changed Events - Check if emtpy or now contain values, change background color accordingly
        private void createUserUserNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(createUserUserNameTextBox.Text))
            {
                createUserUserNameTextBox.BackColor = Color.Salmon;
            }
            else
            {
                createUserUserNameTextBox.BackColor = Color.White;
            }
        }

        private void createUserPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(createUserPasswordTextBox.Text))
            {
                createUserPasswordTextBox.BackColor = Color.Salmon;
            }
            else
            {
                createUserPasswordTextBox.BackColor = Color.White;
            }
        }

        private void createUserConfirmTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(createUserConfirmTextBox.Text))
            {
                createUserConfirmTextBox.BackColor = Color.Salmon;
            }
            else
            {
                createUserConfirmTextBox.BackColor = Color.White;
            }
        }

        private void createUserCreatorTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(createUserCreatorTextBox.Text))
            {
                createUserCreatorTextBox.BackColor = Color.Salmon;
            }
            else
            {
                createUserCreatorTextBox.BackColor = Color.White;
            }
        }
    }
}

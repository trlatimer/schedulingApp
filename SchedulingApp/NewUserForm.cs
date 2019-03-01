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
        public static LoginForm loginForm = null;
        private static string username;
        private static string password;
        private static string passwordConfirm;
        private static string creator;

        public NewUserForm()
        {
            InitializeComponent();
        }

        private void NewUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginForm.Show();
        }

        private void createUserCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            loginForm.Show();
        }

        private void createUserCreateButton_Click(object sender, EventArgs e)
        {
            // Obtain data from textboxes
            username = createUserUserNameTextBox.Text;
            password = createUserPasswordTextBox.Text;
            passwordConfirm = createUserConfirmTextBox.Text;
            creator = createUserCreatorTextBox.Text;

            foreach (Control control in Controls)
            {
                if (String.IsNullOrWhiteSpace(control.Text))
                {
                    control.BackColor = Color.Salmon;
                    MessageBox.Show("All fields are required. Please try again.");
                    return;
                }
            }

            if (password != passwordConfirm)
            {
                MessageBox.Show("The password do not match. Please try again.");
                return;
            }

            DataInterface.createUser(username, password, 1, creator);
            MessageBox.Show("Successfully created user. Please log in to continue.");
            this.Close();
            loginForm.Show();
        }

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

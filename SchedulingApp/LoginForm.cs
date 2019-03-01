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
using System.Globalization;
using System.IO;

namespace SchedulingApp
{
    public partial class LoginForm : Form
    {
        // Instance variables
        private static string currentCulture;
        private static string errorMessage = "Username and/or password not found.";

        public LoginForm()
        {
            InitializeComponent();
            // Obtain user culture and translate appropriately
            determineLanguage();
            // Generate data into database --USE ONLY IF DATABASE HAS BEEN RESET--
            DataInterface.generatePsuedoData();
            
        }

        // Determine language for program
        private void determineLanguage()
        {
            // Obtain language used by user
            currentCulture = CultureInfo.CurrentUICulture.Name;

            // If french, translate appropriately
            if (currentCulture == "fr-FR")
            {
                this.Text = "Calendrier App | S'identifier";
                loginTitleLabel.Text = "Calendrier App";
                loginSubTitleLabel.Text = "Veuillez vous connecter";
                loginSubTitleLabel.Location = new Point(65, 66);
                loginUsernameLabel.Text = "Nom d'utilisateur:";
                loginPasswordLabel.Text = "Mot de passe";
                loginLoginButton.Text = "S'identifier";
                loginCreateUserButton.Text = "Créer un nouvel utilisateur";
                loginExitButton.Text = "Sortie";
                errorMessage = "Nom d'utilisateur et / ou mot de passe non trouvé.";
            }
            else
            {
                return;
            }
        }

        // Generate Log of Logins
        private void recordLogin(string username)
        { 
            string path = "C:/SchedulingApp/Logs";
            string fileName = "log.txt";
            string fullPath = path + fileName;
            string logEntry = $"{username} logged in at {DataInterface.getCurrentDateTime()}" + Environment.NewLine;
            DirectoryInfo dir = new DirectoryInfo(path);
            try
            {
                if (!dir.Exists)
                {
                    dir.Create();
                }
                File.AppendAllText(fullPath, logEntry);
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occurred when generating log. " + $"\n\n{e.Message}" + $"\n\n{e.StackTrace}");
            }
            
            
        }

        private void loginLoginButton_Click(object sender, EventArgs e)
        {
            // Obtain login information
            string userName = loginUsernameTextBox.Text;
            string password = loginPasswordTextBox.Text;
            int userID;

            // Check if username or password are empty
            if (String.IsNullOrWhiteSpace(loginUsernameTextBox.Text) || String.IsNullOrWhiteSpace(loginPasswordTextBox.Text))
            {
                // Display appropriate message based on language
                if (currentCulture == "fr-FR")
                {
                    MessageBox.Show("Le nom d'utilisateur et le mot de passe ne peuvent pas être vides");
                }
                else
                {
                    MessageBox.Show("Username and password cannot be empty");
                }
                return;
            }

            // Open database connection
            DataInterface.DBOpen();

            // Build Query
            MySqlCommand cmd = new MySqlCommand($"SELECT userId FROM user WHERE userName = '{userName}' AND password = '{password}'", DataInterface.conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            // If matching data is present, set current user information and open MainForm
            if (reader.HasRows)
            {
                // Read rows returned
                reader.Read();
                // Set userID based on row returned
                userID = Convert.ToInt32(reader[0]);
                // set current user information
                DataInterface.setCurrentUserID(userID);
                DataInterface.setCurrentUserName(userName);

                // close database connection
                reader.Close();
                DataInterface.DBClose();

                // Hide Login form and open MainForm
                MainForm mainForm = new MainForm();
                MainForm.loginForm = this;
                this.Hide();
                mainForm.Show();
                loginUsernameTextBox.Text = "";
                loginPasswordTextBox.Text = "";
                recordLogin(DataInterface.getCurrentUserName());
            }
            // Username/Password do not match information in database
            else
            {
                // Dipslay language appropriate error message
                MessageBox.Show(errorMessage);
                loginPasswordTextBox.Text = "";
            }
        }

        private void loginCreateUserButton_Click(object sender, EventArgs e)
        {
            NewUserForm newUser = new NewUserForm();
            NewUserForm.loginForm = this;
            this.Hide();
            newUser.Show();
        }

        private void loginExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginUsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(loginUsernameTextBox.Text))
            {
                loginUsernameTextBox.BackColor = Color.Salmon;
            }
            else
            {
                loginUsernameTextBox.BackColor = Color.White;
            }
        }

        private void loginPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(loginPasswordTextBox.Text))
            {
                loginUsernameTextBox.BackColor = Color.Salmon;
            }
            else
            {
                loginUsernameTextBox.BackColor = Color.White;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class MainForm : Form
    {
        public static LoginForm loginForm = null;
        

        public MainForm()
        {
            InitializeComponent();

           // DataInterface.DBOpen();
           // MySqlCommand cmd = new MySqlCommand("SELECT * FROM user", DataInterface.conn);
           // MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
           // DataTable dt = new DataTable();
           // adp.Fill(dt);
           // dataGridView1.DataSource = dt;
           // dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void displayAppointments()
        {
            // TODO ADD APPOINTMENT FUNCTIONALITY
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mainWelcomeLabel.Text = $"Welcome, {DataInterface.getCurrentUserName()}!";
        }

        private void mainExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mainLogoutButton_Click(object sender, EventArgs e)
        {
            MainForm mainform = this;
            loginForm.Show();
            this.Hide();

        }
    }
}

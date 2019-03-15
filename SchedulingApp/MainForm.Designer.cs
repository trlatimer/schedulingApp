namespace SchedulingApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainWelcomeLabel = new System.Windows.Forms.Label();
            this.appointmentCalendar = new System.Windows.Forms.MonthCalendar();
            this.appointmentsDGV = new System.Windows.Forms.DataGridView();
            this.dgvViewMonthRadioButton = new System.Windows.Forms.RadioButton();
            this.dgvViewWeekRadioButton = new System.Windows.Forms.RadioButton();
            this.dgvViewDayRadioButton = new System.Windows.Forms.RadioButton();
            this.dgvViewGroupBox = new System.Windows.Forms.GroupBox();
            this.mainExitButton = new System.Windows.Forms.Button();
            this.mainAddButton = new System.Windows.Forms.Button();
            this.mainEditButton = new System.Windows.Forms.Button();
            this.mainDeleteButton = new System.Windows.Forms.Button();
            this.mainLogoutButton = new System.Windows.Forms.Button();
            this.mainCustomerButton = new System.Windows.Forms.Button();
            this.appointmentsGroupBox = new System.Windows.Forms.GroupBox();
            this.monthReportButton = new System.Windows.Forms.Button();
            this.consultantReportButton = new System.Windows.Forms.Button();
            this.customerReportButton = new System.Windows.Forms.Button();
            this.reportsGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsDGV)).BeginInit();
            this.dgvViewGroupBox.SuspendLayout();
            this.appointmentsGroupBox.SuspendLayout();
            this.reportsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainWelcomeLabel
            // 
            this.mainWelcomeLabel.AutoSize = true;
            this.mainWelcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainWelcomeLabel.Location = new System.Drawing.Point(12, 9);
            this.mainWelcomeLabel.Name = "mainWelcomeLabel";
            this.mainWelcomeLabel.Size = new System.Drawing.Size(96, 24);
            this.mainWelcomeLabel.TabIndex = 0;
            this.mainWelcomeLabel.Text = "Welcome!";
            // 
            // appointmentCalendar
            // 
            this.appointmentCalendar.FirstDayOfWeek = System.Windows.Forms.Day.Sunday;
            this.appointmentCalendar.Location = new System.Drawing.Point(18, 53);
            this.appointmentCalendar.MaxSelectionCount = 1;
            this.appointmentCalendar.Name = "appointmentCalendar";
            this.appointmentCalendar.TabIndex = 1;
            this.appointmentCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.appointmentCalendar_DateChanged);
            // 
            // appointmentsDGV
            // 
            this.appointmentsDGV.AllowUserToAddRows = false;
            this.appointmentsDGV.AllowUserToDeleteRows = false;
            this.appointmentsDGV.AllowUserToOrderColumns = true;
            this.appointmentsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.appointmentsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentsDGV.Location = new System.Drawing.Point(268, 82);
            this.appointmentsDGV.Name = "appointmentsDGV";
            this.appointmentsDGV.ReadOnly = true;
            this.appointmentsDGV.RowHeadersVisible = false;
            this.appointmentsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentsDGV.Size = new System.Drawing.Size(460, 244);
            this.appointmentsDGV.TabIndex = 2;
            this.appointmentsDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.appointmentsDGV_CellClick);
            // 
            // dgvViewMonthRadioButton
            // 
            this.dgvViewMonthRadioButton.AutoSize = true;
            this.dgvViewMonthRadioButton.Location = new System.Drawing.Point(40, 19);
            this.dgvViewMonthRadioButton.Name = "dgvViewMonthRadioButton";
            this.dgvViewMonthRadioButton.Size = new System.Drawing.Size(55, 17);
            this.dgvViewMonthRadioButton.TabIndex = 3;
            this.dgvViewMonthRadioButton.Text = "Month";
            this.dgvViewMonthRadioButton.UseVisualStyleBackColor = true;
            this.dgvViewMonthRadioButton.CheckedChanged += new System.EventHandler(this.dgvViewMonthRadioButton_CheckedChanged);
            // 
            // dgvViewWeekRadioButton
            // 
            this.dgvViewWeekRadioButton.AutoSize = true;
            this.dgvViewWeekRadioButton.Location = new System.Drawing.Point(115, 19);
            this.dgvViewWeekRadioButton.Name = "dgvViewWeekRadioButton";
            this.dgvViewWeekRadioButton.Size = new System.Drawing.Size(54, 17);
            this.dgvViewWeekRadioButton.TabIndex = 4;
            this.dgvViewWeekRadioButton.Text = "Week";
            this.dgvViewWeekRadioButton.UseVisualStyleBackColor = true;
            this.dgvViewWeekRadioButton.CheckedChanged += new System.EventHandler(this.dgvViewWeekRadioButton_CheckedChanged);
            // 
            // dgvViewDayRadioButton
            // 
            this.dgvViewDayRadioButton.AutoSize = true;
            this.dgvViewDayRadioButton.Checked = true;
            this.dgvViewDayRadioButton.Location = new System.Drawing.Point(186, 19);
            this.dgvViewDayRadioButton.Name = "dgvViewDayRadioButton";
            this.dgvViewDayRadioButton.Size = new System.Drawing.Size(44, 17);
            this.dgvViewDayRadioButton.TabIndex = 5;
            this.dgvViewDayRadioButton.TabStop = true;
            this.dgvViewDayRadioButton.Text = "Day";
            this.dgvViewDayRadioButton.UseVisualStyleBackColor = true;
            this.dgvViewDayRadioButton.CheckedChanged += new System.EventHandler(this.dgvViewDayRadioButton_CheckedChanged);
            // 
            // dgvViewGroupBox
            // 
            this.dgvViewGroupBox.Controls.Add(this.dgvViewDayRadioButton);
            this.dgvViewGroupBox.Controls.Add(this.dgvViewWeekRadioButton);
            this.dgvViewGroupBox.Controls.Add(this.dgvViewMonthRadioButton);
            this.dgvViewGroupBox.Location = new System.Drawing.Point(379, 34);
            this.dgvViewGroupBox.Name = "dgvViewGroupBox";
            this.dgvViewGroupBox.Size = new System.Drawing.Size(257, 42);
            this.dgvViewGroupBox.TabIndex = 6;
            this.dgvViewGroupBox.TabStop = false;
            this.dgvViewGroupBox.Text = "View";
            // 
            // mainExitButton
            // 
            this.mainExitButton.Location = new System.Drawing.Point(653, 343);
            this.mainExitButton.Name = "mainExitButton";
            this.mainExitButton.Size = new System.Drawing.Size(75, 23);
            this.mainExitButton.TabIndex = 10;
            this.mainExitButton.Text = "Exit";
            this.mainExitButton.UseVisualStyleBackColor = true;
            this.mainExitButton.Click += new System.EventHandler(this.mainExitButton_Click);
            // 
            // mainAddButton
            // 
            this.mainAddButton.Location = new System.Drawing.Point(6, 20);
            this.mainAddButton.Name = "mainAddButton";
            this.mainAddButton.Size = new System.Drawing.Size(75, 23);
            this.mainAddButton.TabIndex = 11;
            this.mainAddButton.Text = "Add";
            this.mainAddButton.UseVisualStyleBackColor = true;
            this.mainAddButton.Click += new System.EventHandler(this.mainAddButton_Click);
            // 
            // mainEditButton
            // 
            this.mainEditButton.Location = new System.Drawing.Point(6, 49);
            this.mainEditButton.Name = "mainEditButton";
            this.mainEditButton.Size = new System.Drawing.Size(75, 23);
            this.mainEditButton.TabIndex = 12;
            this.mainEditButton.Text = "Edit";
            this.mainEditButton.UseVisualStyleBackColor = true;
            this.mainEditButton.Click += new System.EventHandler(this.mainEditButton_Click);
            // 
            // mainDeleteButton
            // 
            this.mainDeleteButton.Location = new System.Drawing.Point(6, 78);
            this.mainDeleteButton.Name = "mainDeleteButton";
            this.mainDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.mainDeleteButton.TabIndex = 13;
            this.mainDeleteButton.Text = "Delete";
            this.mainDeleteButton.UseVisualStyleBackColor = true;
            this.mainDeleteButton.Click += new System.EventHandler(this.mainDeleteButton_Click);
            // 
            // mainLogoutButton
            // 
            this.mainLogoutButton.Location = new System.Drawing.Point(561, 343);
            this.mainLogoutButton.Name = "mainLogoutButton";
            this.mainLogoutButton.Size = new System.Drawing.Size(75, 23);
            this.mainLogoutButton.TabIndex = 14;
            this.mainLogoutButton.Text = "Logout";
            this.mainLogoutButton.UseVisualStyleBackColor = true;
            this.mainLogoutButton.Click += new System.EventHandler(this.mainLogoutButton_Click);
            // 
            // mainCustomerButton
            // 
            this.mainCustomerButton.Location = new System.Drawing.Point(295, 343);
            this.mainCustomerButton.Name = "mainCustomerButton";
            this.mainCustomerButton.Size = new System.Drawing.Size(99, 23);
            this.mainCustomerButton.TabIndex = 15;
            this.mainCustomerButton.Text = "View Customers";
            this.mainCustomerButton.UseVisualStyleBackColor = true;
            this.mainCustomerButton.Click += new System.EventHandler(this.mainCustomerButton_Click);
            // 
            // appointmentsGroupBox
            // 
            this.appointmentsGroupBox.Controls.Add(this.mainDeleteButton);
            this.appointmentsGroupBox.Controls.Add(this.mainEditButton);
            this.appointmentsGroupBox.Controls.Add(this.mainAddButton);
            this.appointmentsGroupBox.Location = new System.Drawing.Point(142, 227);
            this.appointmentsGroupBox.Name = "appointmentsGroupBox";
            this.appointmentsGroupBox.Size = new System.Drawing.Size(90, 108);
            this.appointmentsGroupBox.TabIndex = 16;
            this.appointmentsGroupBox.TabStop = false;
            this.appointmentsGroupBox.Text = "Appointments";
            // 
            // monthReportButton
            // 
            this.monthReportButton.Location = new System.Drawing.Point(7, 20);
            this.monthReportButton.Name = "monthReportButton";
            this.monthReportButton.Size = new System.Drawing.Size(81, 23);
            this.monthReportButton.TabIndex = 17;
            this.monthReportButton.Text = "By Month";
            this.monthReportButton.UseVisualStyleBackColor = true;
            this.monthReportButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // consultantReportButton
            // 
            this.consultantReportButton.Location = new System.Drawing.Point(7, 49);
            this.consultantReportButton.Name = "consultantReportButton";
            this.consultantReportButton.Size = new System.Drawing.Size(81, 23);
            this.consultantReportButton.TabIndex = 18;
            this.consultantReportButton.Text = "By Consultant";
            this.consultantReportButton.UseVisualStyleBackColor = true;
            this.consultantReportButton.Click += new System.EventHandler(this.consultantReportButton_Click);
            // 
            // customerReportButton
            // 
            this.customerReportButton.Location = new System.Drawing.Point(7, 78);
            this.customerReportButton.Name = "customerReportButton";
            this.customerReportButton.Size = new System.Drawing.Size(81, 23);
            this.customerReportButton.TabIndex = 19;
            this.customerReportButton.Text = "By Customer";
            this.customerReportButton.UseVisualStyleBackColor = true;
            this.customerReportButton.Click += new System.EventHandler(this.customerReportButton_Click);
            // 
            // reportsGroupBox
            // 
            this.reportsGroupBox.Controls.Add(this.customerReportButton);
            this.reportsGroupBox.Controls.Add(this.consultantReportButton);
            this.reportsGroupBox.Controls.Add(this.monthReportButton);
            this.reportsGroupBox.Location = new System.Drawing.Point(28, 227);
            this.reportsGroupBox.Name = "reportsGroupBox";
            this.reportsGroupBox.Size = new System.Drawing.Size(98, 108);
            this.reportsGroupBox.TabIndex = 20;
            this.reportsGroupBox.TabStop = false;
            this.reportsGroupBox.Text = "Reports";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(743, 378);
            this.Controls.Add(this.reportsGroupBox);
            this.Controls.Add(this.appointmentsGroupBox);
            this.Controls.Add(this.mainCustomerButton);
            this.Controls.Add(this.mainLogoutButton);
            this.Controls.Add(this.mainExitButton);
            this.Controls.Add(this.dgvViewGroupBox);
            this.Controls.Add(this.appointmentsDGV);
            this.Controls.Add(this.appointmentCalendar);
            this.Controls.Add(this.mainWelcomeLabel);
            this.Name = "MainForm";
            this.Text = "Schedule App | Home";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsDGV)).EndInit();
            this.dgvViewGroupBox.ResumeLayout(false);
            this.dgvViewGroupBox.PerformLayout();
            this.appointmentsGroupBox.ResumeLayout(false);
            this.reportsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainWelcomeLabel;
        private System.Windows.Forms.MonthCalendar appointmentCalendar;
        private System.Windows.Forms.RadioButton dgvViewMonthRadioButton;
        private System.Windows.Forms.RadioButton dgvViewWeekRadioButton;
        private System.Windows.Forms.RadioButton dgvViewDayRadioButton;
        private System.Windows.Forms.GroupBox dgvViewGroupBox;
        private System.Windows.Forms.Button mainExitButton;
        private System.Windows.Forms.Button mainAddButton;
        private System.Windows.Forms.Button mainEditButton;
        private System.Windows.Forms.Button mainDeleteButton;
        private System.Windows.Forms.Button mainLogoutButton;
        private System.Windows.Forms.Button mainCustomerButton;
        protected System.Windows.Forms.DataGridView appointmentsDGV;
        private System.Windows.Forms.GroupBox appointmentsGroupBox;
        private System.Windows.Forms.Button monthReportButton;
        private System.Windows.Forms.Button consultantReportButton;
        private System.Windows.Forms.Button customerReportButton;
        private System.Windows.Forms.GroupBox reportsGroupBox;
    }
}
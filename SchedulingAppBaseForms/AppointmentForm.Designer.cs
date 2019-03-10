namespace SchedulingAppBaseForms
{
    partial class AppointmentForm
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
            this.appointmentIDLabel = new System.Windows.Forms.Label();
            this.appointmentCustomerLabel = new System.Windows.Forms.Label();
            this.appointmentTitleLabel = new System.Windows.Forms.Label();
            this.appointmentDescriptionLabel = new System.Windows.Forms.Label();
            this.appointmentLocationLabel = new System.Windows.Forms.Label();
            this.appointmentURLLabel = new System.Windows.Forms.Label();
            this.appointmentStartDate = new System.Windows.Forms.DateTimePicker();
            this.appointmentStartLabel = new System.Windows.Forms.Label();
            this.appointmentEndLabel = new System.Windows.Forms.Label();
            this.appointmentEndDate = new System.Windows.Forms.DateTimePicker();
            this.appointmentIDTextBox = new System.Windows.Forms.TextBox();
            this.appointmentTitleTextBox = new System.Windows.Forms.TextBox();
            this.appointmentDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.appointmentLocationTextBox = new System.Windows.Forms.TextBox();
            this.appointmentURLTextBox = new System.Windows.Forms.TextBox();
            this.appointmentCustomerComboBox = new System.Windows.Forms.ComboBox();
            this.appointmentCancelButton = new System.Windows.Forms.Button();
            this.appointmentSaveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.appointmentContactTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // appointmentIDLabel
            // 
            this.appointmentIDLabel.AutoSize = true;
            this.appointmentIDLabel.Location = new System.Drawing.Point(35, 64);
            this.appointmentIDLabel.Name = "appointmentIDLabel";
            this.appointmentIDLabel.Size = new System.Drawing.Size(102, 16);
            this.appointmentIDLabel.TabIndex = 0;
            this.appointmentIDLabel.Text = "Appointment ID:";
            // 
            // appointmentCustomerLabel
            // 
            this.appointmentCustomerLabel.AutoSize = true;
            this.appointmentCustomerLabel.Location = new System.Drawing.Point(69, 93);
            this.appointmentCustomerLabel.Name = "appointmentCustomerLabel";
            this.appointmentCustomerLabel.Size = new System.Drawing.Size(68, 16);
            this.appointmentCustomerLabel.TabIndex = 1;
            this.appointmentCustomerLabel.Text = "Customer:";
            // 
            // appointmentTitleLabel
            // 
            this.appointmentTitleLabel.AutoSize = true;
            this.appointmentTitleLabel.Location = new System.Drawing.Point(100, 122);
            this.appointmentTitleLabel.Name = "appointmentTitleLabel";
            this.appointmentTitleLabel.Size = new System.Drawing.Size(37, 16);
            this.appointmentTitleLabel.TabIndex = 2;
            this.appointmentTitleLabel.Text = "Title:";
            // 
            // appointmentDescriptionLabel
            // 
            this.appointmentDescriptionLabel.AutoSize = true;
            this.appointmentDescriptionLabel.Location = new System.Drawing.Point(58, 287);
            this.appointmentDescriptionLabel.Name = "appointmentDescriptionLabel";
            this.appointmentDescriptionLabel.Size = new System.Drawing.Size(79, 16);
            this.appointmentDescriptionLabel.TabIndex = 3;
            this.appointmentDescriptionLabel.Text = "Description:";
            // 
            // appointmentLocationLabel
            // 
            this.appointmentLocationLabel.AutoSize = true;
            this.appointmentLocationLabel.Location = new System.Drawing.Point(75, 148);
            this.appointmentLocationLabel.Name = "appointmentLocationLabel";
            this.appointmentLocationLabel.Size = new System.Drawing.Size(62, 16);
            this.appointmentLocationLabel.TabIndex = 4;
            this.appointmentLocationLabel.Text = "Location:";
            // 
            // appointmentURLLabel
            // 
            this.appointmentURLLabel.AutoSize = true;
            this.appointmentURLLabel.Location = new System.Drawing.Point(99, 204);
            this.appointmentURLLabel.Name = "appointmentURLLabel";
            this.appointmentURLLabel.Size = new System.Drawing.Size(38, 16);
            this.appointmentURLLabel.TabIndex = 5;
            this.appointmentURLLabel.Text = "URL:";
            // 
            // appointmentStartDate
            // 
            this.appointmentStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.appointmentStartDate.Location = new System.Drawing.Point(187, 228);
            this.appointmentStartDate.Name = "appointmentStartDate";
            this.appointmentStartDate.Size = new System.Drawing.Size(175, 22);
            this.appointmentStartDate.TabIndex = 4;
            // 
            // appointmentStartLabel
            // 
            this.appointmentStartLabel.AutoSize = true;
            this.appointmentStartLabel.Location = new System.Drawing.Point(99, 233);
            this.appointmentStartLabel.Name = "appointmentStartLabel";
            this.appointmentStartLabel.Size = new System.Drawing.Size(38, 16);
            this.appointmentStartLabel.TabIndex = 7;
            this.appointmentStartLabel.Text = "Start:";
            // 
            // appointmentEndLabel
            // 
            this.appointmentEndLabel.AutoSize = true;
            this.appointmentEndLabel.Location = new System.Drawing.Point(102, 260);
            this.appointmentEndLabel.Name = "appointmentEndLabel";
            this.appointmentEndLabel.Size = new System.Drawing.Size(35, 16);
            this.appointmentEndLabel.TabIndex = 8;
            this.appointmentEndLabel.Text = "End:";
            // 
            // appointmentEndDate
            // 
            this.appointmentEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.appointmentEndDate.Location = new System.Drawing.Point(187, 255);
            this.appointmentEndDate.Name = "appointmentEndDate";
            this.appointmentEndDate.Size = new System.Drawing.Size(175, 22);
            this.appointmentEndDate.TabIndex = 5;
            // 
            // appointmentIDTextBox
            // 
            this.appointmentIDTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.appointmentIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentIDTextBox.Location = new System.Drawing.Point(187, 61);
            this.appointmentIDTextBox.Name = "appointmentIDTextBox";
            this.appointmentIDTextBox.Size = new System.Drawing.Size(142, 22);
            this.appointmentIDTextBox.TabIndex = 10;
            this.appointmentIDTextBox.Text = "-- Auto-Implemented--";
            this.appointmentIDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // appointmentTitleTextBox
            // 
            this.appointmentTitleTextBox.Location = new System.Drawing.Point(187, 119);
            this.appointmentTitleTextBox.Name = "appointmentTitleTextBox";
            this.appointmentTitleTextBox.Size = new System.Drawing.Size(142, 22);
            this.appointmentTitleTextBox.TabIndex = 1;
            // 
            // appointmentDescriptionTextBox
            // 
            this.appointmentDescriptionTextBox.Location = new System.Drawing.Point(48, 306);
            this.appointmentDescriptionTextBox.Multiline = true;
            this.appointmentDescriptionTextBox.Name = "appointmentDescriptionTextBox";
            this.appointmentDescriptionTextBox.Size = new System.Drawing.Size(354, 104);
            this.appointmentDescriptionTextBox.TabIndex = 6;
            // 
            // appointmentLocationTextBox
            // 
            this.appointmentLocationTextBox.Location = new System.Drawing.Point(187, 145);
            this.appointmentLocationTextBox.Name = "appointmentLocationTextBox";
            this.appointmentLocationTextBox.Size = new System.Drawing.Size(142, 22);
            this.appointmentLocationTextBox.TabIndex = 2;
            // 
            // appointmentURLTextBox
            // 
            this.appointmentURLTextBox.Location = new System.Drawing.Point(187, 201);
            this.appointmentURLTextBox.Name = "appointmentURLTextBox";
            this.appointmentURLTextBox.Size = new System.Drawing.Size(175, 22);
            this.appointmentURLTextBox.TabIndex = 3;
            // 
            // appointmentCustomerComboBox
            // 
            this.appointmentCustomerComboBox.FormattingEnabled = true;
            this.appointmentCustomerComboBox.Location = new System.Drawing.Point(187, 90);
            this.appointmentCustomerComboBox.Name = "appointmentCustomerComboBox";
            this.appointmentCustomerComboBox.Size = new System.Drawing.Size(142, 24);
            this.appointmentCustomerComboBox.TabIndex = 0;
            // 
            // appointmentCancelButton
            // 
            this.appointmentCancelButton.Location = new System.Drawing.Point(72, 431);
            this.appointmentCancelButton.Name = "appointmentCancelButton";
            this.appointmentCancelButton.Size = new System.Drawing.Size(75, 23);
            this.appointmentCancelButton.TabIndex = 7;
            this.appointmentCancelButton.Text = "Cancel";
            this.appointmentCancelButton.UseVisualStyleBackColor = true;
            // 
            // appointmentSaveButton
            // 
            this.appointmentSaveButton.Location = new System.Drawing.Point(304, 431);
            this.appointmentSaveButton.Name = "appointmentSaveButton";
            this.appointmentSaveButton.Size = new System.Drawing.Size(75, 23);
            this.appointmentSaveButton.TabIndex = 8;
            this.appointmentSaveButton.Text = "Save";
            this.appointmentSaveButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Contact:";
            // 
            // appointmentContactTextBox
            // 
            this.appointmentContactTextBox.Location = new System.Drawing.Point(187, 174);
            this.appointmentContactTextBox.Name = "appointmentContactTextBox";
            this.appointmentContactTextBox.Size = new System.Drawing.Size(142, 22);
            this.appointmentContactTextBox.TabIndex = 14;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(431, 475);
            this.Controls.Add(this.appointmentContactTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.appointmentSaveButton);
            this.Controls.Add(this.appointmentCancelButton);
            this.Controls.Add(this.appointmentCustomerComboBox);
            this.Controls.Add(this.appointmentURLTextBox);
            this.Controls.Add(this.appointmentLocationTextBox);
            this.Controls.Add(this.appointmentDescriptionTextBox);
            this.Controls.Add(this.appointmentTitleTextBox);
            this.Controls.Add(this.appointmentIDTextBox);
            this.Controls.Add(this.appointmentEndDate);
            this.Controls.Add(this.appointmentEndLabel);
            this.Controls.Add(this.appointmentStartLabel);
            this.Controls.Add(this.appointmentStartDate);
            this.Controls.Add(this.appointmentURLLabel);
            this.Controls.Add(this.appointmentLocationLabel);
            this.Controls.Add(this.appointmentDescriptionLabel);
            this.Controls.Add(this.appointmentTitleLabel);
            this.Controls.Add(this.appointmentCustomerLabel);
            this.Controls.Add(this.appointmentIDLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AppointmentForm";
            this.Text = "Schedule App | Appointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label appointmentIDLabel;
        protected System.Windows.Forms.Label appointmentCustomerLabel;
        protected System.Windows.Forms.Label appointmentTitleLabel;
        protected System.Windows.Forms.Label appointmentDescriptionLabel;
        protected System.Windows.Forms.Label appointmentLocationLabel;
        protected System.Windows.Forms.Label appointmentURLLabel;
        protected System.Windows.Forms.DateTimePicker appointmentStartDate;
        protected System.Windows.Forms.Label appointmentStartLabel;
        protected System.Windows.Forms.Label appointmentEndLabel;
        protected System.Windows.Forms.DateTimePicker appointmentEndDate;
        protected System.Windows.Forms.TextBox appointmentIDTextBox;
        protected System.Windows.Forms.TextBox appointmentTitleTextBox;
        protected System.Windows.Forms.TextBox appointmentDescriptionTextBox;
        protected System.Windows.Forms.TextBox appointmentLocationTextBox;
        protected System.Windows.Forms.TextBox appointmentURLTextBox;
        protected System.Windows.Forms.ComboBox appointmentCustomerComboBox;
        protected System.Windows.Forms.Button appointmentCancelButton;
        protected System.Windows.Forms.Button appointmentSaveButton;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox appointmentContactTextBox;
    }
}
namespace SchedulingApp
{
    partial class EditAppointmentForm
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
            this.SuspendLayout();
            // 
            // appointmentTitleTextBox
            // 
            this.appointmentTitleTextBox.TextChanged += new System.EventHandler(this.appointmentTitleTextBox_TextChanged);
            // 
            // appointmentDescriptionTextBox
            // 
            this.appointmentDescriptionTextBox.TextChanged += new System.EventHandler(this.appointmentDescriptionTextBox_TextChanged);
            // 
            // appointmentCustomerComboBox
            // 
            this.appointmentCustomerComboBox.Size = new System.Drawing.Size(142, 24);
            this.appointmentCustomerComboBox.SelectedIndexChanged += new System.EventHandler(this.appointmentCustomerComboBox_SelectedIndexChanged);
            // 
            // appointmentCancelButton
            // 
            this.appointmentCancelButton.Click += new System.EventHandler(this.appointmentCancelButton_Click);
            // 
            // appointmentSaveButton
            // 
            this.appointmentSaveButton.Click += new System.EventHandler(this.appointmentSaveButton_Click);
            // 
            // EditAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 472);
            this.Name = "EditAppointmentForm";
            this.Text = "Schedule App | Edit Appointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
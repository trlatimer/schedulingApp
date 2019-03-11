namespace SchedulingApp
{
    partial class UpdateAppointmentForm
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
            // UpdateAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 472);
            this.Name = "UpdateAppointmentForm";
            this.Text = "UpdateAppointmentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
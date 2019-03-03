namespace SchedulingApp
{
    partial class EditCustomerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // customerIDTextBox
            // 
            this.customerIDTextBox.Text = "";
            // 
            // customerSaveButton
            // 
            this.customerSaveButton.Click += new System.EventHandler(this.customerSaveButton_Click);
            // 
            // customerCancelButton
            // 
            this.customerCancelButton.Click += new System.EventHandler(this.customerCancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(98, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 24);
            this.label1.TabIndex = 26;
            this.label1.Text = "Edit Customer";
            // 
            // EditCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 373);
            this.Controls.Add(this.label1);
            this.Name = "EditCustomerForm";
            this.Text = "editCustomerForm";
            this.Controls.SetChildIndex(this.customerIDTextBox, 0);
            this.Controls.SetChildIndex(this.customerNameTextBox, 0);
            this.Controls.SetChildIndex(this.customerAddressTextBox, 0);
            this.Controls.SetChildIndex(this.customerCityTextBox, 0);
            this.Controls.SetChildIndex(this.customerZipCodeTextBox, 0);
            this.Controls.SetChildIndex(this.customerPhoneTextBox, 0);
            this.Controls.SetChildIndex(this.customerCountryTextBox, 0);
            this.Controls.SetChildIndex(this.customerSaveButton, 0);
            this.Controls.SetChildIndex(this.customerCancelButton, 0);
            this.Controls.SetChildIndex(this.customerAddress2TextBox, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
    }
}
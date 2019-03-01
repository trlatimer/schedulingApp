namespace SchedulingApp
{
    partial class AddCustomerForm
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
            this.addCustomerTitleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // customerIDTextBox
            // 
            this.customerIDTextBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            // 
            // customerNameTextBox
            // 
            this.customerNameTextBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.customerNameTextBox.TabIndex = 0;
            this.customerNameTextBox.TextChanged += new System.EventHandler(this.customerNameTextBox_TextChanged);
            // 
            // customerAddressTextBox
            // 
            this.customerAddressTextBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.customerAddressTextBox.TabIndex = 1;
            this.customerAddressTextBox.TextChanged += new System.EventHandler(this.customerAddressTextBox_TextChanged);
            // 
            // customerCityTextBox
            // 
            this.customerCityTextBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.customerCityTextBox.TabIndex = 3;
            this.customerCityTextBox.TextChanged += new System.EventHandler(this.customerCityTextBox_TextChanged);
            // 
            // customerZipCodeTextBox
            // 
            this.customerZipCodeTextBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.customerZipCodeTextBox.TabIndex = 4;
            this.customerZipCodeTextBox.TextChanged += new System.EventHandler(this.customerZipCodeTextBox_TextChanged);
            // 
            // customerPhoneTextBox
            // 
            this.customerPhoneTextBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.customerPhoneTextBox.TabIndex = 6;
            this.customerPhoneTextBox.TextChanged += new System.EventHandler(this.customerPhoneTextBox_TextChanged);
            // 
            // customerCountryTextBox
            // 
            this.customerCountryTextBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.customerCountryTextBox.TabIndex = 5;
            this.customerCountryTextBox.TextChanged += new System.EventHandler(this.customerCountryTextBox_TextChanged);
            // 
            // customerSaveButton
            // 
            this.customerSaveButton.TabIndex = 8;
            this.customerSaveButton.Click += new System.EventHandler(this.customerSaveButton_Click);
            // 
            // customerCancelButton
            // 
            this.customerCancelButton.TabIndex = 7;
            this.customerCancelButton.Click += new System.EventHandler(this.customerCancelButton_Click);
            // 
            // customerAddress2TextBox
            // 
            this.customerAddress2TextBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.customerAddress2TextBox.TabIndex = 2;
            this.customerAddress2TextBox.TextChanged += new System.EventHandler(this.customerAddress2TextBox_TextChanged);
            // 
            // addCustomerTitleLabel
            // 
            this.addCustomerTitleLabel.AutoSize = true;
            this.addCustomerTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCustomerTitleLabel.Location = new System.Drawing.Point(71, 22);
            this.addCustomerTitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.addCustomerTitleLabel.Name = "addCustomerTitleLabel";
            this.addCustomerTitleLabel.Size = new System.Drawing.Size(190, 24);
            this.addCustomerTitleLabel.TabIndex = 24;
            this.addCustomerTitleLabel.Text = "Add a New Customer";
            // 
            // AddCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 374);
            this.Controls.Add(this.addCustomerTitleLabel);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "AddCustomerForm";
            this.Text = "Schedule App | Add Customer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddCustomerForm_FormClosing);
            this.Controls.SetChildIndex(this.customerAddress2TextBox, 0);
            this.Controls.SetChildIndex(this.customerIDTextBox, 0);
            this.Controls.SetChildIndex(this.customerNameTextBox, 0);
            this.Controls.SetChildIndex(this.customerAddressTextBox, 0);
            this.Controls.SetChildIndex(this.customerCityTextBox, 0);
            this.Controls.SetChildIndex(this.customerZipCodeTextBox, 0);
            this.Controls.SetChildIndex(this.customerPhoneTextBox, 0);
            this.Controls.SetChildIndex(this.customerCountryTextBox, 0);
            this.Controls.SetChildIndex(this.customerSaveButton, 0);
            this.Controls.SetChildIndex(this.customerCancelButton, 0);
            this.Controls.SetChildIndex(this.addCustomerTitleLabel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label addCustomerTitleLabel;
    }
}
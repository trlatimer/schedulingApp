namespace SchedulingAppBaseForms
{
    partial class ReportForm
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
            this.reportTextBox = new System.Windows.Forms.TextBox();
            this.reportCloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportTextBox
            // 
            this.reportTextBox.Location = new System.Drawing.Point(36, 118);
            this.reportTextBox.Multiline = true;
            this.reportTextBox.Name = "reportTextBox";
            this.reportTextBox.ReadOnly = true;
            this.reportTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.reportTextBox.Size = new System.Drawing.Size(1075, 627);
            this.reportTextBox.TabIndex = 0;
            // 
            // reportCloseButton
            // 
            this.reportCloseButton.Location = new System.Drawing.Point(978, 768);
            this.reportCloseButton.Name = "reportCloseButton";
            this.reportCloseButton.Size = new System.Drawing.Size(102, 37);
            this.reportCloseButton.TabIndex = 1;
            this.reportCloseButton.Text = "Close";
            this.reportCloseButton.UseVisualStyleBackColor = true;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1146, 836);
            this.Controls.Add(this.reportCloseButton);
            this.Controls.Add(this.reportTextBox);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox reportTextBox;
        protected System.Windows.Forms.Button reportCloseButton;
    }
}
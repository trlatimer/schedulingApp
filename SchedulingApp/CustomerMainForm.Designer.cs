namespace SchedulingApp
{
    partial class CustomerMainForm
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
            this.customersDGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.customerBackButton = new System.Windows.Forms.Button();
            this.customerAddButton = new System.Windows.Forms.Button();
            this.customerEditButton = new System.Windows.Forms.Button();
            this.customerDeleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customersDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // customersDGV
            // 
            this.customersDGV.AllowUserToAddRows = false;
            this.customersDGV.AllowUserToDeleteRows = false;
            this.customersDGV.AllowUserToOrderColumns = true;
            this.customersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customersDGV.Location = new System.Drawing.Point(146, 53);
            this.customersDGV.Name = "customersDGV";
            this.customersDGV.RowHeadersVisible = false;
            this.customersDGV.Size = new System.Drawing.Size(500, 202);
            this.customersDGV.TabIndex = 0;
            this.customersDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customersDGV_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customers";
            // 
            // customerBackButton
            // 
            this.customerBackButton.Location = new System.Drawing.Point(38, 214);
            this.customerBackButton.Name = "customerBackButton";
            this.customerBackButton.Size = new System.Drawing.Size(75, 23);
            this.customerBackButton.TabIndex = 2;
            this.customerBackButton.Text = "Back";
            this.customerBackButton.UseVisualStyleBackColor = true;
            this.customerBackButton.Click += new System.EventHandler(this.customerBackButton_Click);
            // 
            // customerAddButton
            // 
            this.customerAddButton.Location = new System.Drawing.Point(38, 74);
            this.customerAddButton.Name = "customerAddButton";
            this.customerAddButton.Size = new System.Drawing.Size(75, 23);
            this.customerAddButton.TabIndex = 3;
            this.customerAddButton.Text = "Add";
            this.customerAddButton.UseVisualStyleBackColor = true;
            this.customerAddButton.Click += new System.EventHandler(this.customerAddButton_Click);
            // 
            // customerEditButton
            // 
            this.customerEditButton.Location = new System.Drawing.Point(38, 103);
            this.customerEditButton.Name = "customerEditButton";
            this.customerEditButton.Size = new System.Drawing.Size(75, 23);
            this.customerEditButton.TabIndex = 4;
            this.customerEditButton.Text = "Edit";
            this.customerEditButton.UseVisualStyleBackColor = true;
            // 
            // customerDeleteButton
            // 
            this.customerDeleteButton.Location = new System.Drawing.Point(38, 132);
            this.customerDeleteButton.Name = "customerDeleteButton";
            this.customerDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.customerDeleteButton.TabIndex = 5;
            this.customerDeleteButton.Text = "Delete";
            this.customerDeleteButton.UseVisualStyleBackColor = true;
            // 
            // CustomerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(676, 280);
            this.Controls.Add(this.customerDeleteButton);
            this.Controls.Add(this.customerEditButton);
            this.Controls.Add(this.customerAddButton);
            this.Controls.Add(this.customerBackButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customersDGV);
            this.Name = "CustomerMainForm";
            this.Text = "Schedule App | Customers";
            this.Activated += new System.EventHandler(this.CustomerMainForm_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.customersDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView customersDGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button customerBackButton;
        private System.Windows.Forms.Button customerAddButton;
        private System.Windows.Forms.Button customerEditButton;
        private System.Windows.Forms.Button customerDeleteButton;
    }
}
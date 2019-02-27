namespace SchedulingApp
{
    partial class NewUserForm
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
            this.createUserTitleLabel = new System.Windows.Forms.Label();
            this.createUserUserIDLabel = new System.Windows.Forms.Label();
            this.createUserUserNameLabel = new System.Windows.Forms.Label();
            this.createUserPasswordLabel = new System.Windows.Forms.Label();
            this.createUserPwdConfirmLabel = new System.Windows.Forms.Label();
            this.createUserUserIDTextBox = new System.Windows.Forms.TextBox();
            this.createUserUserNameTextBox = new System.Windows.Forms.TextBox();
            this.createUserPasswordTextBox = new System.Windows.Forms.TextBox();
            this.createUserConfirmTextBox = new System.Windows.Forms.TextBox();
            this.createUserCreateButton = new System.Windows.Forms.Button();
            this.createUserCancelButton = new System.Windows.Forms.Button();
            this.createUserCreatorLabel = new System.Windows.Forms.Label();
            this.createUserCreatorTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // createUserTitleLabel
            // 
            this.createUserTitleLabel.AutoSize = true;
            this.createUserTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createUserTitleLabel.Location = new System.Drawing.Point(63, 9);
            this.createUserTitleLabel.Name = "createUserTitleLabel";
            this.createUserTitleLabel.Size = new System.Drawing.Size(168, 24);
            this.createUserTitleLabel.TabIndex = 0;
            this.createUserTitleLabel.Text = "Create a New User";
            // 
            // createUserUserIDLabel
            // 
            this.createUserUserIDLabel.AutoSize = true;
            this.createUserUserIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createUserUserIDLabel.Location = new System.Drawing.Point(71, 52);
            this.createUserUserIDLabel.Name = "createUserUserIDLabel";
            this.createUserUserIDLabel.Size = new System.Drawing.Size(56, 16);
            this.createUserUserIDLabel.TabIndex = 1;
            this.createUserUserIDLabel.Text = "User ID:";
            // 
            // createUserUserNameLabel
            // 
            this.createUserUserNameLabel.AutoSize = true;
            this.createUserUserNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createUserUserNameLabel.Location = new System.Drawing.Point(61, 78);
            this.createUserUserNameLabel.Name = "createUserUserNameLabel";
            this.createUserUserNameLabel.Size = new System.Drawing.Size(74, 16);
            this.createUserUserNameLabel.TabIndex = 2;
            this.createUserUserNameLabel.Text = "Username:";
            // 
            // createUserPasswordLabel
            // 
            this.createUserPasswordLabel.AutoSize = true;
            this.createUserPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createUserPasswordLabel.Location = new System.Drawing.Point(64, 104);
            this.createUserPasswordLabel.Name = "createUserPasswordLabel";
            this.createUserPasswordLabel.Size = new System.Drawing.Size(71, 16);
            this.createUserPasswordLabel.TabIndex = 3;
            this.createUserPasswordLabel.Text = "Password:";
            // 
            // createUserPwdConfirmLabel
            // 
            this.createUserPwdConfirmLabel.AutoSize = true;
            this.createUserPwdConfirmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createUserPwdConfirmLabel.Location = new System.Drawing.Point(16, 130);
            this.createUserPwdConfirmLabel.Name = "createUserPwdConfirmLabel";
            this.createUserPwdConfirmLabel.Size = new System.Drawing.Size(119, 16);
            this.createUserPwdConfirmLabel.TabIndex = 4;
            this.createUserPwdConfirmLabel.Text = "Confirm Password:";
            // 
            // createUserUserIDTextBox
            // 
            this.createUserUserIDTextBox.BackColor = System.Drawing.SystemColors.GrayText;
            this.createUserUserIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createUserUserIDTextBox.Location = new System.Drawing.Point(150, 51);
            this.createUserUserIDTextBox.Name = "createUserUserIDTextBox";
            this.createUserUserIDTextBox.ReadOnly = true;
            this.createUserUserIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.createUserUserIDTextBox.TabIndex = 5;
            this.createUserUserIDTextBox.Text = "Auto-Incremented";
            this.createUserUserIDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // createUserUserNameTextBox
            // 
            this.createUserUserNameTextBox.Location = new System.Drawing.Point(150, 77);
            this.createUserUserNameTextBox.Name = "createUserUserNameTextBox";
            this.createUserUserNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.createUserUserNameTextBox.TabIndex = 6;
            this.createUserUserNameTextBox.TextChanged += new System.EventHandler(this.createUserUserNameTextBox_TextChanged);
            // 
            // createUserPasswordTextBox
            // 
            this.createUserPasswordTextBox.Location = new System.Drawing.Point(150, 103);
            this.createUserPasswordTextBox.Name = "createUserPasswordTextBox";
            this.createUserPasswordTextBox.PasswordChar = '*';
            this.createUserPasswordTextBox.Size = new System.Drawing.Size(100, 20);
            this.createUserPasswordTextBox.TabIndex = 7;
            this.createUserPasswordTextBox.TextChanged += new System.EventHandler(this.createUserPasswordTextBox_TextChanged);
            // 
            // createUserConfirmTextBox
            // 
            this.createUserConfirmTextBox.Location = new System.Drawing.Point(150, 129);
            this.createUserConfirmTextBox.Name = "createUserConfirmTextBox";
            this.createUserConfirmTextBox.PasswordChar = '*';
            this.createUserConfirmTextBox.Size = new System.Drawing.Size(100, 20);
            this.createUserConfirmTextBox.TabIndex = 8;
            this.createUserConfirmTextBox.TextChanged += new System.EventHandler(this.createUserConfirmTextBox_TextChanged);
            // 
            // createUserCreateButton
            // 
            this.createUserCreateButton.Location = new System.Drawing.Point(156, 196);
            this.createUserCreateButton.Name = "createUserCreateButton";
            this.createUserCreateButton.Size = new System.Drawing.Size(75, 23);
            this.createUserCreateButton.TabIndex = 9;
            this.createUserCreateButton.Text = "Create";
            this.createUserCreateButton.UseVisualStyleBackColor = true;
            this.createUserCreateButton.Click += new System.EventHandler(this.createUserCreateButton_Click);
            // 
            // createUserCancelButton
            // 
            this.createUserCancelButton.Location = new System.Drawing.Point(52, 196);
            this.createUserCancelButton.Name = "createUserCancelButton";
            this.createUserCancelButton.Size = new System.Drawing.Size(75, 23);
            this.createUserCancelButton.TabIndex = 10;
            this.createUserCancelButton.Text = "Cancel";
            this.createUserCancelButton.UseVisualStyleBackColor = true;
            this.createUserCancelButton.Click += new System.EventHandler(this.createUserCancelButton_Click);
            // 
            // createUserCreatorLabel
            // 
            this.createUserCreatorLabel.AutoSize = true;
            this.createUserCreatorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createUserCreatorLabel.Location = new System.Drawing.Point(40, 157);
            this.createUserCreatorLabel.Name = "createUserCreatorLabel";
            this.createUserCreatorLabel.Size = new System.Drawing.Size(95, 16);
            this.createUserCreatorLabel.TabIndex = 11;
            this.createUserCreatorLabel.Text = "Creator Name:";
            // 
            // createUserCreatorTextBox
            // 
            this.createUserCreatorTextBox.Location = new System.Drawing.Point(150, 156);
            this.createUserCreatorTextBox.Name = "createUserCreatorTextBox";
            this.createUserCreatorTextBox.Size = new System.Drawing.Size(100, 20);
            this.createUserCreatorTextBox.TabIndex = 12;
            this.createUserCreatorTextBox.TextChanged += new System.EventHandler(this.createUserCreatorTextBox_TextChanged);
            // 
            // NewUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(284, 240);
            this.Controls.Add(this.createUserCreatorTextBox);
            this.Controls.Add(this.createUserCreatorLabel);
            this.Controls.Add(this.createUserCancelButton);
            this.Controls.Add(this.createUserCreateButton);
            this.Controls.Add(this.createUserConfirmTextBox);
            this.Controls.Add(this.createUserPasswordTextBox);
            this.Controls.Add(this.createUserUserNameTextBox);
            this.Controls.Add(this.createUserUserIDTextBox);
            this.Controls.Add(this.createUserPwdConfirmLabel);
            this.Controls.Add(this.createUserPasswordLabel);
            this.Controls.Add(this.createUserUserNameLabel);
            this.Controls.Add(this.createUserUserIDLabel);
            this.Controls.Add(this.createUserTitleLabel);
            this.Name = "NewUserForm";
            this.Text = "Schedule App | Create New User";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewUserForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label createUserTitleLabel;
        private System.Windows.Forms.Label createUserUserIDLabel;
        private System.Windows.Forms.Label createUserUserNameLabel;
        private System.Windows.Forms.Label createUserPasswordLabel;
        private System.Windows.Forms.Label createUserPwdConfirmLabel;
        private System.Windows.Forms.TextBox createUserUserIDTextBox;
        private System.Windows.Forms.TextBox createUserUserNameTextBox;
        private System.Windows.Forms.TextBox createUserPasswordTextBox;
        private System.Windows.Forms.TextBox createUserConfirmTextBox;
        private System.Windows.Forms.Button createUserCreateButton;
        private System.Windows.Forms.Button createUserCancelButton;
        private System.Windows.Forms.Label createUserCreatorLabel;
        private System.Windows.Forms.TextBox createUserCreatorTextBox;
    }
}
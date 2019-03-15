namespace SchedulingApp
{
    partial class LoginForm
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
            this.loginTitleLabel = new System.Windows.Forms.Label();
            this.loginSubTitleLabel = new System.Windows.Forms.Label();
            this.loginUsernameLabel = new System.Windows.Forms.Label();
            this.loginPasswordLabel = new System.Windows.Forms.Label();
            this.loginUsernameTextBox = new System.Windows.Forms.TextBox();
            this.loginPasswordTextBox = new System.Windows.Forms.TextBox();
            this.loginLoginButton = new System.Windows.Forms.Button();
            this.loginCreateUserButton = new System.Windows.Forms.Button();
            this.loginExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginTitleLabel
            // 
            this.loginTitleLabel.AutoSize = true;
            this.loginTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginTitleLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.loginTitleLabel.Location = new System.Drawing.Point(128, 46);
            this.loginTitleLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.loginTitleLabel.Name = "loginTitleLabel";
            this.loginTitleLabel.Size = new System.Drawing.Size(324, 55);
            this.loginTitleLabel.TabIndex = 0;
            this.loginTitleLabel.Text = "Schedule App";
            this.loginTitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // loginSubTitleLabel
            // 
            this.loginSubTitleLabel.AutoSize = true;
            this.loginSubTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginSubTitleLabel.Location = new System.Drawing.Point(166, 125);
            this.loginSubTitleLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.loginSubTitleLabel.Name = "loginSubTitleLabel";
            this.loginSubTitleLabel.Size = new System.Drawing.Size(250, 44);
            this.loginSubTitleLabel.TabIndex = 1;
            this.loginSubTitleLabel.Text = "Please Log In";
            // 
            // loginUsernameLabel
            // 
            this.loginUsernameLabel.AutoSize = true;
            this.loginUsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginUsernameLabel.Location = new System.Drawing.Point(90, 229);
            this.loginUsernameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.loginUsernameLabel.Name = "loginUsernameLabel";
            this.loginUsernameLabel.Size = new System.Drawing.Size(139, 30);
            this.loginUsernameLabel.TabIndex = 2;
            this.loginUsernameLabel.Text = "Username:";
            // 
            // loginPasswordLabel
            // 
            this.loginPasswordLabel.AutoSize = true;
            this.loginPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginPasswordLabel.Location = new System.Drawing.Point(96, 290);
            this.loginPasswordLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.loginPasswordLabel.Name = "loginPasswordLabel";
            this.loginPasswordLabel.Size = new System.Drawing.Size(133, 30);
            this.loginPasswordLabel.TabIndex = 3;
            this.loginPasswordLabel.Text = "Password:";
            // 
            // loginUsernameTextBox
            // 
            this.loginUsernameTextBox.Location = new System.Drawing.Point(318, 227);
            this.loginUsernameTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.loginUsernameTextBox.Name = "loginUsernameTextBox";
            this.loginUsernameTextBox.Size = new System.Drawing.Size(196, 31);
            this.loginUsernameTextBox.TabIndex = 4;
            this.loginUsernameTextBox.TextChanged += new System.EventHandler(this.loginUsernameTextBox_TextChanged);
            // 
            // loginPasswordTextBox
            // 
            this.loginPasswordTextBox.Location = new System.Drawing.Point(318, 288);
            this.loginPasswordTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.loginPasswordTextBox.Name = "loginPasswordTextBox";
            this.loginPasswordTextBox.PasswordChar = '*';
            this.loginPasswordTextBox.Size = new System.Drawing.Size(196, 31);
            this.loginPasswordTextBox.TabIndex = 5;
            this.loginPasswordTextBox.TextChanged += new System.EventHandler(this.loginPasswordTextBox_TextChanged);
            // 
            // loginLoginButton
            // 
            this.loginLoginButton.Location = new System.Drawing.Point(368, 356);
            this.loginLoginButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.loginLoginButton.Name = "loginLoginButton";
            this.loginLoginButton.Size = new System.Drawing.Size(150, 44);
            this.loginLoginButton.TabIndex = 6;
            this.loginLoginButton.Text = "Login";
            this.loginLoginButton.UseVisualStyleBackColor = true;
            this.loginLoginButton.Click += new System.EventHandler(this.loginLoginButton_Click);
            // 
            // loginCreateUserButton
            // 
            this.loginCreateUserButton.Location = new System.Drawing.Point(50, 375);
            this.loginCreateUserButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.loginCreateUserButton.Name = "loginCreateUserButton";
            this.loginCreateUserButton.Size = new System.Drawing.Size(234, 44);
            this.loginCreateUserButton.TabIndex = 7;
            this.loginCreateUserButton.Text = "Create New User";
            this.loginCreateUserButton.UseVisualStyleBackColor = true;
            this.loginCreateUserButton.Click += new System.EventHandler(this.loginCreateUserButton_Click);
            // 
            // loginExitButton
            // 
            this.loginExitButton.Location = new System.Drawing.Point(368, 413);
            this.loginExitButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.loginExitButton.Name = "loginExitButton";
            this.loginExitButton.Size = new System.Drawing.Size(150, 44);
            this.loginExitButton.TabIndex = 8;
            this.loginExitButton.Text = "Exit";
            this.loginExitButton.UseVisualStyleBackColor = true;
            this.loginExitButton.Click += new System.EventHandler(this.loginExitButton_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(576, 496);
            this.Controls.Add(this.loginExitButton);
            this.Controls.Add(this.loginCreateUserButton);
            this.Controls.Add(this.loginLoginButton);
            this.Controls.Add(this.loginPasswordTextBox);
            this.Controls.Add(this.loginUsernameTextBox);
            this.Controls.Add(this.loginPasswordLabel);
            this.Controls.Add(this.loginUsernameLabel);
            this.Controls.Add(this.loginSubTitleLabel);
            this.Controls.Add(this.loginTitleLabel);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "LoginForm";
            this.Text = "Schedule App | Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loginTitleLabel;
        private System.Windows.Forms.Label loginSubTitleLabel;
        private System.Windows.Forms.Label loginUsernameLabel;
        private System.Windows.Forms.Label loginPasswordLabel;
        private System.Windows.Forms.TextBox loginUsernameTextBox;
        private System.Windows.Forms.TextBox loginPasswordTextBox;
        private System.Windows.Forms.Button loginLoginButton;
        private System.Windows.Forms.Button loginCreateUserButton;
        private System.Windows.Forms.Button loginExitButton;
    }
}


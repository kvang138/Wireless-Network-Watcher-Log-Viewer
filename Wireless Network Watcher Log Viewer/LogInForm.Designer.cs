namespace WirelessNetWatcherLogViewer
{
    partial class LogInForm
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
            this.cbSQLServersAndInstances = new System.Windows.Forms.ComboBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.mtbPassword = new System.Windows.Forms.MaskedTextBox();
            this.lblSQLServer = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.cbDatabase = new System.Windows.Forms.ComboBox();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.lblShowPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbSQLServersAndInstances
            // 
            this.cbSQLServersAndInstances.FormattingEnabled = true;
            this.cbSQLServersAndInstances.Location = new System.Drawing.Point(117, 95);
            this.cbSQLServersAndInstances.Name = "cbSQLServersAndInstances";
            this.cbSQLServersAndInstances.Size = new System.Drawing.Size(384, 24);
            this.cbSQLServersAndInstances.TabIndex = 0;
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(188, 198);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(220, 22);
            this.tbUsername.TabIndex = 2;
            // 
            // mtbPassword
            // 
            this.mtbPassword.Location = new System.Drawing.Point(188, 242);
            this.mtbPassword.Name = "mtbPassword";
            this.mtbPassword.Size = new System.Drawing.Size(220, 22);
            this.mtbPassword.TabIndex = 3;
            this.mtbPassword.UseSystemPasswordChar = true;
            // 
            // lblSQLServer
            // 
            this.lblSQLServer.AutoSize = true;
            this.lblSQLServer.Location = new System.Drawing.Point(242, 76);
            this.lblSQLServer.Name = "lblSQLServer";
            this.lblSQLServer.Size = new System.Drawing.Size(118, 16);
            this.lblSQLServer.TabIndex = 4;
            this.lblSQLServer.Text = "Select SQL server:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(242, 179);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 16);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(245, 223);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(70, 16);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password:";
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(247, 270);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(75, 27);
            this.btnLogIn.TabIndex = 7;
            this.btnLogIn.Text = "Log in";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(242, 122);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(70, 16);
            this.lblDatabase.TabIndex = 8;
            this.lblDatabase.Text = "Database:";
            // 
            // cbDatabase
            // 
            this.cbDatabase.FormattingEnabled = true;
            this.cbDatabase.Location = new System.Drawing.Point(117, 142);
            this.cbDatabase.Name = "cbDatabase";
            this.cbDatabase.Size = new System.Drawing.Size(384, 24);
            this.cbDatabase.TabIndex = 9;
            this.cbDatabase.Text = "SOCLab";
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Location = new System.Drawing.Point(114, 298);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(0, 16);
            this.lblConnectionStatus.TabIndex = 10;
            // 
            // lblShowPassword
            // 
            this.lblShowPassword.AutoSize = true;
            this.lblShowPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowPassword.Location = new System.Drawing.Point(414, 236);
            this.lblShowPassword.Name = "lblShowPassword";
            this.lblShowPassword.Size = new System.Drawing.Size(51, 36);
            this.lblShowPassword.TabIndex = 11;
            this.lblShowPassword.Text = "👁";
            this.lblShowPassword.Click += new System.EventHandler(this.lblShowPassword_Click);
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 362);
            this.Controls.Add(this.lblShowPassword);
            this.Controls.Add(this.lblConnectionStatus);
            this.Controls.Add(this.cbDatabase);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblSQLServer);
            this.Controls.Add(this.mtbPassword);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.cbSQLServersAndInstances);
            this.Name = "LogInForm";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSQLServersAndInstances;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.MaskedTextBox mtbPassword;
        private System.Windows.Forms.Label lblSQLServer;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.ComboBox cbDatabase;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.Label lblShowPassword;
    }
}
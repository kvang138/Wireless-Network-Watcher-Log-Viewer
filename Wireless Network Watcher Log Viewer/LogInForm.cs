/***
 * 
 * The log in form for logging into the database server.
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.SqlServer.Management.Smo;

namespace WirelessNetWatcherLogViewer
{
    public partial class LogInForm : Form
    {
        private Dictionary<string, string> connectionInfo;

        private readonly SQLService _sqlService;

        public event EventHandler<ConnectionEventArgs> LoggedIn;

        private async void LogInForm_Load(object sender, EventArgs e)
        {
            SQLServerFinder sqlServerFinder = new SQLServerFinder();
            List<string> instances = await sqlServerFinder.getAllSQLServersAndInstancesAsync(false);

            // Add the servers and instances to the dropdown menu.
            foreach (string instance in instances)
                cbSQLServersAndInstances.Items.Add(instance);

            // Automatically select the first database and instance on the list.
            if (cbSQLServersAndInstances.Items.Count > 0)
                cbSQLServersAndInstances.SelectedIndex = 0;
        }

        public LogInForm(SQLService sqlService)
        {
            InitializeComponent();

            _sqlService = sqlService;
            connectionInfo = new Dictionary<string, string>();

            // Listen for the form loading event.
            this.Load += LogInForm_Load;
        }

        // Log in to the database with login credentials specified by the user.
        private async void btnLogIn_Click(object sender, EventArgs e)
        {
            // Make sure the user enter in the neccesary information before proceeding with the log in.
            try
            {
                connectionInfo["serverAndInstance"] = cbSQLServersAndInstances.Text.ToString();
                connectionInfo["database"] = cbDatabase.Text.ToString();
                connectionInfo["username"] = tbUsername.Text.ToString();
                connectionInfo["password"] = mtbPassword.Text.ToString();
                connectionInfo["encrypt"] = "true";
                connectionInfo["trustServerCertificate"] = "true";
            }
            catch (Exception ex)
            {
                return;
            }

            // Disable the button to prevent simultaneously log in.
            btnLogIn.Enabled = false;

            lblConnectionStatus.Text = $"Logging into {connectionInfo["serverAndInstance"]} as {connectionInfo["username"]}";

            // Wait for the application to establish a connection with database server with provided login credentials.
            if (!await _sqlService.logIn(connectionInfo))
            {
                lblConnectionStatus.Text = "Unable to log in.";

                // Enable the button if the login was unsuccessful.
                btnLogIn.Enabled = true;
            }
            else // The login was succesful.
            {
                lblConnectionStatus.Text = $"Logged in successfully as {connectionInfo["username"]}.\r\n\r\nDialog will close in 1 second.";

                await Task.Delay(1000);
                
                // Trigger the logged in event.
                LoggedIn.Invoke(this, new ConnectionEventArgs(connectionInfo));

                // dispose and close the log in form.
                this.Visible = false;
                this.Dispose();
            }
        }

        // Allow the user to hide and unhide the password for privacy reasons.
        private void lblShowPassword_Click(object sender, EventArgs e)
        {
            mtbPassword.UseSystemPasswordChar = !mtbPassword.UseSystemPasswordChar;
            
            if (mtbPassword.UseSystemPasswordChar)
                lblShowPassword.Text = "⌣";
            else
                lblShowPassword.Text = "👁";
        }
    }
}

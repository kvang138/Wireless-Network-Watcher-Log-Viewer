/***
 * 
 * The main form for logging in and showing the log.
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WirelessNetWatcherLogViewer
{
    public partial class MainForm : Form
    {
        private readonly SQLService _sqlService;

        private LogInForm logInForm;

        //private Dictionary<string, Int64> timeDiff = new Dictionary<string, Int64>();

        DateTimeCalculators dateTimeCalculators;

        public MainForm(SQLService sqlService)
        {
            InitializeComponent();

            _sqlService = sqlService;

            dateTimeCalculators = new DateTimeCalculators();

            // Automatically select the first time range by default.
            if (cbTimeRange.Items.Count > 0)
                cbTimeRange.SelectedIndex = 0;

            dgvLogs.AutoGenerateColumns = true;

            dgvLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // Make sure the controls are not move around when resizing.
            this.Resize += (object sender, EventArgs e) =>
            {
                this.btnLogInLogOut.Left = (int)(this.ClientSize.Width - 179);
                this.gbLoadLogs.Left = this.ClientSize.Width - this.gbLoadLogs.Width;
            };
        }

        // Show the login form to allow the user to log in and also allow the user to log out of the database with same button.
        private void btnLogInLogOut_Click(object sender, EventArgs e)
        {
            if (btnLogInLogOut.Text == "Log out")
            {
                _sqlService.Dispose();
                _sqlService.Close();

                btnLogInLogOut.Text = "Log in";
                gbLoadLogs.Visible = false;
                clearDataGridTable(dgvLogs);

                return;
            }

            // Show the login form
            if (logInForm != null && !logInForm.IsDisposed)
            {
                logInForm.Show();

                return;
            }

            logInForm = new LogInForm(_sqlService);

            // Enable the button after the login was closed.
            logInForm.FormClosed += (object sender_, FormClosedEventArgs fce) => btnLogInLogOut.Enabled = true;
            
            // Listen for the logged in event to perform the neccesary actions.
            logInForm.LoggedIn += (object sender_, ConnectionEventArgs cea) =>
            {
                gbLoadLogs.Visible = true;
                btnLogInLogOut.Enabled = true;
                btnLogInLogOut.Text = "Log out";

                lblLoadingStatus.Text = "";
            };

            // Show the login form.
            logInForm.Show();

            btnLogInLogOut.Enabled = false;
        }

        // Load the logs from the database server based on the time range selected.
        private async void btnLoadLogs_Click(object sender, EventArgs e)
        {
            string startDateTime = "";
            string endDateTime = "";
            DateTime dateTime = DateTime.Now;

            try
            {
                // If entered in a custom time range.
                if (cbTimeRange.Text.ToString() == "Custom")
                {
                    startDateTime = dpDateTimeRange1.Value.ToString();
                    endDateTime = dpDateTimeRange2.Value.ToString();
                }
                else // If the user selected any of the pre-defined time ranges.
                {
                    startDateTime = dateTimeCalculators.calculateDateTime(cbTimeRange.Text.ToString());
                    endDateTime = dateTime.ToString();

                    dpDateTimeRange1.Text = startDateTime;
                    dpDateTimeRange2.Text = endDateTime;
                }
            }
            catch (Exception ex)
            {
                lblLoadingStatus.Text = "Invalid Time range selected.";
                return;
            }

            // Get the time zone info.
            TimeZoneInfo localTimeZoneInfo = TimeZoneInfo.Local;
            string timeZoneAbbreviation = Regex.Replace(localTimeZoneInfo.Id, "([A-z])[^ ]+(?: |$)", "$1", RegexOptions.IgnoreCase);

            // The query for loading the logs from the database server, also convert the search time ranage into UTC and convert the
            // result date/time into the user's timezone.
            string query = $@"select connectedDevicesReport.reportID, format(connectedDevicesReport.createdDateTime AT TIME ZONE 'UTC' AT TIME ZONE '{localTimeZoneInfo.Id}', 'dddd, MMMM dd, yyyy hh:mm:ss tt fff {timeZoneAbbreviation}') 'Date/Time', connectedDevicesReport.createdDateTime, connectedDevices.eventID, connectedDevices.deviceID, connectedDevices.name, connectedDevices.friendlyName, connectedDevices.currentMACAddress, connectedDevices.ipv4Address, connectedDevices.ipv6Address, connectedDevices.connectionType, connectedDevices.operatingSystem, connectedDevices.deviceType, connectedDevices.description, connectedDevices.signalDecibels, connectedDevices.isGuest, connectedDevices.BSSID from SOCLab.dbo.connected_devices_report connectedDevicesReport
                            join SOCLab.dbo.connected_devices connectedDevices on connectedDevices.reportID = connectedDevicesReport.reportID
                            {(startDateTime != "" && endDateTime != "" ? $"where createdDateTime between '{DateTime.Parse(startDateTime).ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}' and '{DateTime.Parse(endDateTime).ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")}'" : "")} order by connectedDevicesReport.createdDateTime desc";

            lblLoadingStatus.Text = "Now loading data...";
            
            // Wait for the data to load.
            DataTable dataTable = await _sqlService.getDataTableWithReaderAsync(query);
            
            // Show the log on the form and auto resize all of the columns.
            dgvLogs.DataSource = dataTable;
            dgvLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (dataTable.Rows.Count < 1)
                lblLoadingStatus.Text = "No result.";
            else
                lblLoadingStatus.Text = $"Data loaded. {dataTable.Rows.Count} possible rows.";

            // Show when the log were last loaded.
            lblLoadingStatus.Text += $"\r\n\r\nLast loaded: {dateTime.ToString("dddd, MMMM dd, yyyy @ hh:mm:ss tt")}.";

            // Show the time ranges in a friendly time string.
            lblTimeMessage.Text = $"{dateTimeCalculators.toFriendlyTimeString(startDateTime, endDateTime)}";
        }

        // Clear the log table.
        private void clearDataGridTable(DataGridView dgv)
        {
            if (dgvLogs.DataSource is DataTable dt)
                dt.Clear();
        }

        // Clear the log table and status messages.
        private void btnClearTable_Click(object sender, EventArgs e)
        {
            clearDataGridTable(dgvLogs);
            lblLoadingStatus.Text = "";
            lblTimeMessage.Text = "";
        }
    }
}



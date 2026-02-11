namespace WirelessNetWatcherLogViewer
{
    partial class MainForm
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
            this.lblDateTimeSelection = new System.Windows.Forms.Label();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.cbTimeRange = new System.Windows.Forms.ComboBox();
            this.dpDateTimeRange1 = new System.Windows.Forms.DateTimePicker();
            this.dpDateTimeRange2 = new System.Windows.Forms.DateTimePicker();
            this.lblStartDateTime = new System.Windows.Forms.Label();
            this.lblEndDateTime = new System.Windows.Forms.Label();
            this.btnLogInLogOut = new System.Windows.Forms.Button();
            this.btnLoadLogs = new System.Windows.Forms.Button();
            this.gbLoadLogs = new System.Windows.Forms.GroupBox();
            this.lblTimeMessage = new System.Windows.Forms.Label();
            this.lblLoadingStatus = new System.Windows.Forms.Label();
            this.btnClearTable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.gbLoadLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDateTimeSelection
            // 
            this.lblDateTimeSelection.AutoSize = true;
            this.lblDateTimeSelection.Location = new System.Drawing.Point(108, 18);
            this.lblDateTimeSelection.Name = "lblDateTimeSelection";
            this.lblDateTimeSelection.Size = new System.Drawing.Size(114, 16);
            this.lblDateTimeSelection.TabIndex = 1;
            this.lblDateTimeSelection.Text = "Select time range:";
            // 
            // dgvLogs
            // 
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Location = new System.Drawing.Point(12, 12);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.RowHeadersWidth = 51;
            this.dgvLogs.RowTemplate.Height = 24;
            this.dgvLogs.Size = new System.Drawing.Size(1342, 1053);
            this.dgvLogs.TabIndex = 2;
            // 
            // cbTimeRange
            // 
            this.cbTimeRange.FormattingEnabled = true;
            this.cbTimeRange.Items.AddRange(new object[] {
            "Last 15 Minutes",
            "Last 30 Minutes",
            "Last 60 Minutes",
            "Last 2 Hours",
            "Last 4 Hours",
            "Last 6 Hours",
            "Last 8 Hours",
            "Last 12 Hours",
            "Last 24 Hours",
            "Last 2 Days",
            "Last 3 Days",
            "Last 7 Days",
            "Last 2 Weeks",
            "Last 1 Month",
            "Last 2 Months",
            "Last 3 Months",
            "Last 6 Months",
            "Last 1 Year",
            "Last 2 Years",
            "Last 3 Years",
            "Custom"});
            this.cbTimeRange.Location = new System.Drawing.Point(8, 37);
            this.cbTimeRange.Name = "cbTimeRange";
            this.cbTimeRange.Size = new System.Drawing.Size(350, 24);
            this.cbTimeRange.TabIndex = 4;
            // 
            // dpDateTimeRange1
            // 
            this.dpDateTimeRange1.CustomFormat = "dddd, MMMM dd, yyyy h:mm:ss tt";
            this.dpDateTimeRange1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpDateTimeRange1.Location = new System.Drawing.Point(8, 93);
            this.dpDateTimeRange1.Name = "dpDateTimeRange1";
            this.dpDateTimeRange1.Size = new System.Drawing.Size(350, 22);
            this.dpDateTimeRange1.TabIndex = 5;
            // 
            // dpDateTimeRange2
            // 
            this.dpDateTimeRange2.CustomFormat = "dddd, MMMM dd, yyyy h:mm:ss tt";
            this.dpDateTimeRange2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpDateTimeRange2.Location = new System.Drawing.Point(8, 137);
            this.dpDateTimeRange2.Name = "dpDateTimeRange2";
            this.dpDateTimeRange2.Size = new System.Drawing.Size(350, 22);
            this.dpDateTimeRange2.TabIndex = 6;
            // 
            // lblStartDateTime
            // 
            this.lblStartDateTime.AutoSize = true;
            this.lblStartDateTime.Location = new System.Drawing.Point(118, 64);
            this.lblStartDateTime.Name = "lblStartDateTime";
            this.lblStartDateTime.Size = new System.Drawing.Size(104, 16);
            this.lblStartDateTime.TabIndex = 7;
            this.lblStartDateTime.Text = "Start Date/Time:";
            // 
            // lblEndDateTime
            // 
            this.lblEndDateTime.AutoSize = true;
            this.lblEndDateTime.Location = new System.Drawing.Point(121, 118);
            this.lblEndDateTime.Name = "lblEndDateTime";
            this.lblEndDateTime.Size = new System.Drawing.Size(101, 16);
            this.lblEndDateTime.TabIndex = 8;
            this.lblEndDateTime.Text = "End Date/Time:";
            // 
            // btnLogInLogOut
            // 
            this.btnLogInLogOut.Location = new System.Drawing.Point(1499, 10);
            this.btnLogInLogOut.Name = "btnLogInLogOut";
            this.btnLogInLogOut.Size = new System.Drawing.Size(75, 33);
            this.btnLogInLogOut.TabIndex = 9;
            this.btnLogInLogOut.Text = "Log in";
            this.btnLogInLogOut.UseVisualStyleBackColor = true;
            this.btnLogInLogOut.Click += new System.EventHandler(this.btnLogInLogOut_Click);
            // 
            // btnLoadLogs
            // 
            this.btnLoadLogs.Location = new System.Drawing.Point(111, 168);
            this.btnLoadLogs.Name = "btnLoadLogs";
            this.btnLoadLogs.Size = new System.Drawing.Size(75, 30);
            this.btnLoadLogs.TabIndex = 10;
            this.btnLoadLogs.Text = "Load logs";
            this.btnLoadLogs.UseVisualStyleBackColor = true;
            this.btnLoadLogs.Click += new System.EventHandler(this.btnLoadLogs_Click);
            // 
            // gbLoadLogs
            // 
            this.gbLoadLogs.Controls.Add(this.lblTimeMessage);
            this.gbLoadLogs.Controls.Add(this.lblLoadingStatus);
            this.gbLoadLogs.Controls.Add(this.btnClearTable);
            this.gbLoadLogs.Controls.Add(this.lblDateTimeSelection);
            this.gbLoadLogs.Controls.Add(this.btnLoadLogs);
            this.gbLoadLogs.Controls.Add(this.cbTimeRange);
            this.gbLoadLogs.Controls.Add(this.dpDateTimeRange1);
            this.gbLoadLogs.Controls.Add(this.lblEndDateTime);
            this.gbLoadLogs.Controls.Add(this.dpDateTimeRange2);
            this.gbLoadLogs.Controls.Add(this.lblStartDateTime);
            this.gbLoadLogs.Location = new System.Drawing.Point(1360, 49);
            this.gbLoadLogs.Name = "gbLoadLogs";
            this.gbLoadLogs.Size = new System.Drawing.Size(368, 388);
            this.gbLoadLogs.TabIndex = 11;
            this.gbLoadLogs.TabStop = false;
            this.gbLoadLogs.Visible = false;
            // 
            // lblTimeMessage
            // 
            this.lblTimeMessage.Location = new System.Drawing.Point(6, 280);
            this.lblTimeMessage.Name = "lblTimeMessage";
            this.lblTimeMessage.Size = new System.Drawing.Size(358, 98);
            this.lblTimeMessage.TabIndex = 13;
            this.lblTimeMessage.Text = "Time message";
            // 
            // lblLoadingStatus
            // 
            this.lblLoadingStatus.Location = new System.Drawing.Point(72, 212);
            this.lblLoadingStatus.Name = "lblLoadingStatus";
            this.lblLoadingStatus.Size = new System.Drawing.Size(228, 68);
            this.lblLoadingStatus.TabIndex = 12;
            this.lblLoadingStatus.Text = "Now loading...";
            // 
            // btnClearTable
            // 
            this.btnClearTable.Location = new System.Drawing.Point(192, 168);
            this.btnClearTable.Name = "btnClearTable";
            this.btnClearTable.Size = new System.Drawing.Size(88, 30);
            this.btnClearTable.TabIndex = 11;
            this.btnClearTable.Text = "Clear Table";
            this.btnClearTable.UseVisualStyleBackColor = true;
            this.btnClearTable.Click += new System.EventHandler(this.btnClearTable_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1737, 1077);
            this.Controls.Add(this.gbLoadLogs);
            this.Controls.Add(this.btnLogInLogOut);
            this.Controls.Add(this.dgvLogs);
            this.Name = "MainForm";
            this.Text = "Wireless Network Watcher Log Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.gbLoadLogs.ResumeLayout(false);
            this.gbLoadLogs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblDateTimeSelection;
        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.ComboBox cbTimeRange;
        private System.Windows.Forms.DateTimePicker dpDateTimeRange1;
        private System.Windows.Forms.DateTimePicker dpDateTimeRange2;
        private System.Windows.Forms.Label lblStartDateTime;
        private System.Windows.Forms.Label lblEndDateTime;
        private System.Windows.Forms.Button btnLogInLogOut;
        private System.Windows.Forms.Button btnLoadLogs;
        private System.Windows.Forms.GroupBox gbLoadLogs;
        private System.Windows.Forms.Button btnClearTable;
        private System.Windows.Forms.Label lblLoadingStatus;
        private System.Windows.Forms.Label lblTimeMessage;
    }
}








namespace DVLCPresentation
{
    partial class frmLocalLicenseList
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
            this.components = new System.ComponentModel.Container();
            this.dtgview = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btneditApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.btndeleteApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btncancelApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSchedualTest = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVision = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWriiten = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStreet = new System.Windows.Forms.ToolStripMenuItem();
            this.btnIssueDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSerarch = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgview)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgview
            // 
            this.dtgview.AllowUserToAddRows = false;
            this.dtgview.AllowUserToDeleteRows = false;
            this.dtgview.AllowUserToOrderColumns = true;
            this.dtgview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgview.ContextMenuStrip = this.contextMenuStrip1;
            this.dtgview.Location = new System.Drawing.Point(12, 201);
            this.dtgview.Name = "dtgview";
            this.dtgview.ReadOnly = true;
            this.dtgview.Size = new System.Drawing.Size(868, 228);
            this.dtgview.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.btneditApplication,
            this.btndeleteApplication,
            this.toolStripSeparator2,
            this.btncancelApplication,
            this.toolStripSeparator3,
            this.btnSchedualTest,
            this.btnIssueDrivingLicense,
            this.toolStripSeparator4,
            this.btnShowLicense,
            this.toolStripSeparator5,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(246, 210);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(242, 6);
            // 
            // btneditApplication
            // 
            this.btneditApplication.Name = "btneditApplication";
            this.btneditApplication.Size = new System.Drawing.Size(245, 22);
            this.btneditApplication.Text = "Edit Application";
            this.btneditApplication.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // btndeleteApplication
            // 
            this.btndeleteApplication.Name = "btndeleteApplication";
            this.btndeleteApplication.Size = new System.Drawing.Size(245, 22);
            this.btndeleteApplication.Text = "Delete Application";
            this.btndeleteApplication.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(242, 6);
            // 
            // btncancelApplication
            // 
            this.btncancelApplication.Name = "btncancelApplication";
            this.btncancelApplication.Size = new System.Drawing.Size(245, 22);
            this.btncancelApplication.Text = "Cancel Appliation";
            this.btncancelApplication.Click += new System.EventHandler(this.cancelAppliationToolStripMenuItem_Click_1);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(242, 6);
            // 
            // btnSchedualTest
            // 
            this.btnSchedualTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnVision,
            this.btnWriiten,
            this.btnStreet});
            this.btnSchedualTest.Name = "btnSchedualTest";
            this.btnSchedualTest.Size = new System.Drawing.Size(245, 22);
            this.btnSchedualTest.Tag = "1";
            this.btnSchedualTest.Text = "Schedual Tests";
            // 
            // btnVision
            // 
            this.btnVision.Name = "btnVision";
            this.btnVision.Size = new System.Drawing.Size(111, 22);
            this.btnVision.Tag = "1";
            this.btnVision.Text = "Vision";
            this.btnVision.Click += new System.EventHandler(this.TakeVisionTest);
            // 
            // btnWriiten
            // 
            this.btnWriiten.Name = "btnWriiten";
            this.btnWriiten.Size = new System.Drawing.Size(111, 22);
            this.btnWriiten.Tag = "2";
            this.btnWriiten.Text = "written";
            this.btnWriiten.Click += new System.EventHandler(this.TakeWrittenTest);
            // 
            // btnStreet
            // 
            this.btnStreet.Name = "btnStreet";
            this.btnStreet.Size = new System.Drawing.Size(111, 22);
            this.btnStreet.Tag = "3";
            this.btnStreet.Text = "Street";
            this.btnStreet.Click += new System.EventHandler(this.TakeStreetTest);
            // 
            // btnIssueDrivingLicense
            // 
            this.btnIssueDrivingLicense.Name = "btnIssueDrivingLicense";
            this.btnIssueDrivingLicense.Size = new System.Drawing.Size(245, 22);
            this.btnIssueDrivingLicense.Text = "Issue Driving License (First Time)";
            this.btnIssueDrivingLicense.Click += new System.EventHandler(this.GetLicenseForFirstTime);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(242, 6);
            // 
            // btnShowLicense
            // 
            this.btnShowLicense.Name = "btnShowLicense";
            this.btnShowLicense.Size = new System.Drawing.Size(245, 22);
            this.btnShowLicense.Text = "Show License";
            this.btnShowLicense.Click += new System.EventHandler(this.ShowLicenseInfo);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(242, 6);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // txtSerarch
            // 
            this.txtSerarch.BackColor = System.Drawing.SystemColors.Control;
            this.txtSerarch.Location = new System.Drawing.Point(166, 156);
            this.txtSerarch.Multiline = true;
            this.txtSerarch.Name = "txtSerarch";
            this.txtSerarch.Size = new System.Drawing.Size(189, 24);
            this.txtSerarch.TabIndex = 1;
            this.txtSerarch.TextChanged += new System.EventHandler(this.txtSerarch_TextChanged);
            this.txtSerarch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerarch_KeyPress);
            // 
            // cbFilter
            // 
            this.cbFilter.BackColor = System.Drawing.SystemColors.Control;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "LocalDrivingLicenseApplicationID",
            "NationalNo"});
            this.cbFilter.Location = new System.Drawing.Point(23, 156);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(121, 21);
            this.cbFilter.TabIndex = 2;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.button1.Location = new System.Drawing.Point(779, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 41);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddApplicationLocalLicense);
            // 
            // frmLocalLicenseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.txtSerarch);
            this.Controls.Add(this.dtgview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLocalLicenseList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmApplicationScreen";
            this.Load += new System.EventHandler(this.frmApplicationScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgview)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgview;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btneditApplication;
        private System.Windows.Forms.ToolStripMenuItem btndeleteApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btncancelApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem btnSchedualTest;
        private System.Windows.Forms.ToolStripMenuItem btnIssueDrivingLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem btnShowLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.TextBox txtSerarch;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.ToolStripMenuItem btnVision;
        private System.Windows.Forms.ToolStripMenuItem btnWriiten;
        private System.Windows.Forms.ToolStripMenuItem btnStreet;
        private System.Windows.Forms.Button button1;
    }
}
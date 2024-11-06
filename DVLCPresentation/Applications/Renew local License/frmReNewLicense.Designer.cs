namespace DVLCPresentation
{
    partial class frmReNewLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReNewLicense));
            this.btnSave = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.lshowLicense = new System.Windows.Forms.LinkLabel();
            this.ctrlLicenseWithFilter1 = new clsPeople.ctrlLicenseWithFilter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbTotalFees = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbLicenseFees = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbApplicationFees = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbExpirationDate = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbIssueDate = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbOldLicenseID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbAppDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbReNewLicenseID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbApplicationID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Location = new System.Drawing.Point(884, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 34);
            this.btnSave.TabIndex = 1;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.Save);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(732, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 34);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Close);
            // 
            // lbName
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(432, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Re New License";
            // 
            // lLicenseHistory
            // 
            this.lLicenseHistory.AutoSize = true;
            this.lLicenseHistory.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLicenseHistory.LinkColor = System.Drawing.Color.Gray;
            this.lLicenseHistory.Location = new System.Drawing.Point(43, 11);
            this.lLicenseHistory.Name = "lLicenseHistory";
            this.lLicenseHistory.Size = new System.Drawing.Size(158, 21);
            this.lLicenseHistory.TabIndex = 6;
            this.lLicenseHistory.TabStop = true;
            this.lLicenseHistory.Text = "Show License History";
            this.lLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lLicenseHistory_LinkClicked);
            // 
            // lshowLicense
            // 
            this.lshowLicense.AutoSize = true;
            this.lshowLicense.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lshowLicense.LinkColor = System.Drawing.Color.Gray;
            this.lshowLicense.Location = new System.Drawing.Point(226, 11);
            this.lshowLicense.Name = "lshowLicense";
            this.lshowLicense.Size = new System.Drawing.Size(127, 21);
            this.lshowLicense.TabIndex = 5;
            this.lshowLicense.TabStop = true;
            this.lshowLicense.Text = "Show Linces Info";
            this.lshowLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ShowLicense);
            // 
            // ctrlLicenseWithFilter1
            // 
            this.ctrlLicenseWithFilter1.FilterEanble = true;
            this.ctrlLicenseWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlLicenseWithFilter1.Location = new System.Drawing.Point(4, 56);
            this.ctrlLicenseWithFilter1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlLicenseWithFilter1.Name = "ctrlLicenseWithFilter1";
            this.ctrlLicenseWithFilter1.Size = new System.Drawing.Size(1064, 347);
            this.ctrlLicenseWithFilter1.TabIndex = 8;
            this.ctrlLicenseWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlLicenseWithFilter1_OnSelectPerson);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNote);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lbTotalFees);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lbLicenseFees);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lbUsername);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lbApplicationFees);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lbExpirationDate);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lbIssueDate);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lbOldLicenseID);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lbAppDate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lbReNewLicenseID);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lbApplicationID);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(30, 410);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(857, 292);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application  New License";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(74, 219);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(486, 61);
            this.txtNote.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Notes : ";
            // 
            // lbTotalFees
            // 
            this.lbTotalFees.AutoSize = true;
            this.lbTotalFees.Location = new System.Drawing.Point(634, 178);
            this.lbTotalFees.Name = "lbTotalFees";
            this.lbTotalFees.Size = new System.Drawing.Size(36, 20);
            this.lbTotalFees.TabIndex = 19;
            this.lbTotalFees.Text = "???";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(523, 178);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 20);
            this.label13.TabIndex = 18;
            this.label13.Text = "Total Fees : ";
            // 
            // lbLicenseFees
            // 
            this.lbLicenseFees.AutoSize = true;
            this.lbLicenseFees.Location = new System.Drawing.Point(171, 178);
            this.lbLicenseFees.Name = "lbLicenseFees";
            this.lbLicenseFees.Size = new System.Drawing.Size(36, 20);
            this.lbLicenseFees.TabIndex = 17;
            this.lbLicenseFees.Text = "???";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 178);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 20);
            this.label12.TabIndex = 16;
            this.label12.Text = "License Fees : ";
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Location = new System.Drawing.Point(634, 147);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(36, 20);
            this.lbUsername.TabIndex = 15;
            this.lbUsername.Text = "???";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(523, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 20);
            this.label11.TabIndex = 14;
            this.label11.Text = "Created By : ";
            // 
            // lbApplicationFees
            // 
            this.lbApplicationFees.AutoSize = true;
            this.lbApplicationFees.Location = new System.Drawing.Point(172, 147);
            this.lbApplicationFees.Name = "lbApplicationFees";
            this.lbApplicationFees.Size = new System.Drawing.Size(36, 20);
            this.lbApplicationFees.TabIndex = 13;
            this.lbApplicationFees.Text = "???";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "Application Fees : ";
            // 
            // lbExpirationDate
            // 
            this.lbExpirationDate.AutoSize = true;
            this.lbExpirationDate.Location = new System.Drawing.Point(634, 109);
            this.lbExpirationDate.Name = "lbExpirationDate";
            this.lbExpirationDate.Size = new System.Drawing.Size(36, 20);
            this.lbExpirationDate.TabIndex = 11;
            this.lbExpirationDate.Text = "???";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(473, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "Expiration Date : ";
            // 
            // lbIssueDate
            // 
            this.lbIssueDate.AutoSize = true;
            this.lbIssueDate.Location = new System.Drawing.Point(135, 113);
            this.lbIssueDate.Name = "lbIssueDate";
            this.lbIssueDate.Size = new System.Drawing.Size(36, 20);
            this.lbIssueDate.TabIndex = 9;
            this.lbIssueDate.Text = "???";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Issue Date : ";
            // 
            // lbOldLicenseID
            // 
            this.lbOldLicenseID.AutoSize = true;
            this.lbOldLicenseID.Location = new System.Drawing.Point(676, 75);
            this.lbOldLicenseID.Name = "lbOldLicenseID";
            this.lbOldLicenseID.Size = new System.Drawing.Size(36, 20);
            this.lbOldLicenseID.TabIndex = 7;
            this.lbOldLicenseID.Text = "???";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(540, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Old License ID : ";
            // 
            // lbAppDate
            // 
            this.lbAppDate.AutoSize = true;
            this.lbAppDate.Location = new System.Drawing.Point(172, 75);
            this.lbAppDate.Name = "lbAppDate";
            this.lbAppDate.Size = new System.Drawing.Size(36, 20);
            this.lbAppDate.TabIndex = 5;
            this.lbAppDate.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Application Date : ";
            // 
            // lbReNewLicenseID
            // 
            this.lbReNewLicenseID.AutoSize = true;
            this.lbReNewLicenseID.Location = new System.Drawing.Point(676, 38);
            this.lbReNewLicenseID.Name = "lbReNewLicenseID";
            this.lbReNewLicenseID.Size = new System.Drawing.Size(36, 20);
            this.lbReNewLicenseID.TabIndex = 3;
            this.lbReNewLicenseID.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(501, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Renewed License ID : ";
            // 
            // lbApplicationID
            // 
            this.lbApplicationID.AutoSize = true;
            this.lbApplicationID.Location = new System.Drawing.Point(172, 38);
            this.lbApplicationID.Name = "lbApplicationID";
            this.lbApplicationID.Size = new System.Drawing.Size(36, 20);
            this.lbApplicationID.TabIndex = 1;
            this.lbApplicationID.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "R.L.Application ID : ";
            // 
            // frmReNewLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 749);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ctrlLicenseWithFilter1);
            this.Controls.Add(this.lLicenseHistory);
            this.Controls.Add(this.lshowLicense);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSave);
            this.Name = "frmReNewLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReNewLicense";
            this.Load += new System.EventHandler(this.frmReNewLicense_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lLicenseHistory;
        private System.Windows.Forms.LinkLabel lshowLicense;
        private clsPeople.ctrlLicenseWithFilter ctrlLicenseWithFilter1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbTotalFees;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbLicenseFees;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbApplicationFees;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbExpirationDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbIssueDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbOldLicenseID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbAppDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbReNewLicenseID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbApplicationID;
        private System.Windows.Forms.Label label2;
    }
}
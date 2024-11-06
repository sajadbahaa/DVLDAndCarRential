namespace DVLCPresentation
{
    partial class ctrlApplicationInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lviewLicense = new System.Windows.Forms.LinkLabel();
            this.lbTestPassed = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbClassLicenseName = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbDrivingLocalLicenseID = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ctrlApplicationBasic1 = new DVLCPresentation.ctrlApplicationBasic();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lviewLicense);
            this.groupBox2.Controls.Add(this.lbTestPassed);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lbClassLicenseName);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lbDrivingLocalLicenseID);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(8, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(686, 137);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Driving License Application Info";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lviewLicense
            // 
            this.lviewLicense.AutoSize = true;
            this.lviewLicense.Location = new System.Drawing.Point(100, 90);
            this.lviewLicense.Name = "lviewLicense";
            this.lviewLicense.Size = new System.Drawing.Size(99, 21);
            this.lviewLicense.TabIndex = 7;
            this.lviewLicense.TabStop = true;
            this.lviewLicense.Text = "View License";
            this.lviewLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lviewLicense_LinkClicked);
            // 
            // lbTestPassed
            // 
            this.lbTestPassed.AutoSize = true;
            this.lbTestPassed.Location = new System.Drawing.Point(449, 90);
            this.lbTestPassed.Name = "lbTestPassed";
            this.lbTestPassed.Size = new System.Drawing.Size(41, 21);
            this.lbTestPassed.TabIndex = 6;
            this.lbTestPassed.Text = "[???]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(264, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 21);
            this.label10.TabIndex = 5;
            this.label10.Text = "Passed Test :  ";
            // 
            // lbClassLicenseName
            // 
            this.lbClassLicenseName.AutoSize = true;
            this.lbClassLicenseName.Location = new System.Drawing.Point(449, 36);
            this.lbClassLicenseName.Name = "lbClassLicenseName";
            this.lbClassLicenseName.Size = new System.Drawing.Size(41, 21);
            this.lbClassLicenseName.TabIndex = 3;
            this.lbClassLicenseName.Text = "[???]";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(225, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(156, 21);
            this.label12.TabIndex = 2;
            this.label12.Text = "Applied For License : ";
            // 
            // lbDrivingLocalLicenseID
            // 
            this.lbDrivingLocalLicenseID.AutoSize = true;
            this.lbDrivingLocalLicenseID.Location = new System.Drawing.Point(131, 36);
            this.lbDrivingLocalLicenseID.Name = "lbDrivingLocalLicenseID";
            this.lbDrivingLocalLicenseID.Size = new System.Drawing.Size(41, 21);
            this.lbDrivingLocalLicenseID.TabIndex = 1;
            this.lbDrivingLocalLicenseID.Text = "[???]";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 21);
            this.label13.TabIndex = 0;
            this.label13.Text = "D.L.App.ID : ";
            // 
            // ctrlApplicationBasic1
            // 
            this.ctrlApplicationBasic1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlApplicationBasic1.Location = new System.Drawing.Point(4, 154);
            this.ctrlApplicationBasic1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlApplicationBasic1.Name = "ctrlApplicationBasic1";
            this.ctrlApplicationBasic1.Size = new System.Drawing.Size(711, 232);
            this.ctrlApplicationBasic1.TabIndex = 4;
            this.ctrlApplicationBasic1.Load += new System.EventHandler(this.ctrlApplicationBasic1_Load);
            // 
            // ctrlApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlApplicationBasic1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ctrlApplicationInfo";
            this.Size = new System.Drawing.Size(731, 393);
            this.Load += new System.EventHandler(this.ctrlApplicationInfo_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbTestPassed;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbClassLicenseName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbDrivingLocalLicenseID;
        private System.Windows.Forms.Label label13;
        private ctrlApplicationBasic ctrlApplicationBasic1;
        private System.Windows.Forms.LinkLabel lviewLicense;
    }
}

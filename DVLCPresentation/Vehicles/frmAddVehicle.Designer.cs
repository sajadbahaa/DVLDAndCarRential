namespace CRentail.Vehicles
{
    partial class frmAddVehicle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddVehicle));
            this.label1 = new System.Windows.Forms.Label();
            this.lbVehicleID = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.txtMileage = new System.Windows.Forms.TextBox();
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFualType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMakes = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lbYear = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lSetImage = new System.Windows.Forms.LinkLabel();
            this.lRemove = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRentail = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbVehicleName = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lbPlateNumber = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlShareScreen1 = new Lib.ControlPublic.ctrlShareScreen();
            this.label13 = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(785, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vehcile ID :";
            // 
            // lbVehicleID
            // 
            this.lbVehicleID.AutoSize = true;
            this.lbVehicleID.Location = new System.Drawing.Point(887, 18);
            this.lbVehicleID.Name = "lbVehicleID";
            this.lbVehicleID.Size = new System.Drawing.Size(18, 21);
            this.lbVehicleID.TabIndex = 2;
            this.lbVehicleID.Text = "?";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbStatus);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cbLicenseClass);
            this.groupBox1.Controls.Add(this.txtMileage);
            this.groupBox1.Controls.Add(this.cbModel);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbFualType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbMakes);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lbYear);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lSetImage);
            this.groupBox1.Controls.Add(this.lRemove);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbVehicleName);
            this.groupBox1.Controls.Add(this.cbCategory);
            this.groupBox1.Controls.Add(this.lbPlateNumber);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.pbImage);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1183, 431);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 315);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 21);
            this.label12.TabIndex = 42;
            this.label12.Text = "License Class : ";
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.BackColor = System.Drawing.SystemColors.Control;
            this.cbLicenseClass.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Location = new System.Drawing.Point(134, 313);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(353, 28);
            this.cbLicenseClass.TabIndex = 41;
            this.cbLicenseClass.SelectedIndexChanged += new System.EventHandler(this.cbLicenseClass_SelectedIndexChanged);
            // 
            // txtMileage
            // 
            this.txtMileage.Location = new System.Drawing.Point(108, 397);
            this.txtMileage.Name = "txtMileage";
            this.txtMileage.Size = new System.Drawing.Size(113, 28);
            this.txtMileage.TabIndex = 40;
            this.txtMileage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMileage_KeyPress);
            this.txtMileage.Validating += new System.ComponentModel.CancelEventHandler(this.txtMileage_Validating_1);
            // 
            // cbModel
            // 
            this.cbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModel.FormattingEnabled = true;
            this.cbModel.Location = new System.Drawing.Point(134, 210);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(216, 29);
            this.cbModel.TabIndex = 38;
            this.cbModel.SelectedIndexChanged += new System.EventHandler(this.cbModel_SelectedIndexChanged_1);
            this.cbModel.Validating += new System.ComponentModel.CancelEventHandler(this.cbModel_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 21);
            this.label6.TabIndex = 37;
            this.label6.Text = "Model :";
            // 
            // cbFualType
            // 
            this.cbFualType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFualType.FormattingEnabled = true;
            this.cbFualType.Location = new System.Drawing.Point(134, 267);
            this.cbFualType.Name = "cbFualType";
            this.cbFualType.Size = new System.Drawing.Size(302, 29);
            this.cbFualType.TabIndex = 36;
            this.cbFualType.SelectedIndexChanged += new System.EventHandler(this.cbFualType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 21);
            this.label3.TabIndex = 35;
            this.label3.Text = "Fual Type :";
            // 
            // cbMakes
            // 
            this.cbMakes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMakes.FormattingEnabled = true;
            this.cbMakes.Location = new System.Drawing.Point(135, 163);
            this.cbMakes.Name = "cbMakes";
            this.cbMakes.Size = new System.Drawing.Size(223, 29);
            this.cbMakes.TabIndex = 34;
            this.cbMakes.SelectedIndexChanged += new System.EventHandler(this.cbMakes_SelectedIndexChanged);
            this.cbMakes.Validating += new System.ComponentModel.CancelEventHandler(this.cbMakes_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 21);
            this.label7.TabIndex = 33;
            this.label7.Text = "Make :";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(753, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 30;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ONRefresg);
            // 
            // lbYear
            // 
            this.lbYear.AutoSize = true;
            this.lbYear.Location = new System.Drawing.Point(187, 109);
            this.lbYear.Name = "lbYear";
            this.lbYear.Size = new System.Drawing.Size(18, 21);
            this.lbYear.TabIndex = 29;
            this.lbYear.Text = "?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 21);
            this.label5.TabIndex = 28;
            this.label5.Text = "Manafacture Year :";
            // 
            // lSetImage
            // 
            this.lSetImage.AutoSize = true;
            this.lSetImage.Location = new System.Drawing.Point(1090, 356);
            this.lSetImage.Name = "lSetImage";
            this.lSetImage.Size = new System.Drawing.Size(87, 21);
            this.lSetImage.TabIndex = 27;
            this.lSetImage.TabStop = true;
            this.lSetImage.Text = "Set Image";
            this.lSetImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lSetImage_LinkClicked);
            // 
            // lRemove
            // 
            this.lRemove.AutoSize = true;
            this.lRemove.Location = new System.Drawing.Point(958, 356);
            this.lRemove.Name = "lRemove";
            this.lRemove.Size = new System.Drawing.Size(71, 21);
            this.lRemove.TabIndex = 26;
            this.lRemove.TabStop = true;
            this.lRemove.Text = "Remove";
            this.lRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lRemove_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtRentail);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(568, 369);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 52);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // txtRentail
            // 
            this.txtRentail.Location = new System.Drawing.Point(154, 17);
            this.txtRentail.Mask = "00";
            this.txtRentail.Name = "txtRentail";
            this.txtRentail.Size = new System.Drawing.Size(29, 28);
            this.txtRentail.TabIndex = 27;
            this.txtRentail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRentail.Validating += new System.ComponentModel.CancelEventHandler(this.txtMileage_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.AliceBlue;
            this.label11.ForeColor = System.Drawing.Color.SeaGreen;
            this.label11.Location = new System.Drawing.Point(189, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 21);
            this.label11.TabIndex = 25;
            this.label11.Text = "$";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 21);
            this.label8.TabIndex = 26;
            this.label8.Text = "Rential Per Day :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Vehcile Name :";
            // 
            // cbVehicleName
            // 
            this.cbVehicleName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVehicleName.FormattingEnabled = true;
            this.cbVehicleName.Location = new System.Drawing.Point(142, 18);
            this.cbVehicleName.Name = "cbVehicleName";
            this.cbVehicleName.Size = new System.Drawing.Size(602, 29);
            this.cbVehicleName.TabIndex = 17;
            this.cbVehicleName.SelectedIndexChanged += new System.EventHandler(this.cbVehicleName_SelectedIndexChanged);
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(142, 61);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(216, 29);
            this.cbCategory.TabIndex = 19;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // lbPlateNumber
            // 
            this.lbPlateNumber.AutoSize = true;
            this.lbPlateNumber.Location = new System.Drawing.Point(168, 356);
            this.lbPlateNumber.Name = "lbPlateNumber";
            this.lbPlateNumber.Size = new System.Drawing.Size(18, 21);
            this.lbPlateNumber.TabIndex = 6;
            this.lbPlateNumber.Text = "?";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 356);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 21);
            this.label10.TabIndex = 16;
            this.label10.Text = "Plate Number  :";
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(926, 17);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(251, 303);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 15;
            this.pbImage.TabStop = false;
            this.pbImage.Click += new System.EventHandler(this.pbImage_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 400);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 21);
            this.label9.TabIndex = 13;
            this.label9.Text = "Mileage  :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Category :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1067, 511);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(128, 27);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.Save);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(933, 511);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 27);
            this.button2.TabIndex = 5;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.CLose);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlShareScreen1
            // 
            this.ctrlShareScreen1.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlShareScreen1.Location = new System.Drawing.Point(26, 4);
            this.ctrlShareScreen1.Margin = new System.Windows.Forms.Padding(6);
            this.ctrlShareScreen1.Name = "ctrlShareScreen1";
            this.ctrlShareScreen1.Size = new System.Drawing.Size(730, 44);
            this.ctrlShareScreen1.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(294, 400);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 21);
            this.label13.TabIndex = 43;
            this.label13.Text = "Status : ";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(397, 400);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(34, 21);
            this.lbStatus.TabIndex = 44;
            this.lbStatus.Text = "???";
            // 
            // frmAddVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 541);
            this.Controls.Add(this.ctrlShareScreen1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbVehicleID);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmAddVehicle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddVehicle";
            this.Load += new System.EventHandler(this.frmAddVehicle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbVehicleID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.ComboBox cbVehicleName;
        private System.Windows.Forms.Label lbPlateNumber;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox txtRentail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel lSetImage;
        private System.Windows.Forms.LinkLabel lRemove;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Lib.ControlPublic.ctrlShareScreen ctrlShareScreen1;
        private System.Windows.Forms.Label lbYear;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbModel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbFualType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMakes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtMileage;
        private System.Windows.Forms.ComboBox cbLicenseClass;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label label13;
    }
}
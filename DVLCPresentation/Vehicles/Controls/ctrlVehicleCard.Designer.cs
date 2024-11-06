namespace CRentail.Vehicles.Controls
{
    partial class ctrlVehicleCard
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
            this.gb = new System.Windows.Forms.GroupBox();
            this.lbClassName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lEditVehicle = new System.Windows.Forms.LinkLabel();
            this.lbNumDorrs = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbYear = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbVehicleID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbVehicleStatus = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbFualType = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbModel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbMake = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbVehicleName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pb = new System.Windows.Forms.PictureBox();
            this.gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.SuspendLayout();
            // 
            // gb
            // 
            this.gb.Controls.Add(this.lbClassName);
            this.gb.Controls.Add(this.label2);
            this.gb.Controls.Add(this.lEditVehicle);
            this.gb.Controls.Add(this.lbNumDorrs);
            this.gb.Controls.Add(this.label11);
            this.gb.Controls.Add(this.lbYear);
            this.gb.Controls.Add(this.label8);
            this.gb.Controls.Add(this.lbVehicleID);
            this.gb.Controls.Add(this.label3);
            this.gb.Controls.Add(this.lbVehicleStatus);
            this.gb.Controls.Add(this.label7);
            this.gb.Controls.Add(this.lbFualType);
            this.gb.Controls.Add(this.label6);
            this.gb.Controls.Add(this.lbModel);
            this.gb.Controls.Add(this.label5);
            this.gb.Controls.Add(this.lbMake);
            this.gb.Controls.Add(this.label4);
            this.gb.Controls.Add(this.lbVehicleName);
            this.gb.Controls.Add(this.label1);
            this.gb.Controls.Add(this.pb);
            this.gb.Location = new System.Drawing.Point(7, 3);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(870, 361);
            this.gb.TabIndex = 0;
            this.gb.TabStop = false;
            this.gb.Text = "   ";
            this.gb.Enter += new System.EventHandler(this.gb_Enter);
            // 
            // lbClassName
            // 
            this.lbClassName.AutoSize = true;
            this.lbClassName.Location = new System.Drawing.Point(435, 322);
            this.lbClassName.Name = "lbClassName";
            this.lbClassName.Size = new System.Drawing.Size(36, 20);
            this.lbClassName.TabIndex = 22;
            this.lbClassName.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Class Name : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lEditVehicle
            // 
            this.lEditVehicle.AutoSize = true;
            this.lEditVehicle.Location = new System.Drawing.Point(93, 322);
            this.lEditVehicle.Name = "lEditVehicle";
            this.lEditVehicle.Size = new System.Drawing.Size(93, 20);
            this.lEditVehicle.TabIndex = 20;
            this.lEditVehicle.TabStop = true;
            this.lEditVehicle.Text = "Edit Vehicle";
            this.lEditVehicle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lbNumDorrs
            // 
            this.lbNumDorrs.AutoSize = true;
            this.lbNumDorrs.Location = new System.Drawing.Point(435, 290);
            this.lbNumDorrs.Name = "lbNumDorrs";
            this.lbNumDorrs.Size = new System.Drawing.Size(36, 20);
            this.lbNumDorrs.TabIndex = 19;
            this.lbNumDorrs.Text = "???";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(306, 290);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 20);
            this.label11.TabIndex = 18;
            this.label11.Text = "Num Doors  : ";
            // 
            // lbYear
            // 
            this.lbYear.AutoSize = true;
            this.lbYear.Location = new System.Drawing.Point(427, 257);
            this.lbYear.Name = "lbYear";
            this.lbYear.Size = new System.Drawing.Size(36, 20);
            this.lbYear.TabIndex = 15;
            this.lbYear.Text = "???";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(306, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Year  : ";
            // 
            // lbVehicleID
            // 
            this.lbVehicleID.AutoSize = true;
            this.lbVehicleID.Location = new System.Drawing.Point(427, 22);
            this.lbVehicleID.Name = "lbVehicleID";
            this.lbVehicleID.Size = new System.Drawing.Size(36, 20);
            this.lbVehicleID.TabIndex = 13;
            this.lbVehicleID.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Vehicle ID   : ";
            // 
            // lbVehicleStatus
            // 
            this.lbVehicleStatus.AutoSize = true;
            this.lbVehicleStatus.Location = new System.Drawing.Point(427, 217);
            this.lbVehicleStatus.Name = "lbVehicleStatus";
            this.lbVehicleStatus.Size = new System.Drawing.Size(36, 20);
            this.lbVehicleStatus.TabIndex = 11;
            this.lbVehicleStatus.Text = "???";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(297, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Is Availabel  : ";
            // 
            // lbFualType
            // 
            this.lbFualType.AutoSize = true;
            this.lbFualType.Location = new System.Drawing.Point(427, 177);
            this.lbFualType.Name = "lbFualType";
            this.lbFualType.Size = new System.Drawing.Size(36, 20);
            this.lbFualType.TabIndex = 9;
            this.lbFualType.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(306, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Fual Type  : ";
            // 
            // lbModel
            // 
            this.lbModel.AutoSize = true;
            this.lbModel.Location = new System.Drawing.Point(427, 137);
            this.lbModel.Name = "lbModel";
            this.lbModel.Size = new System.Drawing.Size(36, 20);
            this.lbModel.TabIndex = 7;
            this.lbModel.Text = "???";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(306, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Model  : ";
            // 
            // lbMake
            // 
            this.lbMake.AutoSize = true;
            this.lbMake.Location = new System.Drawing.Point(427, 97);
            this.lbMake.Name = "lbMake";
            this.lbMake.Size = new System.Drawing.Size(36, 20);
            this.lbMake.TabIndex = 5;
            this.lbMake.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(306, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Make  : ";
            // 
            // lbVehicleName
            // 
            this.lbVehicleName.AutoSize = true;
            this.lbVehicleName.Location = new System.Drawing.Point(427, 61);
            this.lbVehicleName.Name = "lbVehicleName";
            this.lbVehicleName.Size = new System.Drawing.Size(36, 20);
            this.lbVehicleName.TabIndex = 3;
            this.lbVehicleName.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Vehicle Name : ";
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(10, 18);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(272, 292);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb.TabIndex = 0;
            this.pb.TabStop = false;
            // 
            // ctrlVehicleCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ctrlVehicleCard";
            this.Size = new System.Drawing.Size(884, 367);
            this.Load += new System.EventHandler(this.ctrlVehicleCard_Load);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.Label lbVehicleName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbVehicleStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbFualType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbModel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbMake;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbVehicleID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbNumDorrs;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbYear;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel lEditVehicle;
        private System.Windows.Forms.Label lbClassName;
        private System.Windows.Forms.Label label2;
    }
}

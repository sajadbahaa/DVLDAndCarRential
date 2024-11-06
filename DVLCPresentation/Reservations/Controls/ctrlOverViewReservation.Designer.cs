namespace DVLCPresentation.Reservations.Controls
{
    partial class ctrlOverViewReservation
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lbApplicationStatus = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCustomerInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVehicleInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.lbEndDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbStartDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbRentialPerDay = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbInitalRentialDay = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbTotalDueAmount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pbCarRential = new System.Windows.Forms.PictureBox();
            this.pbCustomer = new System.Windows.Forms.PictureBox();
            this.lbReservationID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbMessage = new System.Windows.Forms.Label();
            this.lbMileage = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRetunCar = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarRential)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Application Status :";
            // 
            // lbApplicationStatus
            // 
            this.lbApplicationStatus.AutoSize = true;
            this.lbApplicationStatus.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationStatus.Location = new System.Drawing.Point(181, 218);
            this.lbApplicationStatus.Name = "lbApplicationStatus";
            this.lbApplicationStatus.Size = new System.Drawing.Size(30, 19);
            this.lbApplicationStatus.TabIndex = 4;
            this.lbApplicationStatus.Text = "???";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCustomerInfo,
            this.btnVehicleInfo,
            this.btnRetunCar});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 92);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // btnCustomerInfo
            // 
            this.btnCustomerInfo.Name = "btnCustomerInfo";
            this.btnCustomerInfo.Size = new System.Drawing.Size(182, 22);
            this.btnCustomerInfo.Text = "Show Customer info";
            this.btnCustomerInfo.Click += new System.EventHandler(this.showCustomerInfoToolStripMenuItem_Click);
            // 
            // btnVehicleInfo
            // 
            this.btnVehicleInfo.Name = "btnVehicleInfo";
            this.btnVehicleInfo.Size = new System.Drawing.Size(182, 22);
            this.btnVehicleInfo.Text = "Show Vehicle Info";
            this.btnVehicleInfo.Click += new System.EventHandler(this.showVehicleInfoToolStripMenuItem_Click);
            // 
            // lbEndDate
            // 
            this.lbEndDate.AutoSize = true;
            this.lbEndDate.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEndDate.Location = new System.Drawing.Point(176, 61);
            this.lbEndDate.Name = "lbEndDate";
            this.lbEndDate.Size = new System.Drawing.Size(30, 19);
            this.lbEndDate.TabIndex = 6;
            this.lbEndDate.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "End Date :";
            // 
            // lbStartDate
            // 
            this.lbStartDate.AutoSize = true;
            this.lbStartDate.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStartDate.Location = new System.Drawing.Point(176, 21);
            this.lbStartDate.Name = "lbStartDate";
            this.lbStartDate.Size = new System.Drawing.Size(30, 19);
            this.lbStartDate.TabIndex = 8;
            this.lbStartDate.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Start Date :";
            // 
            // lbRentialPerDay
            // 
            this.lbRentialPerDay.AutoSize = true;
            this.lbRentialPerDay.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRentialPerDay.Location = new System.Drawing.Point(176, 102);
            this.lbRentialPerDay.Name = "lbRentialPerDay";
            this.lbRentialPerDay.Size = new System.Drawing.Size(30, 19);
            this.lbRentialPerDay.TabIndex = 10;
            this.lbRentialPerDay.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Rentail Per Day :";
            // 
            // lbInitalRentialDay
            // 
            this.lbInitalRentialDay.AutoSize = true;
            this.lbInitalRentialDay.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInitalRentialDay.Location = new System.Drawing.Point(176, 138);
            this.lbInitalRentialDay.Name = "lbInitalRentialDay";
            this.lbInitalRentialDay.Size = new System.Drawing.Size(30, 19);
            this.lbInitalRentialDay.TabIndex = 12;
            this.lbInitalRentialDay.Text = "???";
            this.lbInitalRentialDay.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Inital Rential Day  :";
            // 
            // lbTotalDueAmount
            // 
            this.lbTotalDueAmount.AutoSize = true;
            this.lbTotalDueAmount.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalDueAmount.Location = new System.Drawing.Point(176, 177);
            this.lbTotalDueAmount.Name = "lbTotalDueAmount";
            this.lbTotalDueAmount.Size = new System.Drawing.Size(30, 19);
            this.lbTotalDueAmount.TabIndex = 14;
            this.lbTotalDueAmount.Text = "???";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 20);
            this.label10.TabIndex = 13;
            this.label10.Text = "Total Due Amount  :";
            // 
            // pbCarRential
            // 
            this.pbCarRential.Location = new System.Drawing.Point(323, 3);
            this.pbCarRential.Name = "pbCarRential";
            this.pbCarRential.Size = new System.Drawing.Size(208, 234);
            this.pbCarRential.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCarRential.TabIndex = 1;
            this.pbCarRential.TabStop = false;
            // 
            // pbCustomer
            // 
            this.pbCustomer.Location = new System.Drawing.Point(537, 3);
            this.pbCustomer.Name = "pbCustomer";
            this.pbCustomer.Size = new System.Drawing.Size(195, 234);
            this.pbCustomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCustomer.TabIndex = 0;
            this.pbCustomer.TabStop = false;
            // 
            // lbReservationID
            // 
            this.lbReservationID.AutoSize = true;
            this.lbReservationID.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReservationID.Location = new System.Drawing.Point(181, 251);
            this.lbReservationID.Name = "lbReservationID";
            this.lbReservationID.Size = new System.Drawing.Size(30, 19);
            this.lbReservationID.TabIndex = 17;
            this.lbReservationID.Text = "???";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Reservation ID : ";
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMessage.ForeColor = System.Drawing.Color.Red;
            this.lbMessage.Location = new System.Drawing.Point(363, 251);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(30, 19);
            this.lbMessage.TabIndex = 15;
            this.lbMessage.Text = "???";
            // 
            // lbMileage
            // 
            this.lbMileage.AutoSize = true;
            this.lbMileage.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMileage.Location = new System.Drawing.Point(181, 283);
            this.lbMileage.Name = "lbMileage";
            this.lbMileage.Size = new System.Drawing.Size(30, 19);
            this.lbMileage.TabIndex = 19;
            this.lbMileage.Text = "???";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 282);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Milege  : ";
            // 
            // btnRetunCar
            // 
            this.btnRetunCar.Name = "btnRetunCar";
            this.btnRetunCar.Size = new System.Drawing.Size(182, 22);
            this.btnRetunCar.Text = "Return Vehicle";
            this.btnRetunCar.Click += new System.EventHandler(this.returnVehicleToolStripMenuItem_Click);
            // 
            // ctrlOverViewReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.lbMileage);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbReservationID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.lbTotalDueAmount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbInitalRentialDay);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbRentialPerDay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbStartDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbEndDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbApplicationStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbCarRential);
            this.Controls.Add(this.pbCustomer);
            this.Name = "ctrlOverViewReservation";
            this.Size = new System.Drawing.Size(735, 310);
            this.Load += new System.EventHandler(this.ctrlOverViewReservation_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCarRential)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCustomer;
        private System.Windows.Forms.PictureBox pbCarRential;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbApplicationStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnCustomerInfo;
        private System.Windows.Forms.ToolStripMenuItem btnVehicleInfo;
        private System.Windows.Forms.Label lbEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbStartDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbRentialPerDay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbInitalRentialDay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbTotalDueAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbReservationID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Label lbMileage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem btnRetunCar;
    }
}

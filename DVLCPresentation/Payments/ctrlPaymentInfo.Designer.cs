namespace DVLCPresentation.Payments
{
    partial class ctrlPaymentInfo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbReturnID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbUpdatePaymentDate = new System.Windows.Forms.Label();
            this.lbMessage = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbRefundAmount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbTotalRemaining = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbActualTotalAmount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbPaymentDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbInitalTotalAmount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbCutomerName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbPaymentID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbReturnID);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbUpdatePaymentDate);
            this.groupBox1.Controls.Add(this.lbMessage);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lbRefundAmount);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lbTotalRemaining);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lbActualTotalAmount);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lbPaymentDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lbInitalTotalAmount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbCutomerName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lbPaymentID);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(692, 291);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Info";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lbReturnID
            // 
            this.lbReturnID.AutoSize = true;
            this.lbReturnID.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReturnID.Location = new System.Drawing.Point(157, 227);
            this.lbReturnID.Name = "lbReturnID";
            this.lbReturnID.Size = new System.Drawing.Size(26, 17);
            this.lbReturnID.TabIndex = 17;
            this.lbReturnID.Text = "???";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Return ID : ";
            // 
            // lbUpdatePaymentDate
            // 
            this.lbUpdatePaymentDate.AutoSize = true;
            this.lbUpdatePaymentDate.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUpdatePaymentDate.Location = new System.Drawing.Point(157, 191);
            this.lbUpdatePaymentDate.Name = "lbUpdatePaymentDate";
            this.lbUpdatePaymentDate.Size = new System.Drawing.Size(26, 17);
            this.lbUpdatePaymentDate.TabIndex = 6;
            this.lbUpdatePaymentDate.Text = "???";
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMessage.ForeColor = System.Drawing.Color.Red;
            this.lbMessage.Location = new System.Drawing.Point(15, 259);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(223, 17);
            this.lbMessage.TabIndex = 15;
            this.lbMessage.Text = "Processing Completed Successfully";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 191);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 17);
            this.label11.TabIndex = 5;
            this.label11.Text = "Update Payment  : ";
            // 
            // lbRefundAmount
            // 
            this.lbRefundAmount.AutoSize = true;
            this.lbRefundAmount.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRefundAmount.Location = new System.Drawing.Point(157, 157);
            this.lbRefundAmount.Name = "lbRefundAmount";
            this.lbRefundAmount.Size = new System.Drawing.Size(26, 17);
            this.lbRefundAmount.TabIndex = 14;
            this.lbRefundAmount.Text = "???";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 157);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 17);
            this.label10.TabIndex = 13;
            this.label10.Text = "Refund Amount   : ";
            // 
            // lbTotalRemaining
            // 
            this.lbTotalRemaining.AutoSize = true;
            this.lbTotalRemaining.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalRemaining.Location = new System.Drawing.Point(475, 115);
            this.lbTotalRemaining.Name = "lbTotalRemaining";
            this.lbTotalRemaining.Size = new System.Drawing.Size(26, 17);
            this.lbTotalRemaining.TabIndex = 12;
            this.lbTotalRemaining.Text = "???";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(330, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 17);
            this.label9.TabIndex = 11;
            this.label9.Text = "Total Remaining  : ";
            // 
            // lbActualTotalAmount
            // 
            this.lbActualTotalAmount.AutoSize = true;
            this.lbActualTotalAmount.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbActualTotalAmount.Location = new System.Drawing.Point(189, 115);
            this.lbActualTotalAmount.Name = "lbActualTotalAmount";
            this.lbActualTotalAmount.Size = new System.Drawing.Size(26, 17);
            this.lbActualTotalAmount.TabIndex = 10;
            this.lbActualTotalAmount.Text = "???";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(177, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Actual Total Due Amount : ";
            // 
            // lbPaymentDate
            // 
            this.lbPaymentDate.AutoSize = true;
            this.lbPaymentDate.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPaymentDate.Location = new System.Drawing.Point(475, 85);
            this.lbPaymentDate.Name = "lbPaymentDate";
            this.lbPaymentDate.Size = new System.Drawing.Size(26, 17);
            this.lbPaymentDate.TabIndex = 8;
            this.lbPaymentDate.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(330, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Payment Date  : ";
            // 
            // lbInitalTotalAmount
            // 
            this.lbInitalTotalAmount.AutoSize = true;
            this.lbInitalTotalAmount.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInitalTotalAmount.Location = new System.Drawing.Point(475, 49);
            this.lbInitalTotalAmount.Name = "lbInitalTotalAmount";
            this.lbInitalTotalAmount.Size = new System.Drawing.Size(26, 17);
            this.lbInitalTotalAmount.TabIndex = 6;
            this.lbInitalTotalAmount.Text = "???";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(310, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Inital Total Amount  : ";
            // 
            // lbCutomerName
            // 
            this.lbCutomerName.AutoSize = true;
            this.lbCutomerName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCutomerName.Location = new System.Drawing.Point(134, 72);
            this.lbCutomerName.Name = "lbCutomerName";
            this.lbCutomerName.Size = new System.Drawing.Size(26, 17);
            this.lbCutomerName.TabIndex = 4;
            this.lbCutomerName.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Customer Name  : ";
            // 
            // lbPaymentID
            // 
            this.lbPaymentID.AutoSize = true;
            this.lbPaymentID.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPaymentID.Location = new System.Drawing.Point(102, 34);
            this.lbPaymentID.Name = "lbPaymentID";
            this.lbPaymentID.Size = new System.Drawing.Size(26, 17);
            this.lbPaymentID.TabIndex = 2;
            this.lbPaymentID.Text = "???";
            // 
            // pb
            // 
            this.pictureBox1.Image = global::DVLCPresentation.Properties.Resources.Coins;
            this.pictureBox1.Location = new System.Drawing.Point(293, 157);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(230, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Payment ID : ";
            // 
            // ctrlPaymentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlPaymentInfo";
            this.Size = new System.Drawing.Size(717, 310);
            this.Load += new System.EventHandler(this.ctrlPaymentInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbInitalTotalAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbCutomerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbPaymentID;
        private System.Windows.Forms.Label lbRefundAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbTotalRemaining;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbActualTotalAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbPaymentDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbUpdatePaymentDate;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbReturnID;
        private System.Windows.Forms.Label label8;
    }
}

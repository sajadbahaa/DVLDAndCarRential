namespace DVLCPresentation.Reservations.Controls
{
    partial class ctrlCountReservationStatus
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
            this.lbCountCancel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbCountCompleted = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbCountNew = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbCountCancel);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lbCountCompleted);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lbCountNew);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 78);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lbCountCancel
            // 
            this.lbCountCancel.AutoSize = true;
            this.lbCountCancel.Location = new System.Drawing.Point(535, 35);
            this.lbCountCancel.Name = "lbCountCancel";
            this.lbCountCancel.Size = new System.Drawing.Size(34, 21);
            this.lbCountCancel.TabIndex = 11;
            this.lbCountCancel.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(429, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "Cancel  : ";
            // 
            // lbCountCompleted
            // 
            this.lbCountCompleted.AutoSize = true;
            this.lbCountCompleted.Location = new System.Drawing.Point(343, 35);
            this.lbCountCompleted.Name = "lbCountCompleted";
            this.lbCountCompleted.Size = new System.Drawing.Size(34, 21);
            this.lbCountCompleted.TabIndex = 9;
            this.lbCountCompleted.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Completed  : ";
            // 
            // lbCountNew
            // 
            this.lbCountNew.AutoSize = true;
            this.lbCountNew.Location = new System.Drawing.Point(108, 35);
            this.lbCountNew.Name = "lbCountNew";
            this.lbCountNew.Size = new System.Drawing.Size(34, 21);
            this.lbCountNew.TabIndex = 7;
            this.lbCountNew.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "New : ";
            // 
            // ctrlCountReservationStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ctrlCountReservationStatus";
            this.Size = new System.Drawing.Size(649, 98);
            this.Load += new System.EventHandler(this.ctrlCountReservationStatus_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbCountCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbCountCompleted;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbCountNew;
        private System.Windows.Forms.Label label1;
    }
}

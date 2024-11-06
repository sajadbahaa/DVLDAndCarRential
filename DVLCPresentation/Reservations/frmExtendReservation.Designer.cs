namespace DVLCPresentation.Reservations
{
    partial class frmExtendReservation
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
            this.ctrlReservationWithFilter1 = new DVLCPresentation.Reservations.Controls.ctrlReservationWithFilter();
            this.label1 = new System.Windows.Forms.Label();
            this.dtPeriod = new System.Windows.Forms.DateTimePicker();
            this.btnExtend = new System.Windows.Forms.Button();
            this.lshowReservation = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // ctrlReservationWithFilter1
            // 
            this.ctrlReservationWithFilter1.Location = new System.Drawing.Point(12, 12);
            this.ctrlReservationWithFilter1.Name = "ctrlReservationWithFilter1";
            this.ctrlReservationWithFilter1.Size = new System.Drawing.Size(859, 355);
            this.ctrlReservationWithFilter1.TabIndex = 0;
            this.ctrlReservationWithFilter1.OnReservationSelected += new System.EventHandler<clsPeople.clsReservations>(this.ctrlReservationWithFilter1_OnReservationSelected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 381);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Period : ";
            // 
            // dtPeriod
            // 
            this.dtPeriod.Location = new System.Drawing.Point(115, 381);
            this.dtPeriod.Name = "dtPeriod";
            this.dtPeriod.Size = new System.Drawing.Size(208, 20);
            this.dtPeriod.TabIndex = 2;
            // 
            // btnExtend
            // 
            this.btnExtend.Location = new System.Drawing.Point(731, 399);
            this.btnExtend.Name = "btnExtend";
            this.btnExtend.Size = new System.Drawing.Size(127, 39);
            this.btnExtend.TabIndex = 3;
            this.btnExtend.Text = "Extend Reservation";
            this.btnExtend.UseVisualStyleBackColor = true;
            this.btnExtend.Click += new System.EventHandler(this.OnExtendPeriod);
            // 
            // lshowReservation
            // 
            this.lshowReservation.AutoSize = true;
            this.lshowReservation.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lshowReservation.Location = new System.Drawing.Point(716, 12);
            this.lshowReservation.Name = "linkLabel1";
            this.lshowReservation.Size = new System.Drawing.Size(155, 22);
            this.lshowReservation.TabIndex = 4;
            this.lshowReservation.TabStop = true;
            this.lshowReservation.Text = "Show Reservation";
            this.lshowReservation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmExtendReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 450);
            this.Controls.Add(this.lshowReservation);
            this.Controls.Add(this.btnExtend);
            this.Controls.Add(this.dtPeriod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlReservationWithFilter1);
            this.Name = "frmExtendReservation";
            this.Text = "frmExtendReservation";
            this.Load += new System.EventHandler(this.frmExtendReservation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ctrlReservationWithFilter ctrlReservationWithFilter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtPeriod;
        private System.Windows.Forms.Button btnExtend;
        private System.Windows.Forms.LinkLabel lshowReservation;
    }
}
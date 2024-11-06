namespace DVLCPresentation.Reservations
{
    partial class frmReservationStatics
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
            this.ctrlCountReservationStatus1 = new DVLCPresentation.Reservations.Controls.ctrlCountReservationStatus();
            this.SuspendLayout();
            // 
            // ctrlCountReservationStatus1
            // 
            this.ctrlCountReservationStatus1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlCountReservationStatus1.Location = new System.Drawing.Point(67, 33);
            this.ctrlCountReservationStatus1.Margin = new System.Windows.Forms.Padding(5);
            this.ctrlCountReservationStatus1.Name = "ctrlCountReservationStatus1";
            this.ctrlCountReservationStatus1.Size = new System.Drawing.Size(644, 88);
            this.ctrlCountReservationStatus1.TabIndex = 0;
            // 
            // frmReservationStatics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ctrlCountReservationStatus1);
            this.Name = "frmReservationStatics";
            this.Text = "frmReservationStatics";
            this.Load += new System.EventHandler(this.frmReservationStatics_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlCountReservationStatus ctrlCountReservationStatus1;
    }
}
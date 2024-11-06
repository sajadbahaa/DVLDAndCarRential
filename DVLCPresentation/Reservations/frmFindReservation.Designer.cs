namespace DVLCPresentation.Reservations
{
    partial class frmFindReservation
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
            this.SuspendLayout();
            // 
            // ctrlReservationWithFilter1
            // 
            this.ctrlReservationWithFilter1.Location = new System.Drawing.Point(12, 12);
            this.ctrlReservationWithFilter1.Name = "ctrlReservationWithFilter1";
            this.ctrlReservationWithFilter1.Size = new System.Drawing.Size(749, 355);
            this.ctrlReservationWithFilter1.TabIndex = 0;
            this.ctrlReservationWithFilter1.OnReservationSelected += new System.EventHandler<clsPeople.clsReservations>(this.ctrlReservationWithFilter1_OnReservationSelected);
            // 
            // frmFindReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 382);
            this.Controls.Add(this.ctrlReservationWithFilter1);
            this.Name = "frmFindReservation";
            this.Text = "frmFindReservation";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlReservationWithFilter ctrlReservationWithFilter1;
    }
}
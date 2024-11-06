namespace DVLCPresentation.Reservations
{
    partial class frmShowReservationInfo
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
            this.ctrlOverViewReservation1 = new DVLCPresentation.Reservations.Controls.ctrlOverViewReservation();
            this.SuspendLayout();
            // 
            // ctrlOverViewReservation1
            // 
            this.ctrlOverViewReservation1.Location = new System.Drawing.Point(3, 2);
            this.ctrlOverViewReservation1.Name = "ctrlOverViewReservation1";
            this.ctrlOverViewReservation1.Size = new System.Drawing.Size(735, 333);
            this.ctrlOverViewReservation1.TabIndex = 0;
            // 
            // frmShowReservationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ctrlOverViewReservation1);
            this.Name = "frmShowReservationInfo";
            this.Text = "frmShowReservationInfo";
            this.Load += new System.EventHandler(this.frmShowReservationInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlOverViewReservation ctrlOverViewReservation1;
    }
}
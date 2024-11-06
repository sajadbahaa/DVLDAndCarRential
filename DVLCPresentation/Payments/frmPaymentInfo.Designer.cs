namespace DVLCPresentation.Payments
{
    partial class frmPaymentInfo
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
            this.ctrlPaymentInfo1 = new DVLCPresentation.Payments.ctrlPaymentInfo();
            this.SuspendLayout();
            // 
            // ctrlPaymentInfo1
            // 
            this.ctrlPaymentInfo1.Location = new System.Drawing.Point(106, 27);
            this.ctrlPaymentInfo1.Name = "ctrlPaymentInfo1";
            this.ctrlPaymentInfo1.Size = new System.Drawing.Size(654, 320);
            this.ctrlPaymentInfo1.TabIndex = 0;
            // 
            // frmPaymentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ctrlPaymentInfo1);
            this.Name = "frmPaymentInfo";
            this.Text = "frmPaymentInfo";
            this.Load += new System.EventHandler(this.frmPaymentInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPaymentInfo ctrlPaymentInfo1;
    }
}
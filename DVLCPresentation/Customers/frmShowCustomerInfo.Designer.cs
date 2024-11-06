namespace DVLCPresentation.Customers
{
    partial class frmShowCustomerInfo
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
            this.ctrlOverViewCustomers1 = new DVLCPresentation.Customers.Controls.ctrlOverViewCustomers();
            this.SuspendLayout();
            // 
            // ctrlOverViewCustomers1
            // 
            this.ctrlOverViewCustomers1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlOverViewCustomers1.Location = new System.Drawing.Point(13, 4);
            this.ctrlOverViewCustomers1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlOverViewCustomers1.Name = "ctrlOverViewCustomers1";
            this.ctrlOverViewCustomers1.Size = new System.Drawing.Size(363, 371);
            this.ctrlOverViewCustomers1.TabIndex = 0;
            // 
            // frmShowCustomerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 404);
            this.Controls.Add(this.ctrlOverViewCustomers1);
            this.Name = "frmShowCustomerInfo";
            this.Text = "frmShowCustomerInfo";
            this.Load += new System.EventHandler(this.frmShowCustomerInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlOverViewCustomers ctrlOverViewCustomers1;
    }
}
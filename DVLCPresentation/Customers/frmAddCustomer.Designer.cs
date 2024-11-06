namespace DVLCPresentation.Customers
{
    partial class frmAddCustomer
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
            this.ctrlDriverWithFilter1 = new DVLCPresentation.Drivers.ctrlDriverWithFilter();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCusomterID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlDriverWithFilter1
            // 
            this.ctrlDriverWithFilter1.FilterEnable = true;
            this.ctrlDriverWithFilter1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlDriverWithFilter1.Location = new System.Drawing.Point(8, 5);
            this.ctrlDriverWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlDriverWithFilter1.Name = "ctrlDriverWithFilter1";
            this.ctrlDriverWithFilter1.Size = new System.Drawing.Size(596, 433);
            this.ctrlDriverWithFilter1.TabIndex = 0;
            this.ctrlDriverWithFilter1.OnDriverSelected += new System.EventHandler<clsPeople.clsDriver>(this.ctrlDriverWithFilter1_OnDriverSelected);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomer.Location = new System.Drawing.Point(436, 438);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(144, 35);
            this.btnAddCustomer.TabIndex = 2;
            this.btnAddCustomer.Text = "Add Customer";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(268, 438);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Close);
            // 
            // lbName
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(600, 9);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(127, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = ": Customer ID ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbCusomterID
            // 
            this.lbCusomterID.AutoSize = true;
            this.lbCusomterID.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCusomterID.Location = new System.Drawing.Point(724, 9);
            this.lbCusomterID.Name = "lbCusomterID";
            this.lbCusomterID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbCusomterID.Size = new System.Drawing.Size(34, 22);
            this.lbCusomterID.TabIndex = 6;
            this.lbCusomterID.Text = "???";
            this.lbCusomterID.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmAddCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 482);
            this.Controls.Add(this.lbCusomterID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.ctrlDriverWithFilter1);
            this.Name = "frmAddCustomer";
            this.Text = "frmAddCustomer";
            this.Load += new System.EventHandler(this.frmAddCustomer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Drivers.ctrlDriverWithFilter ctrlDriverWithFilter1;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCusomterID;
    }
}
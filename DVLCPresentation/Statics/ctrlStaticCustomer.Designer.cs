namespace DVLCPresentation.Statics
{
    partial class ctrlStaticCustomer
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbStstus = new System.Windows.Forms.Label();
            this.LShowCustomerInfo = new System.Windows.Forms.LinkLabel();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.pbCustomerImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCustomerImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status : ";
            // 
            // lbStstus
            // 
            this.lbStstus.AutoSize = true;
            this.lbStstus.Location = new System.Drawing.Point(85, 304);
            this.lbStstus.Name = "lbStstus";
            this.lbStstus.Size = new System.Drawing.Size(30, 20);
            this.lbStstus.TabIndex = 1;
            this.lbStstus.Text = "???";
            // 
            // LShowCustomerInfo
            // 
            this.LShowCustomerInfo.AutoSize = true;
            this.LShowCustomerInfo.Location = new System.Drawing.Point(50, 266);
            this.LShowCustomerInfo.Name = "LShowCustomerInfo";
            this.LShowCustomerInfo.Size = new System.Drawing.Size(112, 20);
            this.LShowCustomerInfo.TabIndex = 3;
            this.LShowCustomerInfo.TabStop = true;
            this.LShowCustomerInfo.Text = "Customer Info";
            this.LShowCustomerInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LShowCustomerInfo_LinkClicked);
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(6, 337);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(220, 33);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 4;
            this.pbImage.TabStop = false;
            // 
            // pbCustomerImage
            // 
            this.pbCustomerImage.Location = new System.Drawing.Point(3, 3);
            this.pbCustomerImage.Name = "pbCustomerImage";
            this.pbCustomerImage.Size = new System.Drawing.Size(220, 256);
            this.pbCustomerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCustomerImage.TabIndex = 2;
            this.pbCustomerImage.TabStop = false;
            // 
            // ctrlStaticCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.LShowCustomerInfo);
            this.Controls.Add(this.pbCustomerImage);
            this.Controls.Add(this.lbStstus);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ctrlStaticCustomer";
            this.Size = new System.Drawing.Size(226, 373);
            this.Load += new System.EventHandler(this.ctrlStaticCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCustomerImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbStstus;
        private System.Windows.Forms.PictureBox pbCustomerImage;
        private System.Windows.Forms.LinkLabel LShowCustomerInfo;
        private System.Windows.Forms.PictureBox pbImage;
    }
}

namespace DVLCPresentation
{
    partial class frmShowIntetnationalLicense
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
            this.ctrlShowInternationalLicense1 = new DVLCPresentation.ctrlShowInternationalLicense();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlShowInternationalLicense1
            // 
            this.ctrlShowInternationalLicense1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlShowInternationalLicense1.Location = new System.Drawing.Point(9, 59);
            this.ctrlShowInternationalLicense1.Margin = new System.Windows.Forms.Padding(5);
            this.ctrlShowInternationalLicense1.Name = "ctrlShowInternationalLicense1";
            this.ctrlShowInternationalLicense1.Size = new System.Drawing.Size(970, 263);
            this.ctrlShowInternationalLicense1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Close);
            // 
            // frmShowIntetnationalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 318);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlShowInternationalLicense1);
            this.Name = "frmShowIntetnationalLicense";
            this.Text = "frmShowIntetnationalLicense";
            this.Load += new System.EventHandler(this.LoadDate);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlShowInternationalLicense ctrlShowInternationalLicense1;
        private System.Windows.Forms.Button button1;
    }
}
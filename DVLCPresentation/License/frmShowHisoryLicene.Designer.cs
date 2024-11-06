namespace DVLCPresentation
{
    partial class frmShowHisoryLicene
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
            this.button1 = new System.Windows.Forms.Button();
            this.ctrlFilterBy1 = new DVLCPresentation.PersonCardWithFilter();
            this.ctrShowLocalAndInternationalDate1 = new DVLCPresentation.ctrShowLocalAndInternationalDate();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(527, 455);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Close);
            // 
            // ctrlFilterBy1
            // 
            this.ctrlFilterBy1.FilterEnable = true;
            this.ctrlFilterBy1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlFilterBy1.Location = new System.Drawing.Point(4, 5);
            this.ctrlFilterBy1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlFilterBy1.Name = "ctrlFilterBy1";
            this.ctrlFilterBy1.Size = new System.Drawing.Size(530, 444);
            this.ctrlFilterBy1.TabIndex = 0;
            this.ctrlFilterBy1.OnPersonSeleced += new System.Action<int>(this.ctrlFilterBy1_OnPersonSeleced);
            // 
            // ctrShowLocalAndInternationalDate1
            // 
            this.ctrShowLocalAndInternationalDate1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrShowLocalAndInternationalDate1.Location = new System.Drawing.Point(542, 14);
            this.ctrShowLocalAndInternationalDate1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrShowLocalAndInternationalDate1.Name = "ctrShowLocalAndInternationalDate1";
            this.ctrShowLocalAndInternationalDate1.Size = new System.Drawing.Size(705, 439);
            this.ctrShowLocalAndInternationalDate1.TabIndex = 3;
            this.ctrShowLocalAndInternationalDate1.Load += new System.EventHandler(this.ctrShowLocalAndInternationalDate1_Load);
            // 
            // frmShowHisoryLicene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 507);
            this.Controls.Add(this.ctrShowLocalAndInternationalDate1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlFilterBy1);
            this.Name = "frmShowHisoryLicene";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLoadInternationalAndLocalLicense";
            this.Load += new System.EventHandler(this.frmLoadInternationalAndLocalLicense_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PersonCardWithFilter ctrlFilterBy1;
        private System.Windows.Forms.Button button1;
        private ctrShowLocalAndInternationalDate ctrShowLocalAndInternationalDate1;
    }
}
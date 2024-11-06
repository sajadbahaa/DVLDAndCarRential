namespace DVLCPresentation.Vehicles.Maintence
{
    partial class frmMaintanceInfo
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
            this.ctrlMantanceInfo1 = new DVLCPresentation.Vehicles.Maintence.ctrlMantanceInfo();
            this.SuspendLayout();
            // 
            // ctrlMantanceInfo1
            // 
            this.ctrlMantanceInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlMantanceInfo1.Location = new System.Drawing.Point(57, 34);
            this.ctrlMantanceInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlMantanceInfo1.Name = "ctrlMantanceInfo1";
            this.ctrlMantanceInfo1.Size = new System.Drawing.Size(691, 372);
            this.ctrlMantanceInfo1.TabIndex = 0;
            // 
            // frmMaintanceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ctrlMantanceInfo1);
            this.Name = "frmMaintanceInfo";
            this.Text = "frmMaintanceInfo";
            this.Load += new System.EventHandler(this.frmMaintanceInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlMantanceInfo ctrlMantanceInfo1;
    }
}
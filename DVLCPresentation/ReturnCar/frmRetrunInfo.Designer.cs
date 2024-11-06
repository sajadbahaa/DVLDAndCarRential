namespace DVLCPresentation.ReturnCar
{
    partial class frmRetrunInfo
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
            this.ctrlReturnInfo1 = new DVLCPresentation.ReturnCar.ctrlReturnInfo();
            this.SuspendLayout();
            // 
            // ctrlReturnInfo1
            // 
            this.ctrlReturnInfo1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlReturnInfo1.Location = new System.Drawing.Point(14, 14);
            this.ctrlReturnInfo1.Margin = new System.Windows.Forms.Padding(5);
            this.ctrlReturnInfo1.Name = "ctrlReturnInfo1";
            this.ctrlReturnInfo1.Size = new System.Drawing.Size(880, 464);
            this.ctrlReturnInfo1.TabIndex = 0;
            this.ctrlReturnInfo1.Load += new System.EventHandler(this.ctrlReturnInfo1_Load);
            // 
            // frmRetrunInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 548);
            this.Controls.Add(this.ctrlReturnInfo1);
            this.Name = "frmRetrunInfo";
            this.Text = "frmRetrunInfo";
            this.Load += new System.EventHandler(this.frmRetrunInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlReturnInfo ctrlReturnInfo1;
    }
}
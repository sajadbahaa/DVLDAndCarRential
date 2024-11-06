namespace DVLCPresentation.Drivers
{
    partial class frmFindDriver
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
            this.SuspendLayout();
            // 
            // ctrlDriverWithFilter1
            // 
            this.ctrlDriverWithFilter1.FilterEnable = true;
            this.ctrlDriverWithFilter1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlDriverWithFilter1.Location = new System.Drawing.Point(83, 22);
            this.ctrlDriverWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlDriverWithFilter1.Name = "ctrlDriverWithFilter1";
            this.ctrlDriverWithFilter1.Size = new System.Drawing.Size(596, 427);
            this.ctrlDriverWithFilter1.TabIndex = 0;
            this.ctrlDriverWithFilter1.OnDriverSelected += new System.EventHandler<clsPeople.clsDriver>(this.ctrlDriverWithFilter1_OnDriverSelected);
            // 
            // frmFindDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 463);
            this.Controls.Add(this.ctrlDriverWithFilter1);
            this.Name = "frmFindDriver";
            this.Text = "frmFindDriver";
            this.Load += new System.EventHandler(this.frmFindDriver_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlDriverWithFilter ctrlDriverWithFilter1;
    }
}
namespace CRentail.Vehicles
{
    partial class frmShowVehicleInfo
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
            this.ctrlVehicleCard1 = new CRentail.Vehicles.Controls.ctrlVehicleCard();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlVehicleCard1
            // 
            this.ctrlVehicleCard1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlVehicleCard1.Location = new System.Drawing.Point(7, 10);
            this.ctrlVehicleCard1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlVehicleCard1.Name = "ctrlVehicleCard1";
            this.ctrlVehicleCard1.Size = new System.Drawing.Size(977, 362);
            this.ctrlVehicleCard1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.button1.Location = new System.Drawing.Point(512, 375);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CLose);
            // 
            // frmShowVehicleInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 439);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlVehicleCard1);
            this.Name = "frmShowVehicleInfo";
            this.Text = "frmShowVehicleInfo";
            this.Load += new System.EventHandler(this.frmShowVehicleInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlVehicleCard ctrlVehicleCard1;
        private System.Windows.Forms.Button button1;
    }
}
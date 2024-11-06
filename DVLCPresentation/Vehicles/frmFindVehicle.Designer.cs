namespace DVLCPresentation.Vehicles.Controls
{
    partial class frmFindVehicle
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
            this.ctrlVehicleCardWithFilter1 = new DVLCPresentation.Vehicles.Controls.ctrlVehicleCardWithFilter();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlVehicleCardWithFilter1
            // 
            this.ctrlVehicleCardWithFilter1.FilterEnable = true;
            this.ctrlVehicleCardWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlVehicleCardWithFilter1.Location = new System.Drawing.Point(13, 41);
            this.ctrlVehicleCardWithFilter1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlVehicleCardWithFilter1.Name = "ctrlVehicleCardWithFilter1";
            this.ctrlVehicleCardWithFilter1.Size = new System.Drawing.Size(908, 443);
            this.ctrlVehicleCardWithFilter1.TabIndex = 0;
            this.ctrlVehicleCardWithFilter1.OnVehicleSelected += new System.EventHandler<CRentailBussiness.clsVehicles>(this.ctrlVehicleCardWithFilter1_OnVehicleSelected);
            // 
            // btnSearch
            // 
            this.button1.Location = new System.Drawing.Point(795, 505);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmFindVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 551);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlVehicleCardWithFilter1);
            this.Name = "frmFindVehicle";
            this.Text = "frmFindVehicle";
            this.Load += new System.EventHandler(this.frmFindVehicle_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlVehicleCardWithFilter ctrlVehicleCardWithFilter1;
        private System.Windows.Forms.Button button1;
    }
}
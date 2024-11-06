namespace DVLCPresentation.ReturnCar
{
    partial class frmReturnCar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReturnCar));
            this.btnReturn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbReturnID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddionalCharges = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCurrentMileage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtReturn = new System.Windows.Forms.DateTimePicker();
            this.ctrlReservationWithFilter1 = new DVLCPresentation.Reservations.Controls.ctrlReservationWithFilter();
            this.lReturnVehicle = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReturn.BackgroundImage")));
            this.btnReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReturn.Location = new System.Drawing.Point(1025, 398);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(120, 47);
            this.btnReturn.TabIndex = 16;
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(876, 398);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 47);
            this.button2.TabIndex = 17;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbReturnID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtAddionalCharges);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNotes);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCurrentMileage);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtReturn);
            this.groupBox1.Location = new System.Drawing.Point(768, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 355);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // lbReturnID
            // 
            this.lbReturnID.AutoSize = true;
            this.lbReturnID.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReturnID.Location = new System.Drawing.Point(138, 16);
            this.lbReturnID.Name = "lbReturnID";
            this.lbReturnID.Size = new System.Drawing.Size(34, 21);
            this.lbReturnID.TabIndex = 28;
            this.lbReturnID.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 21);
            this.label1.TabIndex = 27;
            this.label1.Text = "Return ID : ";
            // 
            // txtAddionalCharges
            // 
            this.txtAddionalCharges.Location = new System.Drawing.Point(189, 157);
            this.txtAddionalCharges.Name = "txtAddionalCharges";
            this.txtAddionalCharges.Size = new System.Drawing.Size(172, 20);
            this.txtAddionalCharges.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 21);
            this.label5.TabIndex = 25;
            this.label5.Text = "Addtional Charges  : ";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(10, 248);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(376, 101);
            this.txtNotes.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 21);
            this.label4.TabIndex = 23;
            this.label4.Text = "Notes : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 21);
            this.label3.TabIndex = 22;
            this.label3.Text = "Current Mileage :";
            // 
            // txtCurrentMileage
            // 
            this.txtCurrentMileage.Location = new System.Drawing.Point(171, 114);
            this.txtCurrentMileage.Name = "txtCurrentMileage";
            this.txtCurrentMileage.Size = new System.Drawing.Size(108, 20);
            this.txtCurrentMileage.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 21);
            this.label2.TabIndex = 19;
            this.label2.Text = "Return Date  : ";
            // 
            // dtReturn
            // 
            this.dtReturn.Location = new System.Drawing.Point(170, 64);
            this.dtReturn.Name = "dtReturn";
            this.dtReturn.Size = new System.Drawing.Size(200, 20);
            this.dtReturn.TabIndex = 18;
            this.dtReturn.ValueChanged += new System.EventHandler(this.dtReturn_ValueChanged);
            // 
            // ctrlReservationWithFilter1
            // 
            this.ctrlReservationWithFilter1.Location = new System.Drawing.Point(6, 12);
            this.ctrlReservationWithFilter1.Name = "ctrlReservationWithFilter1";
            this.ctrlReservationWithFilter1.Size = new System.Drawing.Size(749, 369);
            this.ctrlReservationWithFilter1.TabIndex = 0;
            this.ctrlReservationWithFilter1.OnReservationSelected += new System.EventHandler<clsPeople.clsReservations>(this.ctrlReservationWithFilter1_OnReservationSelected);
            this.ctrlReservationWithFilter1.Load += new System.EventHandler(this.ctrlReservationWithFilter1_Load);
            // 
            // lReturnVehicle
            // 
            this.lReturnVehicle.AutoSize = true;
            this.lReturnVehicle.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lReturnVehicle.Location = new System.Drawing.Point(380, 422);
            this.lReturnVehicle.Name = "lReturnVehicle";
            this.lReturnVehicle.Size = new System.Drawing.Size(90, 20);
            this.lReturnVehicle.TabIndex = 19;
            this.lReturnVehicle.TabStop = true;
            this.lReturnVehicle.Text = "Return Info";
            this.lReturnVehicle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lReturnVehicle_LinkClicked);
            // 
            // frmReturnCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 450);
            this.Controls.Add(this.lReturnVehicle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.ctrlReservationWithFilter1);
            this.Name = "frmReturnCar";
            this.Text = "frmReturnCar";
            this.Load += new System.EventHandler(this.frmReturnCar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Reservations.Controls.ctrlReservationWithFilter ctrlReservationWithFilter1;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAddionalCharges;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCurrentMileage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtReturn;
        private System.Windows.Forms.LinkLabel lReturnVehicle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbReturnID;
    }
}
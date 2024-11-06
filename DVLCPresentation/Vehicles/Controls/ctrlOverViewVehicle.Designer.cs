namespace DVLCPresentation.Vehicles.Controls
{
    partial class ctrlOverViewVehicle
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlOverViewVehicle));
            this.label1 = new System.Windows.Forms.Label();
            this.lbVehicleName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRentialCar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnmantaince = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBook = new System.Windows.Forms.Button();
            this.pbVehicleStatus = new System.Windows.Forms.PictureBox();
            this.pb = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVehicleStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vehicle Name : ";
            // 
            // lbVehicleName
            // 
            this.lbVehicleName.AutoSize = true;
            this.lbVehicleName.Location = new System.Drawing.Point(117, 288);
            this.lbVehicleName.Name = "lbVehicleName";
            this.lbVehicleName.Size = new System.Drawing.Size(27, 19);
            this.lbVehicleName.TabIndex = 2;
            this.lbVehicleName.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Vehicle Status : ";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.addToolStripMenuItem,
            this.showToolStripMenuItem,
            this.btnRentialCar,
            this.btnmantaince});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.ShowCheckMargin = true;
            this.contextMenuStrip1.Size = new System.Drawing.Size(207, 156);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addToolStripMenuItem.Image")));
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addVehicleToolStripMenuItem_Click);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showToolStripMenuItem.Image")));
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.showToolStripMenuItem.Text = "show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showVehicleInfoToolStripMenuItem_Click);
            // 
            // btnRentialCar
            // 
            this.btnRentialCar.Image = ((System.Drawing.Image)(resources.GetObject("btnRentialCar.Image")));
            this.btnRentialCar.Name = "btnRentialCar";
            this.btnRentialCar.Size = new System.Drawing.Size(206, 26);
            this.btnRentialCar.Text = "Rential";
            this.btnRentialCar.Click += new System.EventHandler(this.OnReserveVehicle);
            // 
            // btnmantaince
            // 
            this.btnmantaince.Image = ((System.Drawing.Image)(resources.GetObject("btnmantaince.Image")));
            this.btnmantaince.Name = "btnmantaince";
            this.btnmantaince.Size = new System.Drawing.Size(206, 26);
            this.btnmantaince.Text = "Mantaince";
            this.btnmantaince.Click += new System.EventHandler(this.btnmantaince_Click);
            // 
            // btnBook
            // 
            this.btnBook.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBook.BackgroundImage")));
            this.btnBook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBook.Location = new System.Drawing.Point(227, 335);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(147, 45);
            this.btnBook.TabIndex = 5;
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.OnReserveVehicle);
            // 
            // pbVehicleStatus
            // 
            this.pbVehicleStatus.Location = new System.Drawing.Point(121, 333);
            this.pbVehicleStatus.Name = "pbVehicleStatus";
            this.pbVehicleStatus.Size = new System.Drawing.Size(62, 47);
            this.pbVehicleStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbVehicleStatus.TabIndex = 4;
            this.pbVehicleStatus.TabStop = false;
            // 
            // pb
            // 
            this.pb.Dock = System.Windows.Forms.DockStyle.Top;
            this.pb.Location = new System.Drawing.Point(0, 0);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(378, 278);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb.TabIndex = 0;
            this.pb.TabStop = false;
            this.pb.Click += new System.EventHandler(this.pb_Click);
            // 
            // ctrlOverViewVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.pbVehicleStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbVehicleName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlOverViewVehicle";
            this.Size = new System.Drawing.Size(378, 383);
            this.Load += new System.EventHandler(this.ctrlOverViewVehicle_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbVehicleStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbVehicleName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbVehicleStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnRentialCar;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.ToolStripMenuItem btnmantaince;
    }
}

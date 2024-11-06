namespace DVLCPresentation.Payments
{
    partial class frmPaymentsList
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnShowPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancelApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExtendVehicle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCompleteProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.showReturnInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1233, 438);
            this.dataGridView1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowPayment,
            this.btnCancelApplication,
            this.btnExtendVehicle,
            this.btnCompleteProcess,
            this.showReturnInfoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(187, 114);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // btnShowPayment
            // 
            this.btnShowPayment.Name = "btnShowPayment";
            this.btnShowPayment.Size = new System.Drawing.Size(186, 22);
            this.btnShowPayment.Text = "Show Payment Info";
            this.btnShowPayment.Click += new System.EventHandler(this.showPaymentInfoToolStripMenuItem_Click);
            // 
            // btnCancelApplication
            // 
            this.btnCancelApplication.Name = "btnCancelApplication";
            this.btnCancelApplication.Size = new System.Drawing.Size(186, 22);
            this.btnCancelApplication.Text = "Cancel Application";
            this.btnCancelApplication.Click += new System.EventHandler(this.btnCancelApplication_Click);
            // 
            // btnExtendVehicle
            // 
            this.btnExtendVehicle.Name = "btnExtendVehicle";
            this.btnExtendVehicle.Size = new System.Drawing.Size(186, 22);
            this.btnExtendVehicle.Text = "Extend Vehcle Rentail";
            this.btnExtendVehicle.Click += new System.EventHandler(this.btnExtendVehicle_Click);
            // 
            // btnCompleteProcess
            // 
            this.btnCompleteProcess.Name = "btnCompleteProcess";
            this.btnCompleteProcess.Size = new System.Drawing.Size(186, 22);
            this.btnCompleteProcess.Text = "Complete Process";
            this.btnCompleteProcess.Click += new System.EventHandler(this.btnCompleteProcess_Click);
            // 
            // showReturnInfoToolStripMenuItem
            // 
            this.showReturnInfoToolStripMenuItem.Name = "showReturnInfoToolStripMenuItem";
            this.showReturnInfoToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.showReturnInfoToolStripMenuItem.Text = "Show Return Info";
            this.showReturnInfoToolStripMenuItem.Click += new System.EventHandler(this.showReturnInfoToolStripMenuItem_Click);
            // 
            // frmPaymentsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmPaymentsList";
            this.Text = "frmPaymentsList";
            this.Load += new System.EventHandler(this.frmPaymentsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnShowPayment;
        private System.Windows.Forms.ToolStripMenuItem btnCancelApplication;
        private System.Windows.Forms.ToolStripMenuItem btnExtendVehicle;
        private System.Windows.Forms.ToolStripMenuItem btnCompleteProcess;
        private System.Windows.Forms.ToolStripMenuItem showReturnInfoToolStripMenuItem;
    }
}
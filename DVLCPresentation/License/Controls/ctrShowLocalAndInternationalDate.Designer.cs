namespace DVLCPresentation
{
    partial class ctrShowLocalAndInternationalDate
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbRecLocal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgviewLocalLicense = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbRecInternational = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtgviewInternatoinalLicense = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgviewLocalLicense)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgviewInternatoinalLicense)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(697, 430);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Info";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(686, 397);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbRecLocal);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dtgviewLocalLicense);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(678, 363);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Local License";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // lbRecLocal
            // 
            this.lbRecLocal.AutoSize = true;
            this.lbRecLocal.Location = new System.Drawing.Point(93, 334);
            this.lbRecLocal.Name = "lbRecLocal";
            this.lbRecLocal.Size = new System.Drawing.Size(31, 21);
            this.lbRecLocal.TabIndex = 3;
            this.lbRecLocal.Text = "???";
            this.lbRecLocal.Click += new System.EventHandler(this.lbRecLocal_Click);
            // 
            // lbName
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Record :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dtgviewLocalLicense
            // 
            this.dtgviewLocalLicense.AllowUserToAddRows = false;
            this.dtgviewLocalLicense.AllowUserToDeleteRows = false;
            this.dtgviewLocalLicense.AllowUserToOrderColumns = true;
            this.dtgviewLocalLicense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgviewLocalLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgviewLocalLicense.Location = new System.Drawing.Point(3, 7);
            this.dtgviewLocalLicense.Name = "dtgviewLocalLicense";
            this.dtgviewLocalLicense.ReadOnly = true;
            this.dtgviewLocalLicense.Size = new System.Drawing.Size(672, 306);
            this.dtgviewLocalLicense.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbRecInternational);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.dtgviewInternatoinalLicense);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(678, 238);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "International License";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbRecInternational
            // 
            this.lbRecInternational.AutoSize = true;
            this.lbRecInternational.Location = new System.Drawing.Point(105, 209);
            this.lbRecInternational.Name = "lbRecInternational";
            this.lbRecInternational.Size = new System.Drawing.Size(31, 21);
            this.lbRecInternational.TabIndex = 5;
            this.lbRecInternational.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Record :";
            // 
            // dtgviewInternatoinalLicense
            // 
            this.dtgviewInternatoinalLicense.AllowUserToAddRows = false;
            this.dtgviewInternatoinalLicense.AllowUserToDeleteRows = false;
            this.dtgviewInternatoinalLicense.AllowUserToOrderColumns = true;
            this.dtgviewInternatoinalLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgviewInternatoinalLicense.Location = new System.Drawing.Point(3, 77);
            this.dtgviewInternatoinalLicense.Name = "dtgviewInternatoinalLicense";
            this.dtgviewInternatoinalLicense.ReadOnly = true;
            this.dtgviewInternatoinalLicense.Size = new System.Drawing.Size(672, 120);
            this.dtgviewInternatoinalLicense.TabIndex = 2;
            this.dtgviewInternatoinalLicense.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgviewInternatoinalLicense_CellContentClick);
            // 
            // ctrShowLocalAndInternationalDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ctrShowLocalAndInternationalDate";
            this.Size = new System.Drawing.Size(705, 439);
            this.Load += new System.EventHandler(this.ctrShowLocalAndInternationalDate_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgviewLocalLicense)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgviewInternatoinalLicense)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lbRecLocal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgviewLocalLicense;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dtgviewInternatoinalLicense;
        private System.Windows.Forms.Label lbRecInternational;
        private System.Windows.Forms.Label label3;
    }
}

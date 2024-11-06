namespace DVLCPresentation.Reservations.Reservation_List
{
    partial class frmAddReservation
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabFindVehicles = new System.Windows.Forms.TabPage();
            this.btnNextCust = new System.Windows.Forms.Button();
            this.ctrlVehicleCardWithFilter1 = new DVLCPresentation.Vehicles.Controls.ctrlVehicleCardWithFilter();
            this.tabFindCustomers = new System.Windows.Forms.TabPage();
            this.btnNextRese = new System.Windows.Forms.Button();
            this.ctrlDriverWithFilter1 = new DVLCPresentation.Drivers.ctrlDriverWithFilter();
            this.tabAddReservation = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbUsername = new System.Windows.Forms.Label();
            this.txtPaymentNote = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDropOf = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPickUp = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.lbVehicleName = new System.Windows.Forms.Label();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.lbInitialTotalDueAmount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbRentialPerDay = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCustomerName = new System.Windows.Forms.Label();
            this.lbPaymentID = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbReservationID = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbApplicationID = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lShowPayment = new System.Windows.Forms.LinkLabel();
            this.tabControl1.SuspendLayout();
            this.tabFindVehicles.SuspendLayout();
            this.tabFindCustomers.SuspendLayout();
            this.tabAddReservation.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabFindVehicles);
            this.tabControl1.Controls.Add(this.tabFindCustomers);
            this.tabControl1.Controls.Add(this.tabAddReservation);
            this.tabControl1.Location = new System.Drawing.Point(2, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(906, 468);
            this.tabControl1.TabIndex = 0;
            // 
            // tabFindVehicles
            // 
            this.tabFindVehicles.Controls.Add(this.btnNextCust);
            this.tabFindVehicles.Controls.Add(this.ctrlVehicleCardWithFilter1);
            this.tabFindVehicles.Location = new System.Drawing.Point(4, 22);
            this.tabFindVehicles.Name = "tabFindVehicles";
            this.tabFindVehicles.Padding = new System.Windows.Forms.Padding(3);
            this.tabFindVehicles.Size = new System.Drawing.Size(898, 442);
            this.tabFindVehicles.TabIndex = 0;
            this.tabFindVehicles.Text = "Find Vehicles";
            this.tabFindVehicles.UseVisualStyleBackColor = true;
            // 
            // btnNextCust
            // 
            this.btnNextCust.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextCust.Location = new System.Drawing.Point(776, 385);
            this.btnNextCust.Name = "btnNextCust";
            this.btnNextCust.Size = new System.Drawing.Size(104, 46);
            this.btnNextCust.TabIndex = 5;
            this.btnNextCust.Text = "Next";
            this.btnNextCust.UseVisualStyleBackColor = true;
            this.btnNextCust.Click += new System.EventHandler(this.NextToLookingForCustomer);
            // 
            // ctrlVehicleCardWithFilter1
            // 
            this.ctrlVehicleCardWithFilter1.FilterEnable = true;
            this.ctrlVehicleCardWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlVehicleCardWithFilter1.Location = new System.Drawing.Point(4, 7);
            this.ctrlVehicleCardWithFilter1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlVehicleCardWithFilter1.Name = "ctrlVehicleCardWithFilter1";
            this.ctrlVehicleCardWithFilter1.Size = new System.Drawing.Size(890, 431);
            this.ctrlVehicleCardWithFilter1.TabIndex = 4;
            this.ctrlVehicleCardWithFilter1.OnVehicleSelected += new System.EventHandler<CRentailBussiness.clsVehicles>(this.ctrlVehicleCardWithFilter1_OnVehicleSelected);
            // 
            // tabFindCustomers
            // 
            this.tabFindCustomers.Controls.Add(this.btnNextRese);
            this.tabFindCustomers.Controls.Add(this.ctrlDriverWithFilter1);
            this.tabFindCustomers.Location = new System.Drawing.Point(4, 22);
            this.tabFindCustomers.Name = "tabFindCustomers";
            this.tabFindCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.tabFindCustomers.Size = new System.Drawing.Size(898, 442);
            this.tabFindCustomers.TabIndex = 1;
            this.tabFindCustomers.Text = "Find Customers";
            this.tabFindCustomers.UseVisualStyleBackColor = true;
            // 
            // btnNextRese
            // 
            this.btnNextRese.Location = new System.Drawing.Point(783, 397);
            this.btnNextRese.Name = "btnNextRese";
            this.btnNextRese.Size = new System.Drawing.Size(105, 37);
            this.btnNextRese.TabIndex = 1;
            this.btnNextRese.Text = "Next";
            this.btnNextRese.UseVisualStyleBackColor = true;
            this.btnNextRese.Click += new System.EventHandler(this.NextToReservation);
            // 
            // ctrlDriverWithFilter1
            // 
            this.ctrlDriverWithFilter1.FilterEnable = true;
            this.ctrlDriverWithFilter1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlDriverWithFilter1.Location = new System.Drawing.Point(10, 6);
            this.ctrlDriverWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlDriverWithFilter1.Name = "ctrlDriverWithFilter1";
            this.ctrlDriverWithFilter1.Size = new System.Drawing.Size(876, 427);
            this.ctrlDriverWithFilter1.TabIndex = 0;
            this.ctrlDriverWithFilter1.OnDriverSelected += new System.EventHandler<clsPeople.clsDriver>(this.ctrlDriverWithFilter1_OnDriverSelected);
            this.ctrlDriverWithFilter1.Load += new System.EventHandler(this.ctrlDriverWithFilter1_Load);
            // 
            // tabAddReservation
            // 
            this.tabAddReservation.BackColor = System.Drawing.Color.LightSlateGray;
            this.tabAddReservation.Controls.Add(this.groupBox1);
            this.tabAddReservation.Location = new System.Drawing.Point(4, 22);
            this.tabAddReservation.Name = "tabAddReservation";
            this.tabAddReservation.Size = new System.Drawing.Size(898, 442);
            this.tabAddReservation.TabIndex = 2;
            this.tabAddReservation.Text = "Add Reservation";
            this.tabAddReservation.Click += new System.EventHandler(this.tabAddReservation_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSlateGray;
            this.groupBox1.Controls.Add(this.lbUsername);
            this.groupBox1.Controls.Add(this.txtPaymentNote);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtNotes);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDropOf);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtPickUp);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtStart);
            this.groupBox1.Controls.Add(this.lbVehicleName);
            this.groupBox1.Controls.Add(this.dtEndDate);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lbInitialTotalDueAmount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lbRentialPerDay);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbCustomerName);
            this.groupBox1.Controls.Add(this.lbPaymentID);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lbReservationID);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lbApplicationID);
            this.groupBox1.Location = new System.Drawing.Point(6, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 426);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsername.Location = new System.Drawing.Point(821, 272);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(30, 19);
            this.lbUsername.TabIndex = 64;
            this.lbUsername.Text = "???";
            // 
            // txtPaymentNote
            // 
            this.txtPaymentNote.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtPaymentNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPaymentNote.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentNote.ForeColor = System.Drawing.Color.Black;
            this.txtPaymentNote.Location = new System.Drawing.Point(160, 272);
            this.txtPaymentNote.Name = "txtPaymentNote";
            this.txtPaymentNote.Size = new System.Drawing.Size(484, 70);
            this.txtPaymentNote.TabIndex = 66;
            this.txtPaymentNote.Text = "";
            this.txtPaymentNote.Validating += new System.ComponentModel.CancelEventHandler(this.VaildationRichBox);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 19);
            this.label3.TabIndex = 62;
            this.label3.Text = "Notes  Payment  :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(673, 272);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 19);
            this.label13.TabIndex = 63;
            this.label13.Text = "UserName  :";
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotes.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.ForeColor = System.Drawing.Color.Black;
            this.txtNotes.Location = new System.Drawing.Point(158, 350);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(486, 70);
            this.txtNotes.TabIndex = 65;
            this.txtNotes.Text = "";
            this.txtNotes.Validating += new System.ComponentModel.CancelEventHandler(this.VaildationRichBox);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(-4, 355);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 19);
            this.label7.TabIndex = 61;
            this.label7.Text = "Notes  Reservation  :";
            // 
            // txtDropOf
            // 
            this.txtDropOf.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtDropOf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDropOf.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDropOf.ForeColor = System.Drawing.Color.Black;
            this.txtDropOf.Location = new System.Drawing.Point(649, 112);
            this.txtDropOf.Name = "txtDropOf";
            this.txtDropOf.Size = new System.Drawing.Size(214, 35);
            this.txtDropOf.TabIndex = 31;
            this.txtDropOf.Text = "";
            this.txtDropOf.Validating += new System.ComponentModel.CancelEventHandler(this.VaildationRichBox);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(498, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 19);
            this.label9.TabIndex = 47;
            this.label9.Text = "Drop Of Location :";
            // 
            // txtPickUp
            // 
            this.txtPickUp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtPickUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPickUp.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPickUp.ForeColor = System.Drawing.Color.Black;
            this.txtPickUp.Location = new System.Drawing.Point(158, 106);
            this.txtPickUp.Name = "txtPickUp";
            this.txtPickUp.Size = new System.Drawing.Size(215, 35);
            this.txtPickUp.TabIndex = 60;
            this.txtPickUp.Text = "";
            this.txtPickUp.Validating += new System.ComponentModel.CancelEventHandler(this.VaildationRichBox);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 19);
            this.label8.TabIndex = 45;
            this.label8.Text = "Pick Up Location :";
            // 
            // dtStart
            // 
            this.dtStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.Location = new System.Drawing.Point(160, 60);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(242, 24);
            this.dtStart.TabIndex = 44;
            // 
            // lbVehicleName
            // 
            this.lbVehicleName.AutoSize = true;
            this.lbVehicleName.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVehicleName.Location = new System.Drawing.Point(579, 213);
            this.lbVehicleName.Name = "lbVehicleName";
            this.lbVehicleName.Size = new System.Drawing.Size(30, 19);
            this.lbVehicleName.TabIndex = 34;
            this.lbVehicleName.Text = "???";
            // 
            // dtEndDate
            // 
            this.dtEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEndDate.Location = new System.Drawing.Point(609, 55);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(242, 24);
            this.dtEndDate.TabIndex = 43;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(438, 161);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(206, 19);
            this.label12.TabIndex = 25;
            this.label12.Text = "Initial Total Due Amount : ";
            // 
            // lbInitialTotalDueAmount
            // 
            this.lbInitialTotalDueAmount.AutoSize = true;
            this.lbInitialTotalDueAmount.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInitialTotalDueAmount.Location = new System.Drawing.Point(650, 161);
            this.lbInitialTotalDueAmount.Name = "lbInitialTotalDueAmount";
            this.lbInitialTotalDueAmount.Size = new System.Drawing.Size(30, 19);
            this.lbInitialTotalDueAmount.TabIndex = 26;
            this.lbInitialTotalDueAmount.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(438, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 19);
            this.label2.TabIndex = 33;
            this.label2.Text = "Vehicle Name  :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(18, 161);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 19);
            this.label10.TabIndex = 23;
            this.label10.Text = "Rentail Per Day :";
            // 
            // lbRentialPerDay
            // 
            this.lbRentialPerDay.AutoSize = true;
            this.lbRentialPerDay.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRentialPerDay.Location = new System.Drawing.Point(181, 161);
            this.lbRentialPerDay.Name = "lbRentialPerDay";
            this.lbRentialPerDay.Size = new System.Drawing.Size(30, 19);
            this.lbRentialPerDay.TabIndex = 24;
            this.lbRentialPerDay.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(498, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 19);
            this.label6.TabIndex = 42;
            this.label6.Text = "End Date  :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 19);
            this.label5.TabIndex = 41;
            this.label5.Text = "Start Date  :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Reservation ID  :";
            // 
            // lbCustomerName
            // 
            this.lbCustomerName.AutoSize = true;
            this.lbCustomerName.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCustomerName.Location = new System.Drawing.Point(181, 213);
            this.lbCustomerName.Name = "lbCustomerName";
            this.lbCustomerName.Size = new System.Drawing.Size(30, 19);
            this.lbCustomerName.TabIndex = 28;
            this.lbCustomerName.Text = "???";
            // 
            // lbPaymentID
            // 
            this.lbPaymentID.AutoSize = true;
            this.lbPaymentID.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPaymentID.Location = new System.Drawing.Point(421, 18);
            this.lbPaymentID.Name = "lbPaymentID";
            this.lbPaymentID.Size = new System.Drawing.Size(30, 19);
            this.lbPaymentID.TabIndex = 40;
            this.lbPaymentID.Text = "???";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 213);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 19);
            this.label11.TabIndex = 27;
            this.label11.Text = "Customer Name  :";
            // 
            // lbReservationID
            // 
            this.lbReservationID.AutoSize = true;
            this.lbReservationID.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReservationID.Location = new System.Drawing.Point(170, 18);
            this.lbReservationID.Name = "lbReservationID";
            this.lbReservationID.Size = new System.Drawing.Size(30, 19);
            this.lbReservationID.TabIndex = 9;
            this.lbReservationID.Text = "???";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(305, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 19);
            this.label15.TabIndex = 39;
            this.label15.Text = "Payment ID  :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(605, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "Application ID  :";
            // 
            // lbApplicationID
            // 
            this.lbApplicationID.AutoSize = true;
            this.lbApplicationID.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationID.Location = new System.Drawing.Point(766, 18);
            this.lbApplicationID.Name = "lbApplicationID";
            this.lbApplicationID.Size = new System.Drawing.Size(30, 19);
            this.lbApplicationID.TabIndex = 11;
            this.lbApplicationID.Text = "???";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(797, 483);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 32);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.SaveInfo);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(689, 483);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 32);
            this.button3.TabIndex = 2;
            this.button3.Text = "Close";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.CLose);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lShowPayment
            // 
            this.lShowPayment.AutoSize = true;
            this.lShowPayment.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lShowPayment.Location = new System.Drawing.Point(358, 490);
            this.lShowPayment.Name = "lShowPayment";
            this.lShowPayment.Size = new System.Drawing.Size(124, 21);
            this.lShowPayment.TabIndex = 3;
            this.lShowPayment.TabStop = true;
            this.lShowPayment.Text = "Show Payment";
            this.lShowPayment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmAddReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 520);
            this.Controls.Add(this.lShowPayment);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmAddReservation";
            this.Text = "frmAddReservation";
            this.Load += new System.EventHandler(this.frmAddReservation_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabFindVehicles.ResumeLayout(false);
            this.tabFindCustomers.ResumeLayout(false);
            this.tabAddReservation.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabFindVehicles;
        private System.Windows.Forms.Button btnNextCust;
        private Vehicles.Controls.ctrlVehicleCardWithFilter ctrlVehicleCardWithFilter1;
        private System.Windows.Forms.TabPage tabFindCustomers;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button3;
        private Drivers.ctrlDriverWithFilter ctrlDriverWithFilter1;
        private System.Windows.Forms.Button btnNextRese;
        private System.Windows.Forms.TabPage tabAddReservation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbApplicationID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbReservationID;
        private System.Windows.Forms.Label lbRentialPerDay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbInitialTotalDueAmount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbCustomerName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbVehicleName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lbPaymentID;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtDropOf;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox txtPickUp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lShowPayment;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.RichTextBox txtPaymentNote;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox txtNotes;
        private System.Windows.Forms.Label label7;
    }
}
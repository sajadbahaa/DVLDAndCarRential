﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation
{
    public partial class frmUserInfo : Form
    {
        
        private int _userID;

        public frmUserInfo(int UserID)
        {
            InitializeComponent();
            _userID = UserID;
            ctrlUserDetials1.LoadUserInfo(_userID);
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {

        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

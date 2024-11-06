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
    public partial class frmShowLicense : Form
    {
        private int _LicenseID;

        public frmShowLicense(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        private void frmShowLicense_Load(object sender, EventArgs e)
        {

            ctrlShowLicense1.LoadLicenseInfo(_LicenseID);
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

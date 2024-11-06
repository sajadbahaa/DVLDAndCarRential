using clsPeople;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation
{
    public partial class ctrlApplicationInfo : UserControl
    {
        private int _LocalDrivingLicenseID;
        private int _ApplicationID;
        private int _LicenseID;
        private clsLocalDrivingLicense _clsLocalDrivingLicense;
        public ctrlApplicationInfo()
        {
            InitializeComponent();
        }
       private void _RestDefaultValuesLocalLicense()
        {
            _ApplicationID = -1;
        lbDrivingLocalLicenseID.Text = "[????]";
        lbClassLicenseName.Text = "[????]";
        _LocalDrivingLicenseID = -1;
            lbTestPassed.Text = "0/3";
            ctrlApplicationBasic1._RestDefaultValue();
        }
       
        public void LoadLocalLicenseIDByLocalLicenseApplicationID(int LocalDrivingLicenseID)
        {
            _clsLocalDrivingLicense =
   clsLocalDrivingLicense.FindByLocalDrivingLicenseID(LocalDrivingLicenseID);
            if (_clsLocalDrivingLicense==null)
            {
                _RestDefaultValuesLocalLicense();
                MessageBox.Show("this Local Driving License ID Not Found");
                return;
            }
            _FillApplicationIDByLocalDrivingLicenseAppID();
        }
        public void LoadLocalLicenseIDByApplicationID(int ApplicationID)
        {
            _clsLocalDrivingLicense = clsLocalDrivingLicense.FindLocalLicensByApplicationID(ApplicationID);
            if (_clsLocalDrivingLicense == null)
            {
                _RestDefaultValuesLocalLicense();
                MessageBox.Show("this Local Driving License ID Not Found");
                return;
            }
            _FillApplicationIDByLocalDrivingLicenseAppID();
        }
        private void _FillApplicationIDByLocalDrivingLicenseAppID()
        {
            _LicenseID = _clsLocalDrivingLicense.GetActiveLicenseID();

            lviewLicense.Enabled = (_LicenseID != -1); 
            
            _LocalDrivingLicenseID = _clsLocalDrivingLicense.LocalDrivingLicenseApplicationID;
            _ApplicationID = _clsLocalDrivingLicense.ApplicationID;
            ctrlApplicationBasic1.LoadApplicationInfo(_ApplicationID);
            lbDrivingLocalLicenseID.Text = _clsLocalDrivingLicense.LocalDrivingLicenseApplicationID.ToString();
          lbClassLicenseName.Text = _clsLocalDrivingLicense.ClassLicsens.ClassName;
            lbTestPassed.Text = clsTests.GetTestPass(_LocalDrivingLicenseID)+"/3"; 
        }
        private void ShowPersonInfo(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void ctrlApplicationInfo_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ctrlApplicationBasic1_Load(object sender, EventArgs e)
        {

        }

        private void lviewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense frm = new frmShowLicense(_LicenseID);
            frm.Show();
        }
    }
}

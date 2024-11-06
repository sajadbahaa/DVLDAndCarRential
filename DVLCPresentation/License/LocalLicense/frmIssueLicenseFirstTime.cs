using Clobal;
using clsPeople;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation
{
    public partial class frmIssueLicenseFirstTime : Form
    {
        private int _LocalDrivingLicensID;
        private clsLocalDrivingLicense LocalDrivingLicense;
        public frmIssueLicenseFirstTime(int LocalDrivingLicenseID)
        {
            InitializeComponent();
            _LocalDrivingLicensID = LocalDrivingLicenseID;
        }


        private void frmAddlicense_Load(object sender, EventArgs e)
        {
            // we need to check out localDriving License exixst
             LocalDrivingLicense = clsLocalDrivingLicense.FindByLocalDrivingLicenseID(_LocalDrivingLicensID);
            if (LocalDrivingLicense==null)
            {
                MessageBox.Show("no Local Driving License Exist");
                return;
            }

            // we check if person Passed 3 exams
            if (!LocalDrivingLicense.IsPassAllTests())
            {
                MessageBox.Show("you should to Complete 3 test then Get Licnese",
                    "",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
                return;
            }
            // we check if you have license Before or not;
            int LicenseID = LocalDrivingLicense.GetActiveLicenseID();
            if (LicenseID!=-1)
            {
                MessageBox.Show("you already have LicenseID  : "+LicenseID);
                this.Close();
                return;
            }
            ctrlApplicationInfo1.LoadLocalLicenseIDByLocalLicenseApplicationID(_LocalDrivingLicensID);
        }

        private void Save(object sender, EventArgs e)
        {
            int LicenseID = LocalDrivingLicense.IssueLicenseForFirstTime(clsGlobal.CurrentUser.UserID, txtNote.Text);
            if (LicenseID!=-1)
            {
                MessageBox.Show($"Saved Successfully for Get License For First time {LicenseID}","Save Info");
                btnSave.Enabled = false;
                return;
            }
            else
            {
                MessageBox.Show("Error in Save Data");
                return;
            }

        }



        private void ctrlApplicationInfo1_Load(object sender, EventArgs e)
        {

        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

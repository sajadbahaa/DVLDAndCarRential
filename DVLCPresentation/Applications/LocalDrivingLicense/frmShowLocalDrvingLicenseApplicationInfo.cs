using System;
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
    public partial class frmShowLocalDrvingLicenseApplicationInfo : Form
    {
        public frmShowLocalDrvingLicenseApplicationInfo(int LocalDrivingLicenseID)
        {
            InitializeComponent();
            ctrlApplicationInfo1.LoadLocalLicenseIDByLocalLicenseApplicationID(LocalDrivingLicenseID);
        }

        public frmShowLocalDrvingLicenseApplicationInfo(int ApplicationID,int LocalDrivingLicenseID=-1)
        {
            InitializeComponent();
            ctrlApplicationInfo1.LoadLocalLicenseIDByApplicationID(ApplicationID);
        }

        private void CLose(object sender, EventArgs e)
        {
            this.Close();
        }
    

    }
}

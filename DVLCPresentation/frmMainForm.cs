using Clobal;
using clsPeople;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using CRentail;
namespace DVLCPresentation
{
    public partial class frmMainForm : Form
    {
        //private Login _frmLogin;
        public frmMainForm()
        {
            InitializeComponent();
            //_frmLogin = frmLogin;
            
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        frmPeopleScreen frmPeople;
        private void ShowPeople(object sender, EventArgs e)
        {
            frmPeople = new frmPeopleScreen();
            frmPeople.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        frmUsersScreen frmUsers;
        private void ShowUsers(object sender, EventArgs e)
        {
            frmUsers = new frmUsersScreen();
            frmUsers.ShowDialog();

        }
        private void Settings(object sender, EventArgs e)
        {

        }
        frmUserInfo fUserInfo;
        private void ShowCurrentUser(object sender, EventArgs e)
        {
            fUserInfo = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            fUserInfo.ShowDialog();
        }
        frmChangePassword fChangePassword;
        private void ShowChangePassworsd(object sender, EventArgs e)
        {
            fChangePassword = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            fChangePassword.ShowDialog();
        }

        private void SignOut(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            
            this.Close();
        }
        frmApplicationTypesSecreen fApplicationTypesScreen;
        private void ShowApplicationTypesScreen(object sender, EventArgs e)
        {
            fApplicationTypesScreen = new frmApplicationTypesSecreen();
            fApplicationTypesScreen.ShowDialog();
        }
        frmListTestType fTestTypes;
        private void ShowTestTtpes(object sender, EventArgs e)
        {
            fTestTypes = new frmListTestType();
            fTestTypes.ShowDialog();
        }
        frmAddOrUpdateLocalDrivingLicense fAddApplication;

       
        private void AddLocalDrivingLicense(object sender, EventArgs e)
        {
            
            fAddApplication = new frmAddOrUpdateLocalDrivingLicense();
            fAddApplication.ShowDialog();
        }
        frmLocalLicenseList fShowApplication;
        private void manageApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();
        }
        frmAddInternationalLicence frmaddInternational;
        private void AddInternationalLicense(object sender, EventArgs e)
        {
            frmaddInternational = new frmAddInternationalLicence();
            frmaddInternational.ShowDialog();
        }

        
        frmDrivers frmShowDriver;
        private void ShowDrivers(object sender, EventArgs e)
        {
            frmShowDriver = new frmDrivers();
            frmShowDriver.ShowDialog();
        }

        private void ShowApplicationLocalLicnse(object sender, EventArgs e)
        
        {
            fShowApplication = new frmLocalLicenseList();
            fShowApplication.ShowDialog();
        }
        frmMangeInternationalLicense frmMangeInternational;
        private void ShowInternationalData(object sender, EventArgs e)
        {
            frmMangeInternational = new frmMangeInternationalLicense();
            frmMangeInternational.ShowDialog();
        }
        
        private void AddReNewLicense(object sender, EventArgs e)
        {
            frmReNewLicense frm = new frmReNewLicense();
            frm.ShowDialog();

        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacementLostOrDamaged frm = new frmReplacementLostOrDamaged();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void detainListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainingList frm = new frmManageDetainingList();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();
        }

        private void ReTakeTest(object sender, EventArgs e)
        {
            frmLocalLicenseList frm = new frmLocalLicenseList();
            frm.ShowDialog();
        }

        private void carRentailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CRentail.frmFormCarRential frm = new CRentail.frmFormCarRential();
            frm.ShowDialog();
        }
    }
}

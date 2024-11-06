using clsPeople;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation
{
    
    public partial class frmLocalLicenseList : Form
    {
        private DataView dtview;
        private clsLocalDrivingLicense _clsLocalDrivingLicense;
        private void _Refresh()
        {
            dtview = clsLocalDrivingLicense.AllLocalDrivingLicense().DefaultView;
            dtgview.DataSource = dtview;
    
        }
        public frmLocalLicenseList()
        {
            InitializeComponent();
        }

        private void frmApplicationScreen_Load(object sender, EventArgs e)
        {
            _Refresh();
        }
        private void GetFilter(string Text)
        {
            string FilterColumn;
            if (Text=="")
            {
                _Refresh();
                return;
            }
            FilterColumn = cbFilter.Text;

            switch (FilterColumn)
            {
                case "LocalDrivingLicenseApplicationID":
                    //dtview.RowFilter = string.Format("[{0}] = {1}", FilterCoulum, txtFilter.Text);
                    dtview.RowFilter = string.Format("[{0}] = {1}",FilterColumn,Text);
                    dtgview.DataSource = dtview;
                    return;
                case "NationalNo":
                    dtview.RowFilter = $"{FilterColumn} like '" + Text + "%'";
                    dtgview.DataSource = dtview;
                    return;
            }

        }
        
        private void txtSerarch_TextChanged(object sender, EventArgs e)
        {
            GetFilter(txtSerarch.Text);
        
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseID = (int)dtgview.CurrentRow.Cells[0].Value;
            frmAddOrUpdateLocalDrivingLicense frm
            = new frmAddOrUpdateLocalDrivingLicense(LocalDrivingLicenseID);
            frm.ShowDialog();
            _Refresh();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
     
            if (MessageBox.Show("Do you want?","Delete Application",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                _clsLocalDrivingLicense = clsLocalDrivingLicense.FindByLocalDrivingLicenseID((int)dtgview.CurrentRow.Cells[0].Value);
                if (_clsLocalDrivingLicense == null)
                {
                    MessageBox.Show("no Local Driving License to Delete");
                    return;
                }
                if (_clsLocalDrivingLicense.Delete())
                    MessageBox.Show("Saved Successfully");
                else
                    MessageBox.Show("there is Error in Deleting Data");
                _Refresh();
            }

            else
            {
                MessageBox.Show("you canceled delete Application");
            }

        }

        private void cancelAppliationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
        private void PassExam(object sender, EventArgs e)
        {
            
        }
        private void SchedualTest(clsTestTypes.enTestType TestType)
        {
            int LocalDrivingLicenseID = (int)dtgview.CurrentRow.Cells[0].Value;
            frmListTestAppointmet frm 
         = new frmListTestAppointmet(LocalDrivingLicenseID, (int)TestType);
            frm.ShowDialog();
            _Refresh();
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            
        }

        private void cancelAppliationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("you wana Cancel Application?","",
              MessageBoxButtons.OK,MessageBoxIcon.Question) == DialogResult.No)
                return;
            else {
                _clsLocalDrivingLicense = clsLocalDrivingLicense.FindByLocalDrivingLicenseID((int)dtgview.CurrentRow.Cells[0].Value);
                if (_clsLocalDrivingLicense == null)
                {
                    MessageBox.Show("no Application to Cancel it");
                    return;
         
                }
                if (clsApplication.CancelStatus(_clsLocalDrivingLicense.ApplicationID))
                {
                    MessageBox.Show("Saved Successfully");
                }
                else
                {
                    MessageBox.Show("it had happened error check it", "Cancel Status"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            //define var  to get Loacl Driving License ID
            int LocalDrivingLicenseID = (int)dtgview.CurrentRow.Cells[0].Value;
            
            // define object from clsLocalDrivingLicense 
            _clsLocalDrivingLicense = 
            clsLocalDrivingLicense.FindByLocalDrivingLicenseID(LocalDrivingLicenseID);
            
            // define var TotalPassedTest to  get how many test 
            //who driver had passed
            int TotalPassedTest = (int)dtgview.CurrentRow.Cells[5].Value;
            
            // Enable / Desiable Issue License (First Time) .
            bool IsLicenseExist = _clsLocalDrivingLicense.IsLicenseIssue();
            btnIssueDrivingLicense.Enabled = (TotalPassedTest==3&&!IsLicenseExist);

            // Enable / Desiable show License 
            btnShowLicense.Enabled = IsLicenseExist;

            //Enable / Desiable btn Cancel
            // we can  only cancel Application when ApplicationStatus = new
            btncancelApplication.Enabled 
            = 
 (_clsLocalDrivingLicense.ApplicationStatus == clsApplication.enApplicationStatus.New);

            //Enable / Desiable  Delete Applcation
            // we can only Delete if VehicleStatus is New not Complete or Cancel
            btndeleteApplication.Enabled
                 = (_clsLocalDrivingLicense.ApplicationStatus == clsApplication.enApplicationStatus.New);
      
            // enable / desiable Edit Application
            btneditApplication.Enabled =
                (_clsLocalDrivingLicense.ApplicationStatus==clsApplication.enApplicationStatus.New);
            
            // here we stopped tommorw we will complete Tests by permission Allaha
            bool PassVisionTest = _clsLocalDrivingLicense.DoesPassTest((int)clsTestTypes.enTestType.VisionTest);
            bool PassWrittenTest = _clsLocalDrivingLicense.DoesPassTest((int)clsTestTypes.enTestType.WrittenTest);
            bool PassStreetTest = _clsLocalDrivingLicense.DoesPassTest((int)clsTestTypes.enTestType.StreetTest);
            btnSchedualTest.Enabled 
= (!PassVisionTest || !PassWrittenTest || !PassStreetTest)
&&(_clsLocalDrivingLicense.ApplicationStatus ==clsApplication.enApplicationStatus.New);
            
            if (btnSchedualTest.Enabled)
            {
            btnVision.Enabled  = !PassVisionTest;
            btnWriiten.Enabled = PassVisionTest&&!PassWrittenTest;
            btnStreet.Enabled  = PassVisionTest&&PassWrittenTest&&!PassStreetTest;
            }

        }


        private void GetLicenseForFirstTime(object sender, EventArgs e)
        {
            frmIssueLicenseFirstTime frmLicense = new frmIssueLicenseFirstTime((int)dtgview.CurrentRow.Cells[0].Value);
            frmLicense.ShowDialog();
            _Refresh();
            
        }

       
        private void ShowLicenseInfo(object sender, EventArgs e)
        {
            int LicenseID = clsLicense.GetLicenseActiveByPersonID(_clsLocalDrivingLicense.PersonID, _clsLocalDrivingLicense.LicenseClassID);
            if (LicenseID != -1)
            {
                frmShowLicense frm = new frmShowLicense(LicenseID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("you dont have license ID","check Info",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLocalDrvingLicenseApplicationInfo frm
                = new frmShowLocalDrvingLicenseApplicationInfo((int)dtgview.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void TakeVisionTest(object sender, EventArgs e)
        {
            SchedualTest(clsTestTypes.enTestType.VisionTest);
        }

        private void TakeWrittenTest(object sender, EventArgs e)
        {
            SchedualTest(clsTestTypes.enTestType.WrittenTest);
        }

        private void TakeStreetTest(object sender, EventArgs e)
        {
            SchedualTest(clsTestTypes.enTestType.StreetTest);

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmShowHisoryLicene frm = new frmShowHisoryLicene(_clsLocalDrivingLicense.PersonID);
            frm.ShowDialog();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSerarch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "LocalDrivingLicenseApplicationID") { 
             if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void AddApplicationLocalLicense(object sender, EventArgs e)
        {
            frmAddOrUpdateLocalDrivingLicense frm = new frmAddOrUpdateLocalDrivingLicense();
            frm.ShowDialog();
            _Refresh();
        }
    }
}


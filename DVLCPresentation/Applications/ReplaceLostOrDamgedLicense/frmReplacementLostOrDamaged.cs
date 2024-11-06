using Clobal;
using clsPeople;
using DVLCPresentation.Global_Classes;
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
  public partial class frmReplacementLostOrDamaged : Form
    
    {
        private int _NewLicenseID;

        public frmReplacementLostOrDamaged()
        {
            InitializeComponent();
        }
        
        private int _GetApplicationTypeID()
        {
            if (rbDamagedLicense.Checked)
                return (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicens;
            else
                return (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;
        }

        private  enum IssueReason {damgedLicene =4,LostLicense = 3 }
        private   IssueReason _GetIssueReason()
        {
            if (rbDamagedLicense.Checked)
                return IssueReason.damgedLicene;
            else
                return IssueReason.LostLicense;
        }

        private void frmReplacementLostOrDamaged_Load(object sender, EventArgs e)
        {
            rbDamagedLicense.Checked = true;
            lblApplicationDate.Text = clsFormat.DateToShortString(DateTime.Now);
            lblApplicationFees.Text = clsAppType.Find((int)_GetApplicationTypeID()).AppFees.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.Username;
        }

        private void ctrlLicenseWithFilter1_OnSelectPerson(int obj)
        {
            int OldLicenseID = obj;

            //check if License Dis active
            llShowLicenseHistory.Enabled = (OldLicenseID!=-1);

            if (OldLicenseID==-1)
            {
                return;
            }
            lblOldLicenseID.Text = OldLicenseID.ToString();

            if (ctrlLicenseWithFilter1.LicneseInfo.IsActive)
            {
                MessageBox.Show("this License Already Active " +
                    "you Can not take New License","Check Info",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                llShowLicenseInfo.Enabled = false;
                btnSave.Enabled = false;
                return;
            }
            btnSave.Enabled = true;
        }

        private void Save(object sender, EventArgs e)
        {
            // we check if Saving New License saved  Successful
            clsLicense NewLicense =
   ctrlLicenseWithFilter1.LicneseInfo.DamagedORLostLicense(clsGlobal.CurrentUser.UserID,
   (clsLicense.enIssueReason)_GetIssueReason());

            if (NewLicense==null)
            {
                return;
            }
            MessageBox.Show("Saved Successfully it has been created New License " +
                $"[{NewLicense.LicenseID}]");
            _NewLicenseID = NewLicense.LicenseID;
            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            lblRreplacedLicenseID.Text = NewLicense.LicenseID.ToString();
            btnSave.Enabled = false;
            llShowLicenseInfo.Enabled = true;

        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lbTile.Text = "Replacement for License Damaged";
            lblApplicationFees.Text = clsAppType.Find((int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicens).AppFees.ToString();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lbTile.Text = "Replacement for License Lost";
            lblApplicationFees.Text = clsAppType.Find((int)clsApplication.enApplicationType.ReplaceLostDrivingLicense).AppFees.ToString();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowHisoryLicene frm = new frmShowHisoryLicene(ctrlLicenseWithFilter1.LicneseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense frm = new frmShowLicense(_NewLicenseID);
            frm.ShowDialog();
        }
    }
}

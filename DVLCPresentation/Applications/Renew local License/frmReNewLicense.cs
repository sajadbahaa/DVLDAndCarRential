using Clobal;
using clsPeople;
using DVLCPresentation.Global_Classes;
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
    public partial class frmReNewLicense : Form
    {
        
        private int _NewLicenseID;
        public frmReNewLicense()
        {
            InitializeComponent();
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Save(object sender, EventArgs e)
        {
            if
 (MessageBox.Show("are you sure","",MessageBoxButtons.OKCancel)==DialogResult.Cancel)
            {
                return;
            }

            clsLicense NewLicense = ctrlLicenseWithFilter1.LicneseInfo.ReNewLicense(txtNote.Text
                , clsGlobal.CurrentUser.UserID);
            if (NewLicense==null)
            {
                MessageBox.Show("Failed Re new License");
                return;
            }

            lbApplicationID.Text = NewLicense.ApplicationID.ToString();
            lbReNewLicenseID.Text = NewLicense.LicenseID.ToString();
            ctrlLicenseWithFilter1.FilterEanble = false;
            btnSave.Enabled = false;
            lshowLicense.Enabled = true;
            _NewLicenseID = NewLicense.LicenseID;
            lbLicenseFees.Text = NewLicense.PaidFees.ToString();
            //lbApplicationFees.Text ;
            MessageBox.Show("Issue Re new License has been Successfully With" +
                $"New ID : {_NewLicenseID}");
        }
        private void frmReNewLicense_Load(object sender, EventArgs e)
        {
            ctrlLicenseWithFilter1.FilterFocuse();
            lbAppDate.Text = clsFormat.DateToShortString(DateTime.Now);
            lbApplicationFees.Text = clsAppType.Find((int)clsApplication.enApplicationType.RenewDrivingLicens).AppFees.ToString();
            lbExpirationDate.Text = "???";
            lbIssueDate.Text = lbAppDate.Text;
            lbUsername.Text = clsGlobal.CurrentUser.Username;
        }

        private void ctrlAddRenNewLicense1_Load(object sender, EventArgs e)
        {

        }
        
        private void ShowLicense(object sender, LinkLabelLinkClickedEventArgs e)
         {
            frmShowLicense frm = new frmShowLicense(_NewLicenseID);
            frm.ShowDialog();
         }
        int _OldLicenseID = -1;

        private void ctrlLicenseWithFilter1_OnSelectPerson(int obj)
        {
            

        _OldLicenseID = obj;

            if (_OldLicenseID==-1)
            {
                return;
            }
            lLicenseHistory.Enabled = (_OldLicenseID!=-1);
           

            lbOldLicenseID.Text = _OldLicenseID.ToString();
            lbLicenseFees.Text = ctrlLicenseWithFilter1.LicneseInfo.ClassLicense.ClassFees.ToString();
            int DefaultValidity = Convert.ToInt32( ctrlLicenseWithFilter1.LicneseInfo.ClassLicense.DefaultValidityLength);
            lbExpirationDate.Text = clsFormat.DateToShortString(DateTime.Now.AddYears(DefaultValidity));
            lbTotalFees.Text = (Convert.ToDecimal(lbApplicationFees.Text) + Convert.ToDecimal(lbLicenseFees.Text)).ToString();
            txtNote.Text = ctrlLicenseWithFilter1.LicneseInfo.Notes;

            // we check if License Not Active
            if (ctrlLicenseWithFilter1.LicneseInfo.IsActive)
            {
                MessageBox.Show("License already active you can not take Re New Licnese" +
                $"With{_OldLicenseID}");
                btnSave.Enabled = false;
                _NewLicenseID = _OldLicenseID;
                lshowLicense.Enabled = true;
                return;
            }

            // we check if License Expired
            if (!(ctrlLicenseWithFilter1.LicneseInfo.IsDateExpired()))
            {
                MessageBox.Show("this License Is not expired , select another one");
                btnSave.Enabled = false;
                return;
            }
            btnSave.Enabled = true;
        
        }

        private void lLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowHisoryLicene frm = new frmShowHisoryLicene(ctrlLicenseWithFilter1.LicneseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }
    }
}

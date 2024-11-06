using Clobal;
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
    public partial class frmDetainLicense : Form
    {
        public frmDetainLicense()
        {
            InitializeComponent();
        }
         private int _DetaindID = -1;
        int _CurrentLicenseID;
        private void ctrlLicenseWithFilter1_OnSelectPerson(int obj)
        {
            _CurrentLicenseID = obj;
            llShowLicenseHistory.Enabled = _CurrentLicenseID != -1;
            lblLicenseID.Text = _CurrentLicenseID.ToString();
            
            // check if license Exist
            
            if (_CurrentLicenseID==-1)
            {
                return;
            }

            // check if license is not Active.

            if (!ctrlLicenseWithFilter1.LicneseInfo.IsActive)
            {
                MessageBox.Show("you can not detain license  not active!," +
                    "Choose Another");
                btnDetain.Enabled = false;
                return;
            }
            // check if License is not Detained
            
            if (ctrlLicenseWithFilter1.LicneseInfo.IsLicenseDetained)
            {
                MessageBox.Show("you already your license still Detained " +
                    "you can not detain it again , selecet another one",
                    "Select Detain License",MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                llShowLicenseInfo.Enabled = false;
                btnDetain.Enabled = false;
                return;
            }
            
            btnDetain.Enabled = true;
            txtFineFees.Text = "";
            txtFineFees.Focus();
        }

        private void ctrlLicenseWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblCreatedByUser.Text = clsGlobal.CurrentUser.Username;
            lblDetainDate.Text = clsFormat.DateToShortString(DateTime.Now);
            ctrlLicenseWithFilter1.FilterFocuse();
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            // we check if it empty
            if(string.IsNullOrEmpty(txtFineFees.Text))
            {
                e.Cancel = true;
                txtFineFees.Focus();
                errorProvider1.SetError(txtFineFees,"this Field should not be Empty");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFineFees,null);
            }

            // we check if if it is char
            if (!clsVaildation.IsNumber(txtFineFees.Text))
            {
                e.Cancel = true;
                txtFineFees.Focus();
                errorProvider1.SetError(txtFineFees, "this Field should not be characters");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFineFees, null);
            }

        }

        private void Save(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("There is some Field are required to complete it.");
                return;
            }
            // now we get new Detain Id 
            int NewDetainID = ctrlLicenseWithFilter1.LicneseInfo
        .Detain(clsGlobal.CurrentUser.UserID, Convert.ToDecimal(txtFineFees.Text));
            if (NewDetainID == -1)
            {
                MessageBox.Show("Saved info has failed","Save Info",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            lblDetainID.Text = NewDetainID.ToString();
            _DetaindID = NewDetainID;
            btnDetain.Enabled = false;
            llShowLicenseInfo.Enabled = true;
            MessageBox.Show("Saved Successfully");   
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense frm = new frmShowLicense(_CurrentLicenseID);
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        
           frmShowHisoryLicene frm = new frmShowHisoryLicene(ctrlLicenseWithFilter1.LicneseInfo.DriverInfo.PersonID);
           frm.ShowDialog();
        
        }
    }
}

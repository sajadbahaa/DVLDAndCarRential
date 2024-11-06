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
    public partial class frmReleaseLicense : Form
    {
        public frmReleaseLicense()
        {
            InitializeComponent();
        }
        private int CurrentLicenseID;
        

       public frmReleaseLicense(int LicenseID)
        {
            InitializeComponent();
            ctrlLicenseWithFilter1.LoadData(LicenseID);
            ctrlLicenseWithFilter1.FilterEanble = false;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ctrlLicenseWithFilter1_OnSelectPerson(int obj)
        {
            CurrentLicenseID = obj;

            if (CurrentLicenseID == -1)
                return;
            
            llShowLicenseHistory.Enabled = CurrentLicenseID != -1;
            lblLicenseID.Text = CurrentLicenseID.ToString();

            // we check if License Detained for Release it later
            if (!ctrlLicenseWithFilter1.LicneseInfo.IsLicenseDetained)
            {
                MessageBox.Show("you can not release license without Detain it first",
                    "Release License",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                btnRelease.Enabled = false;
                llShowLicenseInfo.Enabled = false;
                return;
            }
            lblDetainID.Text = ctrlLicenseWithFilter1.LicneseInfo.DetainedInfo.DetainID.ToString();
            lblDetainDate.Text = clsFormat.DateToShortString(ctrlLicenseWithFilter1.LicneseInfo.DetainedInfo.DetainDate);
            lblFineFees.Text = ctrlLicenseWithFilter1.LicneseInfo.DetainedInfo.FineFees.ToString();
            lblCreatedByUser.Text = ctrlLicenseWithFilter1.LicneseInfo.DetainedInfo.CreatUserInfo.Username.ToString();
            lblApplicationFees.Text = clsAppType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense).AppFees.ToString();
            lblTotalFees.Text = (Convert.ToDecimal(lblApplicationFees.Text) + Convert.ToDecimal(lblFineFees.Text)).ToString();
            btnRelease.Enabled = true;
        }

        private void LoadData(object sender, EventArgs e)
        {
            ctrlLicenseWithFilter1.FilterFocuse();
        }

        private void OnReleaseLicense(object sender, EventArgs e)
        {
            // we will Send data
            int ApplicationID = -1;
            bool IsRelease = ctrlLicenseWithFilter1.
 LicneseInfo.
ReleaseDetainLicense(clsGlobal.CurrentUser.UserID, ref ApplicationID);
            if (!IsRelease)
            {
                MessageBox.Show("Error in Releasing License","Release License",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            lblApplicationID.Text = ApplicationID.ToString();
            MessageBox.Show("Releasing License Saved Successfully");
            btnRelease.Enabled = false;
            llShowLicenseInfo.Enabled = true;
            ctrlLicenseWithFilter1.FilterEanble = false;
        }

        private void ShowLicense(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense frm = new frmShowLicense(CurrentLicenseID);
            frm.ShowDialog();
        }

        private void ShowHistory(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowHisoryLicene frm = new frmShowHisoryLicene(ctrlLicenseWithFilter1.LicneseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void ctrlLicenseWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}

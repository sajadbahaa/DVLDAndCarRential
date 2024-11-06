using Clobal;
using DVLCPresentation;
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

namespace clsPeople
{
    
    public partial class frmAddInternationalLicence : Form
    {
        private int _InternationalID;
        public frmAddInternationalLicence()
        {
            InitializeComponent();
       
        }

        private void Save(object sender, EventArgs e)
        {
            // now we will add application
            clsInternationalLicense InternationalInfo = new clsInternationalLicense();
            InternationalInfo.ApplicationStatus = clsApplication.enApplicationStatus.Complete;
            InternationalInfo.AppDate = DateTime.Now;
            InternationalInfo.LastStatusDate = DateTime.Now;
            InternationalInfo.AppTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;
            InternationalInfo.UserID = clsGlobal.CurrentUser.UserID;
            InternationalInfo.PersonID = ctrladdInternationalLicense1.LicneseInfo.DriverInfo.PersonID;
            InternationalInfo.PaidFees = clsAppType.Find(InternationalInfo.AppTypeID).AppFees;
            // now we add International
            InternationalInfo.InternationalDriverID = ctrladdInternationalLicense1.LicneseInfo.DriverInfo.DriverID;
            InternationalInfo.IssuedUsingLocalLicenseID = ctrladdInternationalLicense1.LicenseID;
            InternationalInfo.IssueDate = DateTime.Now;
            InternationalInfo.ExpirationDate = clsGlobal.VaildityLength;
            InternationalInfo.IsActive = true;
            InternationalInfo.CreatedByUserID = InternationalInfo.UserID;
            if (!InternationalInfo.Save())
            {
                MessageBox.Show("there is Error in DataBase");
                return;
            }
            lblInternationalLicenseID.Text = InternationalInfo.InternationalLicenseID.ToString();
            lblApplicationID.Text = InternationalInfo.ApplicationID.ToString();
            lblLocalLicenseID.Text = InternationalInfo.IssuedUsingLocalLicenseID.ToString();
            _InternationalID = InternationalInfo.InternationalLicenseID;
            lshowLicense.Enabled = true;
            btnSave.Enabled = false;
            ctrladdInternationalLicense1.FilterEanble = false;
            MessageBox.Show("Issue International License Saved Successfully");
        
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddInternationalLicence_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = clsFormat.DateToShortString(DateTime.Now);
            lblCreatedByUser.Text = clsGlobal.CurrentUser.Username;
            //add one year 
            lblExpirationDate.Text = clsFormat.DateToShortString(DateTime.Now.AddYears(1));
            lblFees.Text = clsAppType.Find((int)clsApplication.enApplicationType.NewInternationalLicense).AppFees.ToString();
            lblIssueDate.Text = clsFormat.DateToShortString(DateTime.Now);
           
        }

        private void ShowIntetnationLIcense(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowIntetnationalLicense frmShowInternationalLicense
              = new frmShowIntetnationalLicense(_InternationalID);
            frmShowInternationalLicense.ShowDialog();

        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void ShowLicenseHistory(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowHisoryLicene frmloadDate = 
                new frmShowHisoryLicene(ctrladdInternationalLicense1.LicneseInfo.DriverInfo.PersonID);
            frmloadDate.ShowDialog();

        }

        private void ctrladdInternationalLicense1_Load(object sender, EventArgs e)
        {

        }

        private void ctrladdInternationalLicense1_OnSelectPerson(int obj)
        {
            int LicenseID = obj;
            if (LicenseID==-1)
            {
                return;
            }
            lblLocalLicenseID.Text = LicenseID.ToString();
        lLicenseHistory.Enabled = (LicenseID!=-1);
            // check from person must have class license 3  unitle getting 
            //International License
            if (ctrladdInternationalLicense1.LicneseInfo.ClassLicenseID!=3)
            {
                MessageBox.Show("person can not get International License untel geeting Class License 3");
                return;
            }
            // check if International License is Active.
            int ActiveInternationalID = clsInternationalLicense.GetAnActiveInternationID(ctrladdInternationalLicense1.LicneseInfo.DriverInfo.DriverID);
            if (ActiveInternationalID!=-1)
            {
                MessageBox.Show($"Person already has International ID : {ActiveInternationalID}");
                btnSave.Enabled = false;
                lshowLicense.Enabled = true;
                _InternationalID = ActiveInternationalID;
                return;
            }
            // we can add International License now.
            btnSave.Enabled = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}

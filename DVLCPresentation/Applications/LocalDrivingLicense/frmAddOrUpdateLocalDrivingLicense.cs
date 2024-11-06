using Clobal;
using clsPeople;
using DVLCPresentation.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation
{
    public partial class frmAddOrUpdateLocalDrivingLicense : Form
    {
        private int _LocalDrivingLicenseID = -1;
        private clsLocalDrivingLicense _clslocalDrivingLicense;

   
        private void _GetAllClassLicense()
        {
            DataTable dt = clsClassLicense.GetAllClassLicense();
            foreach (DataRow row in dt.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
        }
        enum    enMode { add = 1,update = 2}
        private enMode _Mode;
        public frmAddOrUpdateLocalDrivingLicense()
        {
            InitializeComponent();
            _Mode = enMode.add;     
        }
        public frmAddOrUpdateLocalDrivingLicense(int LocalDrivingLicenseID)
        {
            InitializeComponent();
            _LocalDrivingLicenseID = LocalDrivingLicenseID;
            _Mode = enMode.update;
        }
        private void _RestDefualtValue()
        {
            _GetAllClassLicense();
            if (_Mode==enMode.add)
            {
                lbMode.Text = "New Local Driving License Application";
                _clslocalDrivingLicense = new clsLocalDrivingLicense();
                cbLicenseClass.SelectedIndex = 2;
                lbApplicationDate.Text = DateTime.Now.ToShortDateString();
                lbApplicationFees.Text =
            clsAppType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).AppFees.ToString();
                lbApplicationLocalLicenseID.Text = "????";
                lbUsername.Text = clsGlobal.CurrentUser.Username;
                tabApplicationInfo.Enabled = false;
                btnSave.Enabled = false;
                ctrlFilterBy1.FilterFocuse();

            }
            else
            {
                lbMode.Text = "Update Local Driving License Application";
                tabApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
            }
        }
        private void _LoadData()
        {
            ctrlFilterBy1.FilterEnable = false;
_clslocalDrivingLicense 
= clsLocalDrivingLicense.FindByLocalDrivingLicenseID(_LocalDrivingLicenseID);
            if (_clslocalDrivingLicense==null)
            {
                MessageBox.Show($"this {_LocalDrivingLicenseID} Not found");
                this.Close();
                return;
            }
            lbUsername.Text = clsUser.FindByUserID(_clslocalDrivingLicense.UserID).Username;
            lbApplicationFees.Text = _clslocalDrivingLicense.PaidFees.ToString();
            ctrlFilterBy1.LoadPersonInfo(_clslocalDrivingLicense.PersonID);
            lbApplicationLocalLicenseID.Text =
            _clslocalDrivingLicense.LocalDrivingLicenseApplicationID.ToString();
            lbApplicationDate.Text  = clsFormat.DateToShortString(_clslocalDrivingLicense.AppDate);
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(clsClassLicense.GetClassName(_clslocalDrivingLicense.LicenseClassID));
        }
        private void AddApplication_Load(object sender, EventArgs e)
        {
            _RestDefualtValue();
            if (_Mode == enMode.update)
                _LoadData();
        
        }



        private void Save(object sender, EventArgs e)
        {
         int ClassLicenseID = clsClassLicense.GetClassID(cbLicenseClass.Text);
         int ApplicationID = clsApplication.GetApplicatonIDActiveForLicenseClass(ctrlFilterBy1.PersonID,(int)clsApplication.enApplicationType.NewDrivingLicense, ClassLicenseID);
         //  if application exist and Active
            if (ApplicationID!=-1)
            {
                MessageBox.Show($"this ApplicationID Active [{ApplicationID}], you can't take same " +
                    "Class License twoice" +
                    "","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            // handel if you have License Already
            if (clsLicense.IsLicenseIDExistByPersonID(ctrlFilterBy1.PersonID,ClassLicenseID))
            {
                MessageBox.Show($"this License is Active  for {cbLicenseClass.Text}" +
                    $", Choose Diffrent Class License","Check this Licene has Issued Or Not for Person",
                    MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            _clslocalDrivingLicense.AppDate = DateTime.Now;
            _clslocalDrivingLicense.LastStatusDate = DateTime.Now;
            _clslocalDrivingLicense.PersonID = ctrlFilterBy1.PersonID;
            _clslocalDrivingLicense.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _clslocalDrivingLicense.AppTypeID = 1;
            _clslocalDrivingLicense.LicenseClassID = ClassLicenseID;
            _clslocalDrivingLicense.PaidFees = Convert.ToDecimal(lbApplicationFees.Text);
            _clslocalDrivingLicense.UserID = clsGlobal.CurrentUser.UserID;
            
            if (_clslocalDrivingLicense.Save())
            {
                MessageBox.Show("Saved Successfully","",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
                lbApplicationLocalLicenseID.Text = _clslocalDrivingLicense.LocalDrivingLicenseApplicationID.ToString();
            }
            else
            {
                MessageBox.Show("there Is Error in Data","",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
        }


    private void GotoFillApplicationInfoNext(object sender, EventArgs e)
        {
            if (_Mode==enMode.update)
            {
            btnSave.Enabled = true;
            tabApplicationInfo.Enabled = true;
            tabLocalLicense.SelectedTab = tabLocalLicense.TabPages["tabApplicationInfo"];
            return;
            }
            if (ctrlFilterBy1.PersonID!=-1)
            {
                btnSave.Enabled = true;
                tabApplicationInfo.Enabled = true;
                tabLocalLicense.SelectedTab = tabLocalLicense.TabPages["tabApplicationInfo"];
            }
            else
            {
                MessageBox.Show("this PersonID / National No Not Found Select Another Person");
                ctrlFilterBy1.FilterFocuse();
            }
        }

        
        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void tabPersonalInfo_Click(object sender, EventArgs e)
        {

        }

        private void frmAddOrUpdateLocalDrivingLicense_Activated(object sender, EventArgs e)
        {
            ctrlFilterBy1.FilterFocuse();
        }
    }
}

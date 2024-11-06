using clsPeople;
using DVLCPresentation.Global_Classes;
using DVLCPresentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation
{
    public partial class ctrlShowLicense : UserControl
    {
        public int DriverID
        {
            get
            {
                return Convert.ToInt32(lbDriverID.Text);
            }
        }

        public ctrlShowLicense()
        {
            InitializeComponent();
        }


        public clsLicense _clslicense ;
        private int _LicenseID = -1;
        public int LicenseID
        {
            get
            {
                return _LicenseID;
            }
        }
        public clsLicense SelectLicenseInfo
        {
            get
            {
                return _clslicense;
            }
        }
        private void _LoadImage()
        {
            if (_clslicense==null)
            {
                pb.Image = Resources.male;
                return;
            }

            if (_clslicense.DriverInfo.PersonInfo.ImagePath==null)
            {
                if (_clslicense.DriverInfo.PersonInfo.Gendor == 0)
                    pb.Image = Resources.male;
                else
                    pb.Image = Resources.female;

                return;
            }

            string Image = _clslicense.DriverInfo.PersonInfo.ImagePath;
            if (Image!="")
            {
                if (File.Exists(Image))
                    pb.Load(Image);
                else
                 MessageBox.Show("we could not find this Path : " +Image );
            }
            

        }

    public void ResetDefaultValue()
        {

            lbClassName.Text = "???";
            lbDateOfBirth.Text = "???";
            lbDriverID.Text = "???";
            lbExpirationDate.Text = "???";
            lbGendor.Text = "???";
            lbIsActive.Text = "???";
            lbIsDetained.Text = "???";
            lbIssueDate.Text = "???";
            lbIssueReason.Text = "???";
            lbLicenseID.Text = "???";
            lbName.Text = "???";
            lbNationalNo.Text = "???";
            lbNote.Text = "???";

            _LicenseID = -1;
            _LoadImage();
            _clslicense = new clsLicense();

        }
        public void LoadLicenseInfo(int LicenseID)
{
            _clslicense = clsLicense.Find(LicenseID);
            if (_clslicense==null)
            {
                MessageBox.Show("no License ID  in License Data","Load Data",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
                ResetDefaultValue();
                return;
            }
            _LicenseID = LicenseID;
            lbClassName.Text = _clslicense.ClassLicense.ClassName;
            lbDateOfBirth.Text = clsFormat.DateToShortString(_clslicense.DriverInfo.PersonInfo.Birth);
            lbDriverID.Text = _clslicense.DriverLicenseID.ToString();
            lbExpirationDate.Text = clsFormat.DateToShortString(_clslicense.ExpirationDate);
            lbGendor.Text = (_clslicense.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female");
            lbIsActive.Text = (_clslicense.IsActive?"Active":"not Active");
            lbIsDetained.Text = (_clslicense.IsLicenseDetained?"yes":"no");
            lbIssueDate.Text = clsFormat.DateToShortString(_clslicense.IssueDate);
            lbIssueReason.Text = _clslicense.IssueReasonText;
            lbLicenseID.Text = _clslicense.LicenseID.ToString();
            lbName.Text = _clslicense.DriverInfo.PersonInfo.FullName();
            lbNationalNo.Text = _clslicense.DriverInfo.PersonInfo.NationalNo;
            lbNote.Text = (string.IsNullOrEmpty(_clslicense.Notes)?"no note":_clslicense.Notes);
            _LoadImage();
        }
        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void lbIsDetained_Click(object sender, EventArgs e)
        {

        }

        private void ctrlShowLicense_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

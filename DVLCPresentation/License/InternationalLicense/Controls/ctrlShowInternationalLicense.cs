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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation
{
    public partial class ctrlShowInternationalLicense : UserControl
    {
        public ctrlShowInternationalLicense()
        {
            InitializeComponent();
        }
        private clsInternationalLicense _clsInternational;

        private int _InternationalID;
        public int InternationalID
        {
            get
            {
                return _InternationalID;
            }
        }
        private void _LoadImage()
        {
            if (_clsInternational.LicenseInfo.DriverInfo.PersonInfo.Gendor == 0)
                pb.Image = Resources.male;
            else
                pb.Image = Resources.female;
            if (_clsInternational.LicenseInfo.DriverInfo.PersonInfo.ImagePath!="")
            {
                if (File.Exists(_clsInternational.LicenseInfo.DriverInfo.PersonInfo.ImagePath))
                {
                    string ImagePath = _clsInternational.LicenseInfo.DriverInfo.PersonInfo.ImagePath;
                    pb.Load(ImagePath);
                }
            }
        }
        public void LoadInternatioalLicenseInfo(int InternationalID)
        {
            _InternationalID = InternationalID;
             _clsInternational = clsInternationalLicense.Find(InternationalID);
            if (_clsInternational==null)
            {
                MessageBox.Show("no International ID in Data","Load Data Failed with ID : "+ _InternationalID,
                MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
        }

;           lbBirth.Text = clsFormat.DateToShortString( _clsInternational.LicenseInfo.DriverInfo.PersonInfo.Birth);
            lbDriverID.Text = _clsInternational.InternationalDriverID.ToString();
            lbExpirationDate.Text = clsFormat.DateToShortString(_clsInternational.ExpirationDate);
            lbFullName.Text = _clsInternational.LicenseInfo.DriverInfo.PersonInfo.FullName();
            lbGendor.Text = (_clsInternational.LicenseInfo.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female");
            lbIntNationalLicen.Text = _clsInternational.LicenseInfo.DriverInfo.PersonInfo.NationalNo;
            lbIsActive.Text = (_clsInternational.IsActive?"Yes":"No");
            lbIssueDate.Text = clsFormat.DateToShortString(_clsInternational.IssueDate);
            lbLicenseID.Text = _clsInternational.IssuedUsingLocalLicenseID.ToString();
            lbInternationalID.Text = _clsInternational.InternationalLicenseID.ToString();
            lbApplicationID.Text = _clsInternational.ApplicationID.ToString();
            _LoadImage();
                
        }
        private void ctrlShowInternationalLicense_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

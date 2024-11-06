using clsPeople;
using DVLCPresentation.Global_Classes;
using DVLCPresentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation
{
    public partial class ctrlAddTest : UserControl
    {
    
        public ctrlAddTest()
        {
            InitializeComponent();
        }
        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest;
        private clsLocalDrivingLicense _LocalDrivingLicense;
        private clsAppointment _Appointment;
        private int _LocalDrivingLicenseID;
        private int _AppointmentID;
        private int _TestID =-1;
        public int TestID
        {
            get
            {
                return _TestID;
            }
        }
        public clsTestTypes.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;
                switch (_TestTypeID)
                {
                    case clsTestTypes.enTestType.VisionTest:
                        gbTakeTest.Text = "Vision Test";
                        pb.Image = Resources.vision;

                        break;
                    case clsTestTypes.enTestType.WrittenTest:
                        gbTakeTest.Text = "Written Test";
                        pb.Image = Resources.exam;

                        break;
                    case clsTestTypes.enTestType.StreetTest:
                        gbTakeTest.Text = "Street Test";
                        pb.Image = Resources.drivingTest;

                        break;
                }
            }
        }
        public void LoadInfo(int AppointmentID)
        {
            _AppointmentID = AppointmentID;
            _Appointment = clsAppointment.Find(_AppointmentID);
            if (_Appointment==null)
            {
                MessageBox.Show("no Appointment ID here in Data","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            _LocalDrivingLicenseID = _Appointment.LocalDrivingLicenseApplicationID;
            _LocalDrivingLicense = clsLocalDrivingLicense.FindByLocalDrivingLicenseID(_LocalDrivingLicenseID);
            if (_LocalDrivingLicense==null)
            {
                MessageBox.Show("Local Driving license not exist","",
                MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            _TestID = _Appointment.TestID;
            lbClassName.Text = _LocalDrivingLicense.ClassLicsens.ClassName;
            lbDate.Text = clsFormat.DateToShortString(_Appointment.AppointmentDate);
            lbFees.Text = _Appointment.PaidFees.ToString();
            lbLocalDrivingLicenseID.Text = _LocalDrivingLicenseID.ToString();
            lbtrails.Text = _LocalDrivingLicense.GetTrailsPerTest(_TestTypeID).ToString();
            lbPersonName.Text = _LocalDrivingLicense.ApplicationFullName;
            lbTestID.Text = (_TestID==-1?"Not take it yet":_Appointment.TestID.ToString());
        
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        
        
        private void ctrlAddTest_Load(object sender, EventArgs e)
        {

        }
    }
}

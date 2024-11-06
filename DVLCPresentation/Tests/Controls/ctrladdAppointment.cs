using Clobal;
using clsPeople;
using DVLCPresentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation
{
    public partial class ctrladdAppointment : UserControl
    {

        enum enMode { add = 1, Update = 2 }
        private enMode _Mode = enMode.add;
        enum enCreatingMode { ForFirstTime = 1, ReTakeTest = 2 }
        private enCreatingMode _CreateMode = enCreatingMode.ForFirstTime;
        private clsLocalDrivingLicense LocalDrivingLicene;
        private int _LocalDrivingLiceneID;
        private clsAppointment _Appointment;
        private int _AppointmentID;
        clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest;

        public ctrladdAppointment()
        {
            InitializeComponent();
            lbMessage.Visible = false;
        }

        public void LoadInfo(int AppointmentID, int LocalDrivingLiceneID)
        {
            // #1 we check if AppointmentId is exists or not
            _AppointmentID = AppointmentID;
            if (_AppointmentID == -1)
                _Mode = enMode.add;
            else
                _Mode = enMode.Update;

            _LocalDrivingLiceneID = LocalDrivingLiceneID;
            //#2 we check object  if it exist 
            LocalDrivingLicene = clsLocalDrivingLicense.FindByLocalDrivingLicenseID(_LocalDrivingLiceneID);
            if (LocalDrivingLicene == null)
            {
                MessageBox.Show("no LocalDrivingLicenseID  exist,so we " +
                    "can not Add Test appointment", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            //#3 check if person has Test appointment 
            if (LocalDrivingLicene.DoesAttendTestType(_TestTypeID))
                _CreateMode = enCreatingMode.ReTakeTest;
            else
                _CreateMode = enCreatingMode.ForFirstTime;

            //#4 if _CreateMode ==RetakeTest fill data reather than lbRetakeID
            if (_CreateMode == enCreatingMode.ReTakeTest)
            {
                lbReFees.Text = clsAppType.Find((int)clsApplication.enApplicationType.RetakeTest).AppFees.ToString();
                lbtitle.Text = "ReTake Test";
                lbReTakeTestID.Text = "???";
                gbReTakeTest.Enabled = true;
            }
            else
            //#5 if _CreateMode ==FirstTime Rest Default Values
            {
                lbReFees.Text = "0";
                lbtitle.Text = "Schdual Test";
                lbReTakeTestID.Text = "???";
                gbReTakeTest.Enabled = false;
            }
            lbLocalDrivingLicenseID.Text = LocalDrivingLicene.LocalDrivingLicenseApplicationID.ToString();
            lbClassName.Text = LocalDrivingLicene.ClassLicsens.ClassName;
            lbPersonName.Text = LocalDrivingLicene.ApplicationFullName;

            // this will show Trails for this Test before
            lbTrails.Text =
                  LocalDrivingLicene.GetTrailsPerTest(_TestTypeID).ToString();

            if (_Mode == enMode.add)
            {
                lbFees.Text = clsTestTypes.Find((int)_TestTypeID).Fees.ToString();
                _Appointment = new clsAppointment();
                dtAppointment.MinDate = DateTime.Now;
                return;
            }
            else
            {
                if (!_LoadAppointment())
                    return;
            }
            lbTotalFees.Text = (Convert.ToDecimal(lbFees.Text) + Convert.ToDecimal(lbReFees.Text)).ToString();

            if (!_HandelanActiveAppointment())
                return;
            if (!_HadelAppointmentLocked())
                return;
            if (!_HandelPreviousTest())
                return;
            if (!_HandelRetakeTest())
                return;


        }

        private bool _HandelanActiveAppointment()
        {
            if (_Mode == enMode.add && clsLocalDrivingLicense.IsThereAnActiveSchedualTest(_LocalDrivingLiceneID, _TestTypeID))
            {
                lbMessage.Text = "Person already has an active Test Appointment";
                btnSave.Enabled = false;
                dtAppointment.Enabled = false;
                return false;
            }
            return true;
        }

        private bool _LoadAppointment()
        {
            _Appointment = clsAppointment.Find(_AppointmentID);
            if (_Appointment == null)
            {
                MessageBox.Show("no Appointment in Data");
                btnSave.Enabled = false;
                return false;
            }
            lbFees.Text = _Appointment.PaidFees.ToString();
            // we compare Current Date With old Date 

            if (DateTime.Compare(DateTime.Now, _Appointment.AppointmentDate) > 0)
            {
                dtAppointment.MinDate = DateTime.Now;
                dtAppointment.Value = DateTime.Now;
            }
            else
            {
                dtAppointment.MinDate = _Appointment.AppointmentDate;
                dtAppointment.Value = _Appointment.AppointmentDate;
            }

            // we check if Retake test created or not;

            if (_Appointment.ReTakeTestID == -1)
            {
                lbReFees.Text = "0";
                lbReTakeTestID.Text = "A/V";

            }
            else
            {
                lbReTakeTestID.Text = _Appointment.ReTakeTestID.ToString();
                lbReFees.Text = _Appointment.ReTakeTest.PaidFees.ToString();
                lbtitle.Text = "Schedul ReTakeTest";
                gbReTakeTest.Enabled = true;
            }

            return true;
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
                        gbAppointment.Text = "Vision Test";
                        pb.Image = Resources.vision;

                        break;
                    case clsTestTypes.enTestType.WrittenTest:
                        gbAppointment.Text = "Written Test";
                        pb.Image = Resources.exam;

                        break;
                    case clsTestTypes.enTestType.StreetTest:
                        gbAppointment.Text = "Street Test";
                        pb.Image = Resources.drivingTest;

                        break;
                }
            }
        }
     
        private bool _HadelAppointmentLocked()
        {
// check  _appointment.IsLocked ==true then (it will show you can not Update)
// else  if it was false then you can update
            if (_Appointment.IsLocked)
            {
                lbMessage.Visible = true;
                lbMessage.Text = "Person already Sat for the lest , Appointment loacked";
                btnSave.Enabled = false;
                dtAppointment.Enabled = false;
                return false;
            }
            else
                lbMessage.Visible = false;

            return true;
        }
        private bool _HandelRetakeTest()
        {
              // first we need to check if mode = add and 
             // creation mode = Retake Test
            if(_Mode==enMode.add&&_CreateMode==enCreatingMode.ReTakeTest)
            {
                clsApplication Application = new clsApplication();
                Application.AppDate = DateTime.Now;
                Application.PaidFees = clsAppType.Find((int)clsApplication.enApplicationType.RetakeTest).AppFees;
                Application.ApplicationStatus = clsApplication.enApplicationStatus.Complete;
                Application.AppTypeID = (int)clsApplication.enApplicationType.RetakeTest;
                Application.UserID = clsGlobal.CurrentUser.UserID;
                Application.PersonID = LocalDrivingLicene.PersonID;
                Application.LastStatusDate = DateTime.Now;
                if (!Application.Save())
                {
                    _Appointment.ReTakeTestID = -1;
                    MessageBox.Show("Re take Application  Failed","Adding Re" +
                        "Take Application",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }
                _Appointment.ReTakeTestID = Application.ApplicationID;
            }
            return true;
        }
        
        private void ctrladdAppointment_Load(object sender, EventArgs e)
        {
   
        }

        private  bool _HandelPreviousTest()
        {
            // if test vision test we do not to to check if it pass or not
            switch (_TestTypeID)
            {
                case clsTestTypes.enTestType.VisionTest:
                    return true;

                case clsTestTypes.enTestType.WrittenTest:
                    // we need to check if person passed Vision Test or not;
                    if (!LocalDrivingLicene.DoesPassTest((int)_TestTypeID))
                    {
                        lbMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtAppointment.Enabled = false;
                        lbMessage.Text = "you can not Schedul, you need to pass vision test First!";
                        return false;
                    }
                    else
                    {
                        btnSave.Enabled = true;
                        lbMessage.Visible = false;
                        dtAppointment.Enabled = true;
                        return true;
                    }
                case clsTestTypes.enTestType.StreetTest:
                    // we need to check if person passed Vision Test or not;
                    if (!LocalDrivingLicene.DoesPassTest((int)_TestTypeID))
                    {
                        lbMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtAppointment.Enabled = false;
                        lbMessage.Text = "you can not Schedul, you need to pass Written test First!";
                        return false;
                    }
                    else
                    {
                        btnSave.Enabled = true;
                        lbMessage.Visible = false;
                        dtAppointment.Enabled = true;
                        return true;
                    }
            }
            return false;

    }
        private void gbReTakeTest_Enter(object sender, EventArgs e)
        {

        }

        private void SaveInfo(object sender, EventArgs e)
        {
            if (!_HandelRetakeTest())
                return;

            _Appointment.TestTypeID = (int)_TestTypeID;
            _Appointment.AppointmentDate = DateTime.Now;
            _Appointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _Appointment.IsLocked = false;
            _Appointment.PaidFees = Convert.ToDecimal(lbFees.Text);
            _Appointment.LocalDrivingLicenseApplicationID = _LocalDrivingLiceneID;
            if (_Appointment.Save())
            {
                MessageBox.Show("Saved Successfully");
                _Mode = enMode.Update;
            }
            else
            {
                MessageBox.Show("there is Error");
                return;
            }
        }
    }
}

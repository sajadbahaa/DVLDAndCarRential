using clsPeople;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation
{
    public partial class frmListTestAppointmet : Form
    {
        private int _LocalDrivingLicenseID;
        
        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest;
        public frmListTestAppointmet(int LocalDrivingLicensID,int TestTypeID)
        {
            InitializeComponent();
            _LocalDrivingLicenseID = LocalDrivingLicensID;
            _TestTypeID = (clsTestTypes.enTestType)TestTypeID;
            ctrlApplicationInfo1.LoadLocalLicenseIDByLocalLicenseApplicationID(LocalDrivingLicensID);
        }
        
        DataView dv;
        void _Refresh()
        {
               dv = clsAppointment.GetAllAppointments((int)_TestTypeID,_LocalDrivingLicenseID).DefaultView;
               dtgview.DataSource = dv;
            lbCount.Text = dv.Count.ToString();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlDrivingLicensApplicationInfo1_Load(object sender, EventArgs e)
        {

        }

        private void frmAppointmetScreencs_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoadData(object sender, EventArgs e)
        {
                 _Refresh();
        }

        private void ctrlApplicationInfo1_Load(object sender, EventArgs e)
        {

        }

        private void frmAddAppointment(object sender, EventArgs e)
        {

        }
        private void AddAppointment(object sender, EventArgs e)
    {
 clsLocalDrivingLicense LocalDrivingLicense
 = clsLocalDrivingLicense.FindByLocalDrivingLicenseID(_LocalDrivingLicenseID);
// check if Schedual Test Active 
if (LocalDrivingLicense.IsThereAnActiveSchedualTest(_TestTypeID))
            {
                MessageBox.Show("Person Already has Test Appointment Active"
                    ,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            // we define object from clsTest
            // to check if test exist or not 
            // if object null
clsTests LastTest = LocalDrivingLicense.GetLastTestPerTestType(_TestTypeID);
if (LastTest==null)
{
    //we will implement about adding Appointment
    frmAddAppointment frm = new frmAddAppointment(_TestTypeID, _LocalDrivingLicenseID, -1);
    frm.ShowDialog();
    _Refresh();
    return;
}
            // if you succesed
            if (LastTest.TestRestult)
            {
                MessageBox.Show("you have passed Exam");
                return;
            }
            // if you failed
            frmAddAppointment frmReSchedualTest
               =  new frmAddAppointment(_TestTypeID,LastTest.TestAppointment.LocalDrivingLicenseApplicationID);
            frmReSchedualTest.ShowDialog();
            _Refresh();
        }
         
    private void EditAppointment(object sender, EventArgs e)
        {
            int AppointmentID = (int)dtgview.CurrentRow.Cells[0].Value;
            frmAddAppointment frm = new frmAddAppointment(_TestTypeID, _LocalDrivingLicenseID,
   AppointmentID);
            frm.ShowDialog();
            _Refresh();
        }
        
        private void AddTest(object sender, EventArgs e)
        {
            int AppointmentID = (int)dtgview.CurrentRow.Cells[0].Value;
            frmAddTest frm = new frmAddTest(_TestTypeID, AppointmentID);
            frm.ShowDialog();
            _Refresh();
        }
    }
}

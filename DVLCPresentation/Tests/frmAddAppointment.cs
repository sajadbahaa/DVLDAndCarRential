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

namespace clsPeople
{
    public partial class frmAddAppointment : Form
    {
        //int TestTypeID,int AppointmentID, int LocalDrivingLicense, string ClassName, string PersonName,
        //bool Lock, decimal Fees, int TestID,
        //    bool IsPass, IsFail;



        /// <summary>
        /// Appointment Table
        /// </summary>
        
        private int _AppointmentID;
        private int _localDrivingLicensID;
        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest;        
        
        
        public frmAddAppointment 
        (clsTestTypes.enTestType TestTypeID,int LocalDrivingLicensID, int AppointmentID = -1)
       {
         InitializeComponent();
            _localDrivingLicensID = LocalDrivingLicensID;
            _TestTypeID = TestTypeID;
            _AppointmentID = AppointmentID;
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void frmAddAppointment_Load(object sender, EventArgs e)
        {
            ctrladdAppointment1.TestTypeID = _TestTypeID;
            ctrladdAppointment1.LoadInfo(_AppointmentID, _localDrivingLicensID);
        }

        private void Save(object sender, EventArgs e)
        {

        }
    }
 
}

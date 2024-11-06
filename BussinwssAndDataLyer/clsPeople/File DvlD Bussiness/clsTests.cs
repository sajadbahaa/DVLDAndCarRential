using DvlcDataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clsPeople
{
    public class clsTests
    {
        //   int TestID, ref int TestAppointmentID,
        //ref bool TestResult, ref string Notes, ref int CreatedByUserID
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestRestult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public clsAppointment TestAppointment { get; set; }
        enum enMode { add = 1, update = 2 }
        private enMode _Mode;
        public clsTests() {
            _Mode = enMode.add;
            TestID = -1;
            TestAppointmentID = -1;
            TestRestult = false;
            Notes = "";
            CreatedByUserID = -1;
        }
        private clsTests(int TestID, int TestAppointmentID, bool TestRestult,
         string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestRestult = TestRestult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestAppointment = clsAppointment.Find(TestAppointmentID);
            _Mode = enMode.update;

        }

        public static clsTests Find(int TestID)
        {
            int TestAppointmentID = -1, UserID = -1;
            bool Result = false;
            string Notes = "";
            if (dtTests.Find(TestID, ref TestAppointmentID, ref Result
            , ref Notes, ref UserID))
            {
                return new clsTests(TestID, TestAppointmentID, Result, Notes, UserID);
            }
            else
            {
                return null;
            }
        }
        public static clsTests FindTetsIDByAppointmentID(int TestAppointmentID)
        {
            int TestID = -1, UserID = -1;
            bool Result = false;
            string Notes = "";
            if (dtTests.Find(ref TestID, TestAppointmentID, ref Result
            , ref Notes, ref UserID))
            {
                return new clsTests(TestID, TestAppointmentID, Result, Notes, UserID);
            }
            else
            {
                return null;
            }
        }
        public static clsTests FindLastTest(int PersonID, int LicenseClassID, clsTestTypes.enTestType TestTypeID)
        {
            int TestID = -1, UserID = -1, TestAppointmentID = -1;
            bool Result = false; string Notes = "";
            if (dtTests.GetLastTestPerTestType(PersonID, LicenseClassID, (int)TestTypeID
                , ref TestID, ref TestAppointmentID, ref Result, ref Notes, ref UserID))
            {
                return new clsTests(TestID, TestAppointmentID, Result, Notes, UserID);
            }
            else
            {
                return null;
            }
        }
        private bool _Add()
        {
            this.TestID = dtTests.Add(this.TestAppointmentID, this.TestRestult, this.Notes, this.CreatedByUserID);
            return (this.TestID > -1);
        }
        private bool _Update()
        {
            return (dtTests.Update(this.TestID, this.TestAppointmentID, this.TestRestult, this.Notes, this.CreatedByUserID));
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.add:
                    if (_Add())
                    {
                        _Mode = enMode.update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.update:
                    return _Update();
            }
            return false;

        }
        
        public static byte GetTestPass(int LocalDrivingLicenseID)
        {
            return (dtTests.GetPassedTestCount(LocalDrivingLicenseID));
        }
        public static bool GetAllPassTest(int LocalDrivingLicenseID)
        {
            return (dtTests.GetPassedTestCount(LocalDrivingLicenseID)==3);
        }
    }
}

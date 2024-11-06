using DvlcDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsPeople
{
    public class clsAppointment
    {
        //      int TestAppointmentID,ref int TestTypeID,
        //ref int LocalDrivingLicenseApplicationID,ref DateTime AppointmentDate,
        //ref Decimal PaidFees,ref int CreatedByUserID,ref bool IsLocked
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Decimal PaidFees { get; set; }

        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int ReTakeTestID { get; set; }
        enum enMode { add = 1, update = 2 }
        private enMode _Mode;
        enum enTestType { enVisionTest =1,enWrittenTest =2,enStreetTets =3}
        private enTestType _enTestType = enTestType.enVisionTest;
        public int TestID
        {
            get
            {
                return _GetTestID();
            }
        }
        public clsApplication ReTakeTest { get; set; }
        
        public clsAppointment()
        {
            TestAppointmentID = -1;
            TestTypeID = -1;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            IsLocked = false;
            _Mode = enMode.add;
            this.ReTakeTestID = -1;
        }

        private clsAppointment(int TestAppointmentID, int TestTypeID,
            int LocalDrivingLicenseApplicationID,
         DateTime AppointmentDate, Decimal PaidFees, int CreatedByUserID
           ,bool IsLocked, int ReTakeTestID)
        {
            _Mode = enMode.update;
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.PaidFees = PaidFees;
            this.ReTakeTestID = ReTakeTestID;
            this.IsLocked = IsLocked;
            this.AppointmentDate = AppointmentDate;
            this.CreatedByUserID = CreatedByUserID;
            this.ReTakeTest = clsApplication.FindByAppID(ReTakeTestID);
            CurrentTest(this.TestTypeID);
        
        }

        private void CurrentTest(int TestTypeID)
        {
            switch (TestTypeID)
            {
                case 1:
                    _enTestType = enTestType.enVisionTest;
                    break;
                case 2:
                    _enTestType = enTestType.enWrittenTest;
                    break;
                case 3:
                    _enTestType = enTestType.enStreetTets;
                    break;
            }

        } 
       
       static public bool  IsPass(int AppointmentID)
        {
            
            clsTests _clsTest = clsTests.FindTetsIDByAppointmentID(AppointmentID);
       if (_clsTest!=null)
            {
                if (_clsTest.TestRestult)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public static clsAppointment Find(int AppointmentID)
        {
         
            int TestTypeID = -1, LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now;
            Decimal PaidFees = 0;
            int CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestID = -1;
            if (
    dtAppointment.Find(AppointmentID, ref TestTypeID, 
 ref LocalDrivingLicenseApplicationID, 
 ref AppointmentDate,ref PaidFees,ref CreatedByUserID,
 ref IsLocked,ref RetakeTestID))
            {
 return new clsAppointment(AppointmentID,TestTypeID,LocalDrivingLicenseApplicationID,
     AppointmentDate,PaidFees,CreatedByUserID,IsLocked,RetakeTestID);
            }
            else
            {
                return null;
            }
        
        }
        
        
        private bool _Add()
        {
            this.TestAppointmentID = dtAppointment.Add(this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked
                ,this.ReTakeTestID);
            return (this.TestAppointmentID>-1);
        }
        private bool _Update()
        {
            return (dtAppointment.Update(this.TestAppointmentID,
    this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, 
                this.IsLocked, this.ReTakeTestID));
        }
        static public bool Delete(int AppointmentID)
        {
            return (dtAppointment.Delete(AppointmentID));
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
        
        

        public static bool IsLocalDrivingLicenseExist(int LocalDrivingLicense)
        {
            return (dtAppointment.ExistByLocalDrivingLicenseID(LocalDrivingLicense));
        }
        
        public static DataTable GetAllAppointments(int TestTypeID,int LocalDrivingLicenseID)
        {
            return (dtAppointment.GetAllAppointments(TestTypeID,LocalDrivingLicenseID));
        }
        
    private int _GetTestID()
        {
            return (dtAppointment.GetTestID(TestAppointmentID));
        }
        
    }
}

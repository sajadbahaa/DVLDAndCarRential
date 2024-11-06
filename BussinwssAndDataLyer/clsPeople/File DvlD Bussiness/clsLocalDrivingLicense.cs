using DvlcDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace clsPeople
{
    //int LocalDrivingLicenseApplicationID, ref int ApplicationID,ref int LicenseClassID
    public class clsLocalDrivingLicense:clsApplication
    {
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public clsClassLicense ClassLicsens; 
        enum enMode { add = 1, Update = 2 }
        private enMode _Mode;
        public clsLocalDrivingLicense()
        {
            LocalDrivingLicenseApplicationID = -1;
            LicenseClassID = -1;
            _Mode = enMode.add;
        }
        
      static  public string ClassName(int ClassLicenseID) 
        {
            return clsClassLicense.GetClassName(ClassLicenseID);
        }
private clsLocalDrivingLicense
(int LocalDrivingLicenseApplicationID, int ApplicationID, int PersonID,
   DateTime AppDate, int AppTypeID, enApplicationStatus ApplicationStatus,
  DateTime LastStatusDate, Decimal PaidFees, int UserID, int LicenseClassID)

        {
this.LicenseClassID = LicenseClassID;
this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
this.ApplicationID= ApplicationID;
this.PersonID = PersonID;
this.ApplicationStatus = ApplicationStatus;
this.AppTypeID = AppTypeID;
this.AppDate = AppDate;
this.LastStatusDate = LastStatusDate;
this.PaidFees = PaidFees;
this.UserID = UserID;
            ClassLicsens = clsClassLicense.Find(this.LicenseClassID);
_Mode = enMode.Update;
        }
        
public static int GetLocalDrivingLicenesID(int ApplicationID,int classLicenseID)
        {
return dtLocalDrivingLicense.
GetLocalDrivingLicenseID(ApplicationID,classLicenseID);
        }


        public static clsLocalDrivingLicense FindByLocalDrivingLicenseID(int LocalDrivingLicenseID)
        {
            int ApplicationID = -1, ClassLicenseID = -1;
            bool IsFind = dtLocalDrivingLicense.Find(LocalDrivingLicenseID, ref ApplicationID, ref ClassLicenseID);


            if (IsFind)
            {
                clsApplication Application = clsApplication.FindByAppID(ApplicationID);
                return new clsLocalDrivingLicense(LocalDrivingLicenseID, ApplicationID,
                    Application.PersonID, Application.AppDate, Application.AppTypeID,
                    Application.ApplicationStatus, Application.LastStatusDate,
                    Application.PaidFees,Application.UserID,ClassLicenseID);
            }
            else
            {
                return null;
            }
        }
        public static clsLocalDrivingLicense
    FindLocalLicensByApplicationID(int ApplicationID)
        {
           int LocalDrivingLicenseID = 1, ClassLicenseID = -1;
            bool IsFind = dtLocalDrivingLicense.Find(ref LocalDrivingLicenseID, ApplicationID, ref ClassLicenseID);

            if (IsFind)
            {
                clsApplication Application = clsApplication.FindByAppID(ApplicationID);
                return new clsLocalDrivingLicense(LocalDrivingLicenseID, ApplicationID,
                    Application.PersonID, Application.AppDate, Application.AppTypeID,
                    Application.ApplicationStatus, Application.LastStatusDate,
                    Application.PaidFees, Application.UserID, ClassLicenseID);

            }
            else
            {
                return null;
            }
        }
        private bool _Add()
        {
            this.LocalDrivingLicenseApplicationID = dtLocalDrivingLicense.Add(this.ApplicationID,this.LicenseClassID);
            return (this.LocalDrivingLicenseApplicationID > -1);

        }
        private bool _Update()
        {
         return (dtLocalDrivingLicense.Update(this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID));
        }
        public static bool Exist(int ID)
        {
            return (dtLocalDrivingLicense.Exist(ID));
        }
        
    public  bool Delete()
        {
            //First we delete Local Driving License ID
            bool IsLocalLicenseDeleted = false;
            bool IsApplicationDeleted = false;
            IsLocalLicenseDeleted = dtLocalDrivingLicense.Delete(this.LocalDrivingLicenseApplicationID);
            if (!IsLocalLicenseDeleted)
                return false;
            IsApplicationDeleted = base.Delete();
            return IsApplicationDeleted;

        }

        public static bool IsClassLicenseIDExist(int ClassLicensID)
        {
            return (dtLocalDrivingLicense.IsClassLicenceExist(ClassLicensID));
        }
        
        public bool Save()
        {
            base.Mode = (clsApplication.enMode)Mode;
            
            if (!base.Save())
                return false;

            switch (_Mode)
            {
            case enMode.add:
                    if (_Add())
                    {
                    _Mode = enMode.Update;
                    return true;
                    
                    }
                    else
                    {
                        return false;
                    
                    }
                case enMode.Update:
                    return _Update();
            }
            return false;
        }
        public int GetActiveLicenseID()
        {
            return clsLicense.GetLicenseActiveByPersonID(this.PersonID, this.LicenseClassID);
        }
        public bool IsLicenseIssue()
        {
            return (GetActiveLicenseID()!=-1);
        }
        public static DataTable AllLocalDrivingLicense()
        {
            return (dtLocalDrivingLicense.AllLocalDrivingLicens());
        }
        public bool DoesPassTest(int  TestTypeID)
        {
            return (dtLocalDrivingLicense.DoesTestPass(this.LocalDrivingLicenseApplicationID,(int)TestTypeID));
        }
        
         public  bool IsThereAnActiveSchedualTest(clsTestTypes.enTestType TestTypeID)
        {
            return (dtLocalDrivingLicense.IsThereAnActiveSchedualTest(this.LocalDrivingLicenseApplicationID,(int)TestTypeID));
        }

        static public 
            bool IsThereAnActiveSchedualTest( int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            return (dtLocalDrivingLicense.IsThereAnActiveSchedualTest(LocalDrivingLicenseApplicationID, (int)TestTypeID));
        }

        public clsTests GetLastTestPerTestType(clsTestTypes.enTestType TestTypeID)
        {
            return clsTests.FindLastTest(this.PersonID, this.LicenseClassID,TestTypeID);
        }
        public bool DoesAttendTestType(clsTestTypes.enTestType TestTypeID)
        {
            return (dtLocalDrivingLicense.DoesAttendTestType(this.LocalDrivingLicenseApplicationID,(int)TestTypeID));
        }
        public byte GetTrailsPerTest(clsTestTypes.enTestType TestTypeID)
        {
            return (dtLocalDrivingLicense.TotalTrailsPerTest(this.LocalDrivingLicenseApplicationID,(int)TestTypeID));
        }
        public bool IsPassAllTests()
        {
            return clsTests.GetAllPassTest(this.LocalDrivingLicenseApplicationID);
        }
        public int IssueLicenseForFirstTime(int UserID,string Notes)
        {
            int LicenseID = -1;
            int DriverID = -1;
            // we define object from clsDriver to 
            // check if this person  exist or not
            clsDriver DriverInfo = clsDriver.FindByPersonID(this.PersonID);
            
            if (DriverInfo==null)
            {
                DriverInfo = new clsDriver();
                DriverInfo.UserID = UserID;
                DriverInfo.PersonID = this.PersonID;
                if (DriverInfo.Save())
                {
                    DriverID = DriverInfo.DriverID;
                }
                else
                {
                    DriverID = -1;
                }
            }
            else
            {
                DriverID = DriverInfo.DriverID;
            }
            // now we will start to add License fro First time
            clsLicense LicenseInfo = new clsLicense();
            LicenseInfo.CreatedByUserID = UserID;
            LicenseInfo.PersonID = this.PersonID;
            LicenseInfo.ApplicationID = this.ApplicationID;
            LicenseInfo.DriverLicenseID = DriverID;
            LicenseInfo.IsActive = true;
            LicenseInfo.IssueDate = DateTime.Now;
            LicenseInfo.ExpirationDate = DateTime.Now.AddYears(this.ClassLicsens.DefaultValidityLength);
            LicenseInfo.IssueReason =(byte) clsLicense.enIssueReason.FirstTime;
            LicenseInfo.Notes = Notes;
            LicenseInfo.PaidFees = this.ClassLicsens.ClassFees;
            LicenseInfo.ClassLicenseID = this.LicenseClassID;
            if (LicenseInfo.Save())
            {
                LicenseID = LicenseInfo.LicenseID;
                this.CompleteStatus();
                return LicenseID;
            }
            else
            {
                return -1;
            }
        }
    }
}

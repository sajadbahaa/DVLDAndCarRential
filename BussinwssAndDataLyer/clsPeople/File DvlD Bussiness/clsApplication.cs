using DvlcDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clsPeople
{

    public class clsApplication 
    {
    public int ApplicationID { get; set; }
    public int PersonID { get; set; }
    public int AppTypeID { get; set; }
    public DateTime AppDate { get; set;}
    public DateTime LastStatusDate { get; set; }
    public decimal PaidFees { get; set; }
    public int UserID { get; set; }
    
public  enum enMode {add =1,update =2}
     
     public enum enApplicationType
        {
       NewDrivingLicense =1,RenewDrivingLicens =2,
    ReplaceLostDrivingLicense=3,ReplaceDamagedDrivingLicens = 4,
    ReleaseDetainedDrivingLicense =5,NewInternationalLicense,RetakeTest = 7,
    CarRential = 8
        }
    //    public enApplicationType applicationType = enApplicationType.CarRential;
    public enum enApplicationStatus { New =1,Cancel =2,Complete =3}
    public clsAppType clsApplicationType;
        public clsUser CreateCurrentUser;
        public  enApplicationStatus ApplicationStatus { get; set; }
public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Complete:
                        return "Complete";
                    case enApplicationStatus.Cancel:
                        return "Cancel";
                    default:
                        return "UnKnown";
                }
            }
        }
public string ApplicationFullName
        {
            get
            {
                return (clsPerson.FindByPersonID(this.PersonID).FullName());
            }
        }

        public enMode Mode;
     
        
        public clsApplication()
        {
            this.AppDate = DateTime.Now;
            this.ApplicationID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.AppTypeID = 1;
            this.PersonID = -1;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;

            Mode = enMode.add;
        }
        public clsPerson PersonInfo;
        private clsApplication ( int AppID,int PersonID, int UserID, int AppTypeID, DateTime AppDate, enApplicationStatus ApplicationStatus,
        DateTime LastStatusDate, decimal PaidFees)
        {
            this.PersonID = PersonID;
            this.UserID = UserID;
            this.AppTypeID = AppTypeID;
            this.AppDate = AppDate;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.ApplicationID = AppID;
            clsApplicationType = clsAppType.Find(this.AppTypeID);
            this.CreateCurrentUser = clsUser.FindByUserID(this.UserID);
            this.PersonInfo = clsPerson.FindByPersonID(PersonID);
            Mode = enMode.update;
        
        }
        
       
        static public int GetApplicatonIDActiveForLicenseClass(int PersonID,int ApplicatonTypeID,int ClassLicenseID)
        {
            return dtApp.GetApplicationActiveForClassLicense(PersonID, ApplicatonTypeID, ClassLicenseID); ;
        }
        
        static public bool DoesApplicationActive(int PersonID,int ApplicationTypeID)
        {
            return (dtApp.DoesPersonHasActiveApplication(PersonID,ApplicationTypeID));
        }
        public bool DeosPersonHasActiveApplication(int ApplicationTypeID)
        {
            return DoesApplicationActive(this.PersonID, ApplicationTypeID);
        }
        public int GetActiveApplicationID(int PersonID,int ApplicationTypeID)
        {
            return dtApp.GetActiveApplicationID(PersonID,ApplicationTypeID);
        }
        
    public static clsApplication FindByAppID(int AppID)
        {
            int UserID = -1, PersonID = -1, AppTypeID = -1;
            DateTime AppDate = DateTime.Now, LastStatusDate = DateTime.Now;
            byte Status = (byte)enApplicationStatus.New ;
            decimal PaidFees = 0;
            if(dtApp.Find(AppID,ref PersonID,ref AppDate,ref AppTypeID,ref  Status,ref LastStatusDate,
                ref PaidFees,ref UserID))
            {
              return new clsApplication( AppID, PersonID,UserID,AppTypeID,AppDate,(enApplicationStatus)Status,LastStatusDate,PaidFees);
            }
            else
            {
                return null;
            }
        }
        
        private bool _Add()
        {
            this.ApplicationID = dtApp.Add(this.PersonID, this.AppDate, this.AppTypeID,(byte) this.ApplicationStatus
         , this.LastStatusDate, this.PaidFees, this.UserID);
            return (this.ApplicationID>-1);
        }
     private bool _Update()
        {
            return (dtApp.Update(this.ApplicationID,this.PersonID, this.AppDate, this.AppTypeID,(byte) this.ApplicationStatus
         , this.LastStatusDate, this.PaidFees, this.UserID));
        }


        

    public  bool Delete()
        {
            return (dtApp.Delete(this.ApplicationID));
        }
    
        // here we will implement 
        public static bool CancelStatus(int ApplicationID)
        {
            return (dtApp.UpdateStatus(ApplicationID,2));
        }
        
        public bool CompleteStatus()
        {
            return (dtApp.UpdateStatus(this.ApplicationID, 3));
        }
        public static bool CompleteStatus(int ApplicationID)
        {
            return (dtApp.UpdateStatus(ApplicationID,3));
        }
        public static DataTable GetAllApplications()
        {
            return (dtApp.AllApplications());
        }
         
        public static int  GetApplicationID(int PersonID,DateTime AppDate)
        {
            return (dtApp.GetApplicationIDByPersonID(PersonID, AppDate));
        }
     
    public bool Save()
        {
            Mode = enMode.add;
            switch (Mode)
            {
                case enMode.add:
                    if (_Add())
                    {
                        Mode = enMode.update;
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


    }
}

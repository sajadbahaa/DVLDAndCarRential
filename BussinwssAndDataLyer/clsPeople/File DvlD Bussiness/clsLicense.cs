using DvlcDataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clsPeople
{
    public  class clsLicense :clsDriver 
    {
    public int LicenseID    { get; set; }        
    public int ApplicationID{ get; set; }       
    public int DriverLicenseID     { get; set; }      
    public int ClassLicenseID { get; set; }        
    public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public Byte IssueReason { get; set; }
        public int CreatedByUserID { get; set; }
        public clsDetained DetainedInfo { get; set; }
    private  enum enMode {add = 1, update = 2}
        private enMode _Mode;
public enum enIssueReason {FirstTime =1,ReNew =2,DamagedReplacement= 3,
        LostReplacement =4}
        public bool IsLicenseDetained
        {
            get
            {
                return clsDetained.IsLicenseDetained(this.LicenseID);
            }
        }
        static public DateTime GetExpirationDate(DateTime dt, int Year)
        {
            return (new DateTime(dt.Date.Year + Year, dt.Month, dt.Day));
        }
        public clsClassLicense ClassLicense;
        public clsDriver DriverInfo;
        public string IssueReasonText
        {
            get
            {
                return clsLicense.GetIssueResason((enIssueReason)this.IssueReason);
            }
        }
        public clsLicense()
        {
            LicenseID = -1;
            ApplicationID = -1;
            ClassLicenseID = -1;
            DriverLicenseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = "";
            PaidFees = 0;
            IsActive = true;
            IssueReason = 0;
            _Mode = enMode.add;

        }

    private clsLicense(int LicenseID,int ApplicationID,int LicenseClas
    ,int DriverLicenseID, DateTime IssueDate,DateTime ExpirationDate,string Notes
    ,Decimal PaidFees,bool IsActive,byte IssueReason,int CreatedByUserID)
        {
            _Mode = enMode.update;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.ClassLicenseID = LicenseClas;
            this.DriverLicenseID = DriverLicenseID;
            this.ApplicationID = ApplicationID;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseID = LicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.DriverInfo = clsDriver.FindByDriverID(DriverLicenseID);
            this.ClassLicense = clsClassLicense.Find(LicenseClas);
            this.DetainedInfo = clsDetained.GetDetainInfoByLicenseID(LicenseID);
        }
        public static clsLicense FindLicenseIDByApplication(int ApplicationID)
        {
            int UserID = -1, LicenseID = -1, DriverID = -1, LicensClass = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            Decimal PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 0;

            if (dtLicense.Find(ref LicenseID,  ApplicationID, ref DriverID, ref LicensClass,
                ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive,
                ref IssueReason, ref UserID
                ))
            {
                return new clsLicense(LicenseID, ApplicationID, LicensClass, DriverID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, UserID);
            }
            else
            {
                return null;
            }
        }
        
        public bool IsDateExpired()
        {
            return (this.ExpirationDate<DateTime.Now);
        }

        public static clsLicense Find(int LicenseID)
        {
            int UserID = -1, ApplicationID = -1, DriverID = -1,LicensClass =-1; 
            DateTime IssueDate = DateTime.Now,ExpirationDate = DateTime.Now;
            string Notes = "";
            Decimal PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 0;
            
            if (dtLicense.Find(LicenseID,ref ApplicationID,ref DriverID,ref LicensClass,
                ref IssueDate,ref ExpirationDate,ref Notes,ref PaidFees,ref IsActive,
                ref IssueReason,ref UserID
                ))
            {
                return new clsLicense(LicenseID,ApplicationID,LicensClass,DriverID,IssueDate,ExpirationDate,Notes,PaidFees,IsActive,IssueReason,UserID);
            }
            else
            {
                return null;
            }
        }
    
       public clsLicense ReNewLicense(string Note,int UserID)
        {
 
            //first we Add Application
            clsApplication Application = new clsApplication();
            Application.AppDate = DateTime.Now;
            Application.PaidFees = clsAppType.Find((int)clsApplication.enApplicationType.RenewDrivingLicens).AppFees;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Complete;
            Application.AppTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicens;
            Application.UserID = UserID;
            Application.LastStatusDate = DateTime.Now;
            Application.PersonID = this.DriverInfo.PersonID;

            if (!Application.Save())
            {
                return null;
            }
            // after adding Application 
            // we will start adding License
            int DefaultValidty = this.ClassLicense.DefaultValidityLength;
            clsLicense NewLicense = new clsLicense();
            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.ClassLicenseID = this.ClassLicenseID;
            NewLicense.DriverLicenseID = this.DriverLicenseID;
            NewLicense.CreatedByUserID = UserID;
            NewLicense.IsActive = true;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidty);
            NewLicense.IssueReason = (int)clsApplication.enApplicationType.RenewDrivingLicens;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.PaidFees = this.ClassLicense.ClassFees;
            NewLicense.Notes = Note;
            
            if (!NewLicense.Save())
            {
                return null;
            }
            this.DeActivateLicense();
            return NewLicense;
        }
       public bool DeActivateLicense()
        {
            return (dtLicense.DeActivateLicense(this.LicenseID)>0);
        }
        
        private bool _Add()
        {

this.LicenseID = dtLicense.Add(this.ApplicationID, this.DriverLicenseID, 
this.ClassLicenseID, this.IssueDate, this.ExpirationDate, 
this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);
            return (this.LicenseID>-1);        
        
        }
        private bool _Update()
        {
            return (dtLicense.Update(this.LicenseID,this.ApplicationID, this.DriverLicenseID,
this.ClassLicenseID, this.IssueDate, this.ExpirationDate,
this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID));
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
        static public bool Delete(int LicenseID)
        {
            return (dtLicense.Delete(LicenseID));
        }
        static  public bool Exist(int LicenseID)
        {
            return (dtLicense.Exist(LicenseID));
        }
       
        public static DataTable GetAllLicensesByDriverID(int DriverID)
        {
            return (dtLicense.GetAllLicensesByDriverID(DriverID));
        }
        public static bool IsLicenseIDExistByPersonID(int PersonID, int ClassLicenseID)
        {
            return (dtLicense.GetLicenseActiveByPersonID(PersonID, ClassLicenseID) != -1);

        }
        public static int GetLicenseActiveByPersonID(int PersonID, int ClassLicenseID)
        {
            return (dtLicense.GetLicenseActiveByPersonID(PersonID, ClassLicenseID));
        }
       static  public string GetIssueResason(enIssueReason issueReason)
        {
            switch (issueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.ReNew:
                    return "Re new";
                case enIssueReason.DamagedReplacement:
                    return "Damaged Replacement";
                case enIssueReason.LostReplacement:
                    return "Lost Replacement";
                default:
                    return "First Time";
            }
        
        }
        public clsLicense DamagedORLostLicense(int UserID,enIssueReason IssueReason)
        {
            // add Application 
            clsApplication ApplicationInfo = new clsApplication();
            ApplicationInfo.UserID = UserID;
            ApplicationInfo.PaidFees = clsAppType.Find((int)IssueReason).AppFees;
            ApplicationInfo.ApplicationStatus = clsApplication.enApplicationStatus.Complete;
            ApplicationInfo.AppDate = DateTime.Now;
            ApplicationInfo.AppTypeID = (IssueReason== enIssueReason.DamagedReplacement?
                (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicens:
                (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense);
            ApplicationInfo.PersonID = this.DriverInfo.PersonID;
            ApplicationInfo.LastStatusDate = DateTime.Now;
            // now we save Application Info
            if (!ApplicationInfo.Save())
            {
                return null;
            }
            // after adding Application

            // we are going to add New License
            int DefaultValidity = this.ClassLicense.DefaultValidityLength;
            clsLicense NewLicense = new clsLicense();
            NewLicense.ApplicationID = ApplicationInfo.ApplicationID;
            NewLicense.ClassLicenseID = this.ClassLicenseID;
            NewLicense.CreatedByUserID = UserID;
            NewLicense.Notes = this.Notes;
            // issue reason if it is damage or lost License with fees = 0
            NewLicense.PaidFees = 0;
            NewLicense.DriverLicenseID = this.DriverLicenseID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidity);
            NewLicense.IssueReason = (byte)IssueReason;
            NewLicense.IsActive = true;
            if (!NewLicense.Save())
            {
                return null ;
            }
            return NewLicense; 

        }
    public int Detain(int UserId,decimal FineFees)
        {
            // we create object from clsDetain
            clsDetained DetainedInfo = new clsDetained();
            DetainedInfo.DetainDate = DateTime.Now;
            DetainedInfo.FineFees = FineFees;
            DetainedInfo.CreatedByUserID = UserId;
            DetainedInfo.LicenseID = this.LicenseID;

            // now  we save info
            if (!DetainedInfo.Save())
            {
                return -1;
            }
            // if its saved Sucessfully it has been Added
            return DetainedInfo.DetainID;
         }
public bool ReleaseDetainLicense(int UserID,ref int ApplicationID)
        {
            // first we add Application
            clsApplication ApplicationInfo = new clsApplication();
            ApplicationInfo.AppDate = DateTime.Now;
            ApplicationInfo.LastStatusDate = DateTime.Now;
            ApplicationInfo.UserID = UserID;
            ApplicationInfo.PaidFees = clsAppType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense).AppFees;
            ApplicationInfo.AppTypeID = (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense;
            ApplicationInfo.PersonID = this.DriverInfo.PersonID;
            ApplicationInfo.ApplicationStatus = clsApplication.enApplicationStatus.Complete;
            if (!ApplicationInfo.Save())
            {
                ApplicationID = -1;
                return false;
            }
            ApplicationID = ApplicationInfo.ApplicationID;

            // now we will release License from Detaining
            return this.DetainedInfo.ReleaseDatained(UserID, ApplicationID);
                }
  public static DataTable GetDriverLicense(int DriverID)
        {
            return clsLicense.GetAllLicensesByDriverID(DriverID);
        }
    public static DataTable GetInternationalLicense(int DriverID)
        {
            return clsInternationalLicense.GetAllInternationalLicenseByDriverID(DriverID);
        }
 public static  int GetLiceneIDActiveByDriverID(int DriverID)
        {
            return dtLicense.GetLicenseActiveByDriverID(DriverID);
        }

        
    }
}

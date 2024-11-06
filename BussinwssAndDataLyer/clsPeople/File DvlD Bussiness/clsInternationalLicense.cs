using DvlcDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clsPeople
{
    public  class clsInternationalLicense:clsApplication
    {


        public int InternationalLicenseID { get; set; }
        public int InternationalDriverID { get; set; }
        public int  IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public clsLicense LicenseInfo { get; set; }

        enum enMode { add = 1,update =2}
        private enMode _Mode;
        public clsInternationalLicense()
        {
            this.AppTypeID =(int) clsApplication.enApplicationType.NewInternationalLicense;
            ApplicationID = -1;
            InternationalLicenseID = -1;
            InternationalDriverID = -1;
            IssuedUsingLocalLicenseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IsActive = true;
            CreatedByUserID = -1;
            _Mode = enMode.add;
        
        }
       
        private 
clsInternationalLicense(int InternationalLicenseID,int InternationalApplicationID
,int DriverID,int IssuedUsingLocalLicenseID,DateTime IssueDate,
 DateTime ExpirationDate,bool IsActive,int CreatedByUserID,
 int PersonID, int AppTypeID, DateTime AppDate,
 enApplicationStatus ApplicationStatus,DateTime LastStatusDate
,decimal PaidFees)
        {
            _Mode = enMode.update;
            this.ApplicationID = InternationalApplicationID;
            this.InternationalDriverID = DriverID;
            this.InternationalLicenseID = InternationalLicenseID;
            this.CreatedByUserID = CreatedByUserID;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.LicenseInfo = clsLicense.Find(IssuedUsingLocalLicenseID);
            // ApplicationInfo
            this.PersonID = PersonID;
            this.UserID = CreatedByUserID;
            this.AppTypeID = AppTypeID;
            this.AppDate = AppDate;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.ApplicationID = InternationalApplicationID;
            clsApplicationType = clsAppType.Find(this.AppTypeID);
            CreateCurrentUser = clsUser.FindByUserID(this.UserID);
        }

        public static clsInternationalLicense Find(int InternationalID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int LocalLicensID = -1;
            DateTime InternationalIssueDate = DateTime.Now;
            DateTime InternationalExpirationDate = DateTime.Now;
            bool IsActive = true;
            int UserID = -1;
            
            int  PersonID = -1, AppTypeID = -1;
            DateTime AppDate = DateTime.Now, LastStatusDateApp = DateTime.Now;
            byte Status = (byte)enApplicationStatus.New;
            decimal PaidFees = 0;


            bool IsInternationlFind = dtInternationalLicense.Find(InternationalID, ref ApplicationID,
                        ref DriverID, ref LocalLicensID, ref InternationalIssueDate, ref InternationalExpirationDate,
                        ref IsActive, ref UserID);

            if (IsInternationlFind)
            {
                bool IsApplicationFind = dtApp.Find(ApplicationID,
                    ref PersonID,ref AppDate,ref AppTypeID,ref Status
                ,ref LastStatusDateApp,ref PaidFees,ref UserID);

                if (IsApplicationFind)
                    return new clsInternationalLicense(InternationalID, ApplicationID, DriverID, LocalLicensID, InternationalIssueDate, InternationalExpirationDate, IsActive, UserID, PersonID
                        , AppTypeID, AppDate, (enApplicationStatus)Status, LastStatusDateApp, PaidFees);
                else
                    return null;
            }
            else
            {
                return null;
            }
        }
       
        
        private bool _Add()
        {
            this.InternationalLicenseID = dtInternationalLicense.Add(this.ApplicationID, this.InternationalDriverID, this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);
            return (this.InternationalLicenseID>-1);
        }
        private bool _Update()
        {
            return (dtInternationalLicense.Update(this.InternationalLicenseID,
this.ApplicationID, this.InternationalDriverID, this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID));
        }
        
        
        public static bool Delete(int InternationalID)
        {
            return (dtInternationalLicense.Delete(InternationalID));
        }
        
        public static bool Exist(int InternationalID)
        {
            return (dtInternationalLicense.Exist(InternationalID));
        }
        
        public static DataTable GetAllInternationalLicenseByDriverID(int DriverID)
        {
            return (dtInternationalLicense.GetAllInternationalLicenseByDriverID(DriverID));
        }

        public bool Save()
        {
            base.Mode = (clsApplication.enMode)_Mode;

            if (!base.Save())
               return false;


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
        public static DataTable GetAllInternationalLicense()
        {
            return dtInternationalLicense.GetAllInternationalLicense();
        }
    public static int GetAnActiveInternationID(int DriverID)
        {
            return (dtInternationalLicense.GetAnActiveInternationalLicenseIDByDriverID(DriverID));
        }
    }
}

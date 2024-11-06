using DvlcDataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace clsPeople
{
    public  class clsDetained
    {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }
        public clsUser CreatUserInfo   { get; set; }
        public clsUser ReleaseUserInfo { get; set; }

        static public bool IsLicenseDetained(int LicenseID)
        {
            return (dtDetained.IsLicenseDetained(LicenseID));
        }
     enum enMode { add =1 ,update = 2}
        private enMode _Mode;
        public clsDetained()
        {
            DetainID = -1;
            DetainDate = DateTime.Now;
            LicenseID = -1;
            FineFees = -1;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseDate = DateTime.Now;
            ReleasedByUserID = -1;
            ReleaseApplicationID = -1;
            _Mode = enMode.add;
        }

    // tommorrow we will complete
    public clsDetained(int DetainID,DateTime DetainDate,
     int LicenseID,decimal FineFees,int CreatedByUserID,
     bool IsReleased,DateTime ReleaseDate, int ReleasedByUserID,
     int ReleaseApplicationID)
        {
            this.CreatedByUserID = CreatedByUserID;
            this.DetainID = DetainID;
            this.DetainDate = DetainDate;
            this.ReleaseDate = ReleaseDate;
            this.FineFees = FineFees;
            this.IsReleased = IsReleased;
            this.LicenseID = LicenseID;
            this.ReleaseApplicationID = ReleaseApplicationID;
            this.CreatUserInfo = clsUser.FindByUserID(this.CreatedByUserID);
            this.ReleaseUserInfo = clsUser.FindByUserID(this.ReleasedByUserID);
            _Mode = enMode.update;
        }

    public static clsDetained GetDetainInfo(int DetainID)
        {
        int LicenseID = -1, CreateUserID = -1,
        ReleaseUserID = -1,ReleaseApplication = -1;
        DateTime DetainDate = DateTime.Now,ReleaseDate = DateTime.MaxValue;
            decimal FineFees = 0;
            bool IsReleased = false;

            bool IsFind = dtDetained.Find(DetainID, ref LicenseID, ref DetainDate
   
               ,ref FineFees, ref CreateUserID,
               ref IsReleased, ref ReleaseDate, ref ReleaseUserID,
               ref ReleaseApplication);

            if (IsFind)
                return new clsDetained(DetainID, DetainDate, LicenseID, FineFees, CreateUserID,
                    IsReleased, ReleaseDate, ReleaseUserID, ReleaseApplication);
            else
                return null;
        }
 private bool _Add()
        {
            this.DetainID = dtDetained.Add(this.LicenseID,
                this.DetainDate, this.FineFees, this.CreatedByUserID);
            return (this.DetainID>-1);
        }
    private bool _Update()
        {
            return (dtDetained.UpdateDetainedLicense(this.DetainID,
this.LicenseID,
                this.DetainDate,this.FineFees, this.CreatedByUserID));
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
public static clsDetained GetDetainInfoByLicenseID(int LicenseID)
        {
            int DetainID = -1, CreateUserID = -1,
      ReleaseUserID = -1, ReleaseApplication = -1;
            DateTime DetainDate = DateTime.Now, ReleaseDate = DateTime.MaxValue;
            decimal FineFees = 0;
            bool IsReleased = false;

            bool IsFind = dtDetained.GetDetainedLicenseInfoByLicenseID( LicenseID, ref DetainID, ref DetainDate

               , ref FineFees, ref CreateUserID,
               ref IsReleased, ref ReleaseDate, ref ReleaseUserID,
               ref ReleaseApplication);

            if (IsFind)
                return new clsDetained(DetainID, DetainDate, LicenseID, FineFees, CreateUserID,
                    IsReleased, ReleaseDate, ReleaseUserID, ReleaseApplication);
            else
                return null;

        }
public static DataTable GetAllDetainedLicense()
        {
            return (dtDetained.GetAllDetainedLicenses());
        }
public bool ReleaseDatained(int UserID,int ApplicationID)
        {
            return (dtDetained.ReleaseDetained(this.DetainID,UserID,ApplicationID));
        }
  
    }
}

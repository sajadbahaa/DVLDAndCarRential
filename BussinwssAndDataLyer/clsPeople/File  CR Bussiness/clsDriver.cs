using DvlcDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clsPeople
{
    public  class clsDriver
    {
    public int DriverID { get; set;}
    public int PersonID { get; set; }
    public int UserID { get; set; }
    public DateTime Date { get; set; }
    public clsPerson PersonInfo;
    
        enum enMode { add =1, update =2};
        private enMode _Mode = enMode.add;
        
      public clsDriver()
        {
            PersonID = -1;
            UserID = -1;
            Date = DateTime.Now;
            DriverID = -1;
            _Mode = enMode.add;
        }
        public bool HasLicenseDriver
        {
            get
            {
                return HasDriverLicenseActive(this.DriverID);
            }
        }
       
        public int CustomerID
        {
            get
            {
                return clsCustomers.GetCustomerIDByDriverID(this.DriverID);
            }
        }
        private clsDriver( int DriverID,int PersonID,int UserID,DateTime Date)
        {
            this.DriverID = DriverID;
            this.Date     = Date;
            this.PersonID = PersonID;
            this.UserID   = UserID;
            this.PersonInfo = clsPerson.FindByPersonID(PersonID);
            _Mode = enMode.update;
        }
        public static clsDriver FindByDriverID(int DriverID)
        {
            int UserID = -1, PersonID = -1;
            DateTime Date = DateTime.Now;
            if (dtDrivers.Find(DriverID,ref PersonID,ref UserID,ref Date))
            {
                return new clsDriver(DriverID,PersonID,UserID,Date);
            }
            else
            {
                return null;
            }
        }
        public static clsDriver FindByPersonID(int PersonID)
        {
            int UserID = -1,  DriverID = -1;
            DateTime Date = DateTime.Now;
            if (dtDrivers.Find(ref DriverID,PersonID, ref UserID, ref Date))
            {
                return new clsDriver(DriverID, PersonID, UserID, Date);
            }
            else
            {
                return null;
            }
        }
        private bool _Add()
        {
            this.DriverID = dtDrivers.Add(this.PersonID, this.UserID, this.Date);
            return (this.DriverID>-1);
        }
        private bool _Update()
        {
            return (dtDrivers.Update(this.DriverID, this.PersonID, this.UserID, this.Date));
        }
        public static bool Exist(int DriverID)
        {
            return (dtDrivers.Exist(DriverID));
        }
        public static bool IsPersonIDExist(int PersonID)
        {
            return (dtDrivers.IsPersonIDExist(PersonID));
        }
        public static int _GetDriverID(int PersonID)
        {
            return dtDrivers.GetDriverID(PersonID);
        }
        public static bool Delete(int DriverID)
        {
            return (dtDrivers.Delete(DriverID));
        }
        public static DataTable GetAllDrivers()
        {
            return (dtDrivers.GetAllDrivers());
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

        public static bool HasDriverLicenseActive(int DriverID)
        {
            return dtLicense.GetLicenseActiveByDriverID(DriverID) != -1;
        }
public static bool HasDriverThisClassLicense(int PersonID,int ClassLicenseID)
        {
            return clsLicense.IsLicenseIDExistByPersonID(PersonID, ClassLicenseID);
        }
        public  bool HasDriverThisClassLicense( int ClassLicenseID)
        {
            return clsLicense.IsLicenseIDExistByPersonID(this.PersonID, ClassLicenseID);
        }

    }
}

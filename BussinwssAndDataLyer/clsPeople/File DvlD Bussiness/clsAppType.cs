using DvlcDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsPeople
{
    public  class clsAppType
    {
    public int AppTypeID { get; set; }
    public string AppName { get; set; }
    public decimal AppFees { get; set; }
    enum enMode { add = 1,update = 2}
        private enMode _Mode;
    public clsAppType()
        {
            _Mode = enMode.add;
            AppTypeID = -1;
            AppFees = 0;
            AppName = "";
        }
    private clsAppType(int AppTypeID,string AppName,decimal AppFees)
        {
            _Mode = enMode.update;
            this.AppTypeID = AppTypeID;
            this.AppFees = AppFees;
            this.AppName = AppName;
        }
    public static clsAppType Find(int AppTypeID)
        {
            string AppTitle = "";
            Decimal AppFees = 0;
            if (dtAppTypes.Find(AppTypeID,ref AppTitle,ref AppFees))
            {
                return new clsAppType(AppTypeID, AppTitle, AppFees);
            }
            else
            {
                return null;
            }

        }
        public static clsAppType Find(string AppTitle)
        {
            int AppTypeID = -1;
            Decimal AppFees = 0;
            if (dtAppTypes.Find(ref AppTypeID,AppTitle, ref AppFees))
            {
                return new clsAppType(AppTypeID, AppTitle, AppFees);
            }
            else
            {
                return null;
            }

        }
        private bool _Add()
        {
            this.AppTypeID = dtAppTypes.Add(this.AppName, this.AppFees);
            return (this.AppTypeID>-1);
        }
    private bool _Update()
        {
            return (dtAppTypes.Update(this.AppTypeID, this.AppName, this.AppFees));
        }
    //public static bool Delete(int AppTypeID)
    //    {
    //        return (dtAppTypes.Delete(AppTypeID));
    //    }
    
       // public static bool Exist(int AppTypeID) 
       // {
       //     return (dtAppTypes.Exist(AppTypeID)); 
       //}
    
        public static DataTable GetAllApplicationTypes()
        {
            return (dtAppTypes.AllApplicationTypes());
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
    }
}

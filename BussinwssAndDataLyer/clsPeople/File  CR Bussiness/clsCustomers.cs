using CRentailBussiness;
using DvlcDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsPeople
{
    public  class clsCustomers
    {

    public int CustomerID { get; set;}
    public int DriverID { get; set; }
    public bool TakePersonalInfo { get; set; }
        public clsDriver DriverInfo { get; set; }
    public static clsCustomers FindCustomerByDriverID( int DriverID)
        {
            int CustomerID = GlobalVar.nullabel ?? -1;
            bool TakePersonalInfo = false;
            bool IsFind = dtCustomers.FindCustomerByDriverID(ref CustomerID, DriverID,ref TakePersonalInfo);
            if (IsFind)
                return new clsCustomers(DriverID, CustomerID, TakePersonalInfo);
            else
                return null;
        }
        public static clsCustomers FindCustomerByCustomerID(int CustomerID)
        {
            int DriverID = GlobalVar.nullabel ?? -1;
            bool TakePersonalInfo = false;
            bool IsFind = dtCustomers.FindCustomerByCustomerID( CustomerID,ref DriverID, ref TakePersonalInfo);
            if (IsFind)
                return new clsCustomers(DriverID, CustomerID, TakePersonalInfo);
            else
                return null;
        }
        public clsCustomers()
        {
            CustomerID = GlobalVar.nullable ?? -1;
            DriverID = GlobalVar.nullable ?? -1;
            TakePersonalInfo = false;
        }
    public clsCustomers(int DriverID,int CustomerID,bool TakePersonalInfo)
        {
            this.DriverID = DriverID;
            this.CustomerID = CustomerID;
            this.TakePersonalInfo = TakePersonalInfo;
            this.DriverInfo = clsDriver.FindByDriverID(DriverID);
        }
    private bool _Add()
        {
            this.CustomerID = dtCustomers.Add(this.DriverID);
            return this.CustomerID != -1;
        }
    public bool Save()
        {
            if (!_Add())
                return false;
            return true;
        }
    static  public bool Delete(int CustomerID)
        {
            return dtCustomers.Delete(CustomerID);
        }
    
    public static int GetCustomerIDByDriverID(int DriverID)
        {
            return dtCustomers.GetCustomerIDByDriverID(DriverID);
        }
    public static bool IsCustomerExist(int DriverID)
        {
            return dtCustomers.GetCustomerIDByDriverID(DriverID) != -1;
        }
    public static DataTable GetAllCustomers()
        {
            return dtCustomers.GetAllCustomers();
        }
    }
}

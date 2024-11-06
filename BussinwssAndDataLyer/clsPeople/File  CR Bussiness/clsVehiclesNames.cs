using CRentailData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRentailBussiness
{
    public class clsVehiclesNames: GlobalVar
    {
    public int VehicleNameID { get; }
    public string VehicleName { get; }
        

        public clsVehiclesNames()
        {

            VehicleName = nullable?.ToString();
            VehicleNameID = nullable ?? -1;
        }

    public clsVehiclesNames(int VehicleNameID,string VehicleName)
        {
            this.VehicleNameID = VehicleNameID;
            this.VehicleName = VehicleName;
        }
    public static clsVehiclesNames Find(int VehicleID)
        {
            string VehicleName = nullable?.ToString();

            bool IsFind = dtVechilesNames.Find(VehicleID, ref VehicleName);
            if (IsFind)
                return new clsVehiclesNames(VehicleID, VehicleName);
            else
                return null;
        }
    
     public static DataTable GetAllVehiclesNames()
        {
            return dtVechilesNames.GetAllVehiclesNames();
        }
    public static int GetVehicleNameIDByVehicleName(string VehicleName)
        {
            return dtVechilesNames.GetVehicleNameIDByVehicleName(VehicleName);
        }
    }
}

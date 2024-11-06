using CRentailData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRentailBussiness
{
    public  class clsMainFacturesYears:GlobalVar
    {
    public int MainFactureYearID { get; }
    public decimal Year { get; }
    public clsMainFacturesYears()
        {
            MainFactureYearID = nullable ?? -1;
        Year = nullable ?? -1;
        }
    public clsMainFacturesYears(int MainFactureYearID,decimal Year)
        {
            this.MainFactureYearID = MainFactureYearID;
            this.Year = Year;
        }

        public static clsMainFacturesYears Find(int MainFactureYearID)
        {
            decimal Year = nullable ?? -1;
            bool IsFind = dtMainfacturesYears.Find(MainFactureYearID, ref  Year);
            if (IsFind)
                return new clsMainFacturesYears(MainFactureYearID, Year);
            else
                return null;
        }

    public static DataTable GetAllMainfactureYears()
        {
            return dtMainfacturesYears.GetAllMainfacturesYears();
        }
    public static Decimal GetYearForVehicle(int VehicleNameID)
        {
            return dtMainfacturesYears.GetYear(VehicleNameID);
        }
    
    }
}

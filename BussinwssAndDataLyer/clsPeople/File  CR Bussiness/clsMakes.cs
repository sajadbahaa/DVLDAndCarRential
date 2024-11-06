using CRentailData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace CRentailBussiness
{
    public  class clsMakes:GlobalVar
    {
    public int MakeID { get; }
    public string Make { get; }
    public clsMakes()
        {
            MakeID = nullable ?? -1;
            Make = nullable?.ToString();
        }
    public clsMakes(int MakeID,string Make)
        {
            this.MakeID = MakeID;
            this.Make = Make;
        }
    public static clsMakes Find(int MakeID)
        {
        string Make = nullable?.ToString();
            bool IsFind = dtMakes.Find(MakeID, ref Make);
            if (IsFind)
                return new clsMakes(MakeID, Make);
            else
                return null;
        }
    public static DataTable GetAllMakes()
        {
            return dtMakes.GetAllMakes();
        }
    public static int GetMakeIDByMake(StringBuilder Make)
        {
            return dtMakes.GetMakeIDByMake(Make);
        
                }
    
    }
}

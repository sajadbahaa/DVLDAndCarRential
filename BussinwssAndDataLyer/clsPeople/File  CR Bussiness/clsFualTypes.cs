using CRentailData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRentailBussiness
{
    public  class clsFualTypes : GlobalVar
    {
    public int FualTypesID { get; }
    public string FualType { get; }

    public clsFualTypes()
        {
            FualTypesID = nullable ?? -1;
            FualType = nullable?.ToString();
        }
     public clsFualTypes(int FualTypesID, string FualType)
        {
            this.FualType = FualType;
            this.FualTypesID = FualTypesID;
        }
 public static clsFualTypes Find(int FualTypeID)
        {
      string FualType = nullable?.ToString();
      bool IsFind = dtFualTypes.Find(FualTypeID, ref FualType);

            if (IsFind)
                return new clsFualTypes(FualTypeID, FualType);
            else
                return null;
        }

public static DataTable GetAllFualTypes()
        {
         return dtFualTypes.GetAllFualTypes();
        }
public static int GetFualTypeIDByFualType(StringBuilder FualType)
        {
            return dtFualTypes.GetFualTypeIDByFualType(FualType);
        }
    
    }
}

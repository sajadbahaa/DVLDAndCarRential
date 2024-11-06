using CRentailData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRentailBussiness
{
    public class clsModels:GlobalVar
    {
    public int ModelID { get; }
    public string Model { get;}
    public clsModels()
        {
            ModelID = nullable ?? -1;
            Model = nullable?.ToString();
        }
    public clsModels(int ModelID,string Model)
        {
            this.ModelID = ModelID;
            this.Model = Model;
        }
   
    public static clsModels Find(int ModelID)
        {
            string Model = nullable?.ToString();
            bool IsFind = dtModels.Find(ModelID, ref Model);
            if (IsFind)
                return new clsModels(ModelID, Model);
            else
                return null;
        }
    public static DataTable GetAllModels()
        {
            return dtModels.GetAllModels();
        }
    public static int GetModelIDByModel(StringBuilder Model)
        {
            return dtModels.GetModelIDByModel(Model);
        }
            }
}

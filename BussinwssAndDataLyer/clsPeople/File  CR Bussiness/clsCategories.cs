using CRentailData;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRentailBussiness
{
    public  class clsCategories:GlobalVar
    {
    public int CategoryID { get;}
    public Byte Category {get;}
    public clsCategories()
        {
            CategoryID = nullable?? -1;
            Category = 0;
        }
    public clsCategories(int CategoryID, Byte Category)
        {
            this.CategoryID = CategoryID;
            this.Category = Category;
        }
    
    public static clsCategories Find(int CategoryID)
        {
            Byte Category = 0;
            bool IsFind = dtCategories.Find(CategoryID, ref Category);
            if (IsFind)
                return new clsCategories(CategoryID, Category);
            else
                return null;
        }
    public static DataTable GetAllCategories()
        {
            return dtCategories.GetAllCategoriesTypes();
        }
    public static DataTable GetAllVehiclesByCategory(Byte Category)
        {
            return dtCategories.GetAllVehicleNameByCategory(Category);
        }
    
    public static int GetCategoryIDByCategory(Byte category)
        {
            return dtCategories.GetCategoryIDByCategory(category);
        }
    }
}

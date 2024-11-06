using DvlcDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsPeople
{
    public class clsTestTypes
    {
        //int TestTypeID,string TestTypeTitle, string TestTypeDescription,Decimal TestTypeFees
          public  enum enTestType
        {
            VisionTest = 1,WrittenTest = 2,StreetTest = 3
        }
        static public enTestType TestType;

        public int TestTypeID { get; set; }
        public string Title { get; set; }
        public string Description { get; set;}
        public decimal Fees { get; set; }
        enum enMode { Update = 1};
        private enMode _Mode;
        private clsTestTypes(int TestTypeID, string Title, string Description, decimal Fees)
        {
            this.TestTypeID = TestTypeID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
            _Mode = enMode.Update;
        }
        public static clsTestTypes Find(int TestTypeID)
        {
            string Title = "", Description = "";
            Decimal Fees = 0;
            if (dtTestTypes.Find(TestTypeID,ref Title,ref Description,ref Fees))
            {
                return new clsTestTypes(TestTypeID,Title,Description,Fees);
            }
            else
            {
                return  null;
            }
        }
        private bool _Update()
        {
            return (dtTestTypes.Update(this.TestTypeID,Title,Description,Fees));
        }
        public bool Save()
        {
            switch (_Mode) 
            {
                case enMode.Update:
                    return _Update();
            }
            return false;
        }
        public static DataTable GetAllTestTypes()
        {
            return (dtTestTypes.GetAllTestTypes());
        }
    }
}

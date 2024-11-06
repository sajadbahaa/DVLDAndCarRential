using DvlcDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace clsPeople
{
    public class clsClassLicense
    {
       public int LicenseClassID         {get;set;}
       public string ClassName           {get;set;}
       public string ClassDescription    {get;set;}
       public byte MinimumAllowedAge     {get;set;}
       public byte DefaultValidityLength {get;set;}
       public Decimal ClassFees          {get; set; }
        private clsClassLicense(int LicenseClassID, string ClassName,
           byte MinimumAllowedAge,byte DefaultValidityLength,
          Decimal ClassFees)
        {
            this.DefaultValidityLength = DefaultValidityLength;
            this.LicenseClassID = LicenseClassID;
            this.ClassFees = ClassFees;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;

        }
        public static clsClassLicense Find(int ClassLicenseID)
        {
            string ClassName = "", ClassDescription = "";
            byte MinimumAllowedAge = 0;
            byte DefaultValidityLength = 0;
            Decimal ClassFees = 0;
            if (dtLicenceClass.Find(ClassLicenseID,ref ClassName,
              ref ClassDescription,ref MinimumAllowedAge,ref DefaultValidityLength,
             ref ClassFees))
            {
            return new clsClassLicense(ClassLicenseID, ClassName,MinimumAllowedAge,
                   DefaultValidityLength, ClassFees);
            }
            else
            {
                return null;
            }
        }

      public static DataTable GetAllClassLicense()
        {
            return (dtLicenceClass.AllCalassLicaense());
        }
    public static int GetClassID(string ClassName)
        {
            return (dtLicenceClass.GetID(ClassName));
        }
        public static string GetClassName(int ClassID)
        {
            return (dtLicenceClass.GetClassName(ClassID));
        }
      

    }
}

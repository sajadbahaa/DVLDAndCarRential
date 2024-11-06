using DvlcDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace clsPeople
{
    //ref int PersonID, string NationlNo, ref string FirstName, ref string SecondName,
    //string ThirdName, ref string LastName, ref DateTime DataOfBirth, ref Byte Gendor, ref string Address,
    //string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath
   public class clsPerson
    {
    public int PersonID { get; set; }
    public string NationalNo { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SecondName { get; set; }
    public string ThirdName { get; set; }
    public DateTime Birth { get; set; }
    public Byte Gendor { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int CountryID { get; set; }
    public string ImagePath { get; set;}
    enum enMode { add = 1, update =2}
        private enMode _Mode;
   public string FullName()
        {
            return this.FirstName +' '+ SecondName + ' ' + ThirdName + ' ' + LastName;
        }
        public clsPerson()
        {
        
            PersonID = -1;
            NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            Birth = DateTime.Now;
            Gendor = 0;
            Address = "";
            Phone = "";
            Email = "";
            CountryID = -1;
            ImagePath = null;
            _Mode = enMode.add;
        }
        private clsPerson(int PersonID,string NationalNo,string FirstName,string SecondName,string ThirdName,
            string LastName,DateTime Birth, Byte Gendor,string Address,string Phone,string Email,int CountryID,
            string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Birth = Birth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.CountryID = CountryID;
            this.ImagePath = ImagePath;
            _Mode = enMode.update;
        }
        public static string GendorType(Byte Gendor)
        {
            if (Gendor==0)
            {
                return "Male";
            }
            else
            {
                return "Female";
            }
        }
        public static clsPerson FindByPersonID(int PersonID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "",
            LastName = ""; DateTime Birth = DateTime.Now; Byte Gendor = 1;
            string Address = "", Phone = "", Email = "";
            int CountryID = -1;
            string ImagePath = "";
            if (dtPeople.Find(PersonID,ref NationalNo,ref FirstName,ref SecondName,ref ThirdName,ref LastName,ref Birth,
               ref Gendor,ref Address,ref Phone,ref Email,ref CountryID,ref ImagePath))
            {
                return new clsPerson(PersonID,NationalNo,FirstName,SecondName,ThirdName,LastName,Birth,Gendor,Address,Phone,
                    Email,CountryID,ImagePath);
            }
            else
            {
                return null;
            }
        }
        public static clsPerson FindByNationalNo(string  NationalNo)
        {
            int PersonID = -1; string FirstName = "", SecondName = "", ThirdName = "",
            LastName = ""; DateTime Birth = DateTime.Now; Byte Gendor = 1;
            string Address = "", Phone = "", Email = "";
            int CountryID = -1;
            string ImagePath = "";
            if (dtPeople.FindByNationalNo(ref PersonID,NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref Birth,
               ref Gendor, ref Address, ref Phone, ref Email, ref CountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, Birth, Gendor, Address, Phone,
                    Email, CountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }
        private bool _Add()
        {
            this.PersonID =
            dtPeople.Add(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
            Birth, this.Gendor, this.Address, this.Phone, this.Email, this.CountryID, this.ImagePath);
            return (this.PersonID>-1);
        }
        private bool _Update()
        {
            return (dtPeople.Update(this.PersonID,this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
                this.LastName,Birth, this.Gendor, this.Address, this.Phone, this.Email, this.CountryID,
                this.ImagePath));
        }
        public static bool Delete(int PersonID)
        {
            return (dtPeople.Delete(PersonID));
        }
        public static bool IsPersonIDExist(int PersonID)
        {
            return dtPeople.Exsist(PersonID);
        }
     
        public static bool IsNationalNoExist(string NationalNo)
        {
            return (dtPeople.Exsist(NationalNo));
        }

        public static DataTable GetAllPeople()
        {
            return dtPeople.GetAllPeople();
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

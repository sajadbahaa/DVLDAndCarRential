using clsPeople;
using CRentailData;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRentailBussiness
{
    /// <summary>
    /// this class is to add vehicle with full Info
    /// 
    /// </summary>
 public class clsVehicles:GlobalVar
    {
public int vehicleID { get; set; }
public int vehicleNameID { get; set; }
public int FualTypeID { get; set; }
public int ModelID { get; set; }
public int MakeID { get; set; }
public int CategoryID { get; set; }
public short MainFactueYear { get; set; }
public string Image { get; set; }
public decimal mileage { get; set; }
public decimal RentailPerDay { get; set;}
public string PlateNumber { get; set;}
public enStatusVehicle VehicleStatus { get; set; }
public int ClassLicenseID { get; set; }
    public enum enStatusVehicle { Available = 1,Reserve =2,Maintence =3}
        
        public string StatusVehicleString()
        {
            switch (this.VehicleStatus)
            {
                case enStatusVehicle.Available:
                    return "Available";
                case enStatusVehicle.Reserve:
                    return "Reserve";
                case enStatusVehicle.Maintence:
                    return "Maintence";
            }
            return "Un Known";
        }
public clsCategories CategoryInfo { get; }
public clsFualTypes FualTypeInfo { get; }
public clsMakes MakeInfo { get; }
public clsModels ModelInfo { get; }

public clsVehiclesNames VehicleNamesInfo { get; }

   public clsVehicles()
        {
            vehicleID = nullable ?? -1;
        MainFactueYear = 1001;
        ModelID = nullable ?? -1;
            MakeID = nullable ?? -1;
            CategoryID = nullable ?? -1;
            vehicleNameID = nullable ?? -1;
            FualTypeID = nullable ?? -1;
            Image = nullable?.ToString();
            _mode = enMode.add;
        }

public string ClassName
        {
            get
            {
                return clsClassLicense.GetClassName(this.ClassLicenseID);

            }
        }
   public clsVehicles(int vehicleID,int vehicleNameID,int  FualTypeID,
       int ModelID, int MakeID,int CategoryID, short MainFactueYear
       , string Image,decimal mileage,decimal RentailPerDay,string PlateNumber,
       enStatusVehicle VehicleStatus,int ClassLicenseID)
        {
            this.vehicleID = vehicleID;
            this.vehicleNameID = vehicleNameID;
            this.MainFactueYear = MainFactueYear;
            this.MakeID = MakeID;
            this.ModelID = ModelID;
            this.CategoryID = CategoryID;
            this.FualTypeID = FualTypeID;
            this.Image = Image;
            this.ClassLicenseID = ClassLicenseID;
            this.MakeInfo = clsMakes.Find(MakeID);
            this.CategoryInfo = clsCategories.Find(CategoryID);
            this.FualTypeInfo = clsFualTypes.Find(FualTypeID);
            this.VehicleStatus = VehicleStatus;
            this.ModelInfo = clsModels.Find(ModelID);
            this.VehicleNamesInfo = clsVehiclesNames.Find(vehicleNameID);
            this.PlateNumber = PlateNumber;
            this.RentailPerDay = RentailPerDay;
            this.mileage = mileage;
            _mode = enMode.Update;
        }
public string NumDoorsString()
        {
            switch (this.CategoryInfo.Category)
            {
                case 1:
                    return "One Door";
                case 2:
                    return "Two Doors";
                case 3:
                    return "Three Doors";
                case 4:
                    return "Four Doors";
                case 5:
                    return "Five Doors";
                case 6:
                    return "Six Doors";
                case 8:
                    return "Eight Doors";
                default:
                    return "Two Doors";
            }
        }
 private bool _Add() 
        {
            this.vehicleID = dtVehicles.Add(this.vehicleNameID, this.CategoryID,
                this.ModelID, this.MainFactueYear, this.MakeID, this.FualTypeID
                , this.mileage, this.RentailPerDay, this.PlateNumber,
                this.Image,this.ClassLicenseID);
            return this.vehicleID !=nullable;
        }
 private bool _Update()
        {
            return dtVehicles.Update(this.vehicleID, this.vehicleNameID, this.CategoryID,
                this.ModelID,  this.MakeID, this.FualTypeID
                , this.mileage, this.RentailPerDay,
                 this.Image,this.MainFactueYear,this.ClassLicenseID);
        
        }  
    
   public bool Save()
        {
            switch (_mode) 
            {
                case enMode.add:
                    if (_Add())
                    {
                        _mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _Update();
            }
            return false;

        }

public static string GetPlateNumber()
        {
            StringBuilder sr = new StringBuilder("");
            Random r = new Random();
            for(int i= 1;i<20;i++)
            {
             sr.Append(r.Next(i));
            }
            return sr.ToString();
        }
   public static clsVehicles FindByVehicleID(int vehicleID)
        {
            int vehicleNameID = nullable ?? -1, FualTypeID = nullable ?? -1,
       ModelID = nullable ?? -1, MakeID = nullable ?? -1,
       CategoryID = nullable ?? -1, ClassLicenseID = nullable??-1;
            short MainFactueYear = 1001 ;
            string Image = nullable?.ToString();
      decimal mileage = nullable ?? -1, RentailPerDay = nullable ?? -1;
            string PlateNumber = nullable?.ToString();

            Byte Status = (Byte) enStatusVehicle.Available;
            bool IsFind = dtVehicles.Find(vehicleID, ref vehicleNameID, ref CategoryID,
                ref ModelID, ref MainFactueYear,
                ref MakeID, ref FualTypeID, ref mileage, ref RentailPerDay,
                ref PlateNumber, ref Status, ref Image,ref ClassLicenseID);
            if (IsFind)
                return new clsVehicles(vehicleID, vehicleNameID,
                    FualTypeID, ModelID, MakeID, CategoryID, MainFactueYear, 
               Image, mileage, RentailPerDay, PlateNumber, (enStatusVehicle)Status,ClassLicenseID);
            else
                return null;
        }
   public static DataTable GetAllVehivles()
        {
            return dtVehicles.GetAllVehicles();
        }
   public static bool Delete(int VehicleID)
        {
            return dtVehicles.Delete(VehicleID);
        }
public static DataTable GetAllVehiclesByCategory(decimal category)
        {
            return dtVehicles.GetAllVehiclesByCategory(category);
        }
        public static DataTable GetAllVehiclesByFualType(StringBuilder FualType)
        {
            return dtVehicles.GetAllVehiclesByFualType(FualType);
        }
 private static DataTable GetAllVehiclesStatus(bool status)
        {
            return dtVehicles.GetAllVehiclesStatus(status);
        }
   static  public DataTable GetAllVehiclesAvailable()
        {
            return GetAllVehiclesStatus(true);
        }
   static  public DataTable GetAllVehiclesUnAvailable()
        {
            return GetAllVehiclesStatus(false);
        }


    }
}

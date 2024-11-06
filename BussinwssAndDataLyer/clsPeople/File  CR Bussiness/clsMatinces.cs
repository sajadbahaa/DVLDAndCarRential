using CRentailBussiness;
using DvlcDataLayer.CRentialData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsPeople.File_DvlD_Bussiness
{
    public  class clsMatinces
    {
    public int MaintanceID { get; set; }
    public string Desctroption { get; set; }
    public bool IsRepired { get;}
    public DateTime MaintanceDate { get; set;}
    public DateTime? EndMaintenceDate { get;}
    public decimal Cost { get; set; }
    public int UserID { get; set; }
    public int VehicleID { get; set; }
  
        public enum enMode { add =1 ,Update = 2}
        private enMode _Mode = enMode.add;
        public clsMatinces()
        {
            _Mode = enMode.add;
            VehicleID = GlobalVar.nullable ?? -1;
            Desctroption = GlobalVar.nullable?.ToString();
            MaintanceDate = GlobalVar.dtnullable ?? DateTime.MinValue;
            MaintanceID = GlobalVar.nullable ?? -1;
            Cost = GlobalVar.nullable ?? -1;
            IsRepired = false;
            EndMaintenceDate = GlobalVar.dtnullable;
        UserID = GlobalVar.nullable ?? -1;
        }

    public clsVehicles VehicleInfo { get; }
public clsUser UserInfo { get; set; }
    private clsMatinces(int MaintanceID,int VehicleID,DateTime MaintanceDate
        ,string Desctroption,decimal Cost, DateTime? EndMaintenceDate,
        bool IsRepired,int UserID)
        {
            this.MaintanceID = MaintanceID;
            this.MaintanceDate = MaintanceDate;
            this.Desctroption = Desctroption;
            this.Cost = Cost;
            this.VehicleID = VehicleID;
            this.IsRepired = IsRepired;
            this.UserID = UserID;
            this.EndMaintenceDate = EndMaintenceDate;
            this.VehicleInfo = clsVehicles.FindByVehicleID(VehicleID);
            this.UserInfo = clsUser.FindByUserID(UserID);
            _Mode = enMode.Update;
        }

    public static clsMatinces FindByMaintanceID(int ID)
        {
            int VehicleID = -1,UserID = -1;
            DateTime MaintanceDate = DateTime.MinValue;
            string Desctroption = "" ;
            decimal Cost = 0;
            bool IsRepired = false;
            DateTime? EndDate = GlobalVar.dtnullable;
            
            bool IsFind = dtMaintaince.Find(ID, ref VehicleID, ref Desctroption, ref MaintanceDate
                ,ref EndDate, ref Cost, ref IsRepired,ref UserID);
            if (IsFind)
                return new clsMatinces(ID, VehicleID, MaintanceDate, Desctroption, Cost, EndDate, IsRepired,UserID);
            else
                return null;
        
        }
    
    private bool _Add()
        {
            this.MaintanceID = dtMaintaince.Add(this.VehicleID, this.Desctroption,
                this.MaintanceDate, this.Cost,this.UserID);
            return this.MaintanceID != -1;
        }
    private bool _Update()
        {
            return dtMaintaince.Update(this.MaintanceID,this.VehicleID) ;
        }
        public bool CompleteProcessMantiance()
        {
            return   _Update();
        }
    

    public bool Save()
        {
            switch (_Mode)
            {
                case enMode.add:
                    if (_Add())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
            }
            return false;
        }
    
    public short GetCountMaintanceForVehicle()
        {
            return dtMaintaince.GetCountMaintanceForVehicle(this.VehicleID);
        }
public static DataTable GetAllMatiences()
        {
            return dtMaintaince.GetAllMaintense();
        }    
    
    }
}

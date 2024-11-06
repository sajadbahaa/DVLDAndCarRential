using CRentailBussiness;
using DvlcDataLayer.CRentialData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsPeople.File__CR_Bussiness
{
    public class clsReturns
    {
    public int ReturnID { get; set; }
    public DateTime ReturnDate { get; set; }
    public string Notes { get;set;}
    public int ReservationID { get; set; }
    public byte ActualRentailDays { get; set; }
    public decimal AddtionalCharges { get; set; }
    public short mileage { get; set; }
    public decimal TotalMileage { get; set; }
    public int UserID { get; set; }
    public decimal ActualTotalAmount { get; set; }
    public int VehicleID { get; set; }
    public clsUser UserInfo { get; }
    public clsReservations ReservationInfo { get; }

    public clsReturns()
        {
            ReturnID = GlobalVar.nullabel?? -1;
            ReturnDate = GlobalVar.dtnullable ?? DateTime.MinValue;
            Notes = GlobalVar.nullable?.ToString();
            ReservationID = GlobalVar.nullable ?? -1;
            ActualRentailDays = GlobalVar.nullabel ?? 0;
            ActualTotalAmount = GlobalVar.dcnullable ?? -1;
            UserID = GlobalVar.nullable ?? -1;
            AddtionalCharges = GlobalVar.dcnullable ?? -1;
            TotalMileage = GlobalVar.dcnullable ?? -1;

        }

    public clsReturns(int ReturnID,int ReservationID, DateTime ReturnDate,
        string Notes, byte ActualRentailDays, decimal AddtionalCharges,
        short mileage, decimal TotalMileage, int UserID, decimal ActualTotalAmount)
        {
            this.ReturnID = ReturnID;
            this.ReturnDate = ReturnDate;
            this.UserID = UserID;
            this.ReservationID = ReservationID;
            this.Notes = Notes;
            this.TotalMileage = TotalMileage;
            this.ActualRentailDays = ActualRentailDays;
            this.AddtionalCharges = AddtionalCharges;
            this.mileage = mileage;
            this.ActualTotalAmount = ActualTotalAmount;
            this.ReservationInfo = clsReservations.FindByReservationID(ReservationID);
            this.UserInfo = clsUser.FindByUserID(UserID);
        }
    
    public static clsReturns FindByRetrurID(int ReturnID)
        {
            int UserID = -1, ReservID = -1;
            string Notes = "";
            byte ActualRentialDay = 0;
            decimal AdditionalCharges = 0
                ,TotalMileage = 0, ActualTotalAmount = 0;
            short mileage = 0;
            DateTime dt = DateTime.MinValue;
            bool IsFind = dtReturn.Find(ReturnID, ref ReservID, ref mileage,
                ref ActualRentialDay, ref dt, ref TotalMileage, ref Notes, 
                ref AdditionalCharges, ref ActualTotalAmount, ref UserID);
            if (IsFind)
                return new clsReturns(ReturnID, ReservID, dt, Notes, ActualRentialDay,
                    AdditionalCharges, mileage, TotalMileage, UserID, ActualTotalAmount);
            else
                return null;
        }
    
        public  bool _Add()
        {
            this.ReturnID = dtReturn.Add(this.ReservationID, this.mileage, this.ActualRentailDays, this.ReturnDate, this.TotalMileage, this.Notes, this.AddtionalCharges,this.ActualTotalAmount, this.UserID,this.VehicleID);
            return this.ReturnID != -1;
        }
    public bool Save()
        {
            return _Add();
        }
   
    
    }
}

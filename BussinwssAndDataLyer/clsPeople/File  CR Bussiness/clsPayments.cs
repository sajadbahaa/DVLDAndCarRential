using CRentailBussiness;
using DvlcDataLayer.CRentialData;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clsPeople.File__CR_Bussiness
{
    public class clsPayments:clsReservations
    {
    public int PaymentID { get; set; }
    public int CreatedByUserID { get; set; }
    public int? returnID 
        { 
            get;
        }
    public decimal ? ActualTotalDueAmount
        {
            get;
        }
    public decimal ? TotalRemaining 
        {
            get;
        }
    public decimal ?TotalRefunedAmount {
            get;
        }
    public DateTime PaymentDate { get; }
    public DateTime ? UpdatePaymentDate
        {
            get;
        }
    public string notes { get; set;}
        public clsUser CreetedUserInfo { get;  }
        public clsReservations ReservationInfo { get; set; }
 public enum enMode { add = 1,Update}
        private enMode _Mode = enMode.add;
        public clsPayments()
        {
            PaymentID = GlobalVar.nullable ?? -1;
            PaymentDate = GlobalVar.dtnullable ?? DateTime.MinValue;
             CreatedByUserID = GlobalVar.nullable ?? -1;
            notes = GlobalVar.nullable?.ToString();
            GlobalVar._mode = GlobalVar.enMode.add;
        }
public clsPayments(int PaymentID,int ReservationID,int CreatedByUserID,
   int? returnID, decimal? ActualTotalDueAmount, decimal? TotalRemaining,
   decimal ?TotalRefunedAmount, DateTime PaymentDate, DateTime? UpdatePaymentDate,string Notes)
        {
            this.ReservationID = ReservationID;
            this.PaymentID = PaymentID;
            this.returnID = returnID;
            this.TotalRefunedAmount = TotalRefunedAmount;
            this.TotalRemaining = TotalRemaining;
            this.ActualTotalDueAmount = ActualTotalDueAmount;
            this.PaymentDate = PaymentDate;
            this.UpdatePaymentDate = UpdatePaymentDate;
            this.notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            this.ReservationInfo = FindByReservationID(ReservationID);
            this.CreetedUserInfo = clsUser.FindByUserID(UserID);
            GlobalVar._mode = GlobalVar.enMode.Update;
        }

    public static clsPayments FindByPaymentID(int PaymentID)
        {
            int UserID = -1, ReservationID = -1;
            DateTime PaymentDate = DateTime.MinValue;
            decimal InitalTotalAmount = -1;
            string note = "";
            int? returnID = GlobalVar.nullable;
            decimal ?ActualTotalAmount = GlobalVar.dcnullable;
            decimal? TotalRemaining = GlobalVar.dcnullable;
            decimal? TotalRefunedAmount = GlobalVar.dcnullable;
            DateTime? UpdateDate = GlobalVar.dtnullable;

            bool IsFind = dtPayments.FindByPaymentID(PaymentID, ref ReservationID
            , ref InitalTotalAmount, ref note, ref UserID,ref ActualTotalAmount
            ,ref TotalRemaining, ref TotalRefunedAmount,
            ref PaymentDate ,ref UpdateDate,ref returnID);

            if (IsFind)
                return new clsPayments(PaymentID, ReservationID, UserID, returnID,
                    ActualTotalAmount, TotalRemaining, TotalRefunedAmount,
                    PaymentDate, UpdateDate,note);
            else
                return null;
        
        }

        private bool _Add()
        {
            this.PaymentID = dtPayments.Add(this.ReservationID, this.InitialTotalDueAmount, this.notes, this.CreatedByUserID);
            return this.PaymentID != -1;
        }
        
        private bool _Update()
        {
            return true;
        }

        public bool Save()
        {
            base.Mode = (clsReservations.enMode)_Mode;
            if (!base.Save())
                return false;


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

                case enMode.Update:
                    return _Update();
            }
            return false;
        }
        public bool CancelRentailCar()
        {
            return dtPayments.CancelRentialCar(this.PaymentID, this.ReservationInfo.ApplicationInfo.ApplicationID, this.ReservationInfo.ApplicationInfo.clsApplicationType.AppFees,
                this.ReservationInfo.InitialTotalDueAmount,this.ReservationInfo.CustomerID,this.ReservationInfo.VehicleID);
        }

    static public bool UpdatePaymentAfterReturnVehicle(
        int ReservationID, decimal TotalRemaing, decimal ActualTotalAmount
        , decimal TotalRefunedAmount, int ReturnID, int ApplicationID, int UserID, int CustomerID) 
        {
            return dtPayments.UpdatePaymentAfterReturnVehicle(ReservationID, TotalRemaing, ActualTotalAmount, TotalRefunedAmount, ReturnID, UserID); 
        }
    static public DataTable GetAllPayments()
        {
            return dtPayments.GetAllPayments();
        }
       public bool CompleteProcess()
        {
            return dtPayments.UpdatePaymentLastProcess(this.PaymentID,this.TotalRemaining, this.ReservationInfo.ApplicationID, this.ReservationInfo.CustomerID);
        } 
       
    }

}

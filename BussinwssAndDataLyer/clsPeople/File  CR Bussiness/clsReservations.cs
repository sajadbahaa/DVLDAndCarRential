using clsPeople.File__CR_Bussiness;
using CRentailBussiness;
using DvlcDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clsPeople
{
    public class clsReservations:clsApplication
    {
        //        int ReservationID,ref int CustomerID,ref int VehicleID
        //    ,ref DateTime StartDate,ref DateTime EndDate
        //    ,ref StringBuilder PickUplocation,ref StringBuilder DropOflocation,ref decimal RentialPerDay,
        //ref decimal InitialTotalDueAmount,ref int InitialRentialDays,ref StringBuilder Notes
        public enum enMode { add = 1,update =2}
        public enMode Mode = enMode.add;
        public int ReservationID { get; set; }
        public int CustomerID { get; set; }
        public int VehicleID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set ; }
        public StringBuilder PickUplocation { get; }
        public StringBuilder DropOflocation { get; }
        public  decimal RentialPerDay { get; set; }
        public decimal InitialTotalDueAmount { get; set; }
        public int CreateUserID { get; set; }
        public StringBuilder Notes { get; set; }
        public int InitialRentialDays { get;}
        
        public clsApplication ApplicationInfo { get; }
        public clsUser UserInfo { get;}
        public clsVehicles VehicleInfo { get; set; }
        public clsCustomers CustomerInfo { get; set; }
        public clsReservations()
        {
            ReservationID = GlobalVar.nullable ?? -1;
            CustomerID = GlobalVar.nullable ?? -1;
            VehicleID = GlobalVar.nullable ?? -1;
            StartDate = GlobalVar.dtnullable ?? DateTime.MinValue;
            EndDate = GlobalVar.dtnullable ?? DateTime.MinValue;
            RentialPerDay = GlobalVar.nullable ?? -1;
            InitialRentialDays = GlobalVar.nullable ?? -1;
            InitialTotalDueAmount = GlobalVar.nullable ?? -1;
            Notes = new StringBuilder(GlobalVar.nullable?.ToString());
            PickUplocation = new StringBuilder(GlobalVar.nullable?.ToString());
            DropOflocation = new StringBuilder(GlobalVar.nullable?.ToString());
            ApplicationID = GlobalVar.nullable ?? -1;
            GlobalVar._mode = GlobalVar.enMode.add;
        
        }

        private clsReservations(int ReservationID,int CustomerID
  ,int VehicleID, DateTime StartDate, DateTime EndDate,int ApplicationID,
            StringBuilder PickUplocation,
        StringBuilder DropOflocation, decimal RentialPerDay, decimal InitialTotalDueAmount,
int InitialRentialDays, StringBuilder Notes,int CreateUserID)
        {
            this.ReservationID = ReservationID;
            this.CustomerID = CustomerID;
            this.VehicleID = VehicleID;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.PickUplocation = PickUplocation;
            this.DropOflocation = DropOflocation;
            this.RentialPerDay = RentialPerDay;
            this.InitialTotalDueAmount = InitialTotalDueAmount;
            this.InitialRentialDays = InitialRentialDays;
            this.Notes = Notes;
            this.ApplicationID = ApplicationID;
            this.ApplicationInfo = FindByAppID(ApplicationID);
            this.CreateUserID = CreateUserID;
            this.UserInfo = clsUser.FindByUserID(CreateUserID);
            this.VehicleInfo = clsVehicles.FindByVehicleID(VehicleID);
            this.CustomerInfo = clsCustomers.FindCustomerByCustomerID(CustomerID);
            GlobalVar._mode = GlobalVar.enMode.Update;
        }
        public static clsReservations
FindByReservationID (int ReservationID)
        {
     
            int VehicleID = -1, CustomerID = -1;
            DateTime StartDate = DateTime.MinValue,EndDate = DateTime.MinValue;
            StringBuilder Notes = new StringBuilder(""),
                        PickUplocation = new StringBuilder(""),
                        DropOflocation = new StringBuilder("");

            decimal RentialPerDay = -1, InitialTotalDueAmount = -1;
            int InitialRentialDays = -1,ApplicationID = -1,UserID = -1;

            bool IsFind = dtReservation.Find(ReservationID, ref CustomerID, ref VehicleID,
                ref StartDate, ref EndDate, ref PickUplocation, ref DropOflocation,
                ref RentialPerDay, ref InitialTotalDueAmount
                , ref InitialRentialDays, ref Notes,ref ApplicationID,ref UserID);

            if (IsFind)
                return new clsReservations(ReservationID,CustomerID,VehicleID,StartDate,
                    EndDate,ApplicationID,PickUplocation,DropOflocation,RentialPerDay,InitialTotalDueAmount,
                    InitialRentialDays,Notes,UserID);
            else
                return null;
        }
private bool _Add()
        {
            this.ReservationID = dtReservation.Add(this.CustomerID, this.VehicleID, this.StartDate,
                this.EndDate, this.PickUplocation,this.DropOflocation, this.RentialPerDay,
                this.InitialTotalDueAmount, this.Notes,this.ApplicationID,this.CreateUserID);
            return this.ReservationID != -1;
        }  
private bool _Update()
        {
            return true;
        }
public bool Save()
        {
            base.Mode = (clsApplication.enMode)Mode;
            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.add:
                    if (_Add())
                    {
                        Mode = enMode.update;
                        return true;
                    }
                    else
                        return false;

                case enMode.update:
                     return _Update();
            }
            return false;
        }


         
        public bool ExtendPeriodRentailCar(int UserID,DateTime NewDate)
        {
            this.EndDate = NewDate;
            this.CreateUserID = UserID;
            this.InitialTotalDueAmount = GetTotalAmount1(this.RentialPerDay+this.ApplicationInfo.clsApplicationType.AppFees, 
                this.StartDate, NewDate);
            return dtReservation
  .UpdateExtendCarRentialPeriod(this.ReservationID, this.InitialTotalDueAmount,
  this.CreateUserID, this.EndDate);
        }
    public decimal GetTotalAmount(decimal RentailPerDay,DateTime DayStart, DateTime DayEnd)
        {
            //   return (DayEnd > DayStart ? (((DayEnd - DayStart)+1) * RentailPerDay) : 0);
            if (DayStart.Month < DayEnd.Month)
            {
                int Day = GetDayFromMonth(DayStart.Day, DayStart);
                return ((Day + DayEnd.Day)) * RentailPerDay;
            }

            return (DayEnd.Day > DayStart.Day ? (((DayEnd.Day - DayStart.Day)) * RentailPerDay) : 0);

        }
        public int GetDayFromMonth(int Day,DateTime dt)
        {
            //get last day for month by adding -1 to addDays(-1)
            DateTime firstDayNextMonth = new DateTime(dt.Year, dt.Month, 1).AddMonths(1);

            // Get the last day of the current month by subtracting one day from the first day of next month
            DateTime LastDayForMonth = firstDayNextMonth.AddDays(-1);

            // Get the last day of the month as an integer
            int LastDay = LastDayForMonth.Day;

            // Return the remaining days in the month
            return LastDay - Day;
        }
        public decimal GetTotalAmount1(decimal RentailPerDay, DateTime DayStart, DateTime DayEnd)
        {
            if (DayStart.Month<DayEnd.Month)
            {
                int Day =  GetDayFromMonth(DayStart.Day,DayStart);
                return ((Day + DayEnd.Day) ) * RentailPerDay;
            }
            return ((((DayEnd.Day - DayStart.Day) ) * RentailPerDay));
        }
        public void RentailCarForCustomer(DateTime StartDate, DateTime EndDate, int CustomerID,
            int VehicleID, string PickUp, string DropOF,
            decimal RentialPerDay,string Notes,int UserID,int PersonID)
        {
            // create Application = new Application();
            this.AppTypeID = (int)clsApplication.enApplicationType.CarRential;
            this.UserID = UserID;
            this.PaidFees = clsAppType.Find(this.AppTypeID).AppFees;
            this.PersonID = PersonID;
            

           // now we will start Add new Reservation
            this.StartDate = StartDate;
            this.EndDate = EndDate; ;
            this.Notes.Append(Notes);
            this.CreateUserID = UserID;
            this.CustomerID = CustomerID;
            this.VehicleID = VehicleID;
            this.RentialPerDay = RentialPerDay;
            this.InitialTotalDueAmount = GetTotalAmount(RentialPerDay, StartDate, EndDate);
            this.DropOflocation.Append(DropOF);
            this.PickUplocation.Append(PickUp);
            // this.Notes.Append(Notes);

            if (!this.Save())
                return;

        }

        public bool ReturnVehicle(ref int ReturnID,Byte ActualDay,
            string Note,Decimal AddiionCharges
            ,short mileage,int UserID,DateTime ReturnDate)
        {
            //create object of return Vehicle.
            clsReturns ReturnVehicle = new clsReturns();
            ReturnVehicle.ReservationID = this.ReservationID;
            ReturnVehicle.AddtionalCharges = AddiionCharges;
            ReturnVehicle.ActualRentailDays = ActualDay;

            ReturnVehicle.ActualTotalAmount = (((this.RentialPerDay + this.ApplicationInfo.clsApplicationType.AppFees)* ActualDay) +AddiionCharges);
            ReturnVehicle.Notes = Note;
            ReturnVehicle.TotalMileage = (mileage > this.VehicleInfo.mileage ? mileage - this.VehicleInfo.mileage
                : this.VehicleInfo.mileage - mileage);
            ReturnVehicle.mileage = mileage;
            ReturnVehicle.VehicleID = this.VehicleID;
            ReturnVehicle.UserID = UserID;
            ReturnVehicle.ReturnDate = ReturnDate;
            if (!ReturnVehicle.Save())
            {
                return false;
            }
            ReturnID = ReturnVehicle.ReturnID;

            decimal ActualDueAmount = ReturnVehicle.ActualTotalAmount;

            decimal TotalRemaing = this.InitialTotalDueAmount - ReturnVehicle.ActualTotalAmount;

            decimal TotalRefaundAmont = 0;

            this.CreateUserID = UserID;
            //TotalRemaing = 0;

            return clsPayments.UpdatePaymentAfterReturnVehicle(this.ReservationID, TotalRemaing,
                ActualDueAmount,TotalRefaundAmont,ReturnVehicle.ReturnID, this.ApplicationID,
                this.CreateUserID, this.CustomerID);
       
        }

        public static DataTable GetAllReservationStatus()
        {
            return dtReservation.GetAllReservationsStatus();
        }
        public static DataTable GetAllReservationsNew()
        {
            return dtReservation.GetAllReservationsOnApplicatonStatus(1);
        }
        public static DataTable GetAllReservationsCompleted()
        {
            return dtReservation.GetAllReservationsOnApplicatonStatus(3);
        }
        public static DataTable GetAllReservationsCanceled()
        {
            return dtReservation.GetAllReservationsOnApplicatonStatus(2);
        }
        public static DataTable GetAllResetvationFromHighToLow()
        {
            return dtReservation.GetFromHighstReservationToLow();
        }
        public static DataTable GetAllCustometHighReservation()
        {
            return dtReservation.GetAllReviewCustomerOnStatus("High");
        }
        public static DataTable GetAllCustometMediumReservation()
        {
            return dtReservation.GetAllReviewCustomerOnStatus("Medium");
        }
        public static DataTable GetAllCustometLowReservation()
        {
            return dtReservation.GetAllReviewCustomerOnStatus("Low");
        }
         
        public static DataTable GetAllCustomerOnAllStaus()
        {
            return dtReservation.GetAllReviewCustomerOnAllStatus();
        }

        public static bool GetAllReservationsstatics<T>
            (ref T CountNew, ref T CountComplete, ref T CountCancel)
        {
            return dtReservation.GetAllReservationsstatics(ref CountNew,
                ref CountComplete, ref CountCancel);
        }

    public static DataTable GetEarningForEachVehicle()
        {
            return dtReservation.GetErnningForEachVehicle();
        }
    }
}

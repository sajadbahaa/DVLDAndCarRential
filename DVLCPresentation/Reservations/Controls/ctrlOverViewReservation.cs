using clsPeople;
using CRentail.Public_Classes;
using CRentail.Vehicles;
using DVLCPresentation.Customers;
using DVLCPresentation.Global_Classes;
using DVLCPresentation.Properties;
using DVLCPresentation.ReturnCar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.Reservations.Controls
{
    public partial class ctrlOverViewReservation : UserControl
    {
        public ctrlOverViewReservation()
        {
            InitializeComponent();
        }
        public ctrlOverViewReservation(int ReservationID)
        {
            InitializeComponent();
            LoadReservationInfo(ReservationID);
        }

        private clsReservations _ReservationInfo;
        public clsReservations ReservationInfo
        {
            get
            {
                return _ReservationInfo;
            }
        }
        private int _ReservationID = -1;
        public int ReservationID
        {
            get
            {
                return _ReservationID;
            }
        }
      private  void LoadImage()
        {
            if (_ReservationInfo==null|| _ReservationInfo.VehicleInfo.Image == null
                && _ReservationInfo.CustomerInfo.DriverInfo.PersonInfo.ImagePath == null)
            {
                pbCarRential.Image =
Resources.UnKnownCar; 
                pbCustomer.Image = Resources.male;
                return;
            }

 

            if (_ReservationInfo.VehicleInfo.Image!=null&&_ReservationInfo.CustomerInfo.DriverInfo.PersonInfo.ImagePath!=null)
            {
                if (File.Exists(_ReservationInfo.VehicleInfo.Image))
                {
                    pbCarRential.Load(_ReservationInfo.VehicleInfo.Image);
                }
                else
                {
                    pbCarRential.Image = Resources.UnKnownCar;
                }

                if (File.Exists(_ReservationInfo.CustomerInfo.DriverInfo.PersonInfo.ImagePath))
                {
                    pbCustomer.Load(_ReservationInfo.CustomerInfo.DriverInfo.PersonInfo.ImagePath);
                }
                else
                {
                    pbCustomer.Image = Resources.male;
                }
                return;
            }

            

        }
        private void _ResetDefaultValue()
        {
            lbApplicationStatus.Text = clsFormat.FormatString("???");
            lbEndDate.Text = clsFormat.FormatString("???");
            lbStartDate.Text = clsFormat.FormatString("???");
            lbRentialPerDay.Text = clsFormat.FormatString("???");
            lbInitalRentialDay.Text = clsFormat.FormatString("???");
            lbTotalDueAmount.Text = clsFormat.FormatString("???");
            lbReservationID.Text = clsFormat.FormatString("???");   
            LoadImage();
            lbMessage.Text = "No Reservation";
            lbMileage.Text = clsFormat.FormatString("???");
            _ReservationInfo = new clsReservations();
        }
        public void LoadReservationInfo(int ReservationID)
        {
            _ReservationInfo = clsReservations.FindByReservationID(ReservationID);
            if (_ReservationInfo==null)
            {
                _ResetDefaultValue();
                return;
            }
            _LoadData();
        }
        private void _LoadData()
        {
            _ReservationID = _ReservationInfo.ReservationID;
            lbApplicationStatus.Text = _ReservationInfo.ApplicationInfo.StatusText;
            lbStartDate.Text = clsFormat.DateToShortString(_ReservationInfo.StartDate);
            lbEndDate.Text = clsFormat.DateToShortString(_ReservationInfo.EndDate);
            lbInitalRentialDay.Text = clsFormat.ConverGenericToString(_ReservationInfo.InitialRentialDays);
            lbRentialPerDay.Text = clsFormat.ConverGenericToString(_ReservationInfo.RentialPerDay);
            lbTotalDueAmount.Text = clsFormat.ConverGenericToString(_ReservationInfo.InitialTotalDueAmount);
            lbMileage.Text = clsFormat.ConverGenericToString(_ReservationInfo.VehicleInfo.mileage);
            lbReservationID.Text = clsFormat.ConverGenericToString(ReservationInfo.ReservationID);
            _HandelPaymentProcessing();
            LoadImage();
        }

        public void _HandelPaymentProcessing()
        {
            lbMessage.Text = _ReservationInfo.ApplicationInfo.ApplicationStatus == clsPeople.clsApplication.enApplicationStatus.New ?
                "The Process is Still Continuing" :
                _ReservationInfo.ApplicationInfo.ApplicationStatus
                == clsPeople.clsApplication.enApplicationStatus.Cancel ? "The Reservation Has been Canceled" :
                "The Reservation Completed Successfully";
        }
        private void ctrlOverViewReservation_Load(object sender, EventArgs e)
        {
       
        }
       
       

        private void showCustomerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ReservationID == -1)
                return;
            frmShowCustomerInfo frm = new frmShowCustomerInfo(ReservationInfo.CustomerID);
            frm.ShowDialog();
        }

        private void showVehicleInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ReservationID == -1)
                return;

            frmShowVehicleInfo frm = new frmShowVehicleInfo(ReservationInfo.VehicleID);
            frm.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void returnVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReturnCar frm = new frmReturnCar(_ReservationID);
            frm.ShowDialog();
            LoadReservationInfo(_ReservationID);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (_ReservationID==-1)
            {
                btnVehicleInfo.Enabled = false;
                btnRetunCar.Enabled = false;
                btnCustomerInfo.Enabled = false;
                return;
            }
            btnVehicleInfo.Enabled = true;
            btnCustomerInfo.Enabled = true;
            btnRetunCar.Enabled =
                ReservationInfo.ApplicationInfo.ApplicationStatus
                == clsApplication.enApplicationStatus.New
                && ReservationInfo.VehicleInfo.VehicleStatus == CRentailBussiness.clsVehicles.enStatusVehicle.Reserve
                ? true : false; ;

        }
    }
}

using Clobal;
using clsPeople.File__CR_Bussiness;
using CRentail.Public_Classes;
using DVLCPresentation.Global_Classes;
using DVLCPresentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.ReturnCar
{
    public partial class ctrlReturnInfo : UserControl
    {
        public ctrlReturnInfo()
        {
            InitializeComponent();
        }

        private clsReturns _ReturnInfo;
        public clsReturns ReturnInfo
        {
            get
            {
                return _ReturnInfo;
            }
        }

        private void LoadImage()
        {
            if (_ReturnInfo == null 
                
                || _ReturnInfo. ReservationInfo.VehicleInfo.Image == null)
            {
                pb.Image =
Resources.UnKnownCar;
                return;
            }



            if (_ReturnInfo.ReservationInfo.VehicleInfo.Image != null )
            {
                if (File.Exists(_ReturnInfo.ReservationInfo.VehicleInfo.Image))
                {
                    pb.Load(_ReturnInfo.ReservationInfo.VehicleInfo.Image);
                }
                else
                {
                    pb.Image = Resources.UnKnownCar;
                }

                
                return;
            }



        }


        private void _LoadData()
        {
            lbAtualTotalAmount.Text = clsFormat.ConverGenericToString(_ReturnInfo.ActualTotalAmount);
            lbCustomerName.Text = _ReturnInfo.ReservationInfo.CustomerInfo.DriverInfo.PersonInfo.FullName();
            lbMileage.Text = clsFormat.ConverGenericToString(_ReturnInfo.mileage);
            txtNote.Text = _ReturnInfo.Notes;
            lbReservationID.Text = clsFormat.ConverGenericToString(_ReturnInfo.ReservationID);
            lbReturnDate.Text = clsFormat.DateToShortString(_ReturnInfo.ReturnDate);
            lbReturnID.Text = clsFormat.ConverGenericToString(_ReturnInfo.ReturnID);
            lbTotalMileage.Text = clsFormat.ConverGenericToString(_ReturnInfo.TotalMileage);
            lbAddtionalCharges.Text = clsFormat.ConverGenericToString(_ReturnInfo.AddtionalCharges);
            lbActualReturnDay.Text = clsFilters.FromIntToString(_ReturnInfo.ActualRentailDays);
            lbReservarionDate.Text = clsFormat.DateToShortString(_ReturnInfo.ReservationInfo.StartDate);
            lbRentialPerDay.Text = clsFormat.ConverGenericToString(_ReturnInfo.ReservationInfo.RentialPerDay);

            LoadImage();
        }
        public void ResetDefualtValue()
        {    
                lbAtualTotalAmount.Text = clsFormat.FormatString("???");
                lbCustomerName.Text = clsFormat. FormatString("???");
                lbMileage.Text = clsFormat.FormatString("???");
                txtNote.Text = clsFormat.FormatString("???");
            lbReservationID.Text = clsFormat.FormatString("???");
                lbReturnDate.Text = clsFormat.FormatString("???");
                lbReturnID.Text = clsFormat.FormatString("???");
                lbTotalMileage.Text = clsFormat.FormatString("???");
            lbReservarionDate.Text = clsFormat.FormatString("???");

            lbActualReturnDay.Text = clsFilters.FromIntToString("???");
            lbRentialPerDay.Text = clsFormat.ConverGenericToString("");
            LoadImage();
            _ReturnInfo = new clsReturns();   
        }
        
        public void LoadReturnDate(int ReturnID)
        {
            _ReturnInfo = clsReturns.FindByRetrurID(ReturnID);
            if (_ReturnInfo==null)
            {
                clsGlobalMessages.ErrorMessageFindByID();
                ResetDefualtValue();
                return;
            }
            _LoadData();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ctrlReturnInfo_Load(object sender, EventArgs e)
        {

        }

        private void lbAddtionalCharges_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

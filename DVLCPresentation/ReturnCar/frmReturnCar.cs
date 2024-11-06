using Clobal;
using clsPeople.File__CR_Bussiness;
using CRentail.Public_Classes;
using DVLCPresentation.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.ReturnCar
{
    public partial class frmReturnCar : Form
    {
        public frmReturnCar()
        {
            InitializeComponent();
        }
        int _ReservationID = -1;
        public frmReturnCar(int ReservationID)
        {
            InitializeComponent();
            _ReservationID = ReservationID;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ctrlReservationWithFilter1_OnReservationSelected(object sender, clsPeople.clsReservations e)
        {
            if (e.ReservationID == -1)
            {
                return;
            }

            if (e.ApplicationInfo.ApplicationStatus == clsPeople.clsApplication.enApplicationStatus.Cancel)
            {
                MessageBox.Show("this Reservation has been cancel");
                clsControls.DisableControl(btnReturn);
                return;
            }
            if (e.ApplicationInfo.ApplicationStatus == clsPeople.clsApplication.enApplicationStatus.Complete)
            {
                MessageBox.Show("this Reservation has been completed");
                clsControls.DisableControl(btnReturn);
                return;
            }
            clsControls.EnableControl(btnReturn,dtReturn);
            dtReturn.MinDate = e.StartDate;
            dtReturn.Value = dtReturn.MinDate;
           
        }

        
        private void dtReturn_ValueChanged(object sender, EventArgs e)
        {
         
        }

        public void LoadData()
        {
            RestDefultValue();
            ctrlReservationWithFilter1.LoadReservationInfo(_ReservationID);
        }
        public void RestDefultValue()
        {
                clsControls.DisableControl(dtReturn, lReturnVehicle);
        }
        private void frmReturnCar_Load(object sender, EventArgs e)
        {
        if(_ReservationID==-1)
            RestDefultValue();
        else
            LoadData();
      
        }
        int ReturnID ;

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (!clsVaildation.VaildationFieldsRequired(this))
                return;

            Byte Day = Byte.Parse(clsCalculation.GetActualDay(ctrlReservationWithFilter1.ReservationInfo.StartDate, dtReturn.Value).ToString());
            ReturnID = -1;


            bool IsProcessCompleted =  ctrlReservationWithFilter1.ReservationInfo
             .ReturnVehicle(ref ReturnID,Day
             ,txtNotes.Text,decimal.Parse(txtAddionalCharges.Text),
             short.Parse(txtCurrentMileage.Text),clsGlobal.CurrentUser.UserID,dtReturn.Value);    
            
            if (!IsProcessCompleted)
            {
                clsGlobalMessages.Messages("Faliled Return Vehicle");
                return;
            }
            clsGlobalMessages.Messages("Return Vehicle Successfully");
            clsGlobalMessages.Messages("Updated Payment Successfully");
            //clsGlobalMessages.Messages("Return ID : "+ReturnID);
            lbReturnID.Text = clsFilters.FromIntToString(ReturnID);

            clsControls.EnableControl(lReturnVehicle);
            clsControls.DisableControl(btnReturn);
        }

        private void ctrlReservationWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void lReturnVehicle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRetrunInfo frm = new frmRetrunInfo(ReturnID);
            frm.ShowDialog();
        }
    }
}

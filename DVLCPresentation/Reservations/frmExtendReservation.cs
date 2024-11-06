using Clobal;
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

namespace DVLCPresentation.Reservations
{
    public partial class frmExtendReservation : Form
    {
        public frmExtendReservation()
        {
            InitializeComponent();
        }
        int _ReservationID = -1;
        public frmExtendReservation(int ReservationID)
        {
            InitializeComponent();

            _ReservationID = ReservationID;
        }

        public void DefualtValue()
        {
            clsControls.DisableControl(dtPeriod);
            clsControls.DisableControl(lshowReservation);
            clsControls.DisableControl(btnExtend);

        }
        public void LoadData()
        {
            DefualtValue();
            ctrlReservationWithFilter1.LoadReservationInfo(_ReservationID);

        }
        private void frmExtendReservation_Load(object sender, EventArgs e)
        {
            if (_ReservationID == -1)
                DefualtValue();
            else
                LoadData();
        
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
                clsControls.DisableControl(btnExtend);
                return;
            }
            if (e.ApplicationInfo.ApplicationStatus == clsPeople.clsApplication.enApplicationStatus.Complete)
            {
                MessageBox.Show("this Reservation has been completed");
                clsControls.DisableControl(btnExtend);
                return;
            }
            clsControls.EnableControl(dtPeriod);
            dtPeriod.MinDate = e.EndDate;
            dtPeriod.MaxDate = DateTime.Now.AddMonths(1);
            dtPeriod.Value = dtPeriod.MinDate;
            //MessageBox.Show(ctrlReservationWithFilter1.ReservationInfo.VehicleInfo.VehicleNamesInfo.VehicleName);
            clsControls.EnableControl(btnExtend);
        }

        private void OnExtendPeriod(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
bool IsExtendReservationSucced  = ctrlReservationWithFilter1
    .ReservationInfo.ExtendPeriodRentailCar(clsGlobal.CurrentUser.UserID, dtPeriod.Value);

            if (!IsExtendReservationSucced)
            {
                clsGlobalMessages.Messages("Failed Extend Period ");
                return;
            }
            clsGlobalMessages.Messages("Updated Extend Period Car Rentail Successfully");
            clsControls.DisableControl(btnExtend);
            clsControls.EnableControl(lshowReservation);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowReservationInfo frm = new frmShowReservationInfo(ctrlReservationWithFilter1.ReservationID);
            frm.ShowDialog();
        }
    }
}

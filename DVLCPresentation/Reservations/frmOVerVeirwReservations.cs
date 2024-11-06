using clsPeople;
using CRentail.Public_Classes;
using CRentailBussiness;
using DVLCPresentation.Customers.Controls;
using DVLCPresentation.Reservations.Controls;
using DVLCPresentation.Vehicles.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.Reservations
{
    public partial class frmOVerVeirwReservations : Form
    {
        public frmOVerVeirwReservations()
        { 
            InitializeComponent();
            //this.Load += ReservationsScrreen_Load;
        }

        DataTable dt;
        public void GetAllVehicelUnAvailableByStatus()
        {
            int VehicleID = -1;
             dt = clsVehicles.GetAllVehiclesUnAvailable();
            foreach (DataRow r in dt.Rows)
            {
                VehicleID = int.Parse(r["VehicleID"].ToString());
                ctrlOverViewVehicle myControl = new ctrlOverViewVehicle(VehicleID);

                //clickVehicle = myControl;
                // Set a fixed size for each card

                flowLayoutPanel1.Controls.Add(myControl);
                // Add the control to the form            
            }
            if (VehicleID == -1)
                return;

            this.Controls.Add(flowLayoutPanel1);
        }

        private void carResevationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnRefresh();
            GetAllVehicelUnAvailableByStatus();
        }
        public  async Task GetAllReservationsCanceledAsync()
        {
            int ReservationID = -1;
            DataTable dt = clsReservations.GetAllReservationsCanceled();

            foreach (DataRow r in dt.Rows)
            {
                ReservationID = int.Parse(r["ReservationID"].ToString());
                ctrlOverViewReservation customer = new ctrlOverViewReservation(ReservationID);
                flowLayoutPanel1.Controls.Add(customer);
                await Task.Yield();
            }

             //this.Controls.Add(flowLayoutPanel1);
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void OnRefresh()
        {
            flowLayoutPanel1.Controls.Clear();
        
        }
        
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnRefresh();
            cbFilter.SelectedIndex = 1;
        }

        public async Task GetAllReservationNewAsync()
        {
            int ReservationID = -1;
            DataTable dt = clsReservations.GetAllReservationsNew();

            foreach (DataRow r in dt.Rows)
            {
                ReservationID = int.Parse(r["ReservationID"].ToString());
                ctrlOverViewReservation customer = new ctrlOverViewReservation(ReservationID);
                flowLayoutPanel1.Controls.Add(customer);
                await Task.Yield();
            }
            if (ReservationID == -1)
                return;

        }

        private   void ReservationsScrreen_Load(object sender, EventArgs e)
        {
            //   GetAllReservationsNew();
            try
            {
                ctrlCountReservationStatus1.LoadReservationStatics();
                cbFilter.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                clsGlobalMessages.Messages("Errror"+ex);
            }

        }
        public  async Task GetAllReservationsAsync()
        {
            int ReservationID = -1;
            DataTable dt = clsReservations.GetAllReservationStatus();

            foreach (DataRow r in dt.Rows)
            {
                ReservationID = int.Parse(r["ReservationID"].ToString());
                ctrlOverViewReservation customer = new ctrlOverViewReservation(ReservationID);
                flowLayoutPanel1.Controls.Add(customer);
                await Task.Yield();
            
            }
            if (ReservationID == -1)
                return;
        //    this.Controls.Add(flowLayoutPanel1);
        }

        public async Task GetAllReservationsCompletedAsync()
        {
            int ReservationID = -1;
            DataTable dt = clsReservations.GetAllReservationsCompleted();

            foreach (DataRow r in dt.Rows)
            {
                ReservationID = int.Parse(r["ReservationID"].ToString());
                ctrlOverViewReservation customer = new ctrlOverViewReservation(ReservationID);
                flowLayoutPanel1.Controls.Add(customer);
                await Task.Yield();

            }
            if (ReservationID == -1)
                return;
            //    this.Controls.Add(flowLayoutPanel1);
        }




        private void btnRefresh_Click(object sender, EventArgs e)
        {
        }

        private  async void refreshToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OnRefresh();
            cbFilter.SelectedIndex = 1;
            ctrlCountReservationStatus1.LoadReservationStatics();
            await GetAllReservationNewAsync();
        }

        private async void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text=="All")
            {
                OnRefresh();
               await GetAllReservationsAsync();return;
            }
            if (cbFilter.Text == "New")
            {
                OnRefresh();
                await GetAllReservationNewAsync();return;
            }
            if (cbFilter.Text=="Cancel")
            {
                OnRefresh();
                await GetAllReservationsCanceledAsync();return;
            }
            if (cbFilter.Text=="Completed")
            {
                OnRefresh();
                await GetAllReservationsCompletedAsync();return;
            }
        }
    }
}

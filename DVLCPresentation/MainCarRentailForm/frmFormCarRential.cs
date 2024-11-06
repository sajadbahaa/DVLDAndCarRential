
using CRentail.frmVehicles;
using CRentail.Vehicles;
using DVLCPresentation;
using DVLCPresentation.Customers;
using DVLCPresentation.Payments;
using DVLCPresentation.Reservations;
using DVLCPresentation.Statics;
using DVLCPresentation.Vehicles.Maintence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRentail
{
    public partial class frmFormCarRential : Form
    {
        public frmFormCarRential()
        {
            InitializeComponent();
     //       ctrlShareScreen1.LoadTitleInfo("Main Form");
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void vehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    frmOverViewVehilces frm = new frmOverViewVehilces();
            //    frm.ShowDialog();
            //}
        }
        private void vehicleListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOverViewVehilces frm = new frmOverViewVehilces();
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDrivers frm = new frmDrivers();
            frm.ShowDialog();

        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomersList frm = new frmCustomersList();
            frm.ShowDialog();
        }

        private void vehicleListToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmVehicleList frm = new frmVehicleList();
            frm.ShowDialog();

        }

        private void carRentalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOVerVeirwReservations frm = new frmOVerVeirwReservations();
            frm.ShowDialog();
        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPaymentsList frm = new frmPaymentsList();
            frm.ShowDialog();
        }

        private void staticVehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStatics frm = new frmStatics();
            frm.ShowDialog();
        }

        private void maintenseListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMaintanceList frm = new frmMaintanceList();
            frm.ShowDialog();
        }

        private void OnEarningStaticsClick(object sender, EventArgs e)
        {
            frmShowAllEarningForEacVehicle frm = new frmShowAllEarningForEacVehicle();
                frm.ShowDialog();
        }
    }
}

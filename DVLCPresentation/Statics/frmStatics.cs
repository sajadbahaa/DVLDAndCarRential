using clsPeople;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.Statics
{
    public partial class frmStatics : Form
    {
        public frmStatics()
        {
            InitializeComponent();
        }
        public  async void GetAllHighstReservationToLow()
        {
            int VehicleiD = -1;
            short NumberOfCustomers = -1;
            short NumberReservationForVehicles = -1;
            string Status = "";
            DataTable dt = clsReservations.GetAllResetvationFromHighToLow();
            foreach (DataRow row in dt.Rows)
            {
                //VehicleID,NumberVehicleForEachReserv,VehicleStatus

                VehicleiD = int.Parse(row["VehicleID"].ToString());
                NumberReservationForVehicles = short.Parse(row["NumberVehicleForEachReserv"].ToString());
                NumberOfCustomers = short.Parse(row["NumberOfCustomers"].ToString());
                Status = row["Status"].ToString();
                ctrlStaticsReservations control =
                    new ctrlStaticsReservations(VehicleiD, NumberReservationForVehicles,
                    NumberOfCustomers, Status);
                flowLayoutPanel1.Controls.Add(control);

                await Task.Yield();
            }

        }
        private void frmStatics_Load(object sender, EventArgs e)
        {
             GetAllHighstReservationToLow();
        }
    }
}

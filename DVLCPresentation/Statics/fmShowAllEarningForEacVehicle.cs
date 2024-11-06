using clsPeople;
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

namespace DVLCPresentation.Statics
{
    public partial class frmShowAllEarningForEacVehicle : Form
    {
        public frmShowAllEarningForEacVehicle()
        {
            InitializeComponent();
        }
        public async Task GetAllEarningVehicle()
        {
            int VehicleID = -1;
            decimal money = 0;
            DataTable dt = clsReservations.GetEarningForEachVehicle();
            foreach (DataRow r in dt.Rows)
            {
                VehicleID = clsFormat.ConvetStringToDataType<int>(r["VehicleID"].ToString());
                money = clsFormat.ConvetStringToDataType<decimal>(r["earnings"].ToString());
                ctrlGetEarningForEachVehicle control = new ctrlGetEarningForEachVehicle(VehicleID, money);
                await Task.Yield();
                flowLayoutPanel1.Controls.Add(control);
            }
        }
        private  async void fmShowAllEarningForEacVehicle_Load(object sender, EventArgs e)
        {
            await  GetAllEarningVehicle();
        }
    }
}

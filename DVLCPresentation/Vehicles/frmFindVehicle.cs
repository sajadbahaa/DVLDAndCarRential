using Clobal;
using CRentailBussiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.Vehicles.Controls
{
    public partial class frmFindVehicle : Form
    {
        public frmFindVehicle()
        {
            InitializeComponent();
        }
        public frmFindVehicle(int VehicleID)
        {
            InitializeComponent();
            ctrlVehicleCardWithFilter1.FilterEnable = false;
            ctrlVehicleCardWithFilter1.LoadVehicleData(VehicleID);
        }

        private void ctrlVehicleCardWithFilter1_OnVehicleSelected(object sender, CRentailBussiness.clsVehicles e)
        {
            if (ctrlVehicleCardWithFilter1.VehicleID == -1)
                return;

            MessageBox.Show("Vehicle Name : "+e.VehicleNamesInfo.VehicleName);
        }

        private void frmFindVehicle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ctrlVehicleCardWithFilter1.VehicleID!=-1)
            {
                MessageBox.Show("Exist");
            }
            else
            {
                MessageBox.Show("Choose another VehicleID");
            }
        }
    }
}

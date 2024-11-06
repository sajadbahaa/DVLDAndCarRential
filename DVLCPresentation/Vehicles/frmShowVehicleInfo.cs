using CRentail.Public_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRentail.Vehicles
{
    public partial class frmShowVehicleInfo : Form
    {
        public frmShowVehicleInfo(int VehicleID)
        {
            InitializeComponent();
            ctrlVehicleCard1.LoadVehicleData(VehicleID);
        }

        private void frmShowVehicleInfo_Load(object sender, EventArgs e)
        {

        }

        private void CLose(object sender, EventArgs e)
        {
            clsGlobalMessages.Close(this);
        }
    }
}

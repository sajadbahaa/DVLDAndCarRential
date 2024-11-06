using clsPeople;
using CRentail.Vehicles;
using CRentailBussiness;
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
    public partial class ctrlGetEarningForEachVehicle : UserControl
    {
        public ctrlGetEarningForEachVehicle(int VehicleID,decimal earning)
        {
            InitializeComponent();
            LoadData(ref VehicleID,ref  earning);
        }
        private int _VehicleID = -1;
        private decimal _earning = 0;
        private void _ResetDefault()
        {
            _VehicleID = -1;
            _earning = 0;
            clsControls.DisableControl(linShowVehicleInfo);
        }

        public void LoadData(ref  int VehicleID, ref decimal earning)
        {
            if (VehicleID==-1)
            {
                _ResetDefault();
                return;
            }
            _VehicleID = VehicleID;
            lbMoney.Text = clsFormat.ConverGenericToString(earning);
            clsControls.EnableControl(linShowVehicleInfo);

        }
        private void ctrlGetEarningForEachVehicle_Load(object sender, EventArgs e)
        {

        }

        private void linShowVehicleInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowVehicleInfo frm = new frmShowVehicleInfo(_VehicleID);
            frm.ShowDialog();
        }
    }
}

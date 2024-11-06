
using Clobal;
using CRentail.Public_Classes;
using CRentailBussiness;
using DVLCPresentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRentail.Vehicles.Controls
{
    public partial class ctrlVehicleCard : UserControl
    {
        public ctrlVehicleCard()
        { 
            InitializeComponent();
        }
        public ctrlVehicleCard(int ID)
        {
            InitializeComponent();

            LoadVehicleData(ID);
        }
        private clsVehicles _VehicleInfo;

        public clsVehicles VehicleInfo
        {
            get
            {
                return _VehicleInfo;
            }

        }

        private int _VehicleID = -1;
        public int VehicleID
        {
            get
            {
                return _VehicleID;
            }
        }
        private void LoadImage()
        {
            if (_VehicleInfo == null)
            {
                pb.Image = Resources.UnKnownCar;
                return;
            }
            if (_VehicleInfo.Image==null)
            {
                pb.Image = Resources.UnKnownCar;
                return;
            }

            if (File.Exists(_VehicleInfo.Image))
            {
                pb.ImageLocation = _VehicleInfo.Image;
                return;
            }
            else
            {
                MessageBox.Show($"We Could not Find Path " +
                    $"{_VehicleInfo.Image}");
            }

        }
        private void _LoadData()
        {
            lbModel.Text = _VehicleInfo.ModelInfo.Model;
            lbMake.Text = _VehicleInfo.MakeInfo.Make;
            lbFualType.Text = _VehicleInfo.FualTypeInfo.FualType;
            lbVehicleStatus.Text = _VehicleInfo.StatusVehicleString();
            lbNumDorrs.Text = _VehicleInfo.NumDoorsString();
            lbVehicleName.Text = _VehicleInfo.VehicleNamesInfo.VehicleName;
            lbVehicleID.Text = _VehicleInfo.vehicleID.ToString();
            lbYear.Text = _VehicleInfo.MainFactueYear.ToString();
            lEditVehicle.Enabled =  true;

            LoadImage();
            lbClassName.Text = _VehicleInfo.ClassName;

        }
        public void DefaultValue()
        {
            lbFualType.Text = "???";
            lbMake.Text = "???";
            lbModel.Text = "???";
            lbVehicleStatus.Text = "???";
            lbVehicleID.Text = "???";
            lbVehicleName.Text = "???";
            lbYear.Text = "???";
            lbNumDorrs.Text = "???";
            lbClassName.Text = "???";
            _VehicleID = GlobalVar.nullable ?? -1;
lEditVehicle.Enabled = false;
            LoadImage();
            _VehicleInfo = new clsVehicles();
        }
        public void LoadVehicleData(int VehicleID)
        {
            _VehicleInfo = clsVehicles.FindByVehicleID(VehicleID);
            if (_VehicleInfo==null)
            {
                clsGlobalMessages.ErrorMessageFindByID();
                DefaultValue();
                return;
            }
            //GlobalVar.nullable = VehicleID;
            _VehicleID = VehicleID;
            _LoadData();

        }
        private void ctrlVehicleCard_Load(object sender, EventArgs e)
        {


        }

        private void gb_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (VehicleID == -1)
                return;

            frmAddVehicle frm = new frmAddVehicle(VehicleID);
            frm.ShowDialog();
            LoadVehicleData(VehicleID);
        }
    }
}

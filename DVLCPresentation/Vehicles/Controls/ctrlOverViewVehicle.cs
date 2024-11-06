using CRentail.Public_Classes;
using CRentail.Vehicles;
using CRentailBussiness;
using DVLCPresentation.Global_Classes;
using DVLCPresentation.Properties;
using DVLCPresentation.Reservations.Reservation_List;
using DVLCPresentation.ReturnCar;
using DVLCPresentation.Vehicles.Maintence;
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

namespace DVLCPresentation.Vehicles.Controls
{
    public partial class ctrlOverViewVehicle : UserControl
    {
        public ctrlOverViewVehicle()
        {
            InitializeComponent();
        }
        public ctrlOverViewVehicle(int VehicleID)
        {
            InitializeComponent();
            LoadVehicleData(VehicleID);
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
            if (_VehicleInfo.Image == null)
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
        private void GetPictureOnVehicleStatus()
        {
            if (_VehicleInfo.VehicleStatus == clsVehicles.enStatusVehicle.Available)
                pbVehicleStatus.Image = Resources.IsAvailable;
            if (_VehicleInfo.VehicleStatus == clsVehicles.enStatusVehicle.Reserve)
                pbVehicleStatus.Image = Resources.RentVehicle;
            if(_VehicleInfo.VehicleStatus == clsVehicles.enStatusVehicle.Maintence)
                pbVehicleStatus.Image = Resources.VehliceMaintenace;
        }
        private void _LoadData()
        {
            //btnRentialCar.Enabled = _VehicleInfo.VehicleStatus ? true : false;
            btnBook.Enabled = btnRentialCar.Enabled;
            lbVehicleName.Text = _VehicleInfo.VehicleNamesInfo.VehicleName;
            //pbVehicleStatus.Image = _VehicleInfo.VehicleStatus ? Resources.Available : Resources.unavailable;
            GetPictureOnVehicleStatus();
            LoadImage();
        }

         public void LoadVehicleData(int VehicleID)
         {
            _VehicleInfo = clsVehicles.FindByVehicleID(VehicleID);
            if (_VehicleInfo == null)
            {
                //    clsGlobalMessages.Messages();
                return;
            }
            //GlobalVar.nullable = VehicleID;
            _VehicleID = VehicleID;
            _LoadData();
    }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddVehicle frm = new frmAddVehicle(VehicleID);
            frm.ShowDialog();
            LoadVehicleData(VehicleID);
        }

        private void showVehicleInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowVehicleInfo frm = new frmShowVehicleInfo(VehicleID);
            frm.ShowDialog();
        }

        private void addVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddVehicle frm = new frmAddVehicle();
            frm.ShowDialog();
        }

        private void ctrlOverViewVehicle_Load(object sender, EventArgs e)
        {

        }

        private void OnReserveVehicle(object sender, EventArgs e)
        {
            //clsGlobalMessages.MessageNotImmplementedYet();
            if (VehicleID == -1)
                return;
            
            frmAddReservation frm = new frmAddReservation(VehicleID);
            frm.ShowDialog();
            LoadVehicleData(_VehicleID);
        }

        private void OnReturnVehicle(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (VehicleID == -1)
            {
                btnRentialCar.Enabled = false;
                btnmantaince.Enabled = false;

                return;
            
            }

            btnmantaince.Enabled = VehicleInfo.VehicleStatus == clsVehicles.enStatusVehicle.Available ? true : false;

        }

        private void pb_Click(object sender, EventArgs e)
        {

        }

        private void btnmantaince_Click(object sender, EventArgs e)
        {
            frmRepireMaintense frm = new frmRepireMaintense(VehicleID);
            frm.ShowDialog();
            LoadVehicleData(VehicleID);
        }
    }
}

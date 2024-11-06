using clsPeople.File_DvlD_Bussiness;
using CRentail.Public_Classes;
using CRentail.Vehicles;
using CRentailBussiness;
using DVLCPresentation.Global_Classes;
using DVLCPresentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.Vehicles.Maintence
{
    public partial class ctrlMantanceInfo : UserControl
    {
        public ctrlMantanceInfo()
        {
            InitializeComponent();
        }
        private clsMatinces _MaintanceInfo;
        public clsMatinces MaintanceInfo
        {
            get
            {
                return _MaintanceInfo;
            }
        }
        
        private void LoadImage()
        {
            if (_MaintanceInfo. VehicleInfo == null)
            {
                pb.Image = Resources.UnKnownCar;
                return;
            }
            if (_MaintanceInfo.VehicleInfo.Image == null)
            {
                pb.Image = Resources.UnKnownCar;
                return;
            }

            if (File.Exists(_MaintanceInfo.VehicleInfo.Image))
            {
                pb.ImageLocation = _MaintanceInfo.VehicleInfo.Image;
                return;
            }
            else
            {
                MessageBox.Show($"We Could not Find Path " +
                    $"{_MaintanceInfo.VehicleInfo.Image}");
            }

        }

        private int _MaintacneID = -1;
        public int MaintaceID { get
            {
                return _MaintacneID;
            } }
        private void _RestDefualtValue()
        {
            _MaintacneID = -1;
            lbCost.Text = clsFormat.FormatString("???"); 
            lbCount.Text         = clsFormat.FormatString("???");
            lbEndMantance.Text   = clsFormat.FormatString("???");
            lbMaintanceID.Text   = clsFormat.FormatString("???");
            lbMantanceStart.Text = clsFormat.FormatString("???");
            txtNote.Text = clsFormat.FormatString("???");
            clsControls.DisableControl(linVehicleInfo);
            lbRepaire.Text = clsFormat.FormatString("???");
            LoadImage();
            _MaintanceInfo = new clsMatinces();
            }
       
        private void _LoadData()
        {
            _MaintacneID = _MaintanceInfo.MaintanceID;
            lbCost.Text = clsFormat.ConverGenericToString(_MaintanceInfo.Cost)+"$";
            lbCount.Text = clsFormat.ConverGenericToString(_MaintanceInfo.GetCountMaintanceForVehicle());
            lbEndMantance.Text = _MaintanceInfo.EndMaintenceDate == GlobalVar.dtnullable ? "NULL" :
                clsFormat.DateToShortString(_MaintanceInfo.EndMaintenceDate.Value);
            lbMaintanceID.Text = clsFormat.ConverGenericToString(_MaintanceInfo.MaintanceID);
            lbMantanceStart.Text = clsFormat.ConverGenericToString(_MaintanceInfo.MaintanceDate);
            txtNote.Text = clsFormat.ConverGenericToString(_MaintanceInfo.Desctroption);
            clsControls.EnableControl(linVehicleInfo);
            lbRepaire.Text = _MaintanceInfo.IsRepired ? clsFormat.ConverGenericToString("True") : clsFormat.ConverGenericToString("False");
            LoadImage();
        }

        public void LoadMaintanceInfo(int MaintaceID)
        {
            _MaintanceInfo = clsMatinces.FindByMaintanceID(MaintaceID);
            if (_MaintanceInfo==null)
            {
                clsGlobalMessages.ErrorMessageFindByID();
                _RestDefualtValue();
                return;
            }
            _LoadData();
        }

        private void ctrlMantanceInfo_Load(object sender, EventArgs e)
        {
        
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkVehicleinfo(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_MaintacneID == -1)
                return;
            frmShowVehicleInfo frm = new frmShowVehicleInfo(_MaintanceInfo.VehicleID);
            frm.ShowDialog();
        }

        private void lbEndMantance_Click(object sender, EventArgs e)
        {

        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

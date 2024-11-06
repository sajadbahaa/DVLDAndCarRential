using CRentail.Public_Classes;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLCPresentation.Statics
{
    public partial class ctrlStaticsReservations : UserControl
    {
        public ctrlStaticsReservations(int VehicleID
            ,short NumberVehicleForEachReserv, short NumberOfCustomers
            , string Status)
        {
            InitializeComponent();
            LoadStaticDetials(VehicleID, NumberVehicleForEachReserv, NumberOfCustomers, Status);
        }

        // VehicleID,NumberVehicleForEachReserv,VehicleStatus

        public clsVehicles VehicleInfo
        {
            get
            {
                return _VehicleInfo;
            }
        }
        private clsVehicles _VehicleInfo;
        private void LoadImage()
        {
            if (_VehicleInfo == null|| _VehicleInfo.Image == null)
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

        public void LoadStaticDetials(int VehicleID, short NumberVehicleForEachReserv,short NumberOfCustomers
            , string Status)
        {
            _VehicleInfo = clsVehicles.FindByVehicleID(VehicleID);
            if (_VehicleInfo==null)
            {
                clsGlobalMessages.ErrorMessageFindByID();
                return;
            }
            lbNumberOFCustomers.Text = clsFormat.ConverGenericToString(NumberOfCustomers);
            lbNumberReservation.Text = clsFormat.ConverGenericToString(NumberVehicleForEachReserv) ;
            lbVehicleName.Text = _VehicleInfo.VehicleNamesInfo.VehicleName;
            lbStatus.Text = Status;
            LoadImage();
            RatingImage(Status);
            
        }
        private void RatingImage(string Status)
        {
            if (Status == "high")
                pbRating.Image = Resources.FiveStars;
            if(Status== "Medium")
                pbRating.Image = Resources.FourStars;
            if(Status== "Low")
                pbRating.Image = Resources.ThreeStars;

        }
        private void ctrlStaticsReservations_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

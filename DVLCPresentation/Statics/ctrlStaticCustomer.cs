using clsPeople;
using CRentail.Public_Classes;
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
using System.Xml.Serialization;

namespace DVLCPresentation.Statics
{
    public partial class ctrlStaticCustomer : UserControl
    {
        public ctrlStaticCustomer(int CustomerID,string Status)
        {
            InitializeComponent();
            LoadCustomerData(CustomerID, Status);
        }
        private clsCustomers _CustomerInfo;
        public clsCustomers CustomerInfo
        {
            get
            {
                return _CustomerInfo;
            }
        }
        private int _PersonID = -1;
        public int PersonID
        {
            get
            {
                return _PersonID;
            }
        }
        private void _LoadImage()
        {
            if (_CustomerInfo == null)
            {
                pbCustomerImage.Image = Resources.male;
                return;
            }
            if (_CustomerInfo.DriverInfo.PersonInfo.ImagePath == null)
            {
                if (_CustomerInfo.DriverInfo.PersonInfo.Gendor == 0)
                    pbCustomerImage.Image = Resources.male;
                else
                    pbCustomerImage.Image = Resources.female;
                return;
            }

            string ImagePath = _CustomerInfo.DriverInfo.PersonInfo.ImagePath;

            if (_CustomerInfo.DriverInfo.PersonInfo.ImagePath != "")
                if (File.Exists(ImagePath))
                    pbCustomerImage.ImageLocation = ImagePath;

        }
        private void GetImageReveiew(string Status)
        {
            if (Status == "High")
                pbImage.Image = Resources.FiveStars;
            if (Status == "Medium")
                pbImage.Image = Resources.FourStars;
            if (Status == "Low")
                pbImage.Image = Resources.ThreeStars;

        }
        private void _LoadData(string Status)
        {
            _PersonID = _CustomerInfo.DriverInfo.PersonID;
            lbStstus.Text = Status;
            clsControls.EnableControl(LShowCustomerInfo);
            GetImageReveiew(Status);
            _LoadImage();
        }

        private void _ResetDefualtValue()
        {
            lbStstus.Text = clsFormat.FormatString();
            _PersonID = -1;
            clsControls.DisableControl(LShowCustomerInfo);
            _LoadImage();
            _CustomerInfo = new clsCustomers();
        }
        public void LoadCustomerData(int CustomerID,string Status)
        {
            _CustomerInfo = clsCustomers.FindCustomerByCustomerID(CustomerID);
            if (_CustomerInfo==null)
            {
                clsGlobalMessages.ErrorMessageFindByID();
            _ResetDefualtValue();
                return;
            }
            _LoadData(Status);
        }
        private void ctrlStaticCustomer_Load(object sender, EventArgs e)
        {

        }

        private void LShowCustomerInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_PersonID == -1)
            {
                clsControls.DisableControl(LShowCustomerInfo);
                return;
            }

            frmShowPersonDetails frm = new frmShowPersonDetails(_PersonID);
            frm.ShowDialog();
        }
    }
}

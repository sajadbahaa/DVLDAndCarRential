using clsPeople;
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

namespace DVLCPresentation.Customers.Controls
{
    public partial class ctrlOverViewCustomers : UserControl
    {
        public ctrlOverViewCustomers()
        {
            InitializeComponent();
        }
        public ctrlOverViewCustomers(int CustomerID)
        {
            InitializeComponent();
            LoadCustomerInfoByCustomerID(CustomerID);
        }
        private int _CustomerID = -1;
        public int CustomerID
        {
            get
            {
                return _CustomerID;
            }
        }
        private void _LoadImage()
        {
            if (_CustomerInfo==null)
            {
                pbImage.Image = Resources.male;
                return;
            }
            if (_CustomerInfo.DriverInfo.PersonInfo.ImagePath==null)
            {
                if (_CustomerInfo.DriverInfo.PersonInfo.Gendor == 0)
                    pbImage.Image = Resources.male;
                else
                    pbImage.Image = Resources.female;
                return; 
            }

            string ImagePath = _CustomerInfo.DriverInfo.PersonInfo.ImagePath;

            if (_CustomerInfo.DriverInfo.PersonInfo.ImagePath != "")
                if (File.Exists(ImagePath))
                    pbImage.ImageLocation = ImagePath;
        
        }
      
        public void ResetDefaultValue()
        {
            label.Text = "Not Found";
            _CustomerID = -1;
            _LoadImage();
            lbCustomerID.Text = clsFormat.FormatString("???");
            _CustomerInfo = new clsCustomers();

        }
        private void LoadData()
        {
            _CustomerID = _CustomerInfo.CustomerID;
            lbName.Text = _CustomerInfo.DriverInfo.PersonInfo.FullName();
            pb1.Image = _CustomerInfo.TakePersonalInfo ? Resources.IsAvailable : Resources.unavailable;
            lbCustomerID.Text = clsFormat.ConverGenericToString(_CustomerInfo.CustomerID);
            _LoadImage();
        }
        
        public void LoadCustomerInfoByCustomerID(int CusomterID)
        {
            _CustomerInfo = clsCustomers.FindCustomerByCustomerID(CusomterID);
            if (_CustomerInfo==null)
            {
                ResetDefaultValue();
                return;
            }
            LoadData();
        }
        public void LoadCustomerInfoByDriverID(int DriverID)
        {
            _CustomerInfo = clsCustomers.FindCustomerByDriverID(CustomerID);
            if (_CustomerInfo == null)
            {
                ResetDefaultValue();
                return;
            }
            LoadData();
        }

        private clsCustomers _CustomerInfo;
        public clsCustomers CustomerInfo
        {
            get
            {
                return _CustomerInfo;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ctrlOverViewCustomers_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_CustomerID == -1)
                return;
            frmShowPersonDetails frm = new frmShowPersonDetails(CustomerInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }
    }
}

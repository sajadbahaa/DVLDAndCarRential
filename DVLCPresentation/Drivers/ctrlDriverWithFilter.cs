using clsPeople;
using CRentail.Public_Classes;
using CRentailBussiness;
using DVLCPresentation.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.Drivers
{
    public partial class ctrlDriverWithFilter : UserControl
    {
        public ctrlDriverWithFilter()
        {
            InitializeComponent();
        }
        public event EventHandler<clsDriver> OnDriverSelected;
        protected void OnClickDriverSelected(clsDriver e)
        {
            OnDriverSelected?.Invoke(this, e);
        }
        private clsDriver _DriverInfo;
        public clsDriver DriverInfo
        {
            get
            {
                return _DriverInfo;
            }
        }

        public bool FilterEnable
        {
            get
            {
                return GlobalVar.FilterEnable;
            }
            set
            {
                GlobalVar.FilterEnable = value;
                gbFilter.Enabled = GlobalVar.FilterEnable;
            }
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                int ID = int.Parse(txtSearch.Text);
                btnSearch.PerformClick();
                txtSearch.Text = "".Trim();
                txtSearch.Text = ID.ToString();
            }
            clsVaildation.UserControlKeyPressHandlerNumber(sender, e);
        }
        private int _DriverID = -1;
        public int DriverID
        {
            get
            {
                return _DriverID;
            }
        }
        public clsCustomers clsCustomersInfo
        {
            get
            {
                return _CustomerInfo;
            }
        }
        private clsCustomers _CustomerInfo;
        public void ResetDefualtValue()
        {
            ctrlPersonDetails1._RestInfo();
            _DriverID = -1;
            _DriverInfo = new clsDriver();
        }
        
        public void LoadDriverInfoByDriverID(int DriverID)
        {
            _DriverInfo = clsDriver.FindByDriverID(DriverID);
            if (_DriverInfo==null)
            {
                clsGlobalMessages.ErrorMessageFindByID();
                ResetDefualtValue();
                return;
            }
            _LoadData();
        }
        public void LoadDriverInfoByPersonID(int PersonID)
        {
            _DriverInfo = clsDriver.FindByPersonID(PersonID);
            if (_DriverInfo == null)
            {
                clsGlobalMessages.ErrorMessageFindByID();
                ResetDefualtValue();
                return;
            }
            _LoadData();
        }
    private void _LoadData()
        {

            _DriverID = _DriverInfo.DriverID;
            _CustomerInfo = clsCustomers.FindCustomerByDriverID(_DriverID);
            ctrlPersonDetails1.LoadPersonDetailsByPersonID(_DriverInfo.PersonID);
        }
        private void _LoadDriveInfoByCustomerID(int CustomerID)
        {
            _CustomerInfo = clsCustomers.FindCustomerByCustomerID(CustomerID);
            if (_CustomerInfo==null)
            {
                ResetDefualtValue();
                return;
            }
            _DriverID = _CustomerInfo.DriverID;
          
            _DriverInfo = _CustomerInfo.DriverInfo ;
            ctrlPersonDetails1.LoadPersonDetailsByPersonID(_CustomerInfo.DriverInfo.PersonID);
        }
        public void FindNow()
        {
            switch (cbFilter.Text)
            {
                case "PersonID":
                    LoadDriverInfoByPersonID(int.Parse(txtSearch.Text));
                    break;
                case "DriverID":
                    LoadDriverInfoByDriverID(int.Parse(txtSearch.Text));
                    break;
                case "CustomerID":
                    _LoadDriveInfoByCustomerID(int.Parse(txtSearch.Text));        
                    break;
            }
            if (FilterEnable&&OnDriverSelected!=null)
            {
                OnClickDriverSelected(DriverInfo);
            
            }
        }
        private void OnClickFilter(object sender, EventArgs e)
        {
            if (!clsVaildation.VaildationFieldsRequired(this))
                return;
            FindNow();
        }

        private void txtSearch_Validating(object sender, CancelEventArgs e)
        {
clsVaildation.ValidatingEmpty(sender, e, txtSearch, errorProvider1);
        }

        private void ctrlDriverWithFilter_Load(object sender, EventArgs e)
        {
            clsFilters.FilterFocuse(txtSearch);
            clsControls.NextComboBox(cbFilter, 1);
            
            cbFilter.SelectedIndex = 2;
        }
        public void FilterFocuse()
        {
            clsFilters.FilterFocuse(txtSearch);
        }

        private void ctrlPersonDetails1_Load(object sender, EventArgs e)
        {

        }
    }
}

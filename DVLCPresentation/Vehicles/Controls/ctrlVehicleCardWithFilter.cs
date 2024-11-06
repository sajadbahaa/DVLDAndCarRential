using CRentail.Public_Classes;
using CRentail.Vehicles;
using CRentailBussiness;
using DVLCPresentation.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.Vehicles.Controls
{
    public partial class ctrlVehicleCardWithFilter : UserControl
    {
        public ctrlVehicleCardWithFilter()
        {
            InitializeComponent();
        }
        public event EventHandler<clsVehicles> OnVehicleSelected;
        protected virtual void OnClickVehicleSelected(clsVehicles e)
        {
            OnVehicleSelected?.Invoke(this, e);
        }
    public int VehicleID
        {
            get
            {
                return ctrlVehicleCard1.VehicleID;
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
        public clsVehicles VehicleSelected
        {
            get
            {
                return ctrlVehicleCard1.VehicleInfo;
            }
        }
        public void FilterFocuse()
        {
            clsFilters.FilterFocuse(txtSearch);
        }
        public void GetNewVehicle(int VehicleID)
        {
            txtSearch.Text = VehicleID.ToString();
            ctrlVehicleCard1.LoadVehicleData(VehicleID);
        }
        private void ctrlVehicleCard1_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            //FilterFocuse();
        }

        
        public void LoadVehicleData(int VehicleID)
        {
            txtSearch.Text = clsFilters.FromIntToString(VehicleID);
            LoadVehicleData();
        }

        public void LoadVehicleData()
        {
            ctrlVehicleCard1.LoadVehicleData(int.Parse(txtSearch.Text));

            if (FilterEnable && OnVehicleSelected != null)
            {
                OnClickVehicleSelected(VehicleSelected); 
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!clsVaildation.VaildationFieldsRequired(this))
                return;
            LoadVehicleData();
        }
    
        private void ctrlVehicleCardWithFilter_Load(object sender, EventArgs e)
        {
            clsFilters.FilterFocuse(txtSearch);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)13)
            {
                btnSearch.PerformClick();
                int ID = int.Parse(txtSearch.Text);
                txtSearch.Text = "".Trim();
                txtSearch.Text = ID.ToString();
            }
            clsVaildation.UserControlKeyPressHandlerNumber(sender, e);
        
        }

        private void AddVehicle(object sender, EventArgs e)
        {
            frmAddVehicle frm = new frmAddVehicle();
            frm.GetNewVehicleID += GetNewVehicle;
            frm.ShowDialog();
        }

        private void txtSearch_Validating(object sender, CancelEventArgs e)
        {
            clsVaildation.ValidatingEmpty(sender, e, txtSearch, errorProvider1);

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

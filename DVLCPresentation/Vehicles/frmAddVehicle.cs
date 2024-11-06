
#define debug

using clsPeople;
using CRentail.Public_Classes;
using CRentailBussiness;
using DVLCPresentation.Global_Classes;
using DVLCPresentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


namespace CRentail.Vehicles
{
    public partial class frmAddVehicle : Form
    {

        private clsVehicles _VehicleInfo;
        public Action<int> GetNewVehicleID;
        public virtual void GetNewID(int VehicleID)
        {
            GetNewVehicleID?.Invoke(VehicleID);
        }

        public void GetNewVehicle(int VehicleID)
        {
            lbVehicleID.Text = VehicleID.ToString();
        }
        public int vehicleID { get; set; }
        public int vehicleNameID { get; set; }
        public int CategoryID { get; set; }
        public int ModelID { get; set; }
        public int MakeID { get; set; }
        public int FualTypeID { get; set; }
        public int ClassLicenseID { get; set; }
        public frmAddVehicle()
        {
            InitializeComponent();
            ctrlShareScreen1.LoadTitleInfo("Add Vehicle");
            GlobalVar._mode = GlobalVar.enMode.add;
            GetNewVehicleID += GetNewVehicle;
        }
        public frmAddVehicle(int VehicleID)
        {
            InitializeComponent();
            ctrlShareScreen1.LoadTitleInfo("Update Vehicle");
            GlobalVar._mode = GlobalVar.enMode.Update;
            vehicleID = VehicleID;
        }
        private void Save(object sender, EventArgs e)
        {
            string Image = _VehicleInfo.Image;
            //    clsGlobalMessages.MessageNotImmplementedYet();
            if (!clsVaildation.VaildationFieldsRequired(this))
                return;

            if (!clsUtilize.HandelImage(ref Image, pbImage))
                return;

            _VehicleInfo.Image = Image;
            _VehicleInfo.MainFactueYear = short.Parse(lbYear.Text);
            _VehicleInfo.MakeID = MakeID;
            _VehicleInfo.ModelID = ModelID;
            _VehicleInfo.CategoryID = CategoryID;
            _VehicleInfo.FualTypeID = FualTypeID;
            //_VehicleInfo.VehicleStatus = chIsAvaliable.Checked;
            _VehicleInfo.mileage = Decimal.Parse(txtMileage.Text);
            _VehicleInfo.RentailPerDay = Decimal.Parse(txtRentail.Text);
            _VehicleInfo.PlateNumber = lbPlateNumber.Text;
            _VehicleInfo.vehicleNameID = vehicleNameID;
            _VehicleInfo.ClassLicenseID = ClassLicenseID;
            if (GlobalVar._mode == GlobalVar.enMode.add)
            {
                if (!_VehicleInfo.Save())
                {
                    clsGlobalMessages.ErrorMessageAdded();
                }
                clsGlobalMessages.AddMessage();
                GetNewVehicleID?.Invoke(_VehicleInfo.vehicleID);
            }
            else
            {
                if (!_VehicleInfo.Save())
                {
                    clsGlobalMessages.ErrorMessageUpdate();
                    return;
                }
                clsGlobalMessages.UpdateMessage();

            }
            btnSave.Enabled = false;



        }

        private void CLose(object sender, EventArgs e)
        {
            clsGlobalMessages.Close(this);
        }

        //[Conditional("debug")]
        public async void RestDefaultValue()
        {

            Task t1 = GetAllMakes();

            Task t2 = GetAllModels();

            await Task.WhenAll(t1, t2);
            GetAllCategories();
            GetAllFualTypes();
            _GetAllClassLicense();

            if (GlobalVar._mode == GlobalVar.enMode.add)
            {
                _VehicleInfo = new clsVehicles();
                vehicleID = GlobalVar.nullable ?? -1;
                lbPlateNumber.Text = clsVehicles.GetPlateNumber();
                lbStatus.Text = clsFormat.ConverGenericToString(clsVehicles.enStatusVehicle.Available);
            //    lRemove.Visible = pbImage.ImageLocation != null;
            
            }
            pbImage.Image = Resources.UnKnownCar;


        }
        public void LoadData()
        {
            _VehicleInfo = clsVehicles.FindByVehicleID(vehicleID);
            if (_VehicleInfo == null)
            {
                clsGlobalMessages.ErrorMessageFindByID();
            }
            lbYear.Text = _VehicleInfo.MainFactueYear.ToString().Trim();
            lbPlateNumber.Text = _VehicleInfo.PlateNumber;
            lbVehicleID.Text = _VehicleInfo.vehicleID.ToString();
            txtMileage.Text = (_VehicleInfo.mileage).ToString();
            txtRentail.Text = _VehicleInfo.RentailPerDay.ToString();
            cbCategory.SelectedIndex = cbCategory.FindString(_VehicleInfo.CategoryInfo.Category.ToString());
            cbFualType.SelectedIndex = cbFualType.FindString(_VehicleInfo.FualTypeInfo.FualType);
            cbMakes.SelectedIndex = cbMakes.FindString(_VehicleInfo.MakeInfo.Make);
            cbModel.SelectedIndex = cbModel.FindString(_VehicleInfo.ModelInfo.Model);
            cbVehicleName.Text = (_VehicleInfo.VehicleNamesInfo.VehicleName);
            cbLicenseClass.Text = _VehicleInfo.ClassName;
            lbStatus.Text = _VehicleInfo.StatusVehicleString();
            // chIsAvaliable.Checked = _VehicleInfo.VehicleStatus ? true : false;
            if (_VehicleInfo.Image != null)
                pbImage.ImageLocation = _VehicleInfo.Image;
            lRemove.Visible = pbImage.ImageLocation != null;

        }


        private  void frmAddVehicle_Load(object sender, EventArgs e)
        {
            RestDefaultValue();
            
            if (GlobalVar._mode == GlobalVar.enMode.Update)
                LoadData();




        }
        private void _GetAllClassLicense()
        {
            DataTable dt = clsClassLicense.GetAllClassLicense();
            foreach (DataRow row in dt.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
            cbLicenseClass.SelectedIndex = 2;
        }

        public async Task GetAllMakes()
        {
            //Parallel.For(0, iteration, ProcessBody);


            DataTable dt = clsMakes.GetAllMakes();

            foreach (DataRow r in dt.Rows)
            {
                cbMakes.Items.Add(r["Make"]);
                await Task.Delay(0);
            }
            cbMakes.SelectedIndex = 0;

        }
        public async Task GetAllModels()
        {
            DataTable dt = clsModels.GetAllModels();

            foreach (DataRow r in dt.Rows)
            {
                cbModel.Items.Add(r["Model"]);
                await Task.Delay(0);
            }

            cbModel.SelectedIndex = 0;

        }
        public void GetAllMainFactureYears()
        {

        }
        public async Task GetAllVehiclesNames(byte Category)
        {
            DataTable dt = clsCategories.GetAllVehiclesByCategory(Category);

            StringBuilder sr = new StringBuilder();
            sr.Append("VehicleName");
            foreach (DataRow r in dt.Rows)
            {
                //    cbVehicleName.Items.Add(r["VehicleName"]);
                cbVehicleName.Items.Add(r[sr.ToString()]);
                await Task.Delay(0);
            }
            cbVehicleName.SelectedIndex = 0;
        }
        public void GetAllFualTypes()
        {
            DataTable dt = clsFualTypes.GetAllFualTypes();

            StringBuilder sr = new StringBuilder();
            sr.Append("FualType");

            foreach (DataRow r in dt.Rows)
            {
                cbFualType.Items.Add(r[sr.ToString()]);
            }
            cbFualType.SelectedIndex = 0;

        }
        public void GetAllCategories()
        {
            DataTable dt = clsCategories.GetAllCategories();


            foreach (DataRow r in dt.Rows)
            {
                cbCategory.Items.Add(r["Category"]);
            }

            cbCategory.SelectedIndex = 0;

        }
        private async Task GetVehicleNameID()
        {
            vehicleNameID = clsVehiclesNames.GetVehicleNameIDByVehicleName(cbVehicleName.Text);
            await Task.Delay(0);
        }
        private void cbVehicleName_SelectedIndexChanged(object sender, EventArgs e)
        {

            Task t1 = GetVehicleNameID();

            Task.WhenAll(t1);

            lbYear.Text = clsMainFacturesYears.GetYearForVehicle(vehicleNameID).ToString(); ;

            cbVehicleName.Text = cbVehicleName.Text;

        }
        private void lSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Images File |*.png;*.jpeg;*.jpg;*.bmp;*.gif";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string Path = openFileDialog1.FileName;
                pbImage.ImageLocation = Path;
            }

            lRemove.Visible = true;

        }

        private void lRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.ImageLocation = null;


          //  pbImage.Image = Resources.UnKnownCar;

            lRemove.Visible = false;

        }

        private void ctrlShareScreen1_Load(object sender, EventArgs e)
        {
        }


        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            Task t1 = GetAllVehiclesNames(Byte.Parse(cbCategory.Text.ToString()));


            Task.WhenAll(t1);

            CategoryID = clsCategories.GetCategoryIDByCategory(Byte.Parse(cbCategory.Text));
            //MessageBox.Show("CategoryID: "+CategoryID);           
        }

        private void pbImage_Click(object sender, EventArgs e)
        {

        }

        private void ONRefresg(object sender, EventArgs e)
        {
            cbVehicleName.Items.Clear();
        }

        private void cbMakes_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder sr = new StringBuilder(cbMakes.Text);
            MakeID = clsMakes.GetMakeIDByMake(sr);
        }

        private void cbModel_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            StringBuilder sr = new StringBuilder(cbModel.Text);
            ModelID = clsModels.GetModelIDByModel(sr);
            // MessageBox.Show("ModelID : "+ModelID);
        }

        private void chIsAvaliable_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtMileage_Validating(object sender, CancelEventArgs e)
        {
            clsVaildation.ValidatingEmpty(sender, e, txtRentail, errorProvider1);
        }

        private void cbFualType_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder sr = new StringBuilder(cbFualType.Text);
            FualTypeID = clsFualTypes.GetFualTypeIDByFualType(sr);
            //MessageBox.Show("FualTypeID : "+FualTypeID);
        }


        private void txtMileage_Validating_1(object sender, CancelEventArgs e)
        {
            clsVaildation.ValidatingEmpty(sender, e,txtMileage, errorProvider1);
        }

        private void txtMileage_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!clsVaildation.IsNumber(txtMileage.Text))
            {
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
            }
        }

        private void cbMakes_Validating(object sender, CancelEventArgs e)
        {

            if (clsVaildation.IsZero(MakeID))
            {
                e.Cancel = true;
                cbMakes.Focus();
                errorProvider1.SetError(cbMakes, "This field i required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cbMakes, null);

            }
        }

        private void cbModel_Validating(object sender, CancelEventArgs e)
        {
            if (clsVaildation.IsZero(ModelID))
            {
                e.Cancel = true;
                cbModel.Focus();
                errorProvider1.SetError(cbModel, "This field i required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cbModel, null);

            }
        }

        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassLicenseID = clsClassLicense.GetClassID(cbLicenseClass.Text);
        //    MessageBox.Show("Class License ID : "+ClassLicenseID);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
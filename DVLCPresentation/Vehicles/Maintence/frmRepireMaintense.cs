using Clobal;
using clsPeople.File_DvlD_Bussiness;
using CRentail.Public_Classes;
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

namespace DVLCPresentation.Vehicles.Maintence
{
    public partial class frmRepireMaintense : Form
    {
        public frmRepireMaintense()
        {
            InitializeComponent();
        }
        private  int _VehicleID = -1;
        public frmRepireMaintense(int VehicleID)
        {
            InitializeComponent();
            _VehicleID = VehicleID;
        }
        public void LoadData()
        {
          //  ctrlVehicleCardWithFilter1.FilterEnable = false;
            _ResetDefualtValue();
            ctrlVehicleCardWithFilter1.LoadVehicleData(_VehicleID);
        
        }
        public clsMatinces MantianceInfo;
        private void _ResetDefualtValue()
        {
            clsControls.DisableControl(btnSave, likMantienceInfo,IsRepaire);
            MantianceInfo = new clsMatinces();
        }
        private void frmRepireMaintense_Load(object sender, EventArgs e)
        {
            if (_VehicleID == -1)
                _ResetDefualtValue();
            else
                LoadData();
        }

        private void ctrlVehicleCardWithFilter1_OnVehicleSelected(object sender, CRentailBussiness.clsVehicles e)
        {
            if (e.vehicleID == -1)
                return;

            if(e.VehicleStatus!=CRentailBussiness.clsVehicles.enStatusVehicle.Available)
            {
                clsGlobalMessages.Messages("you can not Repaire Vehicle not Available");
                clsControls.DisableControl(btnSave, IsRepaire);
                return;
            }

            clsControls.EnableControl(btnSave);
            

        }

        private void txtNotes_Validating(object sender, CancelEventArgs e)
        {
  clsVaildation.ValidatingEmpty(sender, e, txtNotes, errorProvider1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!clsVaildation.VaildationFieldsRequired(this))
            {
                return;
            }
            MantianceInfo.Desctroption = txtNotes.Text;
            MantianceInfo.MaintanceDate = dtMantaince.Value;
            MantianceInfo.Cost =   clsFormat.ConvetStringToDataType<decimal>(txtCost.Text);
            MantianceInfo.VehicleID = ctrlVehicleCardWithFilter1.VehicleID;
            MantianceInfo.UserID = clsGlobal.CurrentUser.UserID;
            if (!MantianceInfo.Save())
                clsGlobalMessages.ErrorMessageAdded();
            else
                clsGlobalMessages.AddMessage();

            lbMantienceID.Text = clsFormat.ConverGenericToString(MantianceInfo.MaintanceID);
            clsControls.DisableControl(btnSave);

            clsControls.EnableControl(likMantienceInfo);
            //MantianceInfo.MaintanceDate =
        }

        private void txtCost_Validating(object sender, CancelEventArgs e)
        {
            clsVaildation.ValidatingEmpty(sender, e, txtCost, errorProvider1);
        }

        private void likMantienceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmMaintanceInfo frm = new frmMaintanceInfo(MantianceInfo.MaintanceID);
            frm.ShowDialog();
        }
    }
}

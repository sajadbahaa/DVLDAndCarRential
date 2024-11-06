using Clobal;
using clsPeople;
using clsPeople.File__CR_Bussiness;
using CRentail.Public_Classes;
using DVLCPresentation.Global_Classes;
using DVLCPresentation.Payments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.Reservations.Reservation_List
{
    public partial class frmAddReservation : Form
    {
        
        public frmAddReservation()
        {
            InitializeComponent();
        }
        public frmAddReservation(int VehicleID)
        {
            InitializeComponent();
            ctrlVehicleCardWithFilter1.LoadVehicleData(VehicleID);
            LoadVehicleInfo();
        }

        public clsPayments PaymentInfo;

        private void _RestReservationObj()
        {
            dtStart.MinDate = DateTime.Now;
            dtStart.Value = dtStart.MinDate;
            dtEndDate.MinDate = DateTime.Now;
            dtEndDate.MaxDate = DateTime.Now.AddMonths(1);
            dtEndDate.Value = dtEndDate.MinDate;
            PaymentInfo = new clsPayments();
            lbUsername.Text = clsGlobal.CurrentUser.Username;

            _RestDefaultControl();
        }
        private void _RestDefaultControl()
        {
            clsControls.DisableControl(btnSave, tabFindCustomers,tabAddReservation);
            clsControls.DisableControl(lShowPayment);
        }
        private void frmAddReservation_Load(object sender, EventArgs e)
        {
            _RestReservationObj();       
        }

        private void NextToLookingForCustomer(object sender, EventArgs e)
        {
            if (ctrlVehicleCardWithFilter1.VehicleID != -1)
            {

                if (ctrlVehicleCardWithFilter1.VehicleSelected.VehicleStatus == CRentailBussiness.clsVehicles.enStatusVehicle.Maintence)
                {
                    clsGlobalMessages.Messages("This Vehicle in Maintance Mode");
                    return;
                }
                if (ctrlVehicleCardWithFilter1.VehicleSelected.VehicleStatus == CRentailBussiness.clsVehicles.enStatusVehicle.Reserve)
                {
                    clsGlobalMessages.Messages("This Vehicle  in Rerervation Mode");
                    return;

                }

                clsControls.EnableControl(tabFindCustomers);
                clsControls.NextTabControl(tabControl1, 1);
            }
            else
            {
                MessageBox.Show("Choose another VehicleID");
            }
        
        }

        public void LoadVehicleInfo()
        {
            lbVehicleName.Text = ctrlVehicleCardWithFilter1.VehicleSelected.VehicleNamesInfo.VehicleName;

            lbRentialPerDay.Text = clsFilters.FromIntToString(ctrlVehicleCardWithFilter1.VehicleSelected.RentailPerDay);

        }
        private void ctrlVehicleCardWithFilter1_OnVehicleSelected(object sender, CRentailBussiness.clsVehicles e)
        {
            if (e.vehicleID == -1)
                return;
            
            //if (!e.VehicleStatus)
            //{
            //    clsGlobalMessages.Messages("This Vehicle is Un Available");
            //    return;
            //}

            LoadVehicleInfo();
            //MessageBox.Show("Vehicle Name : " + e.VehicleNamesInfo.VehicleName);


        }

        private void SaveInfo(object sender, EventArgs e)
        {
           
           // clsGlobalMessages.MessageNotImmplementedYet();
            if (!clsVaildation.VaildationFieldsRequired(this))
                return;

            //bool IsAddedSuccessfully =        PaymentInfo.RentailCarForCustomer(dtStart.Value, dtEndDate.Value, ctrlDriverWithFilter1.DriverInfo.PersonID
            //    , ctrlVehicleCardWithFilter1.VehicleID, ref _ReservationID
            //    ,txtPickUp.Text,txtDropOf.Text
            //    , decimal.Parse(lbRentialPerDay.Text),txtNotes.Text, clsGlobal.CurrentUser.UserID,
            //    ctrlDriverWithFilter1.DriverInfo.PersonID);

            //if (!IsAddedSuccessfully)
            //{
            //    clsGlobalMessages.ErrorMessageAdded();
            //    return;
            //}

            PaymentInfo.AppTypeID = (int)clsApplication.enApplicationType.CarRential;
            PaymentInfo.UserID = clsGlobal.CurrentUser.UserID;
            PaymentInfo.PaidFees = clsAppType.Find(PaymentInfo.AppTypeID).AppFees;
            PaymentInfo.PersonID = ctrlDriverWithFilter1.DriverInfo.PersonID;


            // now we will start Add new Reservation
            PaymentInfo.StartDate = dtStart.Value;
            PaymentInfo.EndDate = dtEndDate.Value;
            PaymentInfo.Notes.Append(txtNotes.Text);
            PaymentInfo.CreateUserID = clsGlobal.CurrentUser.UserID;
            PaymentInfo.CustomerID = ctrlDriverWithFilter1.DriverInfo.CustomerID;
            PaymentInfo.VehicleID = ctrlVehicleCardWithFilter1.VehicleID;
            PaymentInfo.RentialPerDay = decimal.Parse(lbRentialPerDay.Text);
            PaymentInfo.InitialTotalDueAmount = PaymentInfo. GetTotalAmount(PaymentInfo.RentialPerDay+ PaymentInfo.PaidFees, PaymentInfo.StartDate,PaymentInfo.EndDate);
            PaymentInfo.DropOflocation.Append(txtDropOf.Text);
            PaymentInfo.PickUplocation.Append(txtPickUp.Text);
            PaymentInfo.notes = txtPaymentNote.Text;
            PaymentInfo.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            if(!PaymentInfo.Save())
            {
                clsGlobalMessages.ErrorMessageAdded();
                return;
            }

            clsGlobalMessages.AddMessage();
            //lbReservationID.Text = clsFilters.ConverGenericToString(_ReservationID);
            lbApplicationID.Text = clsFilters.FromIntToString(PaymentInfo.ApplicationID);
            lbInitialTotalDueAmount.Text = clsFilters.FromIntToString(PaymentInfo.InitialTotalDueAmount);
            lbPaymentID.Text = clsFormat.ConverGenericToString(PaymentInfo.PaymentID);
            lbReservationID.Text = clsFormat.ConverGenericToString(PaymentInfo.ReservationID);
            clsControls.DisableControl(btnSave);
            clsControls.EnableControl(lShowPayment);
        }

        private void CLose(object sender, EventArgs e)
        {
            clsGlobalMessages.Close(this);
        }

        private void ctrlDriverWithFilter1_OnDriverSelected(object sender, clsPeople.clsDriver e)
        {
            if (e.DriverID == -1)
                return;

            //     MessageBox.Show("Dreiver Name : "+e.PersonInfo.FullName());
            if (e.CustomerID==-1)
            {
                clsGlobalMessages.Messages("This Customer Not Found");
                return;
            }
                

            if (!e.HasDriverThisClassLicense(ctrlVehicleCardWithFilter1.VehicleSelected.ClassLicenseID))
            {
                clsGlobalMessages.Messages($"Driver [{e.PersonInfo.FullName()}] Does not have Class License [{ctrlVehicleCardWithFilter1.VehicleSelected.ClassName}]");
                return;
            }
            

            lbCustomerName.Text = e.PersonInfo.FullName();
            //MessageBox.Show($"yes he has [{ctrlVehicleCardWithFilter1.VehicleSelected.ClassName}]");
        }

        private void NextToReservation(object sender, EventArgs e)
        {
            if (ctrlDriverWithFilter1.DriverID!=-1)
            {
                if (ctrlDriverWithFilter1.DriverInfo.CustomerID != -1)
                {

                    if (!ctrlDriverWithFilter1.DriverInfo.HasDriverThisClassLicense(ctrlVehicleCardWithFilter1.VehicleSelected.ClassLicenseID))
                    {
                        clsGlobalMessages.Messages($"Driver [{ctrlDriverWithFilter1.DriverInfo.PersonInfo.FullName()}] Does not have Class License [{ctrlVehicleCardWithFilter1.VehicleSelected.ClassName}]");
                        return;
                    }
                    if (!ctrlDriverWithFilter1.clsCustomersInfo.TakePersonalInfo)
                    {
                        clsGlobalMessages.Messages("you are already  took another Vehicle.");
                        return;
                    }

                    clsFilters.FilterFocuse(txtPickUp);
                    clsControls.EnableControl(tabAddReservation, btnSave);
                    clsControls.NextTabControl(tabControl1, 2);
                }
            }
            
            else
            {
                clsGlobalMessages.Messages("Choose another Customer ID");
                ctrlDriverWithFilter1.FilterFocuse();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void txtDropOf_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabAddReservation_Click(object sender, EventArgs e)
        {

        }

        private void txtDropOf_KeyPress(object sender, KeyPressEventArgs e)
        {
     //       clsVaildation.UserControlKeyPressHandlerNumber(sender, e);
        }

        private void VaildationRichBox(object sender, CancelEventArgs e)
        {
            clsVaildation.ValidatingEmpty(sender, e, (RichTextBox)sender, errorProvider1);
        }

        private void ctrlDriverWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPaymentInfo frm = new frmPaymentInfo(PaymentInfo.PaymentID);
            frm.ShowDialog();
        }
    }
}

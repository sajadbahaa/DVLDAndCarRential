using clsPeople.File__CR_Bussiness;
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

namespace DVLCPresentation.Payments
{
    public partial class ctrlPaymentInfo : UserControl
    {
        public ctrlPaymentInfo()
        {
            InitializeComponent();
        }

        private int _PayemtID = -1;
        public int paymentID
        {
            get
            {
                return _PayemtID;
            }
        } 
        private clsPayments _PaymentInfo;
        public clsPayments PaymentInfo;
        public void ResetDefaultValue()
        {
            lbCutomerName.Text = clsFormat.FormatString("???");
            lbInitalTotalAmount.Text = clsFormat.FormatString("???");
            lbMessage.Visible = false;
            lbPaymentDate.Text = clsFormat.FormatString("???");
            lbRefundAmount.Text = clsFormat.FormatString("???");
            lbTotalRemaining.Text = clsFormat.FormatString("???");
            lbPaymentID.Text = clsFormat.FormatString("???");
            lbUpdatePaymentDate.Text = clsFormat.FormatString("???");
            _PayemtID = -1;
            _PaymentInfo = new clsPayments();
        }
        private void _LoadData()
        {
            lbCutomerName.Text = _PaymentInfo.ReservationInfo.CustomerInfo.DriverInfo.PersonInfo.FullName();
            lbInitalTotalAmount.Text = clsFormat.ConverGenericToString(_PaymentInfo.ReservationInfo.InitialTotalDueAmount);
            
            
            lbPaymentDate.Text = clsFormat.DateToShortString(_PaymentInfo.PaymentDate);
            lbRefundAmount.Text = 
                _PaymentInfo.TotalRefunedAmount==GlobalVar.dcnullable? 
                clsFormat.ConverGenericToString("Null"): clsFormat.ConverGenericToString(_PaymentInfo.TotalRefunedAmount);   
        lbTotalRemaining.Text =
                _PaymentInfo.TotalRemaining == GlobalVar.dcnullable ?
                clsFormat.ConverGenericToString("Null") : clsFormat.ConverGenericToString(_PaymentInfo.TotalRemaining);

lbUpdatePaymentDate.Text
                = _PaymentInfo.UpdatePaymentDate == GlobalVar.dtnullable ?
                clsFormat.ConverGenericToString("Null") : clsFormat.ConverGenericToString(_PaymentInfo.UpdatePaymentDate);
        lbReturnID.Text 
                = _PaymentInfo.returnID == GlobalVar.nullable ?
 clsFormat.ConverGenericToString("Null") : clsFormat.ConverGenericToString(_PaymentInfo.returnID);

            lbActualTotalAmount.Text = _PaymentInfo.ActualTotalDueAmount == GlobalVar.dcnullable ?
                clsFormat.ConverGenericToString("Null") : clsFormat.ConverGenericToString(_PaymentInfo.ActualTotalDueAmount);

            _HandelPaymentProcessing();
            _PayemtID = _PaymentInfo.PaymentID;
            lbPaymentID.Text = clsFormat.ConverGenericToString(_PayemtID);
        
        }
       public void LoadPaymentID(int PaymentID)
        {
            _PaymentInfo = clsPayments.FindByPaymentID(PaymentID);
            if (_PaymentInfo==null)
            {
                clsGlobalMessages.ErrorMessageFindByID();
                ResetDefaultValue();
                return;
            }
            _LoadData();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void _HandelPaymentProcessing()
        {
            lbMessage.Text = _PaymentInfo.ReservationInfo.ApplicationInfo.ApplicationStatus == clsPeople.clsApplication.enApplicationStatus.New ?
                "The Process is Still Continuing": 
                _PaymentInfo.ReservationInfo.ApplicationInfo.ApplicationStatus 
                == clsPeople.clsApplication.enApplicationStatus.Cancel?"The Process Has been Canceled":
                "The Process Completed Successfully";
        }
        private void ctrlPaymentInfo_Load(object sender, EventArgs e)
        {
            //lbMessage.Visible = false;

        }
    }
}

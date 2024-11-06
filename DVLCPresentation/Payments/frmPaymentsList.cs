using Clobal;
using clsPeople;
using clsPeople.File__CR_Bussiness;
using CRentail.Public_Classes;
using CRentailBussiness;
using DVLCPresentation.Reservations;
using DVLCPresentation.ReturnCar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.Payments
{
    public partial class frmPaymentsList : Form
    {
        public frmPaymentsList()
        {
            InitializeComponent();
        }

        private void frmPaymentsList_Load(object sender, EventArgs e)
        {
            GlobalVar.dtv = clsPayments.GetAllPayments().DefaultView;
            dataGridView1.DataSource = GlobalVar.dtv;

        }

        private void showPaymentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPaymentInfo frm = new frmPaymentInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
        clsPayments PaymentInfo;
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGridView1.RowCount<0)
            {
                btnCancelApplication.Enabled = false;
                btnShowPayment.Enabled = false;
                btnCompleteProcess.Enabled = false;
                return;
            }

            PaymentInfo = clsPayments.FindByPaymentID((int)dataGridView1.CurrentRow.Cells[0].Value);

         bool IsCompleted = PaymentInfo.ReservationInfo.ApplicationInfo.ApplicationStatus == clsApplication.enApplicationStatus.Complete ? true : false;
            bool IsNew = PaymentInfo.ReservationInfo.ApplicationInfo.ApplicationStatus == clsApplication.enApplicationStatus.New ? true : false;
            btnCancelApplication.Enabled = !IsCompleted &&IsNew && PaymentInfo.returnID == GlobalVar.nullable ? true : false;
            btnShowPayment.Enabled = dataGridView1.RowCount > 0 ? true : false;
            btnExtendVehicle.Enabled = IsNew && !IsCompleted&&PaymentInfo.returnID== GlobalVar.nullable ? true:false;
            btnCompleteProcess.Enabled = IsNew && PaymentInfo.returnID != GlobalVar.nullable?true:false;

        }

        private void btnCancelApplication_Click(object sender, EventArgs e)
        {
          if(PaymentInfo.CancelRentailCar())
            {
                clsGlobalMessages.Messages("Canceled Car Rential Application Successfully");
                frmPaymentsList_Load(null, null);
                return;
            }
            else
            {
                clsGlobalMessages.Messages("Error Cancel Care Rential Application");
           
            }

        }

        private void btnExtendVehicle_Click(object sender, EventArgs e)
        {
            frmExtendReservation frm = new frmExtendReservation((int)dataGridView1.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            frmPaymentsList_Load(null, null);

        }

        private void btnCompleteProcess_Click(object sender, EventArgs e)
        {
            if (PaymentInfo.CompleteProcess())
                clsGlobalMessages.Messages("Process Completed Successfully");
                else
                clsGlobalMessages.Messages("Failed Completed  Process ");

            frmPaymentsList_Load(null,null);
        }

        private void showReturnInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //[7]

  frmRetrunInfo frm = 
                new frmRetrunInfo((int)dataGridView1.CurrentRow.Cells[7].Value);
            frm.ShowDialog();

        }
    }
}

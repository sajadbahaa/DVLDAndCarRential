using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.Payments
{
    public partial class frmPaymentInfo : Form
    {
        public frmPaymentInfo(int PaymentID)
        {
            InitializeComponent();
            ctrlPaymentInfo1.LoadPaymentID(PaymentID);
        }

        private void frmPaymentInfo_Load(object sender, EventArgs e)
        {

        }
    }
}

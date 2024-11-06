using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.Customers
{
    public partial class frmShowCustomerInfo : Form
    {
        public frmShowCustomerInfo(int CustomerID)
        {
            InitializeComponent();
            ctrlOverViewCustomers1.LoadCustomerInfoByCustomerID(CustomerID);
        }

        private void frmShowCustomerInfo_Load(object sender, EventArgs e)
        {

        }
    }
}

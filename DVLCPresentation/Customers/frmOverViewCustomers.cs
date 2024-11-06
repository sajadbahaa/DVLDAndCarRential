using clsPeople;
using DVLCPresentation.Customers.Controls;
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
    public partial class frmOverViewCustomers : Form
    {
        public frmOverViewCustomers()
        {
            InitializeComponent();
        }
        public void GetAllCustomers()
        {
            int CustomerID = -1;
            DataTable dt = clsCustomers.GetAllCustomers();

            foreach (DataRow r in dt.Rows)
            {
                CustomerID = int.Parse(r["CustomerID"].ToString());
                ctrlOverViewCustomers customer = new ctrlOverViewCustomers(CustomerID);
                flowLayoutPanel1.Controls.Add(customer);
            }
            if (CustomerID == -1)
                return;
        }

        private void frmOverViewCustomers_Load(object sender, EventArgs e)
        {
            GetAllCustomers();
        }
    }
}

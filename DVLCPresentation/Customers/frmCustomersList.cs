using clsPeople;
using CRentail.Public_Classes;
using CRentailBussiness;
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
    public partial class frmCustomersList : Form
    {
        public frmCustomersList()
        {
            InitializeComponent();
        }

        private void frmCustomersList_Load(object sender, EventArgs e)
        {
            GetAllCustomers();
        }
public void GetAllCustomers()
        {
            int CustomerID = -1;
            DataTable dt = clsCustomers.GetAllCustomers();
            foreach (DataRow row in dt.Rows)
            {
                CustomerID = int.Parse(row["CustomerID"].ToString());
                ctrlOverViewCustomers control = new ctrlOverViewCustomers(CustomerID);

                flowLayoutPanel1.Controls.Add(control);
            }
            this.Controls.Add(flowLayoutPanel1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddCustomer frm = new frmAddCustomer();
            frm.ShowDialog();
            frmCustomersList_Load(null, null);
        }

        private void AddCustomer(object sender, EventArgs e)
        {
            frmAddCustomer frm = new frmAddCustomer();
            frm.ShowDialog();
            OnRefresh();
        }
        public void OnRefresh()
        {
            flowLayoutPanel1.Controls.Clear() ;
            GetAllCustomers();
        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnRefresh();
        }
    }
}

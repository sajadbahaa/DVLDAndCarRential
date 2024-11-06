using clsPeople;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.Statics
{
    public partial class StaticCustomers : Form
    {
        public StaticCustomers()
        {
            InitializeComponent();
        }
        public void GetAllCustomerStatusReservations()
        {
            int CustometID = -1;
            string Status = "";
            DataTable dt = clsReservations.GetAllCustomerOnAllStaus();
            foreach (DataRow row in dt.Rows)
            {
                CustometID = int.Parse(row["CustomerID"].ToString());
                Status = row["StatusCustomer"].ToString();
                ctrlStaticCustomer control = new ctrlStaticCustomer(CustometID, Status);

                flowLayoutPanel1.Controls.Add(control);
            }
        }
        public void GetAllCustomerStatusHighReservations()
        {
            int CustometID = -1;
            string Status = "";
            DataTable dt = clsReservations.GetAllCustometHighReservation();
            foreach (DataRow row in dt.Rows)
            {
                CustometID = int.Parse(row["CustomerID"].ToString());
                Status = row["StatusCustomer"].ToString();
                ctrlStaticCustomer control = new ctrlStaticCustomer(CustometID, Status);

                flowLayoutPanel1.Controls.Add(control);
            }
        }
        public void GetAllCustomerStatusMediumReservations()
        {
            int CustometID = -1;
            string Status = "";
            DataTable dt = clsReservations.GetAllCustometMediumReservation();
            foreach (DataRow row in dt.Rows)
            {
                CustometID = int.Parse(row["CustomerID"].ToString());
                Status = row["StatusCustomer"].ToString();
                ctrlStaticCustomer control = new ctrlStaticCustomer(CustometID, Status);

                flowLayoutPanel1.Controls.Add(control);
            }
        }
        public void GetAllCustomerStatusLowReservations()
        {
            int CustometID = -1;
            string Status = "";
            DataTable dt = clsReservations.GetAllCustometLowReservation();
            foreach (DataRow row in dt.Rows)
            {
                CustometID = int.Parse(row["CustomerID"].ToString());
                Status = row["StatusCustomer"].ToString();
                ctrlStaticCustomer control = new ctrlStaticCustomer(CustometID, Status);

                flowLayoutPanel1.Controls.Add(control);
            }
        }
        
        private void StaticCustomers_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
           // GetAllCustomerStatusReservations();
        }

    public void OnRefresh()
        {
            flowLayoutPanel1.Controls.Clear();
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
                if (cbFilter.Text == "All")
            {
                OnRefresh();
                GetAllCustomerStatusReservations();
                    return;
            }
            
            if (cbFilter.Text == "High")
            {
                OnRefresh();
                GetAllCustomerStatusHighReservations();
                return;
            }
            if (cbFilter.Text == "Medium")
            {
                OnRefresh();
                GetAllCustomerStatusMediumReservations();
                return;
            }
            if (cbFilter.Text == "Low")
            {
                OnRefresh();
                GetAllCustomerStatusLowReservations();
                return;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

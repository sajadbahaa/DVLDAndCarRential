using clsPeople;
using CRentail.Public_Classes;
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
    public partial class frmAddCustomer : Form
    {
        public frmAddCustomer()
        {
            InitializeComponent();
            CustomerInfo = new clsCustomers();
        }

        public int DriverID { get; set; }
        public clsCustomers CustomerInfo;
        public Action<int> DataBack;
        public   void GetDataBack(int CustomerID)
        {
            clsGlobalMessages.AddMessage();
            lbCusomterID.Text = CustomerID.ToString();
        }
        private void Close(object sender, EventArgs e)
        {
            clsGlobalMessages.Close(this);
        }

        private void ctrlDriverWithFilter1_OnDriverSelected(object sender, clsPeople.clsDriver e)
        {
          
            if (e.DriverID == -1)
                return;

            // cheack if he has  license Active
        
            if(!e.HasLicenseDriver)
            {
                MessageBox.Show("he does not have License Active");

                btnAddCustomer.Enabled = false;
                return;
            }
            
            if (clsCustomers.IsCustomerExist(e.DriverID))
            {
                MessageBox.Show($"Another Customer Took person ID {e.PersonInfo.PersonID}");
                btnAddCustomer.Enabled = false;
                return;
            }
            DriverID = e.DriverID;
            btnAddCustomer.Enabled = true;
        }

        private void frmAddCustomer_Load(object sender, EventArgs e)
        {
            btnAddCustomer.Enabled = false;
            DataBack += GetDataBack;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            //clsGlobalMessages.MessageNotImmplementedYet();    
            CustomerInfo.DriverID = DriverID;
            bool IsAddedSuccessfully = CustomerInfo.Save();
            if (!IsAddedSuccessfully)
            {
                clsGlobalMessages.ErrorMessageAdded();
                return;
            }
            DataBack?.Invoke(CustomerInfo.CustomerID);
        }
    }
}

using CRentail.Public_Classes;
using CRentail.Vehicles;
using CRentail.Vehicles.Controls;
using CRentailBussiness;
using DVLCPresentation.Vehicles.Controls;
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

namespace CRentail.frmVehicles
{
    public partial class frmOverViewVehilces : Form
    {
        
        public frmOverViewVehilces()
        {
            InitializeComponent();
        }
        DataTable dt;
        private void OnRefresh()
        {
            flowLayoutPanel1.Controls.Clear();
        }

        private void Close(object sender, EventArgs e)
        {
            clsGlobalMessages.Close(this);
        }
        private void AddVehicle(object sender, EventArgs e)
        {
             // clsGlobalMessages.MessageNotImmplementedYet();
            frmAddVehicle frm = new frmAddVehicle();
            frm.ShowDialog();
            frmVehiclesList_Load(null, null);
        }        
        public void GetAllVehicel()
        {
             dt = clsVehicles.GetAllVehivles();
            foreach (DataRow r  in dt.Rows)
            {
                int CurrentVehicleID = int.Parse(r["VehicleID"].ToString());
                ctrlOverViewVehicle myControl =  new ctrlOverViewVehicle(CurrentVehicleID);

         //       clickVehicle = myControl;
                 // Set a fixed size for each card

                flowLayoutPanel1.Controls.Add(myControl);
                // Add the control to the form            
            }

            this.Controls.Add(flowLayoutPanel1);
        }
        public void GetAllFualTypes()
        {
            DataTable dt = clsFualTypes.GetAllFualTypes();

            StringBuilder sr = new StringBuilder();
            sr.Append("FualType");

            foreach (DataRow r in dt.Rows)
            {
                cbFualType.Items.Add(r[sr.ToString()]);
            }
            cbFualType.SelectedIndex = 0;

        }

        public void GetAllVehicelUnAvailableByStatus()
        {
            int VehicleID = -1;
            dt = clsVehicles.GetAllVehiclesUnAvailable();
            foreach (DataRow r in dt.Rows)
            {
                VehicleID = int.Parse(r["VehicleID"].ToString());
                ctrlOverViewVehicle myControl = new ctrlOverViewVehicle(VehicleID);

                //clickVehicle = myControl;
                // Set a fixed size for each card

                flowLayoutPanel1.Controls.Add(myControl);
                // Add the control to the form            
            }
            if (VehicleID == -1)
                return;

            this.Controls.Add(flowLayoutPanel1);
        }

        public void GetAllVehicelAvailableByStatus()
        {
            int VehicleID = -1;
            dt = clsVehicles.GetAllVehiclesAvailable();
            foreach (DataRow r in dt.Rows)
            {
                VehicleID = int.Parse(r["VehicleID"].ToString());
                ctrlOverViewVehicle myControl = new ctrlOverViewVehicle(VehicleID);

                //clickVehicle = myControl;
                // Set a fixed size for each card

                flowLayoutPanel1.Controls.Add(myControl);
                // Add the control to the form            
            }
            if (VehicleID == -1)
                return;

            this.Controls.Add(flowLayoutPanel1);
        }

        public void GetAllVehicelByCategory(decimal category)
        {
            int VehicleID = -1;
            dt = clsVehicles.GetAllVehiclesByCategory(category);
            foreach (DataRow r in dt.Rows)
            {
                VehicleID = int.Parse(r["VehicleID"].ToString());
                ctrlOverViewVehicle myControl = new ctrlOverViewVehicle(VehicleID);

                //clickVehicle = myControl;
                // Set a fixed size for each card

                flowLayoutPanel1.Controls.Add(myControl);
                // Add the control to the form            
            }
            if (VehicleID == -1)
                return;

            this.Controls.Add(flowLayoutPanel1);
        }
        public void GetAllVehicelByFualType(StringBuilder FualType)
        {
            int VehicleID = -1;
            dt = clsVehicles.GetAllVehiclesByFualType(FualType);
            foreach (DataRow r in dt.Rows)
            {
                VehicleID = int.Parse(r["VehicleID"].ToString());
                ctrlOverViewVehicle myControl = new ctrlOverViewVehicle(VehicleID);

                //clickVehicle = myControl;
                // Set a fixed size for each card

                flowLayoutPanel1.Controls.Add(myControl);
                // Add the control to the form            
            }
            if (VehicleID == -1)
                return;

            this.Controls.Add(flowLayoutPanel1);
        }
        public void GetVehicelByID(int ID)
        {
            ctrlOverViewVehicle myControl1 = new ctrlOverViewVehicle(ID);
            if (myControl1.VehicleID == -1)
                return;

            flowLayoutPanel1.Controls.Add(myControl1);
            this.Controls.Add(flowLayoutPanel1);
        }
        
        private  void frmVehiclesList_Load(object sender, EventArgs e)
        {
 
          cbFilter.SelectedIndex = 0;
            GetAllFualTypes();

        }

        
        
        private void OnRefresh(object sender, EventArgs e)
        {
            OnRefresh();
            GetAllVehicel();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void GetFilterIsAvilable()
        {
            if (cbIsAvailable.Text == "All")
            {
                GlobalVar.dtv.RowFilter = "";
                return;
            }
            // check if it  is Is Available or not;

            int value = cbIsAvailable.Text == "yes" ? 1 : 0;
            GlobalVar.dtv.RowFilter = $"{cbFilter.Text} = {value}";
         //   dtgview.DataSource = GlobalVar.dtv;
        }
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "VehicleID")
            {
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
            }
        }

        public void GetFilter()
        {
            StringBuilder FilterColumn = new StringBuilder("");

            switch (cbFilter.Text)
            {
                case "VehicleID":
                    FilterColumn.Append("VehicleID");
                    break;
                  }

            if (txtFilter.Text == "" || FilterColumn.ToString() == "All")
            {
                // GlobalVar.dtv.RowFilter = "";
                OnRefresh();

                return;
            }

            if (FilterColumn.ToString() != "VehicleName"
                && FilterColumn.ToString() != "Doors")
            {
                //GlobalVar.dtv.RowFilter = $"{FilterColumn.ToString()} = {txtFilter.Text}";
                GetVehicelByID(int.Parse(txtFilter.Text));
            }

        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            OnRefresh();
            GetFilter();

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text == "None")
            { 
                cbDoors.Visible = false;
                cbIsAvailable.Visible = false;
                cbFualType.Visible = false;
                txtFilter.Visible = false;
                OnRefresh();
                return;
            }
            

            if (cbFilter.Text =="All")
            {
                GetAllVehicel();
                cbDoors.Visible = false;
                cbIsAvailable.Visible = false;
                cbFualType.Visible = false;
                txtFilter.Visible = false;

                return;
            }
            else
            {
                OnRefresh();
            }

            bool Enable = false;
            if (cbFilter.Text != "IsAvailable" && cbFilter.Text != "FualType"&&cbFilter.Text!="Doors")
            {
                Enable = false;
                txtFilter.Visible = true;
                cbFualType.Visible = Enable ;
                cbDoors.Visible = Enable;
                cbIsAvailable.Visible = Enable;
                return;
            }
            



            if (cbFilter.Text == "FualType")
            {
               GetAllFualTypes();
                Enable = false;
                cbFualType.SelectedIndex = 0;
                cbFualType.Visible = true;
                cbDoors.Visible = Enable;
                cbIsAvailable.Visible = Enable;
                txtFilter.Visible = Enable;
                return;
            }
           

            if (cbFilter.Text== "Doors")
            {
                cbDoors.Visible = true;
                Enable = false;
                cbIsAvailable.Visible = Enable;
                txtFilter.Visible = Enable;
                cbFualType.Visible = Enable;
                return;
            }
           
            if (cbFilter.Text == "IsAvailable")
            {

                cbIsAvailable.Visible = true;
                cbIsAvailable.SelectedIndex = 0;
                Enable = false;
                cbFualType.Visible = Enable;
                cbDoors.Visible = Enable;
                txtFilter.Visible = Enable;
                return;
            }
            
        }

        private void cbDoors_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnRefresh();
            GetAllVehicelByCategory(decimal.Parse(cbDoors.Text));
        }
        

        private void cbFualType_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnRefresh();
            StringBuilder FualType = new StringBuilder(cbFualType.Text);
            GetAllVehicelByFualType(FualType);

        }

        private void cbIsAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnRefresh();
            if (cbIsAvailable.Text == "yes")
                GetAllVehicelAvailableByStatus();
            else
                GetAllVehicelUnAvailableByStatus();
        }

        

        private void btnRefresh_Click(object sender, EventArgs e)
        {
        OnRefresh();    
            cbFilter.SelectedIndex = 1;
        
        }
    }
}

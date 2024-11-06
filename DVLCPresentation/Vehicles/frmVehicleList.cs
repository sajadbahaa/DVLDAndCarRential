using CRentail.Public_Classes;
using CRentailBussiness;
using CRentailData;
using DVLCPresentation.People.Control;
using DVLCPresentation.Vehicles.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CRentail.Vehicles
{
    public partial class frmVehicleList : Form
    {
        public frmVehicleList()
        {
            InitializeComponent();
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

        private void frmVehicleList_Load(object sender, EventArgs e)
        {
            //Thread t1 = new Thread(() =>
            //{
            //});
            //t1.Start();
            
            GlobalVar.dtv = clsVehicles.GetAllVehivles().DefaultView;
            dtgview.DataSource = GlobalVar.dtv;
            ctrlRecored1.LoadDataRecord(dtgview.RowCount.ToString());
            GetAllFualTypes();
            _RestDefualtValue();
            cbFilter.SelectedIndex = 0; 
        }
        public void GetFilter()
        {
            //            @"

            //None
            //VehicleID
            //VehicleName
            //MainFactueYear
            //Doors
            //"
            StringBuilder FilterColumn = new StringBuilder("");

            switch (cbFilter.Text)
            {
                case "VehicleID":
                    FilterColumn.Append("VehicleID");
                    break;

                case "VehicleName":
                    FilterColumn.Append("VehicleName");
                    break;

                case "MainFactueYear":
                    FilterColumn.Append("MainFactueYear");

                    break;

                case "Doors":
                    FilterColumn.Append("Doors");
                    break;
            }

            if (txtFilter.Text==""||FilterColumn.ToString()=="None")
            {
                GlobalVar.dtv.RowFilter = "";
                return;
            }
            
            if (FilterColumn.ToString()!="VehicleName"
                &&FilterColumn.ToString()!="Doors")
            {
                GlobalVar.dtv.RowFilter = $"{FilterColumn.ToString()} = {txtFilter.Text}";
            }
            else
            {
GlobalVar.dtv.RowFilter = $"{FilterColumn.ToString()} Like '"+ txtFilter.Text+ "%'";
            }
            dtgview.DataSource = GlobalVar.dtv;
        }
        private void AddVehicle(object sender, EventArgs e)
        {
            frmAddVehicle frm = new frmAddVehicle();
            frm.ShowDialog();
            frmVehicleList_Load(null, null);
        }

        private void showVehicleInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowVehicleInfo frm = new frmShowVehicleInfo((int)dtgview.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddVehicle frm = new frmAddVehicle((int)dtgview.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmVehicleList_Load(null,null);
        }

        private void Delete(object sender, EventArgs e)
        {
            if (!clsGlobalMessages.MessageDoyouWantDelete(this))
                return;

            if (!clsVehicles.Delete((int)dtgview.CurrentRow.Cells[0].Value))
                clsGlobalMessages.ErrorDeleteMessage();
            else
                clsGlobalMessages.DeleteMessage();
            frmVehicleList_Load(null, null);
        }
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "VehicleID"||cbFilter.Text== "MainFactueYear")
            {
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            GetFilter();
        }

        private void _RestDefualtValue()
        {
            txtFilter.Visible = false;
            cbFualType.Visible = false;
            cbIsAvailable.Visible = false;
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalVar.IsNone = (cbFilter.Text == "None") ? true : false;
            if (GlobalVar.IsNone)
            {
                _RestDefualtValue();
                
                return;
            }
            //FualType 
            //VehicleStatus
            //VehicleID
            //VehicleName
            //MainFactueYear
            //Doors

            if (cbFilter.Text != "IsAvailable"&& cbFilter.Text != "FualType")
            {
                txtFilter.Visible = true;
            }
            else
            {
                txtFilter.Visible = false;
            }

            if (cbFilter.Text== "IsAvailable")
            {
                cbIsAvailable.SelectedIndex = 0;
                cbIsAvailable.Visible = true;
                return;
            }
            else
            {
                cbIsAvailable.Visible = false;
            }

            if (cbFilter.Text == "FualType")
            {
                cbFualType.Visible = true;
                return;
            }
            else
            {
                cbFualType.Visible = false;
            }
        }
        private void GetFilterIsAvilable()
        {
            if (cbIsAvailable.Text=="All")
            {
                GlobalVar.dtv.RowFilter = "";
                return;
            }
            // check if it  is Is Available or not;

            int  value = cbIsAvailable.Text == "yes" ? 1 : 0;
            GlobalVar.dtv.RowFilter = $"{cbFilter.Text} = {value}";
            dtgview.DataSource = GlobalVar.dtv;
        }

        private void cbIsAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetFilterIsAvilable();
        }
        private void GetFilterFualTypes()
        {
            if (cbFualType.Text=="None")
            {
                GlobalVar.dtv.RowFilter = "";
                return;
            }
            GlobalVar.dtv.RowFilter = $"{cbFilter.Text} Like '" + cbFualType.Text + "%'";
            dtgview.DataSource = GlobalVar.dtv;
        }

        private void cbFualType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetFilterFualTypes();
        }

        private void findVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFindVehicle frm = new frmFindVehicle((int)dtgview.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    public static DataTable GetAllVehicleByCategory(decimal category)
        {
            return dtVehicles.GetAllVehiclesByCategory(category);
        }

    }
}

using clsPeople;
using DVLCPresentation.Drivers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation
{
    public partial class frmDrivers : Form
    {
        DataView dtview;
        private int _PersonID;
        public frmDrivers()
        {
            InitializeComponent();
        }
        private void _Refresh()
        {
            dtview = clsDriver.GetAllDrivers().DefaultView;
            dtgview.DataSource = dtview;
            lbRecord.Text = dtview.Count.ToString();
        }
        
        private void frmDrivers_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            txtSerarch.Visible = false;
            _Refresh();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            clsDriver DriverInfo = clsDriver.FindByDriverID((int)dtgview.CurrentRow.Cells[0].Value);
            if (DriverInfo!=null)
            {
                _PersonID = DriverInfo.PersonID;
            }

        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonDetails frm = new frmShowPersonDetails(_PersonID);
            frm.ShowDialog();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowHisoryLicene frm = new frmShowHisoryLicene(_PersonID);
            frm.ShowDialog();
        }
        private void _GetFilter()
        {
            string FilterColumn = "";
            switch (cbFilter.Text) 
            {
                case "PersonID":
                    FilterColumn = "PersonID";
                    break;
                case "DriverID":
                    FilterColumn = "DriverID";
                    break;
                case "NationalNo":
                    FilterColumn = "NationalNo";
                    break;
            }

            if (txtSerarch.Text==""||cbFilter.Text =="None")
            {
                dtview.RowFilter = "";
                return;
            }
            
            if (cbFilter.Text!= "NationalNo")
            {// filter person ID , Driver ID.
                dtview.RowFilter = ($"{FilterColumn} = {txtSerarch.Text}" );
                dtgview.DataSource = dtview;
                return;
            }
            // filter National No.
            dtview.RowFilter = $"{FilterColumn} Like '" + txtSerarch.Text + "%'";
            dtgview.DataSource = dtview;

        }
        private void txtSerarch_TextChanged(object sender, EventArgs e)
        {
            _GetFilter();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text != "None")
                txtSerarch.Visible = true;
            else
                txtSerarch.Visible = false;

        }

        private void findDriversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFindDriver frm = new frmFindDriver();
            frm.ShowDialog();
        }
    }
}

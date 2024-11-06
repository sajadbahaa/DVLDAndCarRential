using clsPeople;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation
{
    public partial class frmManageDetainingList : Form
    {
        public frmManageDetainingList()
        {
            InitializeComponent();
        }
        DataView dtvDetained;
        void _Refresh()
        {
            dtvDetained = clsDetained.GetAllDetainedLicense().DefaultView;
            dtgview.DataSource = dtvDetained;

        }
        private void frmManageDetainingList_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Visible = false;
            cbIsReleased.Visible = false; 
            _Refresh();
        }

        private void OnClickDetained(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            _Refresh();
        }

        private void OnClickRelease(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();
            _Refresh();
        }

        private void releaseLiceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dtgview.CurrentRow.Cells[1].Value;
            frmReleaseLicense frm = new frmReleaseLicense(LicenseID);
            frm.ShowDialog();
            _Refresh();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text== "DetainID"||cbFilterBy.Text== "ReleaseApplicationID")
            {
                e.Handled = (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar) ? true : false);
            }


        }
        private void _GetFilter()
        {
            string FilterColumn = "";
            
            switch (cbFilterBy.Text)
            {
                case "DetainID":
                    FilterColumn = "DetainID"; break;
                case "IsReleased":
                    FilterColumn = "IsReleased"; break;
                case "NationalNo":
                    FilterColumn = "NationalNo"; break;
                case "FullName":
                    FilterColumn = "FullName"; break;
                case "ReleaseApplicationID":
                    FilterColumn = "ReleaseApplicationID"; break;
            }
            if (cbFilterBy.Text == "None" || txtFilterValue.Text == "")
            { 
                dtvDetained.RowFilter = "";
                return;
            }
            if (FilterColumn== "FullName" || FilterColumn == "NationalNo")
            {
                dtvDetained.RowFilter = $"{FilterColumn} Like'" + txtFilterValue.Text +"%'" ;
                dtgview.DataSource = dtvDetained;

            }
            else
            {
                dtvDetained.RowFilter = $"{FilterColumn} = {txtFilterValue.Text}";
                dtgview.DataSource = dtvDetained;

            }
        }
        private void _GetIsDetained()
        {
            if (cbFilterBy.Text=="All")
            {
                dtvDetained.RowFilter = "";
                return;
            }
            int IsDetained = (cbIsReleased.Text == "Yes" ? 1 : 0);
            dtvDetained.RowFilter = $"{cbFilterBy.Text} = {IsDetained}";
            dtgview.DataSource = dtvDetained;
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _GetFilter();
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            _GetIsDetained();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text=="None")
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = false;
                return;
            }


            if (cbFilterBy.Text!= "IsReleased")
            {
                txtFilterValue.Visible = true;
                cbIsReleased.Visible = false;
            }
            else
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = true;
            }
        }

        private void cmInfo_Opening(object sender, CancelEventArgs e)
        {
            btnRelease.Enabled = !(bool)dtgview.CurrentRow.Cells[3].Value;   
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        // define var for license ID
            int LicenseID = (int)dtgview.CurrentRow.Cells[1].Value;
            // drefine var to get PersonID
            int PersonID = clsLicense.Find(LicenseID).DriverInfo.PersonID;
            // now we have person ID we can access to Person Indo by Person ID
            frmShowPersonDetails frm = new frmShowPersonDetails(PersonID);
            frm.ShowDialog();
            _Refresh();
        }

        private void showHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // define var for license ID
            int LicenseID = (int)dtgview.CurrentRow.Cells[1].Value;
            // drefine var to get PersonID
            int PersonID = clsLicense.Find(LicenseID).DriverInfo.PersonID;
            // we have person ID we can see License History form
            frmShowHisoryLicene frm = new frmShowHisoryLicene(PersonID);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // define var for license ID
            int LicenseID = (int)dtgview.CurrentRow.Cells[1].Value;
            // now we have License ID we can access to License Info of this Person
            frmShowLicense frm = new frmShowLicense(LicenseID);
            frm.ShowDialog();
        }
    }
}

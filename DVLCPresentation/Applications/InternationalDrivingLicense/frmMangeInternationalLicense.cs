using clsPeople;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation
{
    public partial class frmMangeInternationalLicense : Form
    {
        private DataView _dtview;
      
        private void _Refresh()
        {
            _dtview = clsInternationalLicense.GetAllInternationalLicense().DefaultView;
            dtgview.DataSource = _dtview;
            lbRecord.Text = _dtview.Count.ToString();
        }
        private clsInternationalLicense _clsInter;
        public frmMangeInternationalLicense()
        {
            InitializeComponent();
        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadDate(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Visible = false;
            cbIsReleased  .Visible = false;
            _Refresh();
        
        }
         
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            _clsInter = 
  clsInternationalLicense.Find((int)dtgview.CurrentRow.Cells[0].Value);
        }

        frmShowPersonDetails frmPerosn;
        private void ShowPersonDetials(object sender, EventArgs e)
        {
            frmPerosn = new frmShowPersonDetails(_clsInter.PersonID);
            frmPerosn.ShowDialog();
        }
        private void ShowLicenseDetials(object sender, EventArgs e)
        {
            frmShowIntetnationalLicense frm = new frmShowIntetnationalLicense(_clsInter.InternationalLicenseID);
            frm.ShowDialog();
        }
        frmShowHisoryLicene frmLoadDataInternationalAndLocalLicense;
        
        private void ShowInternationalAndLocalLicense(object sender, EventArgs e)
        {
            frmLoadDataInternationalAndLocalLicense = new frmShowHisoryLicene(_clsInter.PersonID);
            frmLoadDataInternationalAndLocalLicense.ShowDialog();   
        }

        private void AddInternationalLicense(object sender, EventArgs e)
        {
            frmAddInternationalLicence frm = new frmAddInternationalLicence();
            frm.Show();
            _Refresh();
        }
        private void _GetFilter()
        {
            
            string FilterColumn = "" ;
            switch (cbFilterBy.Text)
            {
                //"InternationalLicenseID"
                //"ApplicationID" ||
                //"DriverID")
                case "InternationalLicenseID":
                    FilterColumn = "InternationalLicenseID";
                    break;
                case "ApplicationID":
                    FilterColumn = "ApplicationID";
                    break;
                case "DriverID":
                    FilterColumn = "DriverID";
                    break;
            }
            if (cbFilterBy.Text == "None"||txtFilterValue.Text=="".Trim())
            {
                _dtview.RowFilter = "";
                return;
            }
                //dtview.RowFilter = string.Format("[{0}] = {1}", FilterColumn, Text);
                //dtgview.DataSource = dtview;

                _dtview.RowFilter = $"{FilterColumn} = {txtFilterValue.Text}";
                dtgview.DataSource = _dtview;


                //_dtInternationalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _GetFilter();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "InternationalLicenseID"||
                cbFilterBy.Text == "ApplicationID"||
                cbFilterBy.Text==  "DriverID")
            {
                if (!Char.IsControl(e.KeyChar)&&!Char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text!="IsActive")
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

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            //            All
            //Yes
            //No
            if (cbIsReleased.Text=="All")
            {
                _dtview.RowFilter = "";
                return;
            }
            int IsActive = (cbIsReleased.Text == "Yes" ? 1 : 0);
            _dtview.RowFilter = $"{cbFilterBy.Text} = {IsActive}";
            dtgview.DataSource = _dtview;
        }
    }
}

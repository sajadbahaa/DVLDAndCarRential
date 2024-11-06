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
using static System.Net.Mime.MediaTypeNames;

namespace DVLCPresentation
{
    public partial class frmEditApplications : Form
    {
        private int _AppTypeID;
        clsAppType _clsAppType;
        public frmEditApplications(int AppTypeID)
        {
            InitializeComponent();
            _AppTypeID = AppTypeID;
        }

        private void LoadData(object sender, EventArgs e)
        {
            _clsAppType = clsAppType.Find(_AppTypeID);
            txtFees.Text = _clsAppType.AppFees.ToString();
            txtTitle.Text = _clsAppType.AppName.ToString();
            lbMode.Text = "Update Application Types";
            lbAppTypeID.Text = _clsAppType.AppTypeID.ToString();
        }

        private void Save(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("there are Errors , please put mouse on red Icon to See the problems");
                return;
            }
            _clsAppType.AppName = txtTitle.Text;
            _clsAppType.AppFees = Convert.ToDecimal( txtFees.Text);
            if (_clsAppType.Save())
            {
                MessageBox.Show("Saved Successfully");
            }
            else
            {
                MessageBox.Show("Error in Saving Data");
            }
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar)&&!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

       

        private void txtTitle_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "this Field is Required");
            }
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "");
            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "this Field is Required");
            }
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "");
            }
        }
    }
}

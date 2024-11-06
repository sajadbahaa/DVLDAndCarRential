using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clsPeople
{
public partial class ctrlLicenseWithFilter : UserControl
    {
        // define event delegate handler
        public  event Action<int> OnLicenseSelected;
        // create custome Protected to raise event with Parameters

        protected void LicenseSelected(int LicenseID)
        {
            Action<int> Handler = OnLicenseSelected;
            if (Handler != null)
            {
                Handler(LicenseID);
                MessageBox.Show("Here is it "+LicenseID);
            }
                
             }
        private bool _FilterEnable = true;
        public bool FilterEanble
        {
            get
            {
                return _FilterEnable;
            }
            set
            {
                _FilterEnable = value;
                gbFilter.Enabled = _FilterEnable;
            }
        }
        public int LicenseID
        {
            get
            {
                return ctrlShowLicense1.LicenseID;
            }
        }
        public clsLicense LicneseInfo
        {
            get
            {
                return ctrlShowLicense1.SelectLicenseInfo;
            }
        }

        

        public ctrlLicenseWithFilter()
        {
            InitializeComponent();
        }
        public void FilterFocuse()
        {
            txtSearch.Focus();
        }
        
        public void LoadData(int LicenseID)
        {
            ctrlShowLicense1.LoadLicenseInfo(LicenseID);

            if (OnLicenseSelected!=null&&FilterEanble)
            {
                OnLicenseSelected(ctrlShowLicense1.LicenseID);

            }
        }
        
        private void SearchLicense(object sender, EventArgs e)
        {
          
        }

        private void ctrladdInternationalLicense_Load(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
        e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
         
        if (e.KeyChar==(char)13)
        {
            btnFind.PerformClick();
                txtSearch.Text = "".Trim();
        }

        }
        private void txtSearch_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSearch,"this field is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSearch,null);
            }
        }

        private void Search(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fieds are still empty", "Search License",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearch.Focus();
                return;
            }
         
            LoadData(int.Parse(txtSearch.Text));
        
        }
    
    }
}

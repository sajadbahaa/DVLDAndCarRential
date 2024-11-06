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
    public partial class frmShowIntetnationalLicense : Form
    {
        private int _InternationalLicenseID;
        public frmShowIntetnationalLicense(int InternationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID = InternationalLicenseID ;
        }

        private void LoadDate(object sender, EventArgs e)
        {
            ctrlShowInternationalLicense1.LoadInternatioalLicenseInfo(_InternationalLicenseID);
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

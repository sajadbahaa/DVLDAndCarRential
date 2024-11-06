using clsPeople;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation
{
    public partial class ctrShowLocalAndInternationalDate : UserControl
    {
        public ctrShowLocalAndInternationalDate()
        {
            InitializeComponent();
        }
        private DataTable _dtLocal;
        private DataTable _dtInternational;
        
        private int _DriverID;
        private clsDriver _DriverInfo;
        private void _LoadLocalDrivingLicense()
        {
            _dtLocal = clsLicense.GetAllLicensesByDriverID(_DriverID);
            dtgviewLocalLicense.DataSource = _dtLocal;
            lbRecLocal.Text = dtgviewLocalLicense.Rows.Count. ToString();
        }
        private void _LoadInternationalLicense()
        {
            _dtInternational = clsInternationalLicense.GetAllInternationalLicenseByDriverID(_DriverID);
            dtgviewInternatoinalLicense.DataSource = _dtInternational;
            lbRecInternational.Text = _dtInternational.Rows.Count.ToString();
        }
       public void LoadDataByDriverID(int DriverID)
        {
            _DriverInfo = clsDriver.FindByDriverID(DriverID);
            if (_DriverInfo == null)
            {
                MessageBox.Show("there is no Driver ID with " + _DriverInfo.DriverID);
                return;
            }

            _DriverID = _DriverInfo.DriverID;
            _LoadLocalDrivingLicense();
            _LoadInternationalLicense();
        }
        public void Clear()
        {
            _dtLocal.Clear();
            _dtInternational.Clear();
        }
        public void LoadDataByPersonID(int PersonID)
        {

            _DriverInfo = clsDriver.FindByPersonID(PersonID);
            if (_DriverInfo==null)
            {
                MessageBox.Show("there is no Person ID with " + PersonID);
                return;
            }

            
                _DriverID = _DriverInfo.DriverID;
            _LoadLocalDrivingLicense();
            _LoadInternationalLicense();
        }
        private void ctrShowLocalAndInternationalDate_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtgviewInternatoinalLicense_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbRecLocal_Click(object sender, EventArgs e)
        {

        }
    }
}

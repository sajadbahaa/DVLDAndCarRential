using clsPeople;
using DVLCPresentation.Global_Classes;
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
    public partial class ctrlApplicationBasic : UserControl
    {
        private clsApplication _clsApplication;
        private int _ApplicationID;
        public int ApplicationID
        {
            get
            {
                return _ApplicationID;
            }
        }
        public ctrlApplicationBasic()
        {
            InitializeComponent();
        }
        public void _RestDefaultValue()
        {
            _ApplicationID = -1;
                lbApplicationID.Text = "[????]";
                lbDate.Text = "[????]";
                lbFees.Text = "[????]";
                lbLastDate.Text = "[????]";
                lbStatus.Text = "[????]";
                lbApplTypeID.Text = "[????]";
                lbPersonName.Text = "[????]";
                lbUsername.Text = "[????]";   
        }
       private void _FillApplicationInfo()
        {
       _ApplicationID = _clsApplication.ApplicationID;
       lbApplicationID.Text = _clsApplication.ApplicationID.ToString();
       lbApplTypeID.Text = _clsApplication.clsApplicationType.AppName;
       lbDate.Text = clsFormat.DateToShortString(_clsApplication.AppDate);
       lbFees.Text = _clsApplication.PaidFees.ToString();
       lbLastDate.Text = clsFormat.DateToShortString(_clsApplication.LastStatusDate);
       lbPersonName.Text = _clsApplication.ApplicationFullName;
       lbStatus.Text = _clsApplication.StatusText;
       lbUsername.Text = _clsApplication.CreateCurrentUser.Username;
       
        }
        public void LoadApplicationInfo(int ApplicationID)
        {
            _clsApplication = clsApplication.FindByAppID(ApplicationID);
            if (_clsApplication==null)
            {
                _RestDefaultValue();
                MessageBox.Show("this Application ID Not Found");
                return;
            }
            _FillApplicationInfo();
           
        }
        
        private void crlApplicationBasic_Load(object sender, EventArgs e)
        {

        }

        private void LoadPersonInfo(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonDetails frm = new frmShowPersonDetails(_clsApplication.PersonID);
            frm.ShowDialog();
            LoadApplicationInfo(ApplicationID);
        }
 
    }
}

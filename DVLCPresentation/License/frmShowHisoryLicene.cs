using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation
{
    public partial class frmShowHisoryLicene : Form
    {
        
        private int _PersonID;
        

        public frmShowHisoryLicene()
        {
            InitializeComponent();
        }
        public frmShowHisoryLicene
            (int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
         
        }
        
        private void frmLoadInternationalAndLocalLicense_Load(object sender, EventArgs e)
        {
            if (_PersonID!=-1)
            {
                ctrlFilterBy1.FilterEnable = false;
                ctrlFilterBy1.LoadPersonInfo(_PersonID);
                ctrShowLocalAndInternationalDate1.LoadDataByPersonID(_PersonID);
            }
            else
            {
                ctrlFilterBy1.FilterEnable = true;
                ctrlFilterBy1.FilterFocuse();
            }

        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrShowLocalAndInternationalDate1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlFilterBy1_OnPersonSeleced(int obj)
        {
            _PersonID = obj;
            if (_PersonID == -1)
                ctrShowLocalAndInternationalDate1.Clear();
            else
                ctrShowLocalAndInternationalDate1.LoadDataByPersonID(_PersonID);
        
        }
    }
}

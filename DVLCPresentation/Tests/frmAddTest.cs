using Clobal;
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

namespace DVLCPresentation
{
    public partial class frmAddTest : Form
    {
        private clsTestTypes.enTestType _TestTypeID;
        private int _TestAppointmentID;
        
        public frmAddTest(clsTestTypes.enTestType TestTypeID,int AppointmentID)
        {
            InitializeComponent();
            _TestAppointmentID = AppointmentID;
            _TestTypeID = TestTypeID;
            
        }
        private clsTests _clsTest;

        private void frmAddTest_Load(object sender, EventArgs e)
        {
            ctrlAddTest1.TestTypeID = _TestTypeID;
            ctrlAddTest1.LoadInfo(_TestAppointmentID);
            if (_TestAppointmentID == -1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;

            int _TestID = ctrlAddTest1.TestID;
            if (_TestID!=-1)
            {
                _clsTest = clsTests.Find(_TestID);

                if (_clsTest.TestRestult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;

                txtNote.Text = _clsTest.Notes;
                lblUserMessage.Visible = true;

                rbFail.Enabled = false;
                rbPass.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                rbPass.Enabled = true;
                rbFail.Enabled = true;
                lblUserMessage.Visible = false;
                _clsTest = new clsTests();
            }
                
        }

        private void ctrlAddTest1_Load(object sender, EventArgs e)
        {

        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void Save(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?","if you saved" +
                "you will not be able to change result",
                MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.No)
            {
                return;
            }
            if (rbPass.Checked)
                _clsTest.TestRestult = true;
            else
                _clsTest.TestRestult = false;

            _clsTest.Notes = txtNote.Text;
            _clsTest.TestAppointmentID = _TestAppointmentID;
            _clsTest.CreatedByUserID = clsGlobal.CurrentUser.UserID ;
            if (_clsTest.Save())
            {
                //_clsAppointment = clsAppointment.Find(_TestAppointmentID);
                
                //    _clsAppointment.IsLocked = true;
                //    if (_clsAppointment.Save())
                //    {
                //        MessageBox.Show("Saved Successfully");
                //    }
            }
            else
            {
                MessageBox.Show("Error in Data");
            }
        }

        private void Results(RadioButton rd)
        {
            if (rd.Text =="Pass")
            {
                _clsTest.TestRestult = true;
                return;
            }
            if (rd.Text=="Fail")
            {
                _clsTest.TestRestult = false;
            }
        }
        private void GetRsults(object sender, EventArgs e)
        {
            Results((RadioButton)sender);
        }
    }
}

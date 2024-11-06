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
    public partial class frmEditTestTypes : Form
    {
        clsTestTypes _clsTestTypes;
        private int _TestTypeID;
        public frmEditTestTypes(int TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }
       
        private void frmEditTestTpes_Load(object sender, EventArgs e)
        {
           _clsTestTypes = clsTestTypes.Find(_TestTypeID);
            if (_clsTestTypes!=null)
            {
                txtDescription.Text = _clsTestTypes.Description;
                txtFees.Text = _clsTestTypes.Fees.ToString();
                txtTitle.Text = _clsTestTypes.Title;
                lbTestTypeID.Text = _clsTestTypes.TestTypeID.ToString();
            }
            else
            {
                MessageBox.Show($"this {_TestTypeID} not Found");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Save(object sender, EventArgs e)
        {
            _clsTestTypes.Fees = Convert.ToDecimal(txtFees.Text);
            _clsTestTypes.Title = txtTitle.Text;
            _clsTestTypes.Description = txtDescription.Text;
            if (_clsTestTypes.Save())
            {
                MessageBox.Show("Saved Successfully");
            }
            else
            {
                MessageBox.Show("Error in Filling Data");
            }
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

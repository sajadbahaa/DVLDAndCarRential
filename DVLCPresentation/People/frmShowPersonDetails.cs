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
    public partial class frmShowPersonDetails : Form
    {
        public frmShowPersonDetails(int PersonID)
        {
            InitializeComponent();
            ctrlPersonDetails1.LoadPersonDetailsByPersonID(PersonID);
        }
        public frmShowPersonDetails(string NationalNo)
        {
            InitializeComponent();
            ctrlPersonDetails1.LoadPersonDetailsByNationalNumber(NationalNo);
        }


        private void LoadData(object sender, EventArgs e)
        {
        }

        private void CLose(object sender, EventArgs e)
        {
            
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

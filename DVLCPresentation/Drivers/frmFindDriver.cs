using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.Drivers
{
    public partial class frmFindDriver : Form
    {
        public frmFindDriver()
        {
            InitializeComponent();
        }

        private void ctrlDriverWithFilter1_OnDriverSelected(object sender, clsPeople.clsDriver e)
        {
            if (e.DriverID == -1)
                return;

            //     MessageBox.Show("Dreiver Name : "+e.PersonInfo.FullName());

            if (!e.HasLicenseDriver)
                MessageBox.Show("no he does not have License");
            else
                MessageBox.Show("yes he has.");
        }

        private void frmFindDriver_Load(object sender, EventArgs e)
        {

        }
    }
}

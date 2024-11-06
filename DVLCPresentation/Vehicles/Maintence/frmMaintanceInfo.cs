using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.Vehicles.Maintence
{
    public partial class frmMaintanceInfo : Form
    {
        public frmMaintanceInfo(int MaintanceID)
        {
            InitializeComponent();
            ctrlMantanceInfo1.LoadMaintanceInfo(MaintanceID);
        }

        private void frmMaintanceInfo_Load(object sender, EventArgs e)
        {

        }
    }
}

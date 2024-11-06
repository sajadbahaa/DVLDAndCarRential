using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.ReturnCar
{
    public partial class frmRetrunInfo : Form
    {
        public frmRetrunInfo(int RetunrID)
        {
            InitializeComponent();
            ctrlReturnInfo1.LoadReturnDate(RetunrID);
        }

        private void ctrlReturnInfo1_Load(object sender, EventArgs e)
        {

        }

        private void frmRetrunInfo_Load(object sender, EventArgs e)
        {

        }
    }
}

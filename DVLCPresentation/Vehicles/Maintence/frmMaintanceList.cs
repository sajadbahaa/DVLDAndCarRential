using clsPeople.File_DvlD_Bussiness;
using CRentail.Public_Classes;
using CRentailBussiness;
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
    public partial class frmMaintanceList : Form
    {
        public frmMaintanceList()
        {
            InitializeComponent();
        }
        public DataView dtv;
        public clsMatinces MaintanceInfo;
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dtgview.RowCount==0)
            {
                btncompleteProcess.Enabled = false;
                btnshowMaintanceInfo.Enabled = false;
                MaintanceInfo = new clsMatinces();
                return;
            }
            MaintanceInfo = clsMatinces.FindByMaintanceID((int)dtgview.CurrentRow.Cells[0].Value);
        if (MaintanceInfo == null)
                return;

            btncompleteProcess.Enabled = (bool)dtgview.CurrentRow.Cells[5].Value ? false : true; ;
            btnshowMaintanceInfo.Enabled = true;
        
                
                }

        private void frmMaintanceList_Load(object sender, EventArgs e)
        {
            dtv = clsMatinces.GetAllMatiences().DefaultView;
            dtgview.DataSource = dtv;
        }

        private void btnshowMaintanceInfo_Click(object sender, EventArgs e)
        {
            frmMaintanceInfo frm = new frmMaintanceInfo((int)dtgview.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void btncompleteProcess_Click(object sender, EventArgs e)
        {
            if (MaintanceInfo.CompleteProcessMantiance())
                clsGlobalMessages.Messages($"Vehicle {MaintanceInfo.VehicleInfo.VehicleNamesInfo.VehicleName} Has been Repired");
            else
                clsGlobalMessages.Messages("Error in Completing Process Maintance");

            frmMaintanceList_Load(null, null);
        }
    }
}

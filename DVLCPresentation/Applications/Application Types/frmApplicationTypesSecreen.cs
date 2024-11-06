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
    public partial class frmApplicationTypesSecreen : Form
    {
        public frmApplicationTypesSecreen()
        {
            InitializeComponent();
        }
        DataView dv;
        private void _Refresh()
        {
            dv = clsAppType.GetAllApplicationTypes().DefaultView;
            dtgview.DataSource = dv;
            lbRecord.Text = dv.Count.ToString();
        }
        private void LoadData(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }
        frmEditApplications frmEdit;
        private void EditApplication(object sender, EventArgs e)
        {
            frmEdit = new frmEditApplications((int)dtgview.CurrentRow.Cells[0].Value);
            frmEdit.ShowDialog();
            _Refresh();
        }
    }
}

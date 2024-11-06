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
    public partial class frmListTestType : Form
    {
        DataView dtview;
        public frmListTestType()
        {
            InitializeComponent();
        }
        private void _Refresh()
        {
            dtview = clsTestTypes.GetAllTestTypes().DefaultView;
            dtgview.DataSource = dtview;
            lbRecord.Text = dtview.Count.ToString();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmTestTypesScreen_Load(object sender, EventArgs e)
        {
            dtview = clsTestTypes.GetAllTestTypes().DefaultView;
            dtgview.DataSource = dtview;
            lbRecord.Text = dtview.Count.ToString();

            if (dtgview.Rows.Count>0)
            {
                dtgview.Columns[0].HeaderText = "ID";
                dtgview.Columns[0].Width = 100;

                dtgview.Columns[1].HeaderText = "Title";
                dtgview.Columns[1].Width = 200;

                dtgview.Columns[2].HeaderText = "Description";
                dtgview.Columns[2].Width = 250;

                dtgview.Columns[3].HeaderText = "Fees";
                dtgview.Columns[3].Width = 190;
            }
//            _Refresh();
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        frmEditTestTypes fEdit;
        private void EditTestTypes(object sender, EventArgs e)
        {
            fEdit = new frmEditTestTypes((int)dtgview.CurrentRow.Cells[0].Value);
            fEdit.ShowDialog();
            _Refresh();
        }
    }
}

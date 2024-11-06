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
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
namespace DVLCPresentation
{
    public partial class frmPeopleScreen : Form
    {
        DataView dtview;
        
        public frmPeopleScreen()
        {
            InitializeComponent();
        }
        private void _Refresh()
        {
            dtview = clsPerson.GetAllPeople().DefaultView;
            dtgview.DataSource = dtview;
            lbCount.Text = dtview.Count.ToString();
        }
        private void LoadData(object sender, EventArgs e)
        {
            _Refresh();
            cbFilter.SelectedIndex = 0;
        }
        frmAddPerson frmAdd;
        private void AddPerson(object sender, EventArgs e)
        {
            frmAdd = new frmAddPerson();
            frmAdd.ShowDialog();
            _Refresh();
        }
        frmAddPerson fUpdatePerson;
        private void Edit(object sender, EventArgs e)
        {

            fUpdatePerson = new frmAddPerson((int)dtgview.CurrentRow.Cells[0].Value);
            fUpdatePerson.ShowDialog();
            _Refresh();
        }


        private void Delete(object sender, EventArgs e)
        
        {
            if (MessageBox.Show("Are you Sure ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsPerson.Delete((int)dtgview.CurrentRow.Cells[0].Value))
                {
                
                    MessageBox.Show("Saved Successfully");
                    _Refresh();
                }
                else
                {
                    MessageBox.Show("this personID linked with  others Tables");
                    return;
                }

            }
            else
            {
                MessageBox.Show("you did not Delete PersonID");
                return;
            }
        
            
        }
        frmShowPersonDetails frmShowDetials;
        private void ShowDetials(object sender, EventArgs e)
        {
            frmShowDetials = new frmShowPersonDetails((int)dtgview.CurrentRow.Cells[0].Value);
            frmShowDetials.ShowDialog();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {

            string FilterCoulum = "";
            switch (cbFilter.Text)
            {
                case "PersonID":
                    FilterCoulum = "PersonID";
                    break;
                case "NationalNo":
                    FilterCoulum = "NationalNo";
                    break;
                case "FirstName":
                    FilterCoulum = "FirstName";
                    break;
                case "SecondName":
                    FilterCoulum = "SecondName";
                    break;
                case "ThirdName":
                    FilterCoulum = "ThirdName";
                    break;
                case "LastName":
                    FilterCoulum = "LastName";
                    break;

                case "Gendor":
                    FilterCoulum = "Gendor";
                    break;
  
                case "Phone":
                    FilterCoulum = "Phone";
                    break;

                case "Email":
                    FilterCoulum = "Email";
                    break;

                case "Nationality":
                    FilterCoulum = "Nationality";
                    break;
                
                default:
                    FilterCoulum = "None";
                    break;
            }
            if (txtFilter.Text == ""||FilterCoulum=="None")
            {
                dtview.RowFilter = "";
                lbCount.Text = dtgview.Rows.Count.ToString();
                return;
            }
            if (FilterCoulum == "PersonID")
            {
                dtview.RowFilter = string.Format("[{0}] = {1}", FilterCoulum, txtFilter.Text);
                dtgview.DataSource = dtview; 
            }
            //
            else
            {
                dtview.RowFilter = $"{FilterCoulum} Like '"+txtFilter.Text +"%'" ;
                dtgview.DataSource = dtview;
            }
            
            lbCount.Text = dtview.Count.ToString();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            

            
            if (cbFilter.Text == "PersonID")
            {
                if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = (cbFilter.Text!="None");
            if (txtFilter.Visible)
            {
                txtFilter.Text = "";
                txtFilter.Focus();
            }
        }

        private void dtgview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgview_DoubleClick(object sender, EventArgs e)
        {
            frmShowDetials = new frmShowPersonDetails((int)dtgview.CurrentRow.Cells[0].Value);
            frmShowDetials.ShowDialog();
        }
    }
}

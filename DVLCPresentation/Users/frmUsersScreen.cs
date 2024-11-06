using clsPeople;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLCPresentation
{
    public partial class frmUsersScreen : Form
    {
        public frmUsersScreen()
        {
            InitializeComponent();
        }
        DataView _dtAllUsers;
        
        private void _Refresh()
        {
            _dtAllUsers = clsUser.GetAllUsers().DefaultView;
            dtgview.DataSource = _dtAllUsers;
            lbRecord.Text = _dtAllUsers.Count.ToString();
            
        }
        private void LoadData(object sender, EventArgs e)
        {
            _Refresh();
            
            cbFilter.SelectedIndex = 0;
            cbIsActive.SelectedIndex = 0;
        
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "PersonID" || cbFilter.Text == "UserID") { 
                if (!Char.IsControl(e.KeyChar)&&!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            }

        }
        private void Searchby(string Filter)
        {

            txtSearch.Visible = true;
            if (cbFilter.Text=="PersonID"|| cbFilter.Text == "UserID")
                {
                if (string.IsNullOrEmpty(Filter))
                {
                    return;
                }
                _dtAllUsers.RowFilter = $"{cbFilter.Text} = {Filter}";
                    dtgview.DataSource = _dtAllUsers; 
                }
                
            else
            {
                _dtAllUsers.RowFilter = $"{cbFilter.Text} Like '" + Filter + "%'";
                dtgview.DataSource = _dtAllUsers;
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilter.Text)
            {
            case "PersonID":
                    FilterColumn = "PersonID";
                    break;
             case "Username":
                    FilterColumn = "Username";
                    break;
                case "UserID":
                    FilterColumn = "UserID";
                    break;
                case "FullName":
                    FilterColumn = "FullName";
                    break;
                case "IsActive":
                    FilterColumn = "IsActive";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }
            if (txtSearch.Text.Trim()==""||cbFilter.Text=="None")
            {
                _dtAllUsers.RowFilter = "";
                lbRecord.Text = _dtAllUsers.Count.ToString();
                return;
            }
            if (FilterColumn == "UserID" || FilterColumn == "PersonID")
_dtAllUsers.RowFilter  = 
 string.Format("[{0}] = {1}",FilterColumn,txtSearch.Text.Trim());
            else
               _dtAllUsers.RowFilter
                    = $"{FilterColumn} Like '" + txtSearch.Text + "%'";
                dtgview.DataSource = _dtAllUsers;
                        
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilter.Text == "IsActive")
            {
            
                txtSearch.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
            }
            
            else
            
            {
                txtSearch.Visible = (cbFilter.Text !="None");
                cbIsActive.Visible = false;


                if (cbFilter.Text=="None")
                {
                    txtSearch.Visible = false;
                }
                else
                {
                    txtSearch.Visible = true;
                    txtSearch.Text = "";
                    txtSearch.Focus();
                }

            }
        }

        private void cbFilterUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;
            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue ="1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }
            if (FilterValue == "All")
            {
                _dtAllUsers.RowFilter = ""; lbRecord.Text = _dtAllUsers.Count.ToString();
            }
            else
            {
                _dtAllUsers.RowFilter = string.Format("[{0}] = {1}",FilterColumn,FilterValue);
                lbRecord.Text = _dtAllUsers.Count.ToString();
            }
            dtgview.DataSource = _dtAllUsers;
              
        }
        
        private void AddUser(object sender, EventArgs e)
        {
            frmAddUser frm = new frmAddUser();
            frm.ShowDialog();
            _Refresh();
        }

        frmUserInfo fInfoUser;
        clsUser _ClsUser;
        private void ShowDetials(object sender, EventArgs e)
        {
            _ClsUser = clsUser.FindByUserID((int)dtgview.CurrentRow.Cells[0].Value);
            fInfoUser = new frmUserInfo((int)dtgview.CurrentRow.Cells[0].Value);
            fInfoUser.ShowDialog();
        }

        private void EditUser(object sender, EventArgs e)
        {
     frmAddUser frmUpdate = new frmAddUser((int)dtgview.CurrentRow.Cells[0].Value);
            frmUpdate.ShowDialog();
            _Refresh();
        }

        private void Delete(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsUser.Delete((int)dtgview.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Deleted Successfully");
                    _Refresh();
                }
                else
                {
                    MessageBox.Show("This UserID linked With Another Table");
                    return;
                }
            }
        }
       
        frmChangePassword fChangePassword;
        private void ChangePassword(object sender, EventArgs e)
        {
            _ClsUser = clsUser.FindByUserID((int)dtgview.CurrentRow.Cells[0].Value);
            fChangePassword = new frmChangePassword((int)dtgview.CurrentRow.Cells[0].Value);
            fChangePassword.ShowDialog();
            _Refresh();
        }

        private void AddNewUser(object sender, EventArgs e)
        {
            frmAddUser frm = new frmAddUser();
            frm.ShowDialog();
            _Refresh();
        }
    }
}

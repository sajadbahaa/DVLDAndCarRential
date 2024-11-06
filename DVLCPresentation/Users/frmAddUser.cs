using Clobal;
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
    public partial class frmAddUser : Form
    {
        private int _UserID;
        clsUser _clsUser;
     enum enMode { enAdd =1,enUpdate =2};
        private enMode _Mode;
        private void _DefaultData()
        {
            if (_Mode==enMode.enAdd)
            {
                lbMode.Text = "Add User";
                _clsUser = new clsUser();
                tbLoginInfo.Enabled = false;
                btnSave.Enabled = false;
                ctrlFilterBy1.FilterFocuse();
            }
            else
            {
                lbMode.Text = "Update User";
                btnSave.Enabled = true;
                tbLoginInfo.Enabled = true;
            }

            txtConfirm.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
            chIsActive.Checked = true;
        
        }
        private void _FillUserData()
        {
            _clsUser = clsUser.FindByUserID(_UserID);
            ctrlFilterBy1.FilterEnable = false;
            if (_clsUser==null)
            {
                MessageBox.Show($"this UserID [{_UserID}] not found");
                this.Close();
                return;
            }
            lbUserID.Text = _UserID.ToString();
            txtUsername.Text = _clsUser.Username;
            txtPassword.Text = _clsUser.Password;
            txtConfirm.Text = txtPassword.Text;
            chIsActive.Checked = _clsUser.IsActive;
            ctrlFilterBy1.LoadPersonInfo(_clsUser.PersonID);
        }
        public frmAddUser()
        {
            InitializeComponent();
            _Mode = enMode.enAdd;
        }
        public frmAddUser(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.enUpdate;
            _UserID = UserID;
        }
        

       
        
        private void Save(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("some fields are not Complete yet");
                return;
            }
            _clsUser.Username = txtUsername.Text;
            _clsUser.Password = clsGlobal.EncryptDataByHashing(txtPassword.Text);
            _clsUser.PersonID = ctrlFilterBy1.PersonID;
            _clsUser.IsActive = (chIsActive.Checked?true:false);
            if (_clsUser.Save())
            {
                lbUserID.Text = _clsUser.UserID.ToString();
                MessageBox.Show("Saved Successfully","saved",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("there is Errro in DataBase","",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }


        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProvider1.SetError(txtUsername, "you Must enter value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUsername,"");
            }

            if (_Mode==enMode.enAdd)
            {
                if (clsUser.IsUserExist(txtUsername.Text))
                {
                e.Cancel = true;
                errorProvider1.SetError(txtUsername, "Username has already taken by another user");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtUsername,null);
                }
            }
            else
            {
                if (txtUsername.Text!=_clsUser.Username)
                {
                if (clsUser.IsUserExist(txtUsername.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUsername, "Username has already taken by another user");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtUsername, null);
                }
                }
                

            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword,"you Must Enter Value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword,"");
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirm.Text)||txtConfirm.Text!=txtPassword.Text)
            {
                e.Cancel = true;
                txtConfirm.Focus();
                errorProvider1.SetError(txtConfirm, "Confirm Password does not Match  Password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirm,"");
            }
        }
        
        private void ctrlFilterBy1_Load(object sender, EventArgs e)
        {
                 
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }
        
        
        

        

        private void GoToFillUserInfo(object sender, EventArgs e)
        {
            if (_Mode == enMode.enUpdate)
            {
                tbUserInfo.SelectedTab = tbUserInfo.TabPages["tbLoginInfo"];
                return;
            }
            if (ctrlFilterBy1.PersonID!=-1)
            {
                if (clsUser.IsPersonIDFollowedForUser(ctrlFilterBy1.PersonID))
                {
                    MessageBox.Show("Person ID already  has User");
                    ctrlFilterBy1.FilterFocuse();
                }
                else
                {
                    btnSave.Enabled = true;
                    tbLoginInfo.Enabled = true;
                    tbUserInfo.SelectedTab = tbUserInfo.TabPages["tbLoginInfo"];
                }
            }
            else
            {
                MessageBox.Show("Person ID Not Found , Enter Person ID Existed"
                    ,"",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                ctrlFilterBy1.FilterFocuse();
            }
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            _DefaultData();
            if (_Mode == enMode.enUpdate)
                _FillUserData();
        }
    }
}

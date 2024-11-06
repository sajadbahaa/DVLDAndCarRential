using Clobal;
using clsPeople;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation
{
    public partial class frmChangePassword : Form
    {

        private int _UserID;
        private clsUser _clsUser;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void _RestDefaultValue()
        {
            txtCurrentPassword.Focus();
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
        }
       


        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _RestDefaultValue();
            _clsUser = clsUser.FindByUserID(_UserID);
            if (_clsUser==null)
            {
                MessageBox.Show($"we could not find {_UserID}");
                this.Close();
                return;
            }
            ctrlUserDetials1.LoadUserInfo(_UserID);
        }

        private void Save(object sender, EventArgs e)
        {
        if (!this.ValidateChildren())
        {
 MessageBox.Show("Some field are still some error,put mouse on red Icon then you can see Error");
        return;
        }
            bool IsUpdate = _clsUser.ChangePassword(clsGlobal.EncryptDataByHashing( txtNewPassword.Text));

            if (IsUpdate)
            {
                MessageBox.Show("New Password  Saved Successfully","Changing Password",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error in Data");
            }
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                e.Cancel = true;
                txtCurrentPassword.Focus();
                errorProvider1.SetError(txtCurrentPassword,"this record is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCurrentPassword,null);
            }
            if (txtCurrentPassword.Text != _clsUser.Password)
            {
                e.Cancel = true;
                txtCurrentPassword.Focus();
                errorProvider1.SetError(txtCurrentPassword, "Current Password Does not Math The Previous Password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCurrentPassword,null);
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtNewPassword.Text))
            {
                e.Cancel = true;
                
                errorProvider1.SetError(txtNewPassword,"this Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNewPassword,"");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text!=txtNewPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword,"Confirm Password does not match New Password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword,"");
            }
        }
    }
}

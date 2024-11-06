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
using System.Collections.Specialized;
using clsString;
using System.Net.Http;
using System.Xml.Linq;
using System.Linq.Expressions;
using Clobal;
using System.Configuration;
using System.Security.Cryptography;
using DvlcDataLayer;


namespace DVLCPresentation
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        frmMainForm frm;
        private void LoginUser(object sender, EventArgs e)
        {
            clsUser _clsUser  =   clsUser.FindByUsernameAndPassword(txtUsername.Text,clsGlobal.EncryptDataByHashing(txtPassword.Text));
            if (_clsUser!=null)
            {
                if (!_clsUser.IsActive)
                {
                    MessageBox.Show("your Account is not Active, Please Contact with your Admin", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (chRemmberMe.Checked)
                    clsGlobal.RemmberMe(txtUsername.Text.Trim());
                else
                    clsGlobal.DeleteRegister();

                

                clsGlobal.CurrentUser = _clsUser;
                frm = new frmMainForm();
                frm.Show();

            }
            else
            {
                MessageBox.Show("Error Username/Passworf is not vaild");
            }
        }
        //F:\DvlcWindows\InfoUsers

        private async void Login_Load(object sender, EventArgs e)
        {
            string Username = "";
            if (clsGlobal._ReadDataFromRegistry(ref Username))
            {
                txtUsername.Text = Username.Trim();
                chRemmberMe.Checked = true;
            }
            else
                chRemmberMe.Checked = false;

            await Task.Yield();
        }
        private void chRemember_CheckedChanged(object sender, EventArgs e)
        {
        }
      
        private void OnClik(object sender, EventArgs e)
        {
            
        }

        private void chRemember_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

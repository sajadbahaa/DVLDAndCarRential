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
    public partial class ctrlUserDetials : UserControl
    {
        public ctrlUserDetials()
        {
            InitializeComponent();
        }
        private clsUser _User;

        private void _RestDefaultValue()
        {
            lbIsActive.Text = "????";
            lbUserID.Text = "????";
            lbUsername.Text = "????";
            ctrlPersonDetails1._RestInfo();
        }
        private void _FillUserInfo()
        {
            ctrlPersonDetails1.LoadPersonDetailsByPersonID(_User.PersonID);
            lbUserID.Text = _User.UserID.ToString();
            lbUsername.Text = _User.Username;
            lbIsActive.Text = (_User.IsActive?"Active":"Not Active");
        }
        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.FindByUserID(UserID);
            if (_User==null)
            {
                MessageBox.Show("this UserID Not Found");
                _RestDefaultValue();
                return;
            }
            _FillUserInfo();
        }
        
        private void ctrlUserDetials_Load(object sender, EventArgs e)
        {

        }
    }
}

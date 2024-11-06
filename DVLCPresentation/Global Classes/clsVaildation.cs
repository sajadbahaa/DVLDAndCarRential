using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.Global_Classes
{
    public  class clsVaildation
    {
    public static bool VaildateEmail(string EmailAddress)
        {
            var Pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            var rex = new Regex(Pattern);
            return rex.IsMatch(EmailAddress);
        }
    public static bool ValdateIneger(string Number)
        {
            string pattern = @"^[0-9]*$";
            var rex = new Regex(pattern);
            return rex.IsMatch(Number);
        }
    public static bool ValdateFloat(string Number) 
        {
            string pattern = @"^[0-9]*(?:\.[0-9]*)?$";
            var rex = new Regex(pattern);
            return rex.IsMatch(Number);
        }
    public static  bool IsNumber(string Number)
        {
            return (ValdateFloat(Number)||ValdateIneger(Number));
        }

       static public bool IsZero(int Num)
        {
            return Num == 0;
        }
        public static void ValidatingEmpty(object sender, CancelEventArgs e,Control control, ErrorProvider errorProvider1)
        {

            
            if (string.IsNullOrEmpty(control.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(control, "This filed is Required");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(control, null);
            }
        }
        public static void ValidatingNumber(object sender, CancelEventArgs e, Control control, ErrorProvider errorProvider1)
        {

            if (!IsNumber(control.Text))
            {
                e.Cancel = true;
                control.Focus();
                errorProvider1.SetError(control, "This filed does not Accept Characters.");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(control, null);
            }
        }
        static public bool VaildationFieldsRequired(Form frm)
        {
            if (!frm.ValidateChildren())
            {
                MessageBox.Show("Error theres field are required");
                return false;
            }
            return true;
        }
        static public bool VaildationFieldsRequired(UserControl ctr)
        {
            if (!ctr.ValidateChildren())
            {
                MessageBox.Show("Error theres field are required");
                return false;
            }
            return true;
        }
        public static void UserControlKeyPressHandlerNumber(object sender, KeyPressEventArgs e)
        {
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);

        }

    }
}

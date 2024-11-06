using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.Global_Classes
{
    public class clsControls
    {
        public static void DisableControl(Control control1)
        {
            control1.Enabled = false;
        }
        public static void DisableControl(Control control1, Control control2)
        {
            control1.Enabled = false;
            control2.Enabled = false;
        }
        public static void DisableControl(Control control1, Control control2, Control control3)
        {
            control1.Enabled = false;
            control2.Enabled = false;
            control3.Enabled = false;

        }
        public static void NextTabControl(TabControl control,int Index)
        {
            control.SelectedIndex = Index;
        }
        public static void NextComboBox(ComboBox combo,int Index)
        {
            combo.SelectedIndex = Index;
        }
        public static void EnableControl(Control control1)
        {
            control1.Enabled = true;
        }
        public static void VisableControl(Control control1)
        {
            control1.Visible = true;
        }
        public static void UnVisableControl(Control control1)
        {
            control1.Visible = false;
        }
        public static void VisableControl(Control control1, Control control2)
        {
            control1.Visible = true;
            control2.Visible = true;
        }
        public static void UnVisableControl(Control control1, Control control2)
        {
            control1.Visible = false;
            control2.Visible = false;
        }
        public static void EnableControl(Control control1, Control control2)
        {
            control1.Enabled = true;
            control2.Enabled = true;
        }
    }
}

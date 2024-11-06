using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLCPresentation.Global_Classes
{
    public class clsFilters
    {

    public static void FilterFocuse(Control control)
        {
            control.Focus();
        }
    public static string FromIntToString<T>(T text)
        {
      return text.ToString();
        }
    }
}

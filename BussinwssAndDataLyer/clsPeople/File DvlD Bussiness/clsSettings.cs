using DvlcDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsPeople
{
    public class clsSettings
    {
     static public   DateTime VaildityLength
        {
            get
            {
                return clsSettings.GetValidtyLength();
            }
        }
    private static DateTime GetValidtyLength()
        {
            return dtSettings.GetDefaultVaildityLength();
        }
    }
}

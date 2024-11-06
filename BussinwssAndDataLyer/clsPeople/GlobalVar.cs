using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;
namespace CRentailBussiness
{
    public  class GlobalVar
    {
        public static int? nullable = null;
        public static byte? nullabel = null;
    public  enum enMode { add =1 , Update =2}
        public static enMode _mode;

        public static DataView dtv;
        public StringBuilder FilterColumn = new StringBuilder("");

        public static bool IsNone;

        public static bool FilterEnable = true;

        public static DateTime? dtnullable = null;
        public static decimal? dcnullable = null;
    }
}

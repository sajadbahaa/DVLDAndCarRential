using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;
namespace DvlcDataLayer
{
     public class dtAccess
    {
     //public static string Connection = "Server = .; DataBase = DVLD; User ID = sa; Password = sa123456";
       static public string Connection ;
        public static string SourceName = "DVLDApp";
        
        public static void WriteExceptionOnEventViewer(string Message)
        {
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }
EventLog.WriteEntry(SourceName, Message, EventLogEntryType.Error);
        }
    
    }

}


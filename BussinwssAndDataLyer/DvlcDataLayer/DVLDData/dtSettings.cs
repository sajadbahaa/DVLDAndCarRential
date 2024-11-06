using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DvlcDataLayer
{
    public class dtSettings
    {
    public static DateTime GetDefaultVaildityLength()
        {
            DateTime ValidityLength = DateTime.Now;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);

            string query =
     @" select DefaultValidityLength from Settings 
where settingID = @settingID;";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@settingID",1);
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res!=null)
                {
                    ValidityLength = Convert.ToDateTime(res);
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Get Default Validity Length " + ex);

            }
            finally
            {
                connection.Close();
            }
            return ValidityLength;
        }

    }
}

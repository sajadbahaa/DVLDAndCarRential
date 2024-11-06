using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvlcDataLayer
{
    public  class dtLicenceClass
    {
        public static bool 
Find(int LicenseClassID,ref  string ClassName
,ref  string ClassDescription,ref byte MinimumAllowedAge
,ref byte DefaultValidityLength,ref Decimal ClassFees)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select * from LicenseClasses 
Where LicenseClassID = @LicenseClassID";
            SqlCommand Command = new SqlCommand(query,connection);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    IsFind = true;
                    ClassName = (string)reader["ClassName"];
                    ClassDescription = (string)reader["ClassDescription"];
                     MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = (Decimal)reader["ClassFees"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed finding Class License Info By Class License ID" + ex);

            }
            finally
            {
                connection.Close();
            }
            return IsFind; 
        }
    public static int GetID(string ClassName)
        {
            int ClassID = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select LicenseClassID from LicenseClasses Where ClassName = @ClassName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName",ClassName);
            
            try
            {
                
                connection.Open();
                object result = command.ExecuteScalar();
                if (result!=null)
                {
                    ClassID = Convert.ToInt32(result);
                }
                else
                {
                    ClassID = -1;
                }

            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed finding ClassName Info By Class License ID" + ex);

            }
            finally
            {
                connection.Close();
            }
            return ClassID;
        }
        public static string GetClassName(int LicenseClassID)
        {
            string ClassName = "";
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select ClassName from LicenseClasses Where LicenseClassID = @LicenseClassID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {

                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    ClassName = result.ToString();
                }
                

            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed finding Class License ID  Info By Class License Name" + ex);

            }
            finally
            {
                connection.Close();
            }
            return ClassName;
        }
        public static DataTable AllCalassLicaense()
        {
            DataTable dt = new DataTable();
    SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = "Select * from LicenseClasses";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }catch(Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Loading All Class Licenses List " + ex);

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        

    }
}

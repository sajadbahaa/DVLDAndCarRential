using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvlcDataLayer
{
    public class dtAppTypes
    {
    public static bool Find(int ApplicationTypeID,ref string ApplicationTypeTitle,ref Decimal ApplicationFees)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select * from ApplicationTypes Where ApplicationTypeID = @ApplicationTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFind = true;
                    ApplicationFees      = (Decimal)reader["ApplicationFees"];
                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Loading  Application type Info by Application type ID" + ex);
            }
            finally
            {
                connection.Close();
            }
            return IsFind;
        }
        public static bool Find(ref int ApplicationTypeID,string ApplicationTypeTitle, ref Decimal ApplicationFees)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select * from ApplicationTypes Where ApplicationTypeTitle = @ApplicationTypeTitle";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFind = true;
                    ApplicationFees = (Decimal)reader["ApplicationFees"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Loading  Application type Info by title" + ex);

            }
            finally
            {
                connection.Close();
            }
            return IsFind;
        }

        public static int Add( string ApplicationTypeTitle, Decimal ApplicationFees)
        {
            int Affect =-1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Insert Into ApplicationTypes (ApplicationTypeTitle,ApplicationFees)
           Values(@ApplicationTypeTitle,@ApplicationFees);
            Select Scope_Identity();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);
            try
            {
                connection.Open();
                Affect = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Adding Application type Info" + ex);
            }
            finally
            {
                connection.Close();
            }
            return (Affect);
        }
        public static bool Update( int ApplicationTypeID, string ApplicationTypeTitle, Decimal ApplicationFees)
        {
            int Affect = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Update ApplicationTypes 
          set ApplicationTypeTitle = @ApplicationTypeTitle,ApplicationFees = @ApplicationFees
Where ApplicationTypeID = @ApplicationTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

            try
            {
                connection.Open();
                Affect = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Updating Application type Info" + ex);

            }
            finally
            {
                connection.Close();
            }
            return (Affect > -1);
        }
        public static DataTable AllApplicationTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select * from ApplicationTypes";
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
                dtAccess.WriteExceptionOnEventViewer("Failed Get All Application type List" + ex);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

    }
}

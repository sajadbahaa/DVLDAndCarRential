using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DvlcDataLayer
{
    public  class dtTestTypes
    {
    public static bool Find(int TestTypeID,ref  string TestTypeTitle,ref  string TestTypeDescription,ref Decimal TestTypeFees)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select * from TestTypes where TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID",TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFind = true;
                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestTypeDescription = (string)reader["TestTypeDescription"];
                    TestTypeFees = (Decimal)reader["TestTypeFees"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Finding  test Type Data By TestTypeID"+ex);

            }
            finally
            {
                connection.Close();
            }
            return IsFind;
        }
        public static bool Update(int TestTypeID, string TestTypeTitle, string TestTypeDescription, Decimal TestTypeFees)
        {
            int Affect = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Update TestTypes 
Set TestTypeTitle = @TestTypeTitle, TestTypeDescription = @TestTypeDescription,TestTypeFees = @TestTypeFees
where TestTypeID = @TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees",TestTypeFees);
            try
            {
                connection.Open();
                Affect = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Update  test Type Data By TestTypeID"+ex);

            }
            finally
            {
                connection.Close();
            }
            return Affect > -1;
        }
        public static bool Delete(int TestTypeID)
        {
            int Affect = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Delete from  TestTypes 
where TestTypeID = @TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                Affect = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Delete test Type Data By TestTypeID"+ex);

            }
            finally
            {
                connection.Close();
            }
            return Affect > -1;
        }
        public static bool Exist(int TestTypeID)
        {
            bool ISFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"select find  = 'find' from  TestTypes 
where TestTypeID = @TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                ISFind = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Existing test Type Data By TestTypeID"+ex);

            }
            finally
            {
                connection.Close();
            }
            return ISFind;
        }
        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable(dtAccess.Connection);
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = "Select * from TestTypes";
            SqlCommand command = new SqlCommand(query,connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Loading test Type List"+ ex);

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
    }
}

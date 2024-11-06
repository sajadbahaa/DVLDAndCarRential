using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvlcDataLayer
{
    public class dtDrivers
    {
    static public bool Find(int DriverID,ref int PersonID,
    ref int CreatedByUserID,ref DateTime CreatedDate)
        {
            bool IsFind = false;
SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select * from Drivers where 
DriverID  = @DriverID";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@DriverID",DriverID);
            try
            {
            connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFind = true;
                    PersonID = (int)reader["PersonID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Loading Driver Info by Driver ID"+ex);
            }
            finally
            {
                connection.Close();
            }
            return IsFind;
        }
        static public bool Find(ref int DriverID, int PersonID,
            ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select * from Drivers where 
PersonID  = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFind = true;
                    DriverID = (int)reader["DriverID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
            dtAccess.WriteExceptionOnEventViewer("Failed Loading Driver Info by Person ID"+ ex);
            }
            finally
            {
                connection.Close();
            }
            return IsFind;
        }
        public static int Add(int PersonID,
    int CreatedByUserID,DateTime CreatedDate)
        {
            int NewID = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Insert into  Drivers  
(PersonID,CreatedByUserID,CreatedDate)
values(@PersonID,@CreatedByUserID,@CreatedDate);
Select Scope_Identity();";

  SqlCommand command = new SqlCommand(query, connection);
command.Parameters.AddWithValue("@PersonID",PersonID);
command.Parameters.AddWithValue("@CreatedDate",CreatedDate);
command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
  try {
        connection.Open();
                object res = command.ExecuteScalar();
                if (res!=null)
                {
                    NewID = Convert.ToInt32(res);
                }
      }catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Adding Driver Info" + ex);

            }
            finally
            {
                connection.Close();
            }
            return NewID;
        
        }
        public static bool Update(int DriverID, int PersonID,
        int CreatedByUserID, DateTime CreatedDate)
        {
            int Affected = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Update Drivers  
Set PersonID = @PersonID,CreatedByUserID = @CreatedByUserID,CreatedDate = @CreatedDate
Where DriverID  = @DriverID ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                Affected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Updating Driver Info" + ex);

            }
            finally
            {
                connection.Close();
            }
            return (Affected > -1);
        }
        public static bool Delete(int DriverID)
        {
            int Affected = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Delete from Drivers  
Where DriverID  = @DriverID ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            
            try
            {
                connection.Open();
                Affected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Deleting Driver Info " + ex);

            }
            finally
            {
                connection.Close();
            }
            return (Affected > -1);
        }
        //PersonID
        public static int GetDriverID(int PersonID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select DriverID from Drivers  
            Where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result!=null)
                {
                    ID = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Getting  Driver ID" + ex);

            }
            finally
            {
                connection.Close();
            }
            return (ID);
        }
        public static bool Exist(int PersonID)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select find = 'yes' from Drivers  
Where DriverID  = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFind = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Existing  Driver ID " + ex);

            }
            finally
            {
                connection.Close();
            }
            return (IsFind);
        }
        //PersonID
        public static bool IsPersonIDExist(int PersonID)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select find = 'yes' from Drivers  
Where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFind = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed checking  Person ID followed by Driver  " + ex);

            }
            finally
            {
                connection.Close();
            }
            return (IsFind);
        }
        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();
            string query = "select * from Drivers_View;";
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
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
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Loading Driver List" + ex);

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

    } //DriverID  = @DriverID";
}

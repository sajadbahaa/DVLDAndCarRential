using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvlcDataLayer
{//select * from DetainedLicenses
    public class dtDetained
    {
    public static bool Find(
     int DetainID, ref int LicenseID, ref DateTime DetainDate,
    ref  decimal FineFees,ref  int CreatedByUserID,ref  bool IsReleased
     ,ref DateTime ReleaseDate, ref int ReleasedByUserID,
    ref  int ReleaseApplicationID
        )
        {
            bool IsFind = false;
         SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"select * from  DetainedLicenses
Where DetainID = @DetainID";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFind = true;
                    LicenseID = (int)reader["LicenseID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = (decimal)reader["FineFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];

                    if (reader["ReleaseDate"]==System.DBNull.Value)
                    {
                        ReleaseDate = DateTime.MaxValue;
                    }
                    else
                    {
                        ReleaseDate = (DateTime)reader["ReleaseDate"];

                    }
                    if (reader["ReleasedByUserID"] == System.DBNull.Value)
                        ReleasedByUserID = -1;
                    else
                    ReleasedByUserID =(int) reader["ReleasedByUserID"];
                    if (reader["ReleaseDate"] == System.DBNull.Value)
                        ReleaseApplicationID = -1;
                    else
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Loading Detain Info by DetainID" + ex);
            }
            finally
            {
                connection.Close();
            }
            return IsFind;
        }
        public static bool GetDetainedLicenseInfoByLicenseID(int LicenseID,
              ref int DetainID, ref DateTime DetainDate,
              ref decimal FineFees, ref int CreatedByUserID,
              ref bool IsReleased, ref DateTime ReleaseDate,
              ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(dtAccess.Connection);

            string query = "SELECT top 1 * FROM DetainedLicenses WHERE LicenseID = @LicenseID order by DetainID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    DetainID = (int)reader["DetainID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = Convert.ToDecimal(reader["FineFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    IsReleased = (bool)reader["IsReleased"];

                    if (reader["ReleaseDate"] == DBNull.Value)

                        ReleaseDate = DateTime.MaxValue;
                    else
                        ReleaseDate = (DateTime)reader["ReleaseDate"];


                    if (reader["ReleasedByUserID"] == DBNull.Value)

                        ReleasedByUserID = -1;
                    else
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];

                    if (reader["ReleaseApplicationID"] == DBNull.Value)

                        ReleaseApplicationID = -1;
                    else
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                dtAccess.WriteExceptionOnEventViewer("Failed Loading Detain Info by LicenseID" + ex);

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
     
        public static int Add(
        int LicenseID, DateTime DetainDate,
    decimal FineFees, int CreatedByUserID
       )
        {
            int NewID = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Insert into DetainedLicenses
(LicenseID,
DetainDate,
FineFees,
CreatedByUserID,
IsReleased
)

Values(
@LicenseID,
@DetainDate,
@FineFees,
@CreatedByUserID,
0);
Select Scope_Identity();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
     command.Parameters.AddWithValue("@CreatedByUserID",CreatedByUserID);
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res!=null) {
                    NewID = Convert.ToInt32(res);
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Adding Detain Info " + ex);

            }
            finally
            {
                connection.Close();
            }
            return NewID;

        }
        public static bool UpdateDetainedLicense(int DetainID,
            int LicenseID, DateTime DetainDate,
            decimal FineFees, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);

            string query = @"UPDATE dbo.DetainedLicenses
                              SET LicenseID = @LicenseID, 
                              DetainDate = @DetainDate, 
                              FineFees = @FineFees,
                              CreatedByUserID = @CreatedByUserID,

                              WHERE DetainID=@DetainID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainedLicenseID", DetainID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                dtAccess.WriteExceptionOnEventViewer("Failed Updating Detain Info" + ex);

            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static bool ReleaseDetained(int DetainID,int UserID,int ApplicationID)
        {
            int Affect = 0;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Update DetainedLicenses
set IsReleased = 1,ReleasedByUserID = @UserID
,ReleaseDate = @Date,
ReleaseApplicationID = @ApplicationID
		where DetainID = @DetainID;";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@UserID",UserID);
            command.Parameters.AddWithValue("@Date",DateTime.Now);
            command.Parameters.AddWithValue("@ApplicationID",ApplicationID);
            command.Parameters.AddWithValue("@DetainID", DetainID);
            try
            {
                connection.Open();
                Affect = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed ReleaseDetained" + ex);
            }
            finally
            {
                connection.Close();
            }
            return (Affect>0);
        }
        public static bool IsLicenseDetained(int LicenseID)
        {
            bool IsDetained = false;

            SqlConnection connection = new SqlConnection(dtAccess.Connection);

            string query = @"select IsDetained=1 
                            from detainedLicenses 
                            where 
                            LicenseID=@LicenseID 
                            and IsReleased=0;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsDetained = Convert.ToBoolean(result);
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                dtAccess.WriteExceptionOnEventViewer("Failed Check  IsLicenseDetained" + ex);

            }

            finally
            {
                connection.Close();
            }


            return IsDetained;
        }

        public static DataTable GetAllDetainedLicenses()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(dtAccess.Connection);

            string query = "select * from detainedLicenses_View order by IsReleased ,DetainID;";

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
                dtAccess.WriteExceptionOnEventViewer("Failed Loading  LicenseDetained List" + ex);

                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

    }
}

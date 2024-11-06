using DvlcDataLayer;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace clsPeople
{
    public  class dtInternationalLicense
    {
        static public int GetInternationalIDByLocalLicneseID(int IssuedUsingLocalLicenseID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query
  = @"Select InternationalLicenseID from InternationalLicenses where 
IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID";

        SqlCommand command = new SqlCommand(query, connection);
command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID",IssuedUsingLocalLicenseID);
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
                dtAccess.WriteExceptionOnEventViewer("Failed Getting International License ID By Local License ID" + ex);
            }
            finally
            {
                connection.Close();
            }
            return ID;
        }
        public static bool
        Find(int InternationalLicenseID, ref int ApplicationID,
        ref int DriverID,ref int IssuedUsingLocalLicenseID,
        ref DateTime IssueDate,ref DateTime ExpirationDate,
        ref bool IsActive,ref int CreatedByUserID
        )
        {
            bool IsFind = false;
  SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query 
  = @"Select * from InternationalLicenses where InternationalLicenseID = @InternationalLicenseID";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFind = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Loading International License  By International License ID " + ex);

            }
            finally
            {
                connection.Close();
            }
            return IsFind;
        }
        public static int
        Add(int ApplicationID,
        int DriverID, int IssuedUsingLocalLicenseID,
         DateTime IssueDate, DateTime ExpirationDate,
         bool IsActive, int CreatedByUserID
        )
        {
            int NewID = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query
  = @" Update InternationalLicenses
set IsActive = 0
where DriverID = @DriverID;

Insert into InternationalLicenses (ApplicationID,DriverID,IssuedUsingLocalLicenseID,
IssueDate,ExpirationDate,IsActive,CreatedByUserID)
values(@ApplicationID,@DriverID,@IssuedUsingLocalLicenseID,
@IssueDate,@ExpirationDate,@IsActive,@CreatedByUserID);
Select Scope_Identity();";
            SqlCommand command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue("@ApplicationID",ApplicationID);
    command.Parameters.AddWithValue("@DriverID",DriverID);
    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
    command.Parameters.AddWithValue("@IssueDate", IssueDate);
    command.Parameters.AddWithValue("@ExpirationDate",ExpirationDate);
    command.Parameters.AddWithValue("@IsActive",IsActive);
    command.Parameters.AddWithValue("@CreatedByUserID",CreatedByUserID);

            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res!=null)
                {
                    NewID = Convert.ToInt32(res);
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Adding International License" + ex);

            }
            finally
            {
                connection.Close();
            }
            return NewID;
        }
        public static bool
        Update(int InternationalLicenseID, int ApplicationID,
        int DriverID, int IssuedUsingLocalLicenseID,
         DateTime IssueDate, DateTime ExpirationDate,
         bool IsActive, int CreatedByUserID
        )
        {
            int Affected = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query
  = @"Update InternationalLicenses
Set ApplicationID = @ApplicationID,DriverID = @DriverID,
 IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
 IssueDate = @IssueDate,ExpirationDate = @ExpirationDate,
 IsActive = @IsActive,CreatedByUserID = @CreatedByUserID
Where InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            
            try
            {
                connection.Open();
                Affected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Updating International License" + ex);
            }
            finally
            {
                connection.Close();
            }
            return (Affected>-1);

        }
        public static bool Delete(int InternationalLicenseID)
        {
            int Affected = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query 
  = @"Delete from InternationalLicenses Where InternationalLicenseID = @InternationalLicenseID";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@InternationalLicenseID",InternationalLicenseID);
            try
            {
                connection.Open();

                Affected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Deleting International License" + ex);

            }
            finally
            {
                connection.Close();
            }
            return (Affected > -1);
        }

        public static bool Exist(int InternationalLicenseID)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query
    = @"Select find ='yes' from InternationalLicenses Where InternationalLicenseID = @InternationalLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFind = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Existing International License" + ex);

            }
            finally
            {
                connection.Close();
            }
            return (IsFind);
        }
       public static DataTable GetAllInternationalLicenseByDriverID(int DriverID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query
    = @"Select InternationalLicenseID, ApplicationID,
		                IssuedUsingLocalLicenseID , IssueDate, 
                        ExpirationDate, IsActive
from  InternationalLicenses
where DriverID = @DriverID
order by ExpirationDate desc";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
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
                dtAccess.WriteExceptionOnEventViewer("Failed Getting International License List" + ex);

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static DataTable GetAllInternationalLicense()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query
    = @"Select * from InternationalLicenses ";
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
                dtAccess.WriteExceptionOnEventViewer("Failed Getting International License List" + ex);

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
  // tommorw by permaission Allah we will complete.
        static public int GetAnActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            int InternationalLicenseID = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection); 
            string query = @"SELECT Top 1 InternationalLicenseID
                            FROM InternationalLicenses 
                            where
DriverID=@DriverID  and IsActive = 1
Order by ExpirationDate Desc;
";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    InternationalLicenseID = insertedID;
                }
            }

            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Getting AnActiveInternationalLicenseID By DriverID" + ex);

            }

            finally
            {
                connection.Close();
            }


            return InternationalLicenseID;

        }

    }




}

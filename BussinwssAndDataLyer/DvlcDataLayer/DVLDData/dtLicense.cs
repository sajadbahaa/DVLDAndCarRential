using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvlcDataLayer
{
    public class dtLicense
    {
    public static bool Find(int LicenseID,ref int ApplicationID,
     ref  int DriverID,ref  int LicenseClass,ref  DateTime IssueDate,
    ref DateTime ExpirationDate,ref string Notes,ref decimal PaidFees,
      ref bool IsActive,ref Byte IssueReason,ref int CreatedByUserID)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select * from Licenses where LicenseID = @LicenseID";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@LicenseID",LicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFind = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    if (reader["Notes"]==System.DBNull.Value)
                    {
                        Notes = "";

                    }
                    else
                    {
                        Notes = (string)reader["Notes"];
                    }
                    PaidFees = (Decimal)reader["PaidFees"];
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (Byte)reader["IssueReason"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Loading License Info By License ID" + ex);

            }
            finally
            {
                connection.Close();
            }
            return IsFind;
        }
        public static bool Find(ref int LicenseID,  int ApplicationID,
     ref int DriverID, ref int LicenseClass, ref DateTime IssueDate,
    ref DateTime ExpirationDate, ref string Notes, ref decimal PaidFees,
      ref bool IsActive, ref Byte IssueReason, ref int CreatedByUserID)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select * from Licenses where ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
               while (reader.Read())
                {
                    IsFind = true;
                    LicenseID = (int)reader["LicenseID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    if (reader["Notes"] == System.DBNull.Value)
                    {
                        Notes = "";
                    }
                    else
                    {
                        Notes = (string)reader["Notes"];
                    }
                    PaidFees = (Decimal)reader["PaidFees"];
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (Byte)reader["IssueReason"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                reader.Close();
            }catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Loading License Info By App ID" + ex);

            }
            finally
            {
               connection.Close();
            }
            return IsFind;
        }
        public static int Add(int ApplicationID,
 int DriverID, int LicenseClass, DateTime IssueDate,
 DateTime ExpirationDate, string Notes, decimal PaidFees,
 bool IsActive, Byte IssueReason, int CreatedByUserID
  )
        {
            int NewID = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Insert into Licenses (
ApplicationID,DriverID,LicenseClass,IssueDate,
  ExpirationDate,Notes,PaidFees,
 IsActive,IssueReason,CreatedByUserID
)
values(
@ApplicationID,@DriverID,@LicenseClass,@IssueDate,
  @ExpirationDate,@Notes,@PaidFees,
 @IsActive,@IssueReason,@CreatedByUserID
);
Select Scope_Identity();";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@DriverID",DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate",IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            if (Notes=="")
            {
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
            command.Parameters.AddWithValue("@PaidFees",PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
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
              dtAccess.WriteExceptionOnEventViewer("Failed Adding License Info" + ex);
            }
            finally
            {
                connection.Close();
            }
            return NewID;
        
        }
        public static bool Update(int LicenseID, int ApplicationID,
         int DriverID, int LicenseClass, DateTime IssueDate,
         DateTime ExpirationDate, string Notes, decimal PaidFees,
         bool IsActive, Byte IssueReason, int CreatedByUserID
          )
        {
            int Affect = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Update Licenses 
set ApplicationID = @ApplicationID ,DriverID = @DriverID
,LicenseClass = @LicenseClass,IssueDate = @IssueDate,
  ExpirationDate = @ExpirationDate,Notes = @Notes,PaidFees = @PaidFees,
 IsActive = @IsActive,IssueReason = @IssueReason,CreatedByUserID = @CreatedByUserID
 Where LicenseID =@LicenseID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            if (Notes == "")
            {
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            try
            {
                connection.Open();
                Affect = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Updating License Info " + ex);

            }
            finally
            {
                connection.Close();
            }
            return (Affect>-1);
        }
        public static bool Delete(int LicenseID)
        {
            int Affect = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Delete from Licenses Where LicenseID =@LicenseID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                connection.Open();
                Affect = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Deleting License Info " + ex);

            }
            finally
            {
                connection.Close();
            }
            return (Affect > -1);
        }
        public static bool Exist(int LicenseID)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select Find = 'yes' from Licenses Where LicenseID =@LicenseID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFind = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Existing License Info  by license ID" + ex);

            }
            finally
            {
                connection.Close();
            }
            return (IsFind);
        }
        //command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

        public static DataTable GetAllLicensesByDriverID(int DriverID)
        {
            DataTable dt = new DataTable(); 
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"select Licenses.LicenseID,
ApplicationID,
LicenseClasses.ClassName, Licenses.IssueDate, 
Licenses.ExpirationDate,
Licenses.IsActive
from Licenses
inner join LicenseClasses on 
Licenses.LicenseClass  = LicenseClasses.LicenseClassID
where DriverID = @DriverID
order by ExpirationDate desc
;";
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
                dtAccess.WriteExceptionOnEventViewer("Failed Loading  License list " + ex);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
       public static int GetLicenseActiveByPersonID(int PersonID,int ClassLicensID)
        {
            int LicenseID = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @" 
select Licenses.LicenseID
from Licenses
inner join Drivers on Licenses.DriverID = Drivers.DriverID
where Drivers.PersonID = @PersonID
and Licenses.IsActive =1 
and Licenses.LicenseClass = @LicenseClass";
    SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClass",ClassLicensID);
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res!=null&&int.TryParse(res.ToString(),out int curLicenseID))
                {
                    LicenseID = curLicenseID;
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Getting License ID Active " + ex);

            }
            finally
            {
                connection.Close();
            }

            return (LicenseID);
        } 
     public static int DeActivateLicense(int LicenseID)
        {
            int Affect = 0;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"
Update Licenses 
Set IsActive = 0
where LicenseID = @LicenseID;
";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@LicenseID",LicenseID);
            try
            {
                connection.Open();
                Affect = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Applying DeActivateLicense" + ex);

            }
            finally
            {
                connection.Close();
            }
            return Affect;
        }
    public static int GetLicenseActiveByDriverID(int DriverID)
        {
            int ID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"select LicenseID from Licenses
where DriverID  = @ID and IsActive = 1;";
                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@ID",DriverID);
                        object res = command.ExecuteScalar();
                        ID = res != null ? int.Parse(res.ToString()):-1;
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Getting License ID Active by DriverID "+ex);
            }
            return ID;
        }
    }
    
}

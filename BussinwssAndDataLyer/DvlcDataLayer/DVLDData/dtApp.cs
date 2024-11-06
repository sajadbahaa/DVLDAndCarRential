using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DvlcDataLayer
{
    public class dtApp
    {

    public static bool Find(int ApplicationID,ref int ApplicantPersonID, ref DateTime ApplicationDate,
        ref int ApplicationTypeID,ref byte ApplicationStatus,ref DateTime LastStatusDate,ref decimal PaidFees,
        ref int CreatedByUserID)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select * from Applications Where ApplicationID =  @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFind = true;
                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = (byte)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                }
                reader.Close();
            }catch(Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Loading Application by application ID " + ex);

            }
            finally
            {
                connection.Close();
            }
            return IsFind;
        }
public static int GetApplicationActiveForClassLicense
       (int ApplicantPersonID,int ApplicationTypeID,int LicenseClassID)
        {
            int ApplicationID = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"
select Applications.ApplicationID from Applications
inner join LocalDrivingLicenseApplications on
Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
where  ApplicantPersonID  = @ApplicantPersonID 
and ApplicationTypeID = @ApplicationTypeID 
and Applications.ApplicationStatus = 1 and 
LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID;";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
command.Parameters.AddWithValue("@ApplicationTypeID",ApplicationTypeID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
            connection.Open();
                object res = command.ExecuteScalar();
                if (res!=null&&int.TryParse(res.ToString(),out int ActiveID))
                {
                    ApplicationID = ActiveID;
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Getting An active application ID " + ex);

            }
            finally
            {
                connection.Close();
            }
            return ApplicationID;
        }
        public static int GetApplicationIDByPersonID(int ApplicantPersonID,DateTime ApplicationDate)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = 
                @"Select ApplicationID from Applications Where ApplicantPersonID = @ApplicantPersonID and ApplicationDate = @ApplicationDate";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
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
                dtAccess.WriteExceptionOnEventViewer("Failed Finding Person ID for application " + ex);

            }
            finally
            {
                connection.Close();
            }
            return ID;
        }
           
        public static int Add(int ApplicantPersonID, DateTime ApplicationDate,
        int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees,
        int CreatedByUserID)
        {
            int NewID = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Insert Into Applications (ApplicantPersonID,ApplicationDate,ApplicationTypeID,
             ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID)
             Values(@ApplicantPersonID,@ApplicationDate,@ApplicationTypeID,
             @ApplicationStatus,@LastStatusDate,@PaidFees,@CreatedByUserID);
          Select Scope_Identity();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID",ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees",PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID",CreatedByUserID);

            //command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res!=null&&int.TryParse(res.ToString(),out int ID))
                {
                    NewID = ID;
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Adding Application Info" + ex);

            }
            finally
            {
                connection.Close();
            }
            return NewID;
        }
        public static bool Update(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
        int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees,
        int CreatedByUserID)
        {
            int Affect = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Update Applications 
         Set ApplicantPersonID = @ApplicantPersonID,ApplicationDate = @ApplicationDate,
CreatedByUserID = @CreatedByUserID,
PaidFees = @PaidFees,LastStatusDate = @LastStatusDate,
ApplicationStatus = @ApplicationStatus,ApplicationTypeID = @ApplicationTypeID
    Where ApplicationID =  @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                Affect = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed updating Application Info" + ex);

            }
            finally
            {
                connection.Close();
            }
            return (Affect>-1);
        }
       public static bool UpdateStatus(int ApplicationID,byte NewStatus)
        {
            int Affect = 0;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Update Applications
set ApplicationStatus = @NewStatus, 
LastStatusDate = @LastStatusDate
where ApplicationID =  @ApplicationID";
    SqlCommand command = new SqlCommand(query,connection);
    command.Parameters.AddWithValue("@LastStatusDate",DateTime.Now);
    command.Parameters.AddWithValue("@ApplicationID",ApplicationID);
            command.Parameters.AddWithValue("@NewStatus", NewStatus); 
        try 
            {
                connection.Open();
                Affect = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Updating Application Status" + ex);

            }
            finally
            {
                connection.Close();
            }
            return (Affect>0);
        }
        public static bool Delete(int ApplicationID)
        {
            int Affect = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Delete from Applications 
    Where ApplicationID =  @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
           
            try
            {
                connection.Open();
                Affect = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Deleting Application" + ex);

            }
            finally
            {
                connection.Close();
            }
            return (Affect > -1);

        }
        //int ApplicationTypeID
        //        byte ApplicationStatus,int ApplicationID
        public static bool Exist(int ApplicantPersonID, byte ApplicationStatus)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select find = 'yes' from Applications 
    Where ApplicantPersonID =  @ApplicantPersonID And 
ApplicationStatus = @ApplicationStatus";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFind = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed existing Application ID" + ex);

            }
            finally
            {
                connection.Close();
            }
            return (IsFind);
        }

     
        public static DataTable AllApplications ()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select * from Applications";
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
                dtAccess.WriteExceptionOnEventViewer("Failed Getting Application List" + ex);

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static int GetActiveApplicationID(int PersonID, int ApplicationTypeID)
        {
            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(dtAccess.Connection);

            string query = "SELECT ActiveApplicationID=ApplicationID FROM Applications WHERE ApplicantPersonID = @ApplicantPersonID and ApplicationTypeID=@ApplicationTypeID and ApplicationStatus=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    ActiveApplicationID = AppID;
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Get ActiveApplicationID" + ex);
            }
            finally
            {
                connection.Close();
            }

            return ActiveApplicationID;
        }
        public static bool DoesPersonHasActiveApplication(int PersonID,int ApplicationTypeID)
        {
            return (GetActiveApplicationID(PersonID,ApplicationTypeID)!=-1);
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DvlcDataLayer
{
    public  class dtLocalDrivingLicense
    {
    public static bool Find(int LocalDrivingLicenseApplicationID, ref int ApplicationID,ref int LicenseClassID)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select * from LocalDrivingLicenseApplications 
 where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query,connection);
    
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFind = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }
                reader.Close();
            }
            catch (Exception ex )
            {
                dtAccess.WriteExceptionOnEventViewer("Failed loading L.Driving.lice by l.D.l ID" + ex);

            }
            finally
            {
                connection.Close();
            }
            return IsFind;
        }
        public static bool Find(ref  int LocalDrivingLicenseApplicationID, int ApplicationID, ref int LicenseClassID)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select * from LocalDrivingLicenseApplications 
 where ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFind = true;
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }
                reader.Close();
            
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed loading L.Driving.lice by App ID" + ex);

            }
            finally
            {
                connection.Close();
            }
            return IsFind;
        }

        public static  int Add(int ApplicationID, int LicenseClassID)
        {
            int NewID = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Insert into LocalDrivingLicenseApplications(ApplicationID,LicenseClassID)
            Values(@ApplicationID,@LicenseClassID);
            Select Scope_Identity();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID",ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID",LicenseClassID);
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res!=null&&int.TryParse(res.ToString(),out int NewLocalLicensID))
                {
                    NewID = NewLocalLicensID;
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Adding L.Driving.lice " + ex);

            }
            finally
            {
                connection.Close();
            }
            return NewID;
        }
        public static bool Update(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            int Affect =-1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Update LocalDrivingLicenseApplications
Set ApplicationID = @ApplicationID,LicenseClassID = @LicenseClassID
      Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@ApplicationID" ,ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID",LicenseClassID);
            try
            {
                connection.Open();
                Affect = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Updating L.Driving.lice by l.D.l ID" + ex);

            }
            finally
            {
                connection.Close();
            }
            return (Affect>-1);
        }
        static public bool Delete( int LocalDrivingLicenseApplicationID)
        {
            int Affect = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Delete from LocalDrivingLicenseApplications Where
               LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                Affect = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Deleting L.Driving.lice by l.D.l ID" + ex);
            }
            finally
            {
                connection.Close();
            }
            return (Affect > -1);
        }
        public static bool Exist( int LocalDrivingLicenseApplicationID)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select find = 'yes' from LocalDrivingLicenseApplications Where
               LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFind = reader.HasRows;
                reader.Close();
            }

            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Existing L.Driving.lice by l.D.l ID" + ex);

            }
            finally
            {
            connection.Close();
            }
            return IsFind;
        }
        //command.Parameters.AddWithValue("@LicenseClassID",LicenseClassID);
        public static bool IsClassLicenceExist(int LicenseClassID)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select find = 'yes' from LocalDrivingLicenseApplications Where
               LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFind = reader.HasRows;
                reader.Close();
            }

            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed existing class .lic by l.D.l ID" + ex);

            }
            finally
            {
                connection.Close();
            }
            return IsFind;
        }
        public static DataTable AllLocalDrivingLicens()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"select * from LocalDrivingLicenseApplications_View";
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
                dtAccess.WriteExceptionOnEventViewer("Failed loading All L.Driving.lice List" + ex);

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
      
        public static int GetLocalDrivingLicenseID(int ApplicationID, int LicenseClassID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select LocalDrivingLicenseApplicationID
             from LocalDrivingLicenseApplications Where
              ApplicationID = @ApplicationID and LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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
                dtAccess.WriteExceptionOnEventViewer("Failed getting  l.D.l ID By AppID and Class LicenseID " + ex);
            }
            finally
            {
                connection.Close();
            }
            return ID;
        }
        
       

       public static bool DoesTestPass(int LocalDrivingLicenseID,int TestTypeID)
        {
            bool Result = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select top 1 TestResult
from Tests
inner join TestAppointments 
on Tests.TestAppointmentID = TestAppointments.TestAppointmentID
where TestTypeID = @TestTypeID
and TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
order by TestAppointments.TestAppointmentID desc;
";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res!=null&&bool.TryParse(res.ToString(),out bool FinalResutl))
                {
                    Result = FinalResutl;
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Applying Method DoesTestPass" + ex);

            }
            finally
            {
                connection.Close();
            }
            return Result;
        }
    public static bool IsThereAnActiveSchedualTest
(int LocalDrivingLicenseID,int TestTypeID)
        {
            bool Result = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query =
                @"Select  Find = 1 from TestAppointments

inner join LocalDrivingLicenseApplications on 
TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
where TestAppointments.TestTypeID = @TestTypeID
and IsLocked = 0 
and TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseID
Order By TestAppointments.TestAppointmentID desc";
            SqlCommand command = new SqlCommand(query,connection);
   command.Parameters.AddWithValue("@LocalDrivingLicenseID",LocalDrivingLicenseID);
            command.Parameters.AddWithValue("@TestTypeID",TestTypeID);
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res!=null)
                {
                    Result = Convert.ToBoolean(res);
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Return Value(IsThereAnActiveSchedualTest) value" + ex);

            }
            finally
            {
                connection.Close();
            }
            return Result;
        }
 public static bool DoesAttendTestType(int LocalDrivingLicenseID,int TestTypeID)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"select top 1  find = 1 from LocalDrivingLicenseApplications
inner join TestAppointments on LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
inner join Tests on TestAppointments.TestAppointmentID = Tests.TestAppointmentID
where (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID  = @LocalDrivingLicenseApplicationID
And TestAppointments.TestTypeID = @TestTypeID)
Order by TestAppointments.TestAppointmentID desc
;";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res != null )
                {
                    IsFind = Convert.ToBoolean(res);
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Applying Method (DoesAttendTestType)" + ex);

            }
            finally
            {
                connection.Close();
            }
            return IsFind;
        }
    public static byte TotalTrailsPerTest(int LocalDrivingLicenseID, int TestTypeID)
        {
            byte TotalTrails = 0;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"select TotalTrailsPerTest = Count(TestID)
from LocalDrivingLicenseApplications
inner join TestAppointments on LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
inner join Tests on TestAppointments.TestAppointmentID = Tests.TestAppointmentID
where (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID  = @LocalDrivingLicenseApplicationID
And TestAppointments.TestTypeID = @TestTypeID)";
SqlCommand command = new SqlCommand(query, connection);
command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseID);
command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res != null && Byte.TryParse(res.ToString(), out byte result))
                {
                    TotalTrails = result;
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Applying Method (TotalTrailsPerTest)" + ex);

            }
            finally
            {
                connection.Close();
            }
            return TotalTrails;
        }
    }
}

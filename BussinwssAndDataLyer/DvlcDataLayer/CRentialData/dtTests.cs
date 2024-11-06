using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvlcDataLayer
{
    public class dtTests
    {
    public static bool Find(int TestID,ref int TestAppointmentID,
        ref bool TestResult,ref string Notes, ref int CreatedByUserID)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select * from Tests Where TestID = @TestID";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@TestID",TestID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFind = true;
                    TestAppointmentID = (int)reader["TestAppointmentID "];
                    TestResult = (bool)reader["TestResult"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    if (reader["Notes"]==System.DBNull.Value)
                    {
                        Notes = "";
                    }
                    else
                    {
                        Notes = (string)reader["Notes"];
                    }

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Finding  test Data By TestID" + ex);

            }
            finally
            {
                connection.Close();
            }
            return IsFind;
        }
        public static bool Find(ref int TestID, int TestAppointmentID,
        ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select * from Tests Where
 TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFind = true;
                    TestID = (int)reader["TestID"];
                    TestResult = (bool)reader["TestResult"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    if (reader["Notes"] == System.DBNull.Value)
                    {
                        Notes = "";
                    }
                    else
                    {
                        Notes = (string)reader["Notes"];
                    }

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Finding  test Data By TestAppointment" + ex);

            }
            finally
            {
                connection.Close();
            }
            return IsFind;
        }
        public static int Add(int TestAppointmentID,
         bool TestResult, string Notes, int CreatedByUserID)
        {
            int Affected = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Insert into Tests (TestAppointmentID,
         TestResult, Notes, CreatedByUserID)
values (@TestAppointmentID,@TestResult,@Notes,@CreatedByUserID);

Update TestAppointments
set IsLocked = 1
 where TestAppointmentID = @TestAppointmentID;

Select Scope_Identity();";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            if (Notes=="")
            {
                command.Parameters.AddWithValue("@Notes",System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
            command.Parameters.AddWithValue("@CreatedByUserID",CreatedByUserID);

            try
            {
                connection.Open();
                Affected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Adding New test " + ex);

            }
            finally
            {
                connection.Close();
            }
            return (Affected);
        }
        public static bool Update(int TestID,  int TestAppointmentID,
 bool TestResult, string Notes,  int CreatedByUserID)
        {
            int Affected = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Update Tests
set TestAppointmentID = @TestAppointmentID,TestResult = @TestResult , 
Notes = @Notes,CreatedByUserID = @CreatedByUserID
Where TestID = @TestID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            if (Notes == "")
            {
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();
                Affected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Updating  test " + ex);

            }
            finally
            {
                connection.Close();
            }
            return (Affected>-1);
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseID)
        {
            byte TestPassed = 0;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select PassedTest = Count(TestTypeID) from Tests
inner join TestAppointments on 
Tests.TestAppointmentID = TestAppointments.TestAppointmentID
where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
and Tests.TestResult = 1;";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseID);
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res!=null&&byte.TryParse(res.ToString(),out byte PassTest))
                {
                    TestPassed = PassTest;
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed finding Number tests By Local Driving License ID " + ex);

            }
            finally
            {
                connection.Close();
            }
            return TestPassed;
        }
        public static bool Delete(int TestID)
        {
            int Affected = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Delete from Tests
Where TestID = @TestID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID",TestID);

            try
            {
                connection.Open();
                Affected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Deleting  test " + ex);

            }
            finally
            {
                connection.Close();
            }
            return (Affected > -1);
        }
        public static DataTable GetAllTests()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = "Select * from Tests";
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
                dtAccess.WriteExceptionOnEventViewer("Failed Getting  tests List" + ex);

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        
    public static bool 
 GetLastTestPerTestType(int PersonID,int ClassLicenseID,int TestTypeID,
  ref int TestID,ref int TestAppointmentID,ref  bool TestResult, ref string Notes,
  ref int CreatedByUserID)
        {
            bool IsFind = false;
    SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"select top 1 TestID,Tests.TestAppointmentID
,Notes,Tests.CreatedByUserID,TestResult
from  LocalDrivingLicenseApplications
inner join TestAppointments on 
LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID 
= TestAppointments.LocalDrivingLicenseApplicationID
inner join Tests on TestAppointments.TestAppointmentID = Tests.TestAppointmentID
inner join Applications on LocalDrivingLicenseApplications.ApplicationID 
= Applications.ApplicationID

where Applications.ApplicantPersonID = @PersonID 
and  TestAppointments.TestTypeID = @TestTypeID 
and LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
Order by TestAppointments.TestAppointmentID desc";
SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@TestTypeID",TestTypeID);
            command.Parameters.AddWithValue("@LicenseClassID", ClassLicenseID);
            try
            {
            connection.Open();
                SqlDataReader reader = command.ExecuteReader(); 
                if (reader.Read())
                {
                    IsFind = true;
                    TestID = (int)reader["TestID"];
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    if (reader["Notes"] == System.DBNull.Value)
                    {
                        Notes = "";
                    }
                    else
                    {
                        Notes = (string)reader["Notes"];
                    }

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Getting Last Test per test type " + ex);
            }
            finally
            {
                connection.Close();
            }
            return IsFind;
        }
    }
}

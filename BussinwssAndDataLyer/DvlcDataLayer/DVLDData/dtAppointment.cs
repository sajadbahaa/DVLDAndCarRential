using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DvlcDataLayer
{
    public class dtAppointment
    {
        public static bool Find(int TestAppointmentID,ref  int TestTypeID,
  ref int LocalDrivingLicenseApplicationID,ref DateTime AppointmentDate,
  ref  Decimal PaidFees,ref int CreatedByUserID,ref bool IsLocked,
  ref int ReTakeTestID)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select * from TestAppointments
Where TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query,connection);
command.Parameters.AddWithValue("@TestAppointmentID",TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFind = true;
                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];
                    if (reader["RetakeTestApplicationID"]==DBNull.Value)
                    {
                        ReTakeTestID = -1;
                    }
                    else
                    {
                        ReTakeTestID = (int)reader["RetakeTestApplicationID"];
                    }
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Loading Appointment Info by AppointmentID" + ex);

            }
            finally
            {
                connection.Close();
            }
            return IsFind;
        }
        
        //TestTypeID LocalDrivingLicenseApplicationID
        
        public static int Add(int TestTypeID,
  int LocalDrivingLicenseApplicationID, DateTime AppointmentDate,
  Decimal PaidFees,  int CreatedByUserID, bool IsLocked,
  int RetakeTestApplicationID)
        {
            int NewAppointmentID = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Insert Into TestAppointments
(TestTypeID,LocalDrivingLicenseApplicationID, AppointmentDate,
  PaidFees, CreatedByUserID,IsLocked,RetakeTestApplicationID)
values(@TestTypeID,@LocalDrivingLicenseApplicationID, @AppointmentDate,
  @PaidFees, @CreatedByUserID,@IsLocked,@RetakeTestApplicationID);
select Scope_Identity();";

  SqlCommand command = new SqlCommand(query, connection);
command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
command.Parameters.AddWithValue("@PaidFees", PaidFees);
command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
command.Parameters.AddWithValue("@IsLocked", IsLocked);
if (RetakeTestApplicationID==-1)
{
    command.Parameters.AddWithValue("@RetakeTestApplicationID", System.DBNull.Value);
}
else { 
command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
}
            try
            {
                connection.Open();
         object result = command.ExecuteScalar();
                if (result != null)
                {
                    NewAppointmentID = Convert.ToInt32( result);
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Adding Appointment Info " + ex);

            }
            finally
            {
                connection.Close();
            }
            return NewAppointmentID;
        }
        public static bool Update(int TestAppointmentID, int TestTypeID,
  int LocalDrivingLicenseApplicationID, DateTime AppointmentDate,
  Decimal PaidFees, int CreatedByUserID, bool IsLocked,int RetakeTestApplicationID)
        {

            int Affected = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Update TestAppointments
Set  TestTypeID = @TestTypeID, LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
 AppointmentDate = @AppointmentDate, PaidFees = @PaidFees, CreatedByUserID = @CreatedByUserID,
 IsLocked = @IsLocked ,RetakeTestApplicationID = @RetakeTestApplicationID
Where TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID",TestAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            if (RetakeTestApplicationID == -1)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            }

            try
            {
                connection.Open();
                Affected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Updating Appointment Info " + ex);

            }
            finally
            {
                connection.Close();
            }
            return (Affected>-1);
        }
        public static bool ExistByLocalDrivingLicenseID(int LocalDrivingLicenseApplicationID)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @" Select find = 'yes' from  TestAppointments where 
LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID ";
            SqlCommand command = new SqlCommand(query,connection);
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
                dtAccess.WriteExceptionOnEventViewer("Failed Existing  Appointment  by local License ID" + ex);

            }
            finally
            {
                connection.Close();
            }
            return IsFind;
        }
        public static bool Delete(int TestAppointmentID)
        {

            int Affected = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Delete from TestAppointments
Where TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                connection.Open();
                Affected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Deleting Appointment " + ex);

            }
            finally
            {
                connection.Close();
            }
            return (Affected > -1);
        }
        public static DataTable GetAllAppointments(int TestTypeID,int LocalDrivingLicenseApplicationID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select TestAppointmentID, AppointmentDate,
PaidFees, IsLocked
from TestAppointments
where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
and TestTypeID = @TestTypeID
order by TestAppointmentID desc";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
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
                dtAccess.WriteExceptionOnEventViewer("Failed Loading  Appointment List" + ex);

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static int GetTestID(int TestAppointmentID)
        {
            int TestID = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);

            string query = @"select TestID from Tests where TestAppointmentID=@TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
                }
            }

            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Existing  Appointment ID" + ex);

            }

            finally
            {
                connection.Close();
            }


            return TestID;

        }


    }

}

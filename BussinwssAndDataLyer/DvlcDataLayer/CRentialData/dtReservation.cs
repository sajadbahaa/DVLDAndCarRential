using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DvlcDataLayer
{
     public class dtReservation
    {
    public static int Add(int CustomerID,int VehicleID
,DateTime StartDate,DateTime EndDate
,StringBuilder PickUplocation,StringBuilder DropOflocation, decimal RentialPerDay,
decimal InitialTotalDueAmount,StringBuilder Notes
        ,int ApplicatoinID,int UserID 
        )
        {
            int ReservationID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"
INSERT INTO [dbo].[Reservations]
           (CustomerID
           ,VehicleID
           ,StartDate
           ,EndDate
           ,PickUplocation
           ,DropOflocation
           ,RentialPerDay
           ,InitialTotalDueAmount
           ,Notes
           ,ApplicationID
           ,UserID)
     VALUES
           (@CustomerID,@VehicleID,@StartDate,
@EndDate       ,
@PickUplocation,
@DropOflocation,
@RentialPerDay ,
@InitialTotalDueAmount,
@Notes,
@ApplicationID,
@UserID
);
select Scope_Identity();

Update Vehicles
set Status = 2
where VehicleID = @VehicleID;

Update Customers
set TakePersonalInfo = 0
where CustomerID = @CustomerID;";

                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID",CustomerID);
                        command.Parameters.AddWithValue("@VehicleID", VehicleID);
                        command.Parameters.AddWithValue("@StartDate",StartDate);
                        command.Parameters.AddWithValue("@EndDate",EndDate);
                        command.Parameters.AddWithValue("@PickUplocation",PickUplocation.ToString());
                        command.Parameters.AddWithValue("@RentialPerDay",RentialPerDay);
                        command.Parameters.AddWithValue("@DropOflocation", DropOflocation.ToString());
                        command.Parameters.AddWithValue("@InitialTotalDueAmount",InitialTotalDueAmount);
                        command.Parameters.AddWithValue("@Notes",Notes.ToString());
                        command.Parameters.AddWithValue("@ApplicationID", ApplicatoinID);
                        command.Parameters.AddWithValue("@UserID",UserID);
                        object res = command.ExecuteScalar();
                        ReservationID = res != null ? int.Parse(res.ToString()) : -1;
                    }

                    }
                
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Adding Reservation "+ex);
            }
            return ReservationID;
        }

     public static bool Find (int ReservationID,ref  int CustomerID,ref int VehicleID
,ref DateTime StartDate,ref DateTime EndDate
,ref StringBuilder PickUplocation,ref StringBuilder DropOflocation,ref decimal RentialPerDay,
ref decimal InitialTotalDueAmount,ref int InitialRentialDays,ref StringBuilder Notes
        ,ref int ApplicatoinID,ref int UserID)
        {
            bool IsFind = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"
SELECT * FROM [dbo].[Reservations]
where  [ReservationID] = @ID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", ReservationID);
                        using (SqlDataReader reader = command.ExecuteReader()) 
                        {
                            if (reader.Read())
                            {
                                IsFind = true;


                                CustomerID = (int)reader["CustomerID"];
                                VehicleID = (int)reader["VehicleID"];
                                StartDate = (DateTime)reader["StartDate"];
                                EndDate = (DateTime)reader["EndDate"];
                                PickUplocation.Append(reader["PickUplocation"]);

                                if (reader["DropOflocation"] == System.DBNull.Value)
                                    DropOflocation = new StringBuilder(null);
                                else
                                    DropOflocation.Append(reader["DropOflocation"]);

                                InitialRentialDays = (int)reader["InitialRentialDays"];
                                RentialPerDay = (decimal)reader["RentialPerDay"];
                                InitialTotalDueAmount = (decimal)reader["InitialTotalDueAmount"];
                                Notes.Append(reader["Notes"]);
                                ApplicatoinID = (int)reader["ApplicationID"];
                                UserID = (int)reader["UserID"];
                            }
                            
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Finding  Reservation By ID" + ex);
            }
            return IsFind;
        }
    public static DataTable GetAllReservationsOnApplicatonStatus(Byte Status)
        {
            DataTable dt = new DataTable();
            try 
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"select ReservationID from Reservations
inner join Applications on Reservations.ApplicationID = Applications.ApplicationID
where Applications.ApplicationStatus = @Status

;";
                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@Status",Status);
                        using (SqlDataReader read = command.ExecuteReader())
                        {
                            if (read.HasRows)
                                dt.Load(read);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Getting All Reservations " + ex);
            }
            return dt;
        }
       public static bool  GetAllReservationsstatics <T>
            (ref T CountNew,ref T CountComplete,ref T CountCancel)
        {
            bool IsFind = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"
Declare @CountNewReservation smallInt;
Declare @CountCancelReservation smallint;
Declare @CountCompleteReservation smallint;


	Select @CountCancelReservation = COUNT(Case
	when  ApplicationStatus  = 2 then 1
	end),
	@CountCompleteReservation = Count(case 
	when ApplicationStatus = 3 then 1
	end
	),
	@CountNewReservation = Count(case 
	when ApplicationStatus  = 1 then 1
	end
	)
	from Reservations
inner join Applications on Reservations.ApplicationID = Applications.ApplicationID

Select @CountCancelReservation as CountCancel,
@CountCompleteReservation as CountComplete,
@CountNewReservation as CountNew
";
                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        using (SqlDataReader read = command.ExecuteReader())
                        {
                            if (read.Read())
                            {
                                IsFind = true;
                                CountCancel = (T)read["CountCancel"];
                                CountComplete = (T)read["CountComplete"];
                                CountNew = (T)read["CountNew"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Error Getting Reservation Details");
            }
            return IsFind;
        }
        public static DataTable GetAllReservationsStatus()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"select ReservationID from Reservations;

;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader read = command.ExecuteReader())
                        {
                            if (read.HasRows)
                                dt.Load(read);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Getting All Reservations " + ex);
            }
            return dt;
        }

        public static DataTable GetAllReviewCustomerOnStatus(string status)
        {

            DataTable dt = new DataTable();
            try
            {
     using (SqlConnection connection  = new SqlConnection(dtAccess.Connection))
            {
                    connection.Open();
                    string query = @"
select  CustomerID,StatusCustomer from 
(
select  
CustomerID,
case
when Count(Reservations.CustomerID)>10 then 'High'
when Count(Reservations.CustomerID) between 5 and 10 then 'Medium'
when Count(Reservations.CustomerID) <5 then 'Low'
end as StatusCustomer 
from Reservations
group by CustomerID
) as CutomerStatus
where StatusCustomer = @StatusCustomer";

    using (SqlCommand command = new SqlCommand(query,connection))
    {
    command.Parameters.AddWithValue("@StatusCustomer", status);
            using (SqlDataReader read = command.ExecuteReader())
            {
                            if (read.HasRows)
                                dt.Load(read);
            }
                    
                    }

                }


            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Error Get Review All Customer "+ex);
            }
            return dt;
        }
        public static DataTable GetAllReviewCustomerOnAllStatus()
        {

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"
select  CustomerID,StatusCustomer from 
(
select  
CustomerID,
case
when Count(Reservations.CustomerID)>10 then 'High'
when Count(Reservations.CustomerID) between 5 and 10 then 'Medium'
when Count(Reservations.CustomerID) <5 then 'Low'
end as StatusCustomer 
from Reservations
group by CustomerID
) as CutomerStatus";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader read = command.ExecuteReader())
                        {
                            if (read.HasRows)
                                dt.Load(read);
                        }

                    }

                }


            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Error Get Review All Customer " + ex);
            }
            return dt;
        }
        public static DataTable GetErnningForEachVehicle()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection  = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"

select Reservations.VehicleID as  VehicleID,
 Sum( Payments.ActualTotalDueAmount) as earnings
 from Payments
 inner join Reservations on Payments.ReserveID = Reservations.ReservationID
 inner join Applications on Reservations.ApplicationID = Applications.ApplicationID
 where Applications.ApplicationStatus = 3
 group by VehicleID
 order by earnings desc

";
                    using (SqlCommand command  = new SqlCommand(query,connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }


                }
            
                    }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Getting Ernning For Each Vehicle");
            }
            return dt;
        }

        public static bool UpdateExtendCarRentialPeriod
     (int ReservationID, decimal InitialTotalDueAmount,int UserID,
            DateTime EndDate)
        {
            int Affect = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"
Update Reservations

 set InitialTotalDueAmount = @Amount
 ,EndDate = @NewDate,UserID = @UserID
 where ReservationID = @ID;

 Update Payments
 set  PaidInitialTotalAmount = @Amount,UserID = @UserID,
PaymentDate = GetDate()
 where ReserveID = @ID;"; 

                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@Amount",InitialTotalDueAmount);
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@ID", ReservationID);
                        command.Parameters.AddWithValue("@NewDate", EndDate);

                        Affect = command.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Update Extend Car Rential " + ex);
            }
            return Affect>0;
        }

        static public DataTable GetFromHighstReservationToLow()
        {

            DataTable dt = new DataTable();
            try 
            {
                
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"
select VehicleID,NumberVehicleForEachReserv ,NumberOfCustomers,

case 
when NumberVehicleForEachReserv>5 then 'high'
when NumberVehicleForEachReserv>2 then 'Medium'
else 'Low'
end as Status

from (
select VehicleID, Count(ReservationID) as NumberVehicleForEachReserv
,Count(CustomerID) as NumberOfCustomers
from Reservations
group by VehicleID
)r1
Order by NumberVehicleForEachReserv desc 


";
                    using (SqlCommand command =new SqlCommand(query,connection))
                    {
                        using (SqlDataReader read = command.ExecuteReader())
                        {
                            if (read.HasRows)
                                dt.Load(read);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer(" Failed Getting Highst Reserve to low" + ex);
            }
            return dt;
        }

    }
}

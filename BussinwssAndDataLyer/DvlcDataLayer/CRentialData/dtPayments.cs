using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvlcDataLayer.CRentialData
{
    public class dtPayments
    {
    public static int 
Add(int ReserveID,decimal PaidInitialTotalAmount,string Notes,
        int UserID
        )
        {
            //PaymentDate //Payments
            int PaymentID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"Insert into Payments
(ReserveID, PaidInitialTotalAmount,Notes,UserID,PaymentDate)
values(@ReserveID,@PaidInitialTotalAmount,@Notes,@UserID,GetDate());
select Scope_Identity();";

                    using (SqlCommand command =new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@PaidInitialTotalAmount", PaidInitialTotalAmount);
                        command.Parameters.AddWithValue("@ReserveID", ReserveID);
                        command.Parameters.AddWithValue("@Notes", Notes);
                        command.Parameters.AddWithValue("@UserID", UserID);

                        object res = command.ExecuteScalar();
                        PaymentID = res != null ? int.Parse(res.ToString()) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Error Adding Payment "+ex);
            }
            
            return PaymentID;
        }

        public static bool Update()
        {
            int Affect = 0;
            return Affect > 0;
        }
        public static bool FindByPaymentID(int PaymentID,ref int ReserveID, 
            ref decimal PaidInitialTotalAmount
            ,ref string Notes,ref int UserID,ref  decimal ? ActualTotalDueAmount,
            ref decimal ? TotalRemaing,ref decimal ? TotalRefunedAmount,ref DateTime PaymentDate,
            ref DateTime ? UpdatePaymentDate,ref int ? ReturnID)
        {
            bool IsFind = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"Select * from Payments where 
PaymentID = @ID";
                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@ID",PaymentID);
                        using (SqlDataReader read = command.ExecuteReader())
                        {
                            if (read.Read())
                            {
                                IsFind = true;
                                ReserveID = (int)read["ReserveID"];
                                UserID = (int)read["UserID"];
                                PaidInitialTotalAmount = (decimal)read["PaidInitialTotalAmount"];
                                Notes = (string)read["Notes"];
                                PaymentDate = (DateTime)read["PaymentDate"];
                                if (read["ActualTotalDueAmount"]!=DBNull.Value)
                                {
                                    decimal value = (decimal)read["ActualTotalDueAmount"];
                                    if (ActualTotalDueAmount!=value)
                                    {
                                        ActualTotalDueAmount = value;
                                    }
                                }
                                //TotalRemaing
                                if (read["TotalRemaing"] != DBNull.Value)
                                {
                                    decimal value = (decimal)read["TotalRemaing"];
                                    if (TotalRemaing != value)
                                    {
                                        TotalRemaing = value;
                                    }
                                }
                                //TotalRefunedAmount
                                if (read["TotalRefunedAmount"] != DBNull.Value)
                                {
                                    decimal value = (decimal)read["TotalRefunedAmount"];
                                    if (TotalRefunedAmount != value)
                                    {
                                        TotalRefunedAmount = value;
                                    }
                                }
                                if (read["UpdatePaymentDate"] != DBNull.Value)
                                {
                                    DateTime value = (DateTime)read["UpdatePaymentDate"];
                                    if (UpdatePaymentDate != value)
                                    {
                                        UpdatePaymentDate = value;
                                    }
                                }
                                if (read["ReturnID"] != DBNull.Value)
                                {
                                    int value = (int)read["ReturnID"];
                                    if (ReturnID != value)
                                    {
                                        ReturnID = value;
                                    }
                                }

                            }
                        }    
                    }
                }
            }catch(Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Error Finding Payment By ID"+ex);
            }
            return IsFind;
        }
        public static DataTable GetAllPayments()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"
select PaymentID,ReserveID,Payments.PaidInitialTotalAmount as InitialAmount
,ActualTotalDueAmount,TotalRemaing,Payments.TotalRefunedAmount,Payments.UpdatePaymentDate,ReturnID,PaymentDate

,case  
when Applications.ApplicationStatus = 1 then 'New'
when Applications.ApplicationStatus = 2 then 'Cancel'
when Applications.ApplicationStatus = 3 then 'Completed'

end As Status
from Payments
inner join Reservations on Payments.ReserveID = Reservations.ReservationID
inner join Applications on Reservations.ApplicationID = Applications.ApplicationID
;

";
                    using (SqlCommand command = new SqlCommand(query,connection))
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
                dtAccess.WriteExceptionOnEventViewer("Error Finding All Payments "+ex);
            }
            return dt;
        }
        public static bool CancelRentialCar(int PaymentID,int ApplicationID,decimal Amount,decimal PaidInitalAmount
            ,int CustomerID,int VehicleID)
        {
           int Affect = 0;
            try
            {
                using (SqlConnection connection  = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"Update Payments
set ActualTotalDueAmount = @Amount,
TotalRefunedAmount = @PaidInitalAmount - @Amount,
TotalRemaing = 0,
UpdatePaymentDate = GetDate()

where PaymentID = @PaymentID;

Update Applications
set ApplicationStatus = 2, 
LastStatusDate = GetDate()
where ApplicationID = @ApplicationID;

Update Customers
Set TakePersonalInfo = 1
where CustomerID = @CustomerID;

Update Vehicles
set Status = 1
where VehicleID = @VehicleID;
";

                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@Amount", Amount);
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);
                        command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("@PaidInitalAmount", PaidInitalAmount);
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);
                        command.Parameters.AddWithValue("@VehicleID", VehicleID);

                        Affect = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Caneled Rential Car");
            }
            return Affect > 0;
        }
    
    public static bool UpdatePaymentAfterReturnVehicle
    (int ReservationID,decimal  TotalRemaing,decimal ActualTotalAmount
        ,decimal TotalRefunedAmount,int ReturnID,int UserID)
        {
            int Affect = 0; 
            try
            {
                
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"
Update Payments
set 
ActualTotalDueAmount = @ActualTotalAmount
,TotalRemaing = @TotalRemain
,TotalRefunedAmount = @TotalRefunedAmount  
,UpdatePaymentDate = GetDate()
,ReturnID = @ReturnID
,UserID = @UserID
where ReserveID = @ID;
;
";
                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@ActualTotalAmount", ActualTotalAmount);
                        command.Parameters.AddWithValue("@TotalRefunedAmount  ", TotalRefunedAmount);
                        command.Parameters.AddWithValue("@ReturnID  ", ReturnID);
                        command.Parameters.AddWithValue("@UserID  ", UserID);
                       
                        command.Parameters.AddWithValue("@ID  ", ReservationID);
                        command.Parameters.AddWithValue("@TotalRemain", TotalRemaing);
                        
                        Affect = command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Update Payment after Return Vehicle "+ex);
            }
            return Affect > 0;
        }

        public static bool UpdatePaymentLastProcess
    (int PaymentID, decimal? TotalRemaing
        , int ApplicationID,  int CustomerID)
        {
            int Affect = 0;
            try
            {

                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"
Update Payments
set 
TotalRemaing = 0
,TotalRefunedAmount = @TotalRemain
,UpdatePaymentDate = GetDate()

where PaymentID = @ID;

Update Applications
set ApplicationStatus = 3, 
LastStatusDate = GetDate()
where ApplicationID = @ApplicationID;

Update Customers
Set TakePersonalInfo = 1
where CustomerID = @CustomerID;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        //command.Parameters.AddWithValue("@ActualTotalAmount", ActualTotalAmount);
                        //command.Parameters.AddWithValue("@TotalRefunedAmount  ", TotalRefunedAmount);
                        
                        command.Parameters.AddWithValue("@ID  ", PaymentID);
                        command.Parameters.AddWithValue("@TotalRemain", TotalRemaing);
                        command.Parameters.AddWithValue("@ApplicationID ", ApplicationID);
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);

                        Affect = command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Update Payment after Return Vehicle " + ex);
            }
            return Affect > 0;
        }



    }
}

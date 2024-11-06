using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DvlcDataLayer.CRentialData
{
    public class dtReturn
    {
        public static int Add(int ReservationID,short mileage,
            byte ActualRentialDays,DateTime RentialDate,
            decimal TotalMileage,string Notes,
            decimal AdditionalCharges,decimal ActualTotalAmount,
            int UserID,int VehicleID)
        {
            int returnID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"

Update Vehicles
set Status = 1,
mileage  = @mileage
where VehicleID = @VehicleID;


INSERT INTO [dbo].[Returns]
           ([ReservationID]
           ,[mileage]
           ,[ActualRentialDays]
           ,[RentialDate]
           ,[TotalMileage]
           ,[Notes]
           ,[AdditionalCharges]
           ,[ActualTotalAmount]
           ,[UserID])
VALUES
           (@ReservationID
           ,@mileage
           ,@ActualRentialDays
           ,@ReturnDate
           ,@TotalMileage
           ,@Notes
,@AdditionalCharges
           ,@ActualTotalAmount 
         ,@UserID)
;
Select Scope_IDentity();";
                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@ReservationID", ReservationID);
                        command.Parameters.AddWithValue("@mileage", mileage);
                        command.Parameters.AddWithValue("@ActualRentialDays", ActualRentialDays);
                        command.Parameters.AddWithValue("@TotalMileage", TotalMileage);
                        command.Parameters.AddWithValue("@Notes", Notes);
                        command.Parameters.AddWithValue("@AdditionalCharges", AdditionalCharges);
                        command.Parameters.AddWithValue("@ActualTotalAmount", ActualTotalAmount);
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@VehicleID", VehicleID);
                        command.Parameters.AddWithValue("@ReturnDate",RentialDate);
                        object res = command.ExecuteScalar();
                        returnID = res != null ? int.Parse(res.ToString()) : -1;


                    }
                }

            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Add Return Car");
            }
            return returnID;
        }


        public static bool Find(int ReturnID,ref int ReservationID, ref short mileage,
            ref byte ActualRentialDays, ref DateTime RentialDate,
            ref decimal TotalMileage, ref string Notes,
            ref decimal AdditionalCharges, ref decimal ActualTotalAmount,
            ref int UserID)
        {
            bool IsFind = false ;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"Select * from Returns 
Where ReturnID = @ReturnID;
";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ReturnID", ReturnID);
                        
                        using (SqlDataReader read = command.ExecuteReader())
                        {
                            if (read.Read())
                            {
                                IsFind = true;
                                mileage = (short)read["mileage"];
                                RentialDate = (DateTime)read["RentialDate"];
                                ActualRentialDays = (byte)read["ActualRentialDays"];
                                TotalMileage = (short)read["TotalMileage"];
                                Notes = (string)read["Notes"];
                                AdditionalCharges = (decimal)read["AdditionalCharges"];
                                ActualTotalAmount = (decimal)read["ActualTotalAmount"];
                                UserID = (int)read["UserID"];
                                ReservationID = (int)read["ReservationID"];
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Find Return Data");
            }
            return IsFind;
        }


    }

}

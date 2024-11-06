using System;
using System.Data;
using System.Data.SqlClient;

namespace DvlcDataLayer.CRentialData
{
    public class dtMaintaince
    {
        //IsRepaired // Maintaince
        public static int Add(int VehicleID,string Description,
        DateTime MaintainceDate,decimal Cost,int UserID)
        {
            int NewID = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"
INSERT INTO [dbo].[Maintaince]
           (VehicleID
           ,Description
           ,MaintainceDate
           ,Cost,
 UserID)
Values(
 @VehicleID
,@Description
,@MaintainceDate
,@Cost,
@UserID);
Select Scope_Identity();

Update Vehicles
set Status = 3
where VehicleID = @VehicleID;
";

using (SqlCommand command  = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@VehicleID", VehicleID);
                        command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@MaintainceDate", MaintainceDate);
                        command.Parameters.AddWithValue("@Cost", Cost);
                        command.Parameters.AddWithValue("@UserID", UserID);

                        object res = command.ExecuteScalar();
                        NewID = res != null ? int.Parse(res.ToString()) : -1;
                    }

                        ;
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Add Maintance for Vehicle "+ex);
            }
            return NewID ;
        }

        public static bool Update(int MantanceID,int VehicleID)
        {
            int Affect = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"

 Update Maintaince
      
set  IsRepaired = 1,EndMaintaince = GetDate()
where MaintainceID =@ID;

Update Vehicles
set Status = 1
where VehicleID = @VehicleID;
";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VehicleID", VehicleID);
                        command.Parameters.AddWithValue("@ID", MantanceID);
                        Affect = command.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Update Maintance for Vehicle " + ex);
            }
            return Affect>0;
        }

        public static bool Find(int MaintainceID,ref int VehicleID,ref string Description,
        ref DateTime MaintainceDate, ref DateTime ? EndMaintaince, ref decimal Cost,ref bool IsRepaired,
        ref int UserID)
        {
            bool IsFind = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"

Select * from Maintaince
where MaintainceID = @ID";

using (SqlCommand command = new SqlCommand(query, connection))
{
    command.Parameters.AddWithValue("@ID", MaintainceID);
    
                        using (SqlDataReader reader  = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFind = true;
                                VehicleID = (int)reader["VehicleID"];
                                Description = (string)reader["Description"];
                                MaintainceDate = (DateTime)reader["MaintainceDate"];
                                Cost = (decimal)reader["Cost"];
                                IsRepaired = (bool)reader["IsRepaired"];
                                UserID = (int)reader["UserID"];
                                if (reader["EndMaintaince"] != DBNull.Value)
                                    EndMaintaince = (DateTime)reader["EndMaintaince"];

                            }

                        }
                    }

                        ;
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Finding Maintance by MaintanceID " + ex);
            }
            return IsFind;
        }
        //Select * from Maintaince;
        public static DataTable GetAllMaintense()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"

 Select * from Maintaince 

";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }

                        ;
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Finding Maintance by MaintanceID " + ex);
            }
            return dt;
        }

        public static short GetCountMaintanceForVehicle(int VehicleID) 
        {
            short Count = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"select Count(@VehicleID) from Maintaince
group by VehicleID";

                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@VehicleID",VehicleID);

                        object res = command.ExecuteScalar();
                        Count = res != null ? short.Parse(res.ToString()):short.Parse(0.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Count Maintence for Vehicle"+ex);
            }
            return Count;
        }
    }
}

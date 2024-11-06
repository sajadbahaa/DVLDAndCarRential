using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvlcDataLayer;

namespace CRentailData
{
    public  class dtVechilesNames
    {

        public static bool Find(int VehicleID, ref string VehicleName)
        {
            bool IsFind = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();

                    string query = @"select distinct * from VehiclesNames
where VehicleNameID = @VehicleNameID";
                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@VehicleNameID", VehicleID);
                        using (SqlDataReader read = command.ExecuteReader())
                        {
                            if (read.Read())
                            {
                                IsFind = true;
                                VehicleName = (string)read["VehicleName"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Faild Loading Models Data By VehicleNameID  " + ex);
            }
            return IsFind;
        }
     public static int GetVehicleNameIDByVehicleName(string VehicleName)
        {
            int vehicleNameID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"Select VehicleNameID from VehiclesNames
Where VehicleName = @Name";
                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@Name",VehicleName);

                        object res = command.ExecuteScalar();
                        vehicleNameID = res != null ? int.Parse(res.ToString()) : -1;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Error Finding VehicleNameID by VehicleName "+ex);
            }
            return vehicleNameID;
        }
        public static DataTable GetAllVehiclesNames()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();

                    string query = @"select distinct * from VehiclesNames;";
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
                dtAccess.WriteExceptionOnEventViewer("Faild Loading VehiclesName Data " + ex);
            }
            return dt;
        }

        public static DataTable GetAllVehicleNameByCategory(decimal category)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();

                    string query = @"
select distinct   VehicleName from VehiclesNames
inner join Categories on VehiclesNames.VehicleNameID = Categories.VehicleNameID
where Categories.Category = @Category;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Category", category);
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
                dtAccess.WriteExceptionOnEventViewer("Faild Loading Categories Data " + ex);
            }
            return dt;
        }

    }
}

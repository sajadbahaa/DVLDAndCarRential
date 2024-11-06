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
    public  class dtFualTypes
    {
        //  SELECT[FualTypeID]
        //,[FuelType]
        //  FROM[dbo].[FualTypes]

        public static bool Find(int FualTypeID, ref string FuelType)
        {
            bool IsFind = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();

                    string query = @"Select * from FualTypes
where FualTypeID = @FualTypeID";
                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@FualTypeID", FualTypeID);
                        using (SqlDataReader read = command.ExecuteReader())
                        {
                            if (read.Read())
                            {
                                IsFind = true;
                                FuelType = (string)read["FualType"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess. WriteExceptionOnEventViewer("Faild Loading Data By FualTypeID  " + ex);
            }
            return IsFind;
        }
        public static DataTable GetAllFualTypes()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();

                    string query = @"Select * from FualTypes";
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
                dtAccess.WriteExceptionOnEventViewer("Faild Loading FualTypes Data " + ex);
            }
            return dt;
        }
        public static int GetFualTypeIDByFualType( StringBuilder FualType)
        {
            int FualTypeID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();

                    string query = @"Select FualTypeID from FualTypes
where FualType = @FualType";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FualType", FualType.ToString());
                        
                        object res = command.ExecuteScalar();
                        FualTypeID = res != null ? int.Parse(res.ToString()) : -1;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Faild Loading Data By FualTypeID  " + ex);
            }
            return FualTypeID;
        }


    }
}

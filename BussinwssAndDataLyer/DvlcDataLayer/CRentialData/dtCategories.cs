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
    public  class dtCategories
    {
      //  SELECT[CategoryID]
      //,[Category]
      //  FROM[dbo].[Categories]

        // convert Category from Decimal to Byte
        public static bool Find(int CategoryID, ref Byte Category)
        {
            bool IsFind = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();

                    string query = @"Select * from Categories
where CategoryID = @CategoryID";
                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);
                        using (SqlDataReader read = command.ExecuteReader())
                        {
                            if (read.Read())
                            {
                                IsFind = true;
                                Category = (Byte)read["Category"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Faild Loading Categories Data By FualTypeID  " + ex);
            }
            return IsFind;
        }
        public static DataTable GetAllCategoriesTypes()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();

                    string query = @"select distinct Category from Categories";
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
                dtAccess.WriteExceptionOnEventViewer("Faild Loading Categories Data " + ex);
            }
            return dt;
        }

        public static DataTable GetAllVehicleNameByCategory(byte category)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();

                    string query = @"
select distinct top 10  VehicleName from VehiclesNames
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

        public static int GetCategoryIDByCategory(byte category)
        {
            int CategoryID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();

                    string query = @" select  CategoryID from  Categories
where Category  = @Category;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Category", category);
                        object res = command.ExecuteScalar();
                        CategoryID = res != null ? int.Parse(res.ToString()) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Faild Loading Categories Data " + ex);
            }
            return CategoryID;
        }
    }
}

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
    public class dtModels
    {
        public static bool Find(int ModelID, ref string Model)
        {
            bool IsFind = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();

                    string query = @"Select * from Models
where ModelID = @ModelID";
                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@ModelID", ModelID);
                        using (SqlDataReader read = command.ExecuteReader())
                        {
                            if (read.Read())
                            {
                                IsFind = true;
                                Model = (string)read["Model"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Faild Loading Models Data By ModelID  " + ex);
            }
            return IsFind;
        }
        public static DataTable GetAllModels()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();

                    string query = @"Select top 10 * from Models";
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
                dtAccess.WriteExceptionOnEventViewer("Faild Loading Models Data " + ex);
            }
            return dt;
        }
        public static int GetModelIDByModel(StringBuilder Model)
        {
            int ModelID = -1;
                try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();

                    string query = @"Select ModelID from Models
                    where Model = @Model";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Model", Model.ToString());

                        object res = command.ExecuteScalar();
                        ModelID = res != null ? int.Parse(res.ToString()) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Faild Getting Models Data By Model  " + ex);
            }

            return ModelID ;
        
        }

    }
}

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
    public  class dtMakes
    {
        public static bool Find(int MakeID, ref string Make)
        {
            bool IsFind = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();

                    string query = @"select * from Makes
where MakeID = @MakeID";
                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@MakeID", MakeID);
                        using (SqlDataReader read = command.ExecuteReader())
                        {
                            if (read.Read())
                            {
                                IsFind = true;
                                Make = (string)read["Make"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Faild Loading MakeCars Data By MakeID  " + ex);
            }
            return IsFind;
        }
        public static DataTable GetAllMakes()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();

                    string query = @"select distinct top 15 * from Makes;";
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
                dtAccess.WriteExceptionOnEventViewer("Faild Loading Makes Data " + ex);
            }
            return dt;
        }

        public static int GetMakeIDByMake ( StringBuilder Make)
        {
            int MakeID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();

                    string query = @"select MakeID from Makes
where Make = @Make";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Make", Make.ToString());
                        
                            object res = command.ExecuteScalar();
                            MakeID = res != null ? int.Parse(res.ToString()) : -1;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Faild Loading MakeCars Data By MakeID  " + ex);
            }
            return MakeID;
        }


    }
}

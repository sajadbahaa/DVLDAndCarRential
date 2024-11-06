using DvlcDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CRentailData
{
    public  class dtMainfacturesYears
    {
public static bool Find(int YearID,ref decimal Year)
        {
            bool IsFind = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();

                    string query = @"select distinct * from MainFacturesYears;
where YearID = @YearID";
                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@YearID", YearID);
                        using (SqlDataReader read = command.ExecuteReader())
                        {
                            if (read.Read())
                            {
                            IsFind = true;
                            Year = (decimal)read["Year"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Faild Loading Data By Manfaucture ID "+ex);
            }
            return IsFind;
        }
public static DataTable  GetAllMainfacturesYears()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();

                    string query = @"Select top 12 Year from MainFacturesYears";
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
                dtAccess.WriteExceptionOnEventViewer("Faild Loading Data " + ex);
            }
            return dt;
        }

        public static Decimal GetYear(int VehicleNameID)
        {
            Decimal dt = 1001;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {

                    connection.Open();

                    string query = @"select  Year from MainFacturesYears
where VehicleNameID = @VehicleNameID;";

                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@VehicleNameID",VehicleNameID);
                        object res = command.ExecuteScalar();
                        if (res!=null)
                        {
                            dt = Decimal.Parse(res.ToString());
                        }
                    }
                }            
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Error Getting Year by VehicleNameID "+ex);
            }
            return dt;
        }

    }
}

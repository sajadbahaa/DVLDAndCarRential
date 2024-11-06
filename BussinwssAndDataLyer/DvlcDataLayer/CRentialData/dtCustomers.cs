using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvlcDataLayer
{
    public  class dtCustomers
    {
        //_
        public static int Add(int DriverID)
        {
            int CustomerID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"Insert into Customers (DriverID,TakePersonalInfo)
                Values(@DriverID,1);
          Select Scope_Identity();";

                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@DriverID",DriverID);
                        object res = command.ExecuteScalar();
                        CustomerID = res != null ? int.Parse(res.ToString()) : -1;
                    }
                }

            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Adding Customer" +ex);
            }
            return CustomerID;
        }
        public static int GetCustomerIDByDriverID(int DriverID)
        {
            int CustomerID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"Select CustomerID from Customers
                Where  DriverID = @DriverID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DriverID", DriverID);

                        object res = command.ExecuteScalar();
                        CustomerID = res != null ? int.Parse(res.ToString()) : -1;
                    }
                }

            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Adding Customer" + ex);
            }
            return CustomerID;
        }
        public static bool Delete(int CustomerID)
        {
            int Affect = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"Delete from  Customers 
                Where  CustomerID = @CustomerID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);

                        Affect = command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Deleting Customer" + ex);
            }
            return Affect>0;

        }
        public static bool FindCustomerByCustomerID(int CustomerID,ref int DriverID,ref bool TakePersonalInfo)
        {
            bool IsFind = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"Select * from Customers 
                Where  CustomerID = @CustomerID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);
                   using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFind = true;
                                DriverID = (int)reader["DriverID"];
                                TakePersonalInfo = (bool)reader["TakePersonalInfo"];
                            }
                        }
                    
                    }
                }

            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Loading  Customer Data by Customer ID" + ex);
            }
            return IsFind ;

        }
        public static bool FindCustomerByDriverID (ref int CustomerID,  int DriverID, ref bool TakePersonalInfo)
        {
            bool IsFind = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"Select * from Customers 
                Where  DriverID = @DriverID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DriverID", DriverID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFind = true;
                                CustomerID = (int)reader["CustomerID"];
                                TakePersonalInfo = (bool)reader["TakePersonalInfo"];
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Loading  Customer Data by DriverID" + ex);
            }
            return IsFind;

        }
        public static DataTable GetAllCustomers()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"
select  CustomerID, dbo.Drivers.PersonID, dbo.People.FirstName + ' ' + dbo.People.SecondName + ' ' + ISNULL(dbo.People.ThirdName, '') + ' ' + dbo.People.LastName AS FullName  
from Customers
inner join Drivers on Customers .DriverID = Drivers.DriverID
inner join People on Drivers.PersonID  = People.PersonID;
";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                     using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Loading  All Customers " + ex);
            }
            return dt;
        }
     
    }
}

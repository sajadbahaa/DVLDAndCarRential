using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace DvlcDataLayer
{
    
    public class dtPeople
    {
    static public bool Find(int PersonID,ref string NationalNo,ref  string FirstName,ref string SecondName,
  ref  string ThirdName,ref string LastName,ref DateTime DateOfBirth,ref  Byte Gendor , ref string Address,
   ref string Phone,ref string Email,ref int NationalityCountryID,ref string ImagePath)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select * from People Where PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID",PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFind = true;
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    if (reader["ThirdName"]==System.DBNull.Value)
                    {
                        ThirdName = Convert.ToString(null);
                    }
                    else
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }

                    LastName = (string)reader["LastName"];
                    Gendor = (Byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    if (reader["Email"]==System.DBNull.Value)
                    {
                        Email = Convert.ToString(null);
                    }
                    else
                    {
                        Email = (string)reader["Email"];
                    }
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"]==System.DBNull.Value)
                    {
                        ImagePath = Convert.ToString(null);
                    }
                    else
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    DateOfBirth = (DateTime)reader["DateOfBirth"];

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Loading  Person info by Person ID" + ex);
            }
            finally
            {
                connection.Close();
            }
            return IsFind;
        }

    static public bool FindByNationalNo(ref int PersonID, string NationalNo, ref string FirstName, ref string SecondName,ref 
    string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref Byte Gendor, ref string Address,ref
    string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select * from People Where NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFind = true;
                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    if (reader["ThirdName"] == System.DBNull.Value)
                    {
                        ThirdName = Convert.ToString(null);
                    }
                    else
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                     
                    LastName = (string)reader["LastName"];
                    Gendor = (Byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    if (reader["Email"] == System.DBNull.Value)
                    {
                        Email = Convert.ToString(null);
                    }
                    else
                    {
                        Email = (string)reader["Email"];
                    }
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] == System.DBNull.Value)
                    {
                        ImagePath = Convert.ToString(null);
                    }
                    else
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    DateOfBirth = (DateTime)reader["DateOfBirth"];


                }
                reader.Close();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Loading Person Info By National No " + ex);

            }
            finally
            {
                connection.Close();
            }
            return IsFind;
        }
        static public int Add(string NationalNo, string FirstName, string SecondName,
        string ThirdName, string LastName, DateTime DateOfBirth, Byte Gendor, string Address,
        string Phone,  string Email,  int NationalityCountryID, string ImagePath)
        {
            int NewID = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Insert into People (NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,
             Gendor,Address,Phone,Email,NationalityCountryID,ImagePath)
             Values(@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,
             @Gendor,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath);
             Select Scope_Identity();";
            
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            
            if (ThirdName == "")
            {
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ThirdName", ThirdName);

            }
            command.Parameters.AddWithValue("@LastName",LastName);
            command.Parameters.AddWithValue("@DateOfBirth",DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address",Address);
            command.Parameters.AddWithValue("@Phone",Phone);
            
            if (Email == "")
            {
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Email", Email);
            }
            command.Parameters.AddWithValue("@NationalityCountryID",NationalityCountryID);
            if (ImagePath == null)
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }


            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res!=null&&int.TryParse(res.ToString(),out int newID))
                {
                    NewID = newID;
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Adding  New Person" + ex);

            }
            finally
            {
                connection.Close();
            }
            return NewID;
        }
        static public bool Update(int PersonID, string NationalNo, string FirstName, string SecondName,
        string ThirdName, string LastName, DateTime DateOfBirth, Byte Gendor, string Address,
        string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int Affected = -1; 
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Update People 
 Set NationalNo = @NationalNo,FirstName = @FirstName,SecondName = @SecondName,ThirdName = @ThirdName,LastName= @LastName,
DateOfBirth = @DateOfBirth,Gendor = @Gendor,Address = @Address,Phone = @Phone,Email = @Email,
NationalityCountryID = @NationalityCountryID,ImagePath = @ImagePath
Where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName == Convert.ToString(null))
            {
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ThirdName", ThirdName);

            }
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (Email == Convert.ToString(null))
            {
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Email", Email);
            }
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (ImagePath == Convert.ToString(null))
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            try
            {
                connection.Open();
                Affected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Update Person Data" + ex);

            }
            finally
            {
                connection.Close();
            }
            return (Affected>-1);
        }
        static public bool Delete(int PersonID)
        {
            int Affected = -1;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Delete From People
Where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            
            try
            {
                connection.Open();
                Affected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Delete Person Data "+ex);

            }
            finally
            {
                connection.Close();
            }
            return (Affected > -1);
        }
        static public bool Exsist(int PersonID)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select find ='yes' From People
Where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFind = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Finding Person Data by Person ID" + ex);

            }
            finally
            {
                connection.Close();
            }
            return (IsFind);
        }
        static public bool Exsist(string NationalNo)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select find ='yes' From People
Where NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFind = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Finding Person Data by National No" + ex);

            }
            finally
            {
                connection.Close();
            }
            return (IsFind);
        }
        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(dtAccess.Connection);
            string query = @"Select * from People";
            SqlCommand command = new SqlCommand(query,connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                dtAccess.WriteExceptionOnEventViewer("Failed Get All People List" + e);

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }


    }
}

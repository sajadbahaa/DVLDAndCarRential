using CRentailData;
using DvlcDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CRentailData
{
    public  class dtVehicles
    {
    public static int Add
(int NameID,int CategoryID,
 int ModelID,int MainFactueYear,
 int MakeID,int FualTypeID,decimal mileage,
 decimal RentailPerDay,string  PlateNumber,
 string image,int ClassLicenseID)
        {
            int? VID  = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"Insert into Vehicles
(
NameID,
CategoryID,
ModelID,
MainFactueYear,
MakeID,
FualTypeID,
mileage,
RentailPerDay,
PlateNumber,
image,
ClassLicenseID)

values(
@NameID,
@CategoryID,
@ModelID,
@MainFactueYear,
@MakeID,
@FualTypeID,
@mileage,
@RentailPerDay,
@PlateNumber,
@image,
@ClassLicenseID
);
Select Scope_Identity();";
                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@NameID", NameID);
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);
                        command.Parameters.AddWithValue("@ModelID", ModelID);
                        command.Parameters.AddWithValue("@MainFactueYear", MainFactueYear);
                        command.Parameters.AddWithValue("@MakeID", MakeID);
                        command.Parameters.AddWithValue("@FualTypeID", FualTypeID);
                        command.Parameters.AddWithValue("@mileage", mileage);
                        command.Parameters.AddWithValue("@RentailPerDay", RentailPerDay);
                        command.Parameters.AddWithValue("@PlateNumber", PlateNumber);
                        command.Parameters.AddWithValue("@ClassLicenseID", ClassLicenseID);
                        if(image ==null)
command.Parameters.AddWithValue("@image", System.DBNull.Value);
      else
command.Parameters.AddWithValue("@image", image);


                        object res = command.ExecuteScalar();
                        VID = (res == null ? -1 : int.Parse(res.ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Error Adding Vehicle " + ex);
            }
            return VID.Value;
        
        }

public static bool Update
(int VehicleID, int NameID, int CategoryID,
int ModelID,
int MakeID, int FualTypeID, decimal mileage,
decimal RentailPerDay,
string image, int MainFactueYear,int ClassLicenseID)
        {
            int Affect = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"

UPDATE[dbo].[Vehicles]
   SET[NameID]            = @NameID,
      [CategoryID]       = @CategoryID,
      [ModelID]          = @ModelID
      ,[MakeID]           = @MakeID
      ,[FualTypeID]       = @FualTypeID
      ,[mileage]          = @mileage
      ,[RentailPerDay]    = @RentailPerDay
      ,[image]  = @image,
    MainFactueYear = @MainFactueYear,
 ClassLicenseID = @ClassLicenseID
WHERE VehicleID = @VehicleID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VehicleID", VehicleID);
                        command.Parameters.AddWithValue("@NameID", NameID);
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);
                        command.Parameters.AddWithValue("@ModelID", ModelID);
                        command.Parameters.AddWithValue("@MakeID", MakeID);
                        command.Parameters.AddWithValue("@FualTypeID", FualTypeID);
                        command.Parameters.AddWithValue("@mileage", mileage);
                        command.Parameters.AddWithValue("@RentailPerDay", RentailPerDay);
                        command.Parameters.AddWithValue("@MainFactueYear", MainFactueYear);
                        command.Parameters.AddWithValue("@ClassLicenseID", ClassLicenseID);
                        
                        if (image == null)
                            command.Parameters.AddWithValue("@Image", System.DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Image", image);


                        Affect = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Error Update Vehicle " + ex);
            }
            return Affect>0;
        }


public static bool Delete
(int VehicleID)
        {
            int Affect = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"

DELETE FROM [dbo].[Vehicles]

WHERE VehicleID = @VehicleID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VehicleID", VehicleID);
                        Affect = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Error Delete Vehicle " + ex);
            }
            return Affect > 0;
        }

        //SELECT [VehicleID]

        public static bool Find
    ( int VehicleID,ref int NameID, ref int CategoryID,
     ref int ModelID, ref short MainFactueYear,
     ref int MakeID, ref int FualTypeID, ref decimal mileage,
     ref decimal RentailPerDay, ref string PlateNumber,
    ref Byte Status, ref string image,ref int ClassLicenseID)
        {
            bool IsFind = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"Select * from Vehicles
where VehicleID = @VehicleID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VehicleID", VehicleID);
                        using (SqlDataReader r = command.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                IsFind = true;
                                NameID = (int)r["NameID"];
                                CategoryID = (int)r["CategoryID"];
                                ModelID = (int)r["ModelID"];
                                MainFactueYear = (short)r["MainFactueYear"];
                                MakeID = (int)r["MakeID"];
                                FualTypeID = (int)r["FualTypeID"];
                                mileage = (decimal)r["mileage"];
                                RentailPerDay = (decimal)r["RentailPerDay"];
                                PlateNumber = (string)r["PlateNumber"];
                                Status = (Byte)r["Status"];
                                if (r["image"] == System.DBNull.Value)
                                    image = null;
                                else
                                    image = (string)r["image"];

                                ClassLicenseID = (int)r["ClassLicenseID"];
                            }
                        }                 
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Error Loading Vehicle by Vehicle ID" + ex);
            }
            return IsFind;
        }

        public static DataTable GetAllVehicles()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"
SELECT        dbo.Vehicles.VehicleID, dbo.VehiclesNames.VehicleName, dbo.Vehicles.MainFactueYear, dbo.FualTypes.FualType, dbo.Vehicles.Status, dbo.Vehicles.mileage, dbo.Vehicles.RentailPerDay, 
                         CASE WHEN Categories.Category = '1' THEN 'One Door' WHEN Categories.Category = '2' THEN 'Two Doors' WHEN Categories.Category = '3' THEN 'Three Doors' WHEN Categories.Category = '4' THEN 'Four Doors' WHEN Categories.Category
                          = '5' THEN 'Five Doors' WHEN Categories.Category = '6' THEN 'Six Doors' WHEN Categories.Category = '8' THEN 'Eight Doors' END AS Doors
FROM            dbo.Vehicles INNER JOIN
                         dbo.VehiclesNames ON dbo.Vehicles.NameID = dbo.VehiclesNames.VehicleNameID INNER JOIN
                         dbo.Categories ON dbo.Vehicles.CategoryID = dbo.Categories.CategoryID INNER JOIN
                         dbo.FualTypes ON dbo.Vehicles.FualTypeID = dbo.FualTypes.FualTypeID

";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader r = command.ExecuteReader())
                        {
                            if (r.HasRows)
                                dt.Load(r);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Error Getting Vehicle " + ex);
            }
            return dt;
        }
        //select Vehicles.* from Categories
        //inner join Vehicles on Categories.CategoryID = Vehicles.CategoryID
        //where Category = 3
        public static DataTable GetAllVehiclesByCategory(decimal category)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"
select Vehicles.* from Categories
        inner join Vehicles on Categories.CategoryID = Vehicles.CategoryID
        where Category = @category"
;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@category", category);
                        using (SqlDataReader r = command.ExecuteReader())
                        {
                            if (r.HasRows)
                                dt.Load(r);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Error Getting Vehicle  By Category" + ex);
            }
            return dt;
        }

        public static DataTable GetAllVehiclesByFualType(StringBuilder FualType)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"
select Vehicles.VehicleID,FualType from FualTypes
inner join Vehicles on FualTypes.FualTypeID = Vehicles.FualTypeID
where FualType  = @FualType";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FualType", FualType.ToString());
                        using (SqlDataReader r = command.ExecuteReader())
                        {
                            if (r.HasRows)
                                dt.Load(r);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Error Getting Vehicle  By Fual Type" + ex);
            }
            return dt;
        }
        public static DataTable GetAllVehiclesStatus(bool status)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(dtAccess.Connection))
                {
                    connection.Open();
                    string query = @"
select * from Vehicles
where IsAvailable = @Status";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Status", status);
                        using (SqlDataReader r = command.ExecuteReader())
                        {
                            if (r.HasRows)
                                dt.Load(r);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dtAccess.WriteExceptionOnEventViewer("Error Getting Vehicles Status  By Status" + ex);
            }
            return dt;
        }


    }
}


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CarDealershipAPI.Logic;
using CarDealershipAPI.Models.Interfaces;
using CarDealershipAPI.Models.VehicleModels;

namespace CarDealershipAPI.Data.Repositories.ADO
{
    public class ADOVehicleRepository : IVehicleRepository
    {
        public List<Vehicle> GetAll()
        {
            List<Vehicle> list = new List<Vehicle>();
            string[] valuesNeeded =
            {
                "VehicleID", "StaffID", "MakeID", "ModelID", "InteriorID", "BodyStyle",  "Year", "Transmission", "Color", "Mileage",
                "VIN", "MSRP", "SalePrice", "Description", "PicturePath", "Category", "Featured", "Sold"
            };
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllVehicles");
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        List<string> values = new List<string>(valuesNeeded.Length);
                        for (int i = 0; i < valuesNeeded.Length; i++)
                        {
                            values.Add(reader[valuesNeeded[i]].ToString());
                        }

                        Vehicle vehicle = MapToVehicle(values);
                        if (vehicle != null)
                            list.Add(vehicle);
                    }
                }
            }

            return list;
        }

        public Vehicle Get(int vehicleID)
        {
            return GetAll().FirstOrDefault(v => v.VehicleID.Equals(vehicleID));
        }

        public int AddVehicle(Vehicle vehicle)
        {
            int nextID = GetAll().Max(v => v.VehicleID) + 1;
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddVehicle");
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StaffID", vehicle.StaffID);
                command.Parameters.AddWithValue("@MakeID", vehicle.MakeID);
                command.Parameters.AddWithValue("@ModelID", vehicle.ModelID);
                command.Parameters.AddWithValue("@InteriorID", vehicle.InteriorID);
                command.Parameters.AddWithValue("@BodyStyle", vehicle.BodyStyle);
                command.Parameters.AddWithValue("@Year", vehicle.Year);
                command.Parameters.AddWithValue("@Transmission", vehicle.Transmission);
                command.Parameters.AddWithValue("@Color", vehicle.Color);
                command.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                command.Parameters.AddWithValue("@VIN", vehicle.VIN);
                command.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                command.Parameters.AddWithValue("@SalePrice", vehicle.SalePrice);
                command.Parameters.AddWithValue("@Description", vehicle.Description);
                command.Parameters.AddWithValue("@PicturePath", vehicle.PicturePath);
                command.Parameters.AddWithValue("@Category", vehicle.Category);
                command.Parameters.AddWithValue("@Featured", vehicle.Featured);
                command.Parameters.AddWithValue("@Sold", vehicle.Sold);

                command.ExecuteNonQuery();
            }
            return nextID;
        }

        public void EditVehicle(Vehicle vehicle)
        {
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("EditVehicle");
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@VehicleID", vehicle.VehicleID);
                command.Parameters.AddWithValue("@MakeID", vehicle.MakeID);
                command.Parameters.AddWithValue("@ModelID", vehicle.ModelID);
                command.Parameters.AddWithValue("@InteriorID", vehicle.InteriorID);
                command.Parameters.AddWithValue("@BodyStyle", vehicle.BodyStyle);
                command.Parameters.AddWithValue("@Year", vehicle.Year);
                command.Parameters.AddWithValue("@Transmission", vehicle.Transmission);
                command.Parameters.AddWithValue("@Color", vehicle.Color);
                command.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                command.Parameters.AddWithValue("@VIN", vehicle.VIN);
                command.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                command.Parameters.AddWithValue("@SalePrice", vehicle.SalePrice);
                command.Parameters.AddWithValue("@Description", vehicle.Description);
                command.Parameters.AddWithValue("@PicturePath", vehicle.PicturePath);
                command.Parameters.AddWithValue("@Category", vehicle.Category);
                command.Parameters.AddWithValue("@Featured", vehicle.Featured);
                command.Parameters.AddWithValue("@Sold", vehicle.Sold);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteVehicle(int vehicleID)
        {
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DeleteVehicle");
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@VehicleID", vehicleID);

                command.ExecuteNonQuery();
            }
        }

        private Vehicle MapToVehicle(List<string> values)
        {
            if (values.Count != 18) return null;
            Vehicle vehicle = new Vehicle();
            vehicle.VehicleID = int.Parse(values.ElementAt(0));
            vehicle.StaffID = int.Parse(values.ElementAt(1));
            vehicle.MakeID = int.Parse(values.ElementAt(2));
            vehicle.ModelID = int.Parse(values.ElementAt(3));
            vehicle.InteriorID = int.Parse(values.ElementAt(4));
            vehicle.BodyStyle = values.ElementAt(5);
            vehicle.Year = int.Parse(values.ElementAt(6));
            vehicle.Transmission = values.ElementAt(7);
            vehicle.Color = values.ElementAt(8);
            vehicle.Mileage = int.Parse(values.ElementAt(9));
            vehicle.VIN = values.ElementAt(10);
            vehicle.MSRP = decimal.Parse(values.ElementAt(11));
            vehicle.SalePrice = decimal.Parse(values.ElementAt(12));
            vehicle.Description = values.ElementAt(13);
            vehicle.PicturePath = values.ElementAt(14);
            vehicle.Category = values.ElementAt(15);
            vehicle.Featured = bool.Parse(values.ElementAt(16));
            vehicle.Sold = bool.Parse(values.ElementAt(17));

            return vehicle;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CarDealershipAPI.Logic;
using CarDealershipAPI.Models.Interfaces;
using CarDealershipAPI.Models.Sales;

namespace CarDealershipAPI.Data.Repositories.ADO
{
    public class ADOSalesRepository : ISalesRepository
    {
        public List<VehicleSale> GetAll()
        {
            List<VehicleSale> list = new List<VehicleSale>();
            string[] valuesNeeded = {"VehicleSaleID", "StaffID", "DateSold", "AmountSoldFor"};
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllVehicleSales");
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

                        VehicleSale sale = MapToVehicleSale(values);
                        if (sale != null)
                            list.Add(sale);
                    }
                }
            }
            return list;
        }

        public void AddSale(VehicleSale sale)
        {
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddVehicleSale");
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StaffID", sale.StaffID);
                command.Parameters.AddWithValue("@DateSold", sale.DateSold);
                command.Parameters.AddWithValue("@AmountSoldFor", sale.AmountSoldFor);

                command.ExecuteNonQuery();
            }
        }

        private VehicleSale MapToVehicleSale(List<string> values)
        {
            if (values.Count != 4) return null;
            VehicleSale sale = new VehicleSale();
            sale.VehicleSaleID = int.Parse(values.ElementAt(0));
            sale.StaffID = int.Parse(values.ElementAt(1));
            sale.DateSold = DateTime.Parse(values.ElementAt(2));
            sale.AmountSoldFor = decimal.Parse(values.ElementAt(3));

            return sale;
        }
    }
}
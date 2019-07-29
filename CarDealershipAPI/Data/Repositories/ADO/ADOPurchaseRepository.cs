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
    public class ADOPurchaseRepository : IPurchaseRepository
    {
        public List<Purchase> GetAll()
        {
            List<Purchase> list = new List<Purchase>();
            string[] valuesNeeded =
            {
                "PurchaseID", "Name", "PhoneNumber", "Email", "Street1", "Street2", "City", "State", "ZipCode",
                "PurchasePrice", "PurchaseType", "PurchaseDate"
            };
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllPurchases");
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        List<string> values = new List<string>(valuesNeeded.Length);
                        for (int i = 0; i < valuesNeeded.Length; i++)
                        {
                            values.Add(reader[valuesNeeded[i]].ToString());
                        }

                        Purchase purchase = MapToPurchase(values);
                        if (purchase != null)
                            list.Add(purchase);
                    }
                }
            }
            return list;
        }

        public void AddPurchase(Purchase purchase)
        {
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddPurchase");
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", purchase.Name);
                command.Parameters.AddWithValue("@PhoneNumber", purchase.PhoneNumber);
                command.Parameters.AddWithValue("@Email", purchase.Email);
                command.Parameters.AddWithValue("@Street1", purchase.Street1);
                command.Parameters.AddWithValue("@Street2",
                    string.IsNullOrEmpty(purchase.Street2) ? "" : purchase.Street2);
                command.Parameters.AddWithValue("@City", purchase.City);
                command.Parameters.AddWithValue("@State", purchase.State);
                command.Parameters.AddWithValue("@ZipCode", purchase.ZipCode);
                command.Parameters.AddWithValue("@PurchasePrice", purchase.PurchasePrice);
                command.Parameters.AddWithValue("@PurchaseType", purchase.PurchaseType);
                command.Parameters.AddWithValue("@PurchaseDate", purchase.PurchaseDate);

                command.ExecuteNonQuery();
            }
        }

        private Purchase MapToPurchase(List<string> values)
        {
            if (values.Count != 12) return null;
            Purchase purchase = new Purchase();
            purchase.PurchaseID = int.Parse(values.ElementAt(0));
            purchase.Name = values.ElementAt(1);
            purchase.PhoneNumber = values.ElementAt(2);
            purchase.Email = values.ElementAt(3);
            purchase.Street1 = values.ElementAt(4);
            purchase.Street2 = values.ElementAt(5);
            purchase.City = values.ElementAt(6);
            purchase.State = values.ElementAt(7);
            purchase.ZipCode = int.Parse(values.ElementAt(8));
            purchase.PurchasePrice = decimal.Parse(values.ElementAt(9));
            purchase.PurchaseType = values.ElementAt(10);
            purchase.PurchaseDate = DateTime.Parse(values.ElementAt(11));

            return purchase;
        }

    }
}
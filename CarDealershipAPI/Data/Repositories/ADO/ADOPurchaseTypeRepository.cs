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
    public class ADOPurchaseTypeRepository : IPurchaseTypeRepository
    {
        public List<PurchaseType> GetAll()
        {
            List<PurchaseType> list = new List<PurchaseType>();
            string[] valuesNeeded = {"PurchaseTypeID", "PurchaseTypeName"};

            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllPurchaseTypes");
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

                        PurchaseType type = MapToPurchaseType(values);
                        if (type != null)
                            list.Add(type);
                    }
                }
            }

            return list;
        }

        public PurchaseType GetById(int purchaseTypeID)
        {
            return GetAll().FirstOrDefault(p => p.PurchaseTypeID.Equals(purchaseTypeID));
        }

        private PurchaseType MapToPurchaseType(List<string> values)
        {
            if (values.Count != 2) return null;
            PurchaseType type = new PurchaseType();
            type.PurchaseTypeID = int.Parse(values.ElementAt(0));
            type.PurchaseTypeName = values.ElementAt(1);

            return type;
        }
    }
}
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
    public class ADOInteriorRepository : IInteriorRepository
    {
        public List<Interior> GetAll()
        {
            List<Interior> list = new List<Interior>();
            string[] valuesNeeded = { "InteriorID", "InteriorName" };
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllInteriors");
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

                        Interior interior = MapToInterior(values);
                        if (interior != null)
                            list.Add(interior);

                    }
                }
            }

            return list;
        }

        public Interior Get(int interiorID)
        {
            return GetAll().FirstOrDefault(i => i.InteriorID.Equals(interiorID));
        }

        private Interior MapToInterior(List<string> values)
        {
            if (values.Count != 2) return null;
            Interior interior = new Interior();
            interior.InteriorID = int.Parse(values.ElementAt(0));
            interior.InteriorName = values.ElementAt(1);

            return interior;
        }
    }
}
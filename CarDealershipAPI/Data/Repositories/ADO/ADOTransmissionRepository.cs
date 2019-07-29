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
    public class ADOTransmissionRepository : ITransmissionTypeRepository
    {
        public List<Transmission> GetAll()
        {
            List<Transmission> list = new List<Transmission>();
            string[] valuesNeeded = {"TransmissionID", "TransmissionName"};
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllTransmissions");
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

                        Transmission transmission = MapToTransmission(values);
                        if (transmission != null) 
                            list.Add(transmission);
                    }
                }
            }

            return list;
        }

        public Transmission Get(int transmissionTypeID)
        {
            return GetAll().FirstOrDefault(t => t.TransmissionID.Equals(transmissionTypeID));
        }

        public int GetID(string transmissionName)
        {
            Transmission transmission =
                GetAll().FirstOrDefault(t => t.TransmissionName.ToLower().Equals(transmissionName.ToLower()));
            return transmission?.TransmissionID ?? 1;
        }

        private Transmission MapToTransmission(List<string> values)
        {
            if (values.Count != 2) return null;
            Transmission transmission = new Transmission();
            transmission.TransmissionID = int.Parse(values.ElementAt(0));
            transmission.TransmissionName = values.ElementAt(1);

            return transmission;
        }

    }
}
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
    public class ADOMakeRepository : IMakeRepository
    {
        public List<Make> GetAll()
        {
            List<Make> list = new List<Make>();
            string[] valuesNeeded = {"MakeID", "MakeName", "DateAdded", "StaffID"};
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllMakes");
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

                        Make make = MapToMake(values);
                        if (make != null)
                            list.Add(make);
                    }
                }
            }
            return list;
        }

        public Make GetById(int makeID)
        {
            return GetAll().FirstOrDefault(m => m.MakeID.Equals(makeID));
        }

        public int GetMakeId(string makeName)
        {
            Make make = GetAll().FirstOrDefault(m => m.MakeName.ToLower().Equals(makeName.ToLower()));
            return make?.MakeID ?? 1;
        }

        public void AddMake(Make make)
        {
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddMake");
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MakeName", make.MakeName);
                command.Parameters.AddWithValue("@DateAdded", make.DateAdded);
                command.Parameters.AddWithValue("@StaffID", make.StaffId);

                command.ExecuteNonQuery();
            }
        }

        private Make MapToMake(List<string> values)
        {
            if (values.Count != 4) return null;
            Make make = new Make();
            make.MakeID = int.Parse(values.ElementAt(0));
            make.MakeName = values.ElementAt(1);
            make.DateAdded = DateTime.Parse(values.ElementAt(2));
            make.StaffId = int.Parse(values.ElementAt(3));

            return make;
        }

    }
}
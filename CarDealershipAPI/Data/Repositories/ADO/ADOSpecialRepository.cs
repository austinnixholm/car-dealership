using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CarDealershipAPI.Logic;
using CarDealershipAPI.Models.Interfaces;
using CarDealershipAPI.Models.Site;

namespace CarDealershipAPI.Data.Repositories.ADO
{
    public class ADOSpecialRepository : ISpecialRepository
    {
        public List<Special> GetAll()
        {
            List<Special> list = new List<Special>();
            string[] valuesNeeded = {"SpecialID", "SpecialTitle", "SpecialDescription"};
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllSpecials");
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

                        Special special = MapToSpecial(values);
                        if (special != null)
                            list.Add(special);

                    }
                }
            }
            return list;
        }

        public void AddSpecial(Special special)
        {
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddSpecial");
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SpecialTitle", special.SpecialTitle);
                command.Parameters.AddWithValue("@SpecialDescription", special.SpecialDescription);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteSpecial(int specialID)
        {
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DeleteSpecial");
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SpecialID", specialID);
                command.ExecuteNonQuery();
            }
        }

        private Special MapToSpecial(List<string> values)
        {
            if (values.Count != 3) return null;
            Special special = new Special();
            special.SpecialID = int.Parse(values.ElementAt(0));
            special.SpecialTitle = values.ElementAt(1);
            special.SpecialDescription = values.ElementAt(2);

            return special;
        }

    }
}
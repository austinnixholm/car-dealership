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
    public class ADOColorRepository : IColorRepository
    {
        public List<Color> GetAll()
        {
            List<Color> list = new List<Color>();
            string[] valuesNeeded = {"ColorID", "ColorName"};
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllColors");
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

                        Color color = MapToColor(values);
                        if (color != null)
                            list.Add(color);
                    }
                }
            }

            return list;
        }

        public Color Get(int colorID)
        {
            return GetAll().FirstOrDefault(c => c.ColorID.Equals(colorID));
        }

        public int GetID(string colorName)
        {
            Color found = GetAll().FirstOrDefault(c => c.ColorName.ToLower().Equals(colorName.ToLower()));
            return found?.ColorID ?? 1;
        }

        private Color MapToColor(List<string> values)
        {
            if (values.Count != 2) return null;
            Color color = new Color();
            color.ColorID = int.Parse(values.ElementAt(0));
            color.ColorName = values.ElementAt(1);

            return color;
        }
    }
}
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
    public class ADOBodyStyleRepository : IBodyStyleRepository
    {
        public List<BodyStyle> GetAll()
        {
            List<BodyStyle> list = new List<BodyStyle>();
            string[] neededValues = {"BodyStyleID", "Style"};
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllBodyStyles");
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        List<string> values = new List<string>(neededValues.Length);
                        for (int i = 0; i < neededValues.Length; i++)
                        {
                            values.Add(reader[neededValues[i]].ToString());
                        }

                        BodyStyle style = MapToBodyStyle(values);
                        if (style != null)
                            list.Add(style);
                    }
                }
            }

            return list;
        }

        public BodyStyle Get(int bodyStyleID)
        {
            return GetAll().FirstOrDefault(b => b.BodyStyleID.Equals(bodyStyleID));
        }

        public BodyStyle GetByName(string style)
        {
            return GetAll().FirstOrDefault(b => b.Style.ToLower().Equals(style.ToLower()));
        }

        private BodyStyle MapToBodyStyle(List<string> values)
        {
            if (values.Count != 2) return null;
            BodyStyle style = new BodyStyle();
            style.BodyStyleID = int.Parse(values.ElementAt(0));
            style.Style = values.ElementAt(1);

            return style;
        }
    }
}
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
    public class ADOModelRepository : IModelRepository
    {
        public List<Model> GetAll()
        {
            List<Model> list = new List<Model>();
            string[] valuesNeeded = {"ModelID", "ModelName", "MakeID", "BodyStyleID", "StaffID", "DateAdded"};
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllModels");
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

                        Model model = MapToModel(values);
                        if (model != null)
                            list.Add(model);
                    }
                }
            }

            return list;
        }

        public List<Model> GetAllByMake(int makeID)
        {
            List<Model> models = GetAll();
            return (from Model m in models
                where m.MakeID.Equals(makeID)
                select m).ToList();
        }

        public Model GetById(int modelID)
        {
            return GetAll().FirstOrDefault(m => m.ModelID.Equals(modelID));
        }

        public void AddModel(Model model)
        {
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddModel");
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ModelName", model.ModelName);
                command.Parameters.AddWithValue("@MakeID", model.MakeID);
                command.Parameters.AddWithValue("@BodyStyleID", model.BodyStyleID);
                command.Parameters.AddWithValue("StaffID", model.StaffId);
                command.Parameters.AddWithValue("@DateAdded", model.DateAdded);

                command.ExecuteNonQuery();
            }
        }

        private Model MapToModel(List<string> values)
        {
            if (values.Count != 6) return null;
            Model model = new Model();
            model.ModelID = int.Parse(values.ElementAt(0));
            model.ModelName = values.ElementAt(1);
            model.MakeID = int.Parse(values.ElementAt(2));
            model.BodyStyleID = int.Parse(values.ElementAt(3));
            model.StaffId = int.Parse(values.ElementAt(4));
            model.DateAdded = DateTime.Parse(values.ElementAt(5));

            return model;
        }
        
    }
}
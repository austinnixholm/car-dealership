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
    public class ADOStateRepository : IStateRepository
    {
        public List<State> GetAll()
        {
            List<State> list = new List<State>();
            string[] valuesNeeded = {"StateAbbreviation", "StateName"};
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllStates");
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

                        State state = MapToState(values);
                        if (state != null)
                            list.Add(state);
                    }
                }
            }

            return list;
        }

        public State GetByAbbreviation(string stateAbbreviation)
        {
            return GetAll().FirstOrDefault(s => s.StateAbbreviation.ToLower().Equals(stateAbbreviation.ToLower()));
        }

        private State MapToState(List<string> values)
        {
            if (values.Count != 2) return null;
            State state = new State();
            state.StateAbbreviation = values.ElementAt(0);
            state.StateName = values.ElementAt(1);

            return state;
        }
    }
}
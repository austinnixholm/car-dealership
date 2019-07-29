using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CarDealershipAPI.Logic;
using CarDealershipAPI.Models.Interfaces;
using CarDealershipAPI.Models.Staff;

namespace CarDealershipAPI.Data.Repositories.ADO
{
    public class ADOStaffRoleRepository : IStaffRoleRepository
    {
        public List<StaffRole> GetAll()
        {
            List<StaffRole> list = new List<StaffRole>();
            string[] valuesNeeded = {"StaffRoleID", "RoleName"};
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllStaffRoles");
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

                        StaffRole role = MapToStaffRole(values);
                        if (role != null)
                            list.Add(role);
                    }
                }
            }

            return list;
        }

        public StaffRole GetById(int staffRoleID)
        {
            return GetAll().FirstOrDefault(s => s.StaffRoleID.Equals(staffRoleID));
        }

        private StaffRole MapToStaffRole(List<string> values)
        {
            if (values.Count != 2) return null;
            StaffRole role = new StaffRole();
            role.StaffRoleID = int.Parse(values.ElementAt(0));
            role.RoleName = values.ElementAt(1);

            return role;
        }

    }
}
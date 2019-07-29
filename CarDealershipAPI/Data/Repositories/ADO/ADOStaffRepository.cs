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
    public class ADOStaffRepository : IStaffMemberRepository
    {
        public List<StaffMember> GetAll()
        {
            List<StaffMember> list = new List<StaffMember>();
            string[] valuesNeeded = {"StaffID", "Name", "Email", "Password", "StaffRoleID"};
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllUsers");
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

                        StaffMember staff = MapToStaffMember(values);
                        if (staff != null)
                            list.Add(staff);
                    }
                }
            }
            return list;
        }

        public StaffMember GetById(int staffID)
        {
            return GetAll().FirstOrDefault(s => s.StaffID.Equals(staffID));
        }

        public void AddStaffMember(StaffMember staffMember)
        {
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddUser");
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", staffMember.Name);
                command.Parameters.AddWithValue("@Email", staffMember.Email);
                command.Parameters.AddWithValue("@Password", staffMember.Password);
                command.Parameters.AddWithValue("@StaffRoleID", staffMember.StaffRoleID);

                command.ExecuteNonQuery();
            }
        }

        public void EditStaffMember(StaffMember staffMember)
        {
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("EditUser");
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StaffID", staffMember.StaffID);
                command.Parameters.AddWithValue("@Name", staffMember.Name);
                command.Parameters.AddWithValue("@Email", staffMember.Email);
                command.Parameters.AddWithValue("@Password", staffMember.Password);
                command.Parameters.AddWithValue("@StaffRoleID", staffMember.StaffRoleID);

                command.ExecuteNonQuery();
            }
        }

        private StaffMember MapToStaffMember(List<string> values)
        {
            if (values.Count != 5) return null;
            StaffMember staff = new StaffMember();
            staff.StaffID = int.Parse(values.ElementAt(0));
            staff.Name = values.ElementAt(1);
            staff.Email = values.ElementAt(2);
            staff.Password = values.ElementAt(3);
            staff.StaffRoleID = int.Parse(values.ElementAt(4));

            return staff;
        }

    }
}
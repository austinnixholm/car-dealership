using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CarDealershipAPI.Logic;
using CarDealershipAPI.Models.Customer;
using CarDealershipAPI.Models.Interfaces;

namespace CarDealershipAPI.Data.Repositories.ADO
{
    public class ADOContactRepository : IContactRepository
    {
        public List<Contact> GetAll()
        {
            List<Contact> list = new List<Contact>();
            string[] valuesNeeded = {"ContactID", "Name", "Email", "PhoneNumber", "Message"};
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllContacts");
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

                        Contact contact = MapToContact(values);
                        if (contact != null)
                            list.Add(contact);
                    }
                }
            }
            return list;
        }

        public Contact GetByID(int contactID)
        {
            return GetAll().FirstOrDefault(c => c.ContactID.Equals(contactID));
        }

        public void AddContact(Contact contact)
        {
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddContact");
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", contact.Name);
                command.Parameters.AddWithValue("@Email", contact.Email);
                command.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
                command.Parameters.AddWithValue("@Message", contact.Message);

                command.ExecuteNonQuery();
            }
        }

        private Contact MapToContact(List<string> values)
        {
            if (values.Count != 5) return null;
            Contact contact = new Contact();
            contact.ContactID = int.Parse(values.ElementAt(0));
            contact.Name = values.ElementAt(1);
            contact.Email = values.ElementAt(2);
            contact.PhoneNumber = values.ElementAt(3);
            contact.Message = values.ElementAt(4);

            return contact;
        }
    }
}
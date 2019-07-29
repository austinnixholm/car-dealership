using System.Collections.Generic;
using System.Linq;
using CarDealershipAPI.Models.Customer;
using CarDealershipAPI.Models.Interfaces;

namespace CarDealershipAPI.Data.Repositories.Mock
{
    public class MockContactRepository : IContactRepository
    {
        private List<Contact> _contacts = new List<Contact>();

        public List<Contact> GetAll()
        {
            return _contacts;
        }

        public Contact GetByID(int contactID)
        {
            return _contacts.FirstOrDefault(c => c.ContactID.Equals(contactID));
        }

        public void AddContact(Contact contact)
        {
            contact.ContactID = _contacts.Count <= 0 ? 1 : _contacts.Max(c => c.ContactID) + 1;
            _contacts.Add(contact);
        }
    }
}
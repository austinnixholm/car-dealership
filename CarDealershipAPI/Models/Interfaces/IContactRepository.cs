using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealershipAPI.Models.Customer;

namespace CarDealershipAPI.Models.Interfaces
{
    public interface IContactRepository
    {
        List<Contact> GetAll();
        Contact GetByID(int contactID);
        void AddContact(Contact contact);
    }
}

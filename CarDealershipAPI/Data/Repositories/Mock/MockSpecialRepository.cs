using System.Collections.Generic;
using System.Linq;
using CarDealershipAPI.Models.Interfaces;
using CarDealershipAPI.Models.Site;

namespace CarDealershipAPI.Data.Repositories.Mock
{
    public class MockSpecialRepository : ISpecialRepository
    {
        private List<Special> _specials = new List<Special>()
        {
            new Special()
            {
                SpecialID = 1,
                SpecialTitle = "TWO FOR ONE VEHICLE SPECIAL!",
                SpecialDescription = "Get two vehicles for the price of one! Just don't get held down by all of the insurance fees & taxes."
            },
            new Special()
            {
                SpecialID = 2,
                SpecialTitle = "DOWN PAYMENT LUXURY SPECIAL!",
                SpecialDescription = "We'll add luxury interior, dash functions & a brand new sound system to your vehicle! Must put a down payment of at least one half of the total price of vehicle to qualify."
            },
            new Special()
            {
                SpecialID = 3,
                SpecialTitle = "BUY TWO GET LIFETIME WARRANTY!",
                SpecialDescription = "If you purchase two vehicle within the same day, we will provide lifetime warranty to your favorite vehicle of the two! Does not include collisions that are of the recipients fault."
            }
        };

        public List<Special> GetAll()
        {
            return _specials;
        }

        public Special GetById(int specialID)
        {
            return _specials.FirstOrDefault(s => s.SpecialID.Equals(specialID));
        }

        public void AddSpecial(Special special)
        {
            special.SpecialID = _specials.Max(s => s.SpecialID) + 1;
            _specials.Add(special);
        }

        public void EditSpecial(Special special)
        {
            Special old = _specials.FirstOrDefault(s => s.SpecialID.Equals(special.SpecialID));
            old.SpecialTitle = special.SpecialTitle;
            old.SpecialDescription = special.SpecialDescription;
        }

        public void DeleteSpecial(int specialID)
        {
            _specials.RemoveAll(s => s.SpecialID.Equals(specialID));
        }
    }
}
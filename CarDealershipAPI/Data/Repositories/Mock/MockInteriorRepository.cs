using System.Collections.Generic;
using System.Linq;
using CarDealershipAPI.Models.Interfaces;
using CarDealershipAPI.Models.VehicleModels;

namespace CarDealershipAPI.Data.Repositories.Mock
{
    public class MockInteriorRepository : IInteriorRepository
    {
        private List<Interior> _interiors = new List<Interior>()
        {
            new Interior()
            {
                InteriorID = 1,
                InteriorName = "Black Fabric"
            },
            new Interior()
            {
                InteriorID = 2,
                InteriorName = "Beige"
            },
            new Interior()
            {
                InteriorID = 3,
                InteriorName = "Leather"
            },
        };

        public List<Interior> GetAll()
        {
            return _interiors;
        }

        public Interior Get(int interiorID)
        {
            return _interiors.FirstOrDefault(i => i.InteriorID.Equals(interiorID));
        }
    }
}
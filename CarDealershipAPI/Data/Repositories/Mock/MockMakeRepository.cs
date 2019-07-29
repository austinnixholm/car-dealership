using System;
using System.Collections.Generic;
using System.Linq;
using CarDealershipAPI.Models.Interfaces;
using CarDealershipAPI.Models.VehicleModels;

namespace CarDealershipAPI.Data.Repositories.Mock
{
    public class MockMakeRepository :IMakeRepository
    {
        private List<Make> _makes = new List<Make>()
        {
            new Make()
            {
                MakeID = 1,
                MakeName = "Nissan",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Make()
            {
                MakeID = 2,
                MakeName = "Toyota",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Make()
            {
                MakeID = 3,
                MakeName = "Chevrolet",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Make()
            {
                MakeID = 4,
                MakeName = "Hyundai",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Make()
            {
                MakeID = 5,
                MakeName = "Ford",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Make()
            {
                MakeID = 6,
                MakeName = "Tesla",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Make()
            {
                MakeID = 7,
                MakeName = "Dodge",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Make()
            {
                MakeID = 8,
                MakeName = "Jeep",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Make()
            {
                MakeID = 9,
                MakeName = "GMC",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Make()
            {
                MakeID = 10,
                MakeName = "Mercedes Benz",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Make()
            {
                MakeID = 11,
                MakeName = "BMW",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Make()
            {
                MakeID = 12,
                MakeName = "Subaru",
                DateAdded = DateTime.Today,
                StaffId = 2
            }
        };

        public int GetMakeId(string makeName)
        {
            Make make = _makes.FirstOrDefault(m => m.MakeName.ToLower().Equals(makeName.ToLower()));
            return make != null ? make.MakeID : -1;
        }
        
        public List<Make> GetAll()
        {
            return _makes;
        }

        public List<Make> GetAllByName(string makeName)
        {
            return (from Make m in _makes
                where m.MakeName.ToLower().Equals(makeName.ToLower())
                select m).ToList();
        }

        public Make GetById(int makeID)
        {
            return _makes.FirstOrDefault(m => m.MakeID.Equals(makeID));
        }

        public void AddMake(Make make)
        {
            make.MakeID = _makes.Max(m => m.MakeID) + 1;
            _makes.Add(make);
        }

        public void EditMake(Make make)
        {
            Make old = GetById(make.MakeID);
            if (old == null) return;
            old.MakeName = make.MakeName;
        }

        public void DeleteMake(int makeID)
        {
            _makes.RemoveAll(m => m.MakeID.Equals(makeID));
        }
    }
}
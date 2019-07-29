using System;
using System.Collections.Generic;
using System.Linq;
using CarDealershipAPI.Models.Interfaces;
using CarDealershipAPI.Models.VehicleModels;

namespace CarDealershipAPI.Data.Repositories.Mock
{
    public class MockModelRepository : IModelRepository
    {
        private List<Model> _models = new List<Model>()
        {
            new Model()
            {
                ModelID = 1,
                BodyStyleID = (int) BodyStyles.Sedan,
                MakeID = 1,
                ModelName = "Altima",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 2,
                BodyStyleID = (int) BodyStyles.Sedan,
                MakeID = 2,
                ModelName = "Camry",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 3,
                BodyStyleID = (int) BodyStyles.Sedan,
                MakeID = 2,
                ModelName = "Corolla",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 4,
                BodyStyleID = (int) BodyStyles.Hatchback,
                MakeID = 4,
                ModelName = "Elantra GT",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 4,
                BodyStyleID = (int) BodyStyles.Sedan,
                MakeID = 4,
                ModelName = "Sonata",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 5,
                BodyStyleID = (int) BodyStyles.SUV,
                MakeID = 1,
                ModelName = "Rogue",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 6,
                BodyStyleID = (int) BodyStyles.Sedan,
                MakeID = 6,
                ModelName = "Model S",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 7,
                BodyStyleID = (int) BodyStyles.SUV,
                MakeID = 8,
                ModelName = "Wrangler",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 8,
                BodyStyleID = (int) BodyStyles.SUV,
                MakeID = 8,
                ModelName = "Cherokee",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 9,
                BodyStyleID = (int) BodyStyles.Sedan,
                MakeID = 10,
                ModelName = "A-Class",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 10,
                BodyStyleID = (int) BodyStyles.Sedan,
                MakeID = 10,
                ModelName = "C-Class",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 11,
                BodyStyleID = (int) BodyStyles.Sedan,
                MakeID = 10,
                ModelName = "E-Class",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 12,
                BodyStyleID = (int) BodyStyles.Sedan,
                MakeID = 10,
                ModelName = "S-Class",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 10,
                BodyStyleID = (int) BodyStyles.Sedan,
                MakeID = 10,
                ModelName = "C-Class",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 11,
                BodyStyleID = (int) BodyStyles.Hatchback,
                MakeID = 12,
                ModelName = "WRX",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 12,
                BodyStyleID = (int) BodyStyles.Hatchback,
                MakeID = 12,
                ModelName = "Outback",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 13,
                BodyStyleID = (int) BodyStyles.Hatchback,
                MakeID = 12,
                ModelName = "Forester",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 14,
                BodyStyleID = (int) BodyStyles.Sedan,
                MakeID = 7,
                ModelName = "Charger",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 15,
                BodyStyleID = (int) BodyStyles.Sedan,
                MakeID = 7,
                ModelName = "Challenger",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 16,
                BodyStyleID = (int) BodyStyles.Sedan,
                MakeID = 5,
                ModelName = "Focus",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 15,
                BodyStyleID = (int) BodyStyles.Hatchback,
                MakeID = 5,
                ModelName = "Focus RS",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 16,
                BodyStyleID = (int) BodyStyles.Pickup,
                MakeID = 9,
                ModelName = "Sierra",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 17,
                BodyStyleID = (int) BodyStyles.SUV,
                MakeID = 9,
                ModelName = "Acadia",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 18,
                BodyStyleID = (int) BodyStyles.Coupe,
                MakeID = 11,
                ModelName = "E9",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 19,
                BodyStyleID = (int) BodyStyles.Sedan,
                MakeID = 3,
                ModelName = "Malibu",
                DateAdded = DateTime.Today,
                StaffId = 2
            },
            new Model()
            {
                ModelID = 20,
                BodyStyleID = (int) BodyStyles.SUV,
                MakeID = 3,
                ModelName = "Suburban",
                DateAdded = DateTime.Today,
                StaffId = 2
            }
        };

        public List<Model> GetAll()
        {
            return _models;
        }

        public List<Model> GetAllByName(string modelName)
        {
            List<Model> models = new List<Model>();
            foreach (Model m in _models)
            {
                if (m.ModelName.ToLower().Contains(modelName)) models.Add(m);
            }

            return models;
        }

        public List<Model> GetAllByMake(int makeID)
        {
            return (from Model m in _models
                where m.MakeID.Equals(makeID)
                select m).ToList();
        }

        public Model GetById(int modelID)
        {
            return _models.FirstOrDefault(m => m.ModelID.Equals(modelID));
        }

        public void AddModel(Model model)
        {
            model.ModelID = _models.Max(m => m.ModelID) + 1;
            _models.Add(model);
        }

        public void EditModel(Model model)
        {
            Model old = GetById(model.ModelID);
            if (old == null) return;
            old.BodyStyleID = model.BodyStyleID;
            old.MakeID = model.MakeID;
            old.ModelName = model.ModelName;
        }

        public void DeleteModel(int modelID)
        {
            _models.RemoveAll(m => m.ModelID.Equals(modelID));
        }
    }
}
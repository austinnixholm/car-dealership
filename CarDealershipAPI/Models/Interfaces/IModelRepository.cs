using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarDealershipAPI.Models.VehicleModels;

namespace CarDealershipAPI.Models.Interfaces
{
    public interface IModelRepository
    {
        List<Model> GetAll();
        List<Model> GetAllByMake(int makeID);
        Model GetById(int modelID);
        void AddModel(Model model);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarDealershipAPI.Models.VehicleModels;

namespace CarDealershipAPI.Models.Interfaces
{
    public interface IMakeRepository
    {
        List<Make> GetAll();
        Make GetById(int makeID);
        int GetMakeId(string makeName);
        void AddMake(Make make);
    }
}
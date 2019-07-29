using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarDealershipAPI.Models.VehicleModels;

namespace CarDealershipAPI.Models.Interfaces
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAll();
        Vehicle Get(int vehicleID);
        int AddVehicle(Vehicle vehicle);
        void EditVehicle(Vehicle vehicle);
        void DeleteVehicle(int vehicleID);
    }
}
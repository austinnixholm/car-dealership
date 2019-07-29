using System;
using System.Collections.Generic;
using System.Linq;
using CarDealershipAPI.Models.Interfaces;
using CarDealershipAPI.Models.VehicleModels;

namespace CarDealershipAPI.Data.Repositories.Mock
{
    public class MockVehicleRepository : IVehicleRepository
    {
        private List<Vehicle> _vehicles = new List<Vehicle>()
        {
            new Vehicle()
            {
                VehicleID = 1,
                MakeID = 1,
                ModelID = 1,
                Transmission = Enum.GetName(typeof(TransmissionTypes), TransmissionTypes.Automatic),
                Color = "Green",
                Description = "A nice green car.",
                Featured = true,
                InteriorID = 2,
                Mileage = 13500,
                MSRP = 7500.00M,
                PicturePath = "/Content/images/stockcar.jpg",
                SalePrice = 6000.00M,
                StaffID = 1,
                Year = 2005,
                VIN = "34234234234DE121VG",
                Category = "New"
            },
            new Vehicle()
            {
                VehicleID = 2,
                MakeID = 1,
                ModelID = 1,
                Transmission = Enum.GetName(typeof(TransmissionTypes), TransmissionTypes.Manual),
                Color = "Black",
                Description = "A nice black car.",
                Featured = true,
                InteriorID = 1,
                Mileage = 13500,
                MSRP = 4500.00M,
                PicturePath = "/Content/images/stockcar.jpg",
                SalePrice = 3000.00M,
                StaffID = 1,
                Year = 2013,
                VIN = "34234sd234234DE121VG",
                Category = "New"
            },
            new Vehicle()
            {
                VehicleID = 3,
                MakeID = 1,
                ModelID = 1,
                Transmission = Enum.GetName(typeof(TransmissionTypes), TransmissionTypes.Manual),
                Color = "Silver",
                Description = "A nice silver car.",
                Featured = true,
                InteriorID = 2,
                Mileage = 13500,
                MSRP = 4500.00M,
                PicturePath = "/Content/images/stockcar.jpg",
                SalePrice = 3000.00M,
                StaffID = 1,
                Year = 2002,
                VIN = "34234sd234234DE121VG",
                Category = "New"
            },
            new Vehicle()
            {
                VehicleID = 4,
                MakeID = 4,
                ModelID = 4,
                Transmission = Enum.GetName(typeof(TransmissionTypes), TransmissionTypes.Manual),
                Color = "Silver",
                Description = "A nice silver car.",
                Featured = true,
                InteriorID = 2,
                Mileage = 13500,
                MSRP = 8525.00M,
                PicturePath = "/Content/images/stockcar.jpg",
                SalePrice = 3000.00M,
                StaffID = 1,
                Year = 2014,
                VIN = "34234sd234234DE121VG",
                Category = "New"
            },
            new Vehicle()
            {
                VehicleID = 5,
                MakeID = 1,
                ModelID = 5,
                Transmission = Enum.GetName(typeof(TransmissionTypes), TransmissionTypes.Manual),
                Color = "Silver",
                Description = "A nice silver car.",
                Featured = true,
                InteriorID = 1,
                Mileage = 13500,
                MSRP = 12000.00M,
                PicturePath = "/Content/images/stockcar.jpg",
                SalePrice = 3000.00M,
                StaffID = 1,
                Year = 2009,
                VIN = "34234sd234234DE121VG",
                Category = "New"
            },
            new Vehicle()
            {
                VehicleID = 6,
                MakeID = 2,
                ModelID = 3,
                Transmission = Enum.GetName(typeof(TransmissionTypes), TransmissionTypes.Manual),
                Color = "Silver",
                Description = "A nice silver car.",
                Featured = true,
                InteriorID = 3,
                Mileage = 13500,
                MSRP = 2500.00M,
                PicturePath = "/Content/images/stockcar.jpg",
                SalePrice = 3000.00M,
                StaffID = 1,
                Year = 2001,
                VIN = "34234sd234234DE121VG",
                Category = "New"
            },
            new Vehicle()
            {
                VehicleID = 7,
                MakeID = 4,
                ModelID = 4,
                Transmission = Enum.GetName(typeof(TransmissionTypes), TransmissionTypes.Manual),
                Color = "Silver",
                Description = "A nice silver car.",
                Featured = true,
                InteriorID = 2,
                Mileage = 48750,
                MSRP = 4500.00M,
                PicturePath = "/Content/images/stockcar.jpg",
                SalePrice = 3000.00M,
                StaffID = 1,
                Year = 2006,
                VIN = "34234sd234234DE121VG",
                Category = "Used"
            },
            new Vehicle()
            {
                VehicleID = 8,
                MakeID = 1,
                ModelID = 5,
                Transmission = Enum.GetName(typeof(TransmissionTypes), TransmissionTypes.Manual),
                Color = "Silver",
                Description = "A nice silver car.",
                Featured = true,
                InteriorID = 1,
                Mileage = 89300,
                MSRP = 4500.00M,
                PicturePath = "/Content/images/stockcar.jpg",
                SalePrice = 3000.00M,
                StaffID = 1,
                Year = 2012,
                VIN = "34234sd234234DE121VG",
                Category = "Used"
            },
            new Vehicle()
            {
                VehicleID = 9,
                MakeID = 1,
                ModelID = 1,
                Transmission = Enum.GetName(typeof(TransmissionTypes), TransmissionTypes.Manual),
                Color = "Silver",
                Description = "A nice silver car.",
                Featured = true,
                InteriorID = 1,
                Mileage = 43246,
                MSRP = 4500.00M,
                PicturePath = "/Content/images/stockcar.jpg",
                SalePrice = 3000.00M,
                StaffID = 1,
                Year = 2009,
                VIN = "34234sd234234DE121VG",
                Category = "Used"
            },

        };

        public List<Vehicle> GetAll()
        {
            return _vehicles;
        }

        public Vehicle Get(int vehicleID)
        {
            return _vehicles.FirstOrDefault(v => v.VehicleID.Equals(vehicleID));
        }

        public int AddVehicle(Vehicle vehicle)
        {
            vehicle.VehicleID = _vehicles.Max(v => v.VehicleID) + 1;
            _vehicles.Add(vehicle);
            return vehicle.VehicleID;
        }

        public void EditVehicle(Vehicle vehicle)
        {
            Vehicle old = Get(vehicle.VehicleID);
            if (vehicle == null) return;
            old.StaffID = vehicle.StaffID;
            old.MakeID = vehicle.MakeID;
            old.ModelID = vehicle.ModelID;
            old.Year = vehicle.Year;
            old.Transmission = vehicle.Transmission;
            old.Color = vehicle.Color;
            old.InteriorID = vehicle.InteriorID;
            old.Mileage = vehicle.Mileage;
            old.VIN = vehicle.VIN;
            old.MSRP = vehicle.MSRP;
            old.SalePrice = vehicle.SalePrice;
            old.Description = vehicle.Description;
            old.PicturePath = vehicle.PicturePath;
            old.Featured = vehicle.Featured;
            old.Category = vehicle.Category;
            old.Sold = vehicle.Sold;
        }

        public void DeleteVehicle(int vehicleID)
        {
            _vehicles.RemoveAll(v => v.VehicleID.Equals(vehicleID));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CarDealershipAPI.Logic;
using CarDealershipAPI.Models.VehicleModels;
using NUnit.Framework;

namespace CarDealershipAPI.Tests
{
    [TestFixture]
    public class UnitTests
    {
        [SetUp]
        public void ResetDB()
        {
            using (SqlConnection connection = new SqlConnection(Manager.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DBReset", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
        }

        //bad staff id, fail
        [TestCase(0, 1, 1, 2, "Sedan", 2005, "Automatic", "Green", 570, "34234234234DE121VG", 7500.00, 6000.00,
            "A nice green car.", "/Content/images/stockcar.jpg", "New", true, false)]
        //success case
        [TestCase(2, 1, 1, 2, "Sedan", 2005, "Automatic", "Green", 570, "34234234234DE121VG", 7500.00, 6000.00,
            "A nice green car.", "/Content/images/stockcar.jpg", "New", true, false)]
        public void AddVehicleTest(int staffID, int makeID, int modelID, int interiorID, string bodyStyle, int year,
            string transmission, string color, int mileage, string vin, decimal msrp, decimal salePrice,
            string description, string picturePath, string category, bool featured, bool sold)
        {
            Vehicle vehicle = new Vehicle()
            {
                StaffID = staffID,
                MakeID = makeID,
                ModelID = modelID,
                InteriorID = interiorID,
                BodyStyle = bodyStyle,
                Category = category,
                Color = color,
                Description = description,
                Featured = featured,
                Mileage = mileage,
                VIN = vin,
                MSRP = msrp,
                SalePrice = salePrice,
                PicturePath = picturePath,
                Sold = sold,
                Transmission = transmission,
                Year = year
            };
            int id = Manager.VehicleRepository.AddVehicle(vehicle);
            Vehicle newVehicle = Manager.VehicleRepository.Get(id);
            Assert.True(newVehicle != null);
            Assert.AreEqual(newVehicle.StaffID, staffID);
            Assert.AreEqual(newVehicle.MakeID, makeID);
            Assert.AreEqual(newVehicle.ModelID, modelID);
            Assert.AreEqual(newVehicle.InteriorID, interiorID);
            Assert.AreEqual(newVehicle.BodyStyle, bodyStyle);
            Assert.AreEqual(newVehicle.Category, category);
            Assert.AreEqual(newVehicle.Color, color);
            Assert.AreEqual(newVehicle.Description, description);
            Assert.AreEqual(newVehicle.Featured, featured);
            Assert.AreEqual(newVehicle.Mileage, mileage);
            Assert.AreEqual(newVehicle.VIN, vin);
            Assert.AreEqual(newVehicle.MSRP, msrp);
            Assert.AreEqual(newVehicle.SalePrice, salePrice);
            Assert.AreEqual(newVehicle.PicturePath, picturePath);
            Assert.AreEqual(newVehicle.Sold, sold);
            Assert.AreEqual(newVehicle.Transmission, transmission);
            Assert.AreEqual(newVehicle.Year, year);
        }

        //bad vehicle id - fail
        [TestCase(0, 1, 1, 2, "Sedan", 2005, "Automatic", "Green", 570, "34234234234DE121VG", 7500.00, 6000.00,
            "A nice green car.", "/Content/images/stockcar.jpg", "New", true, false)]
        //changed transmission - success
        [TestCase(1, 1, 1, 2, "Sedan", 2005, "Manual", "Green", 570, "34234234234DE121VG", 7500.00, 6000.00,
            "A nice green car.", "/Content/images/stockcar.jpg", "New", true, false)]
        public void EditVehicleTest(int vehicleID, int makeID, int modelID, int interiorID, string bodyStyle, int year,
            string transmission, string color, int mileage, string vin, decimal msrp, decimal salePrice,
            string description, string picturePath, string category, bool featured, bool sold)
        {
            Vehicle old = Manager.VehicleRepository.Get(vehicleID);
            Vehicle vehicle = new Vehicle()
            {
                MakeID = makeID,
                ModelID = modelID,
                InteriorID = interiorID,
                BodyStyle = bodyStyle,
                Category = category,
                Color = color,
                Description = description,
                Featured = featured,
                Mileage = mileage,
                VIN = vin,
                MSRP = msrp,
                SalePrice = salePrice,
                PicturePath = picturePath,
                Sold = sold,
                Transmission = transmission,
                Year = year
            };
            Manager.VehicleRepository.EditVehicle(vehicle);
            Vehicle now = Manager.VehicleRepository.Get(vehicleID);
            bool makeChanged = old.MakeID != now.MakeID;
            bool modelChanged = old.ModelID != now.ModelID;
            bool interiorChanged = old.InteriorID != now.InteriorID;
            bool bodyStyleChanged = old.BodyStyle != now.BodyStyle;
            bool categorychanged = old.Category != now.Category;
            bool colorChanged = old.Color != now.Color;
            bool descriptionChanged = old.Description != now.Description;
            bool featuredChanged = old.Featured != now.Featured;
            bool mileageChanged = old.Mileage != now.Mileage;
            bool vinChanged = old.VIN != now.VIN;
            bool msrpChanged = old.MSRP != now.MSRP;
            bool salePriceChanged = old.SalePrice != now.SalePrice;
            bool picPathChanged = old.PicturePath != now.PicturePath;
            bool soldChanged = old.Sold != now.Sold;
            bool transmissionChanged = old.Transmission != now.Transmission;
            bool yearChanged = old.Year != now.Year;

            Assert.AreEqual(true, (makeChanged || modelChanged || interiorChanged || bodyStyleChanged || categorychanged
                                   || colorChanged || descriptionChanged || featuredChanged || mileageChanged ||
                                   vinChanged
                                   || msrpChanged || salePriceChanged || picPathChanged || soldChanged ||
                                   transmissionChanged || yearChanged));
        }
    }
}
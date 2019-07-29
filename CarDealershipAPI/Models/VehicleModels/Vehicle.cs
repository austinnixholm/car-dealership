using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipAPI.Models.VehicleModels
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public int StaffID { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public int Year { get; set; }
        public string BodyStyle { get; set; }
        public string Transmission { get; set; }
        public string Color { get; set; }
        public int InteriorID { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
        public string Description { get; set; }
        public string PicturePath { get; set; }
        public bool Featured { get; set; }
        public string Category { get; set; }
        public bool Sold { get; set; } = false;
    }
}
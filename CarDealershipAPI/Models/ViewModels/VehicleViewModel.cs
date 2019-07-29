using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarDealershipAPI.Models.Sales;
using CarDealershipAPI.Models.VehicleModels;

namespace CarDealershipAPI.Models.ViewModels
{
    public class VehicleViewModel
    { 
        public Vehicle Vehicle { get; set; }
        public Make Make { get; set; }
        public Model Model { get; set; }
        public BodyStyle BodyStyle { get; set; }
        public Interior Interior { get; set; }

        public PurchaseModel PurchaseModel { get; set; }
    }
}
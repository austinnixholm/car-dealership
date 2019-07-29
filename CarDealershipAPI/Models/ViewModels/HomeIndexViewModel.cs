using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarDealershipAPI.Models.Site;

namespace CarDealershipAPI.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public Special Special { get; set; }
        public List<VehicleViewModel> Vehicles = new List<VehicleViewModel>();
    }
}
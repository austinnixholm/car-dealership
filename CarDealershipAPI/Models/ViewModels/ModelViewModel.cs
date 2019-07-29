using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarDealershipAPI.Models.VehicleModels;

namespace CarDealershipAPI.Models.ViewModels
{
    public class ModelViewModel
    {
        public string Make { get; set; }
        public string BodyStyle { get; set; }
        public Model Model { get; set; }
        public string StaffMemberEmail { get; set; }
    }
}
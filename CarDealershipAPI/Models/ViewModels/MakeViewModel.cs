using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarDealershipAPI.Models.VehicleModels;

namespace CarDealershipAPI.Models.ViewModels
{
    public class MakeViewModel
    {
        public Make Make { get; set; }
        public string StaffMemberEmail { get; set; }
    }
}
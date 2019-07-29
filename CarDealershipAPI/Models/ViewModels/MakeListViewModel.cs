using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarDealershipAPI.Models.VehicleModels;

namespace CarDealershipAPI.Models.ViewModels
{
    public class MakeListViewModel
    {
        public Make NewMake { get; set; }
        public List<MakeViewModel> ViewModels = new List<MakeViewModel>();
    }
}
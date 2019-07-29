using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealershipAPI.Models.VehicleModels;

namespace CarDealershipAPI.Models.ViewModels
{
    public class ModelListViewModel
    {
        public Model NewModel { get; set; }
        public int SelectedMakeID { get; set; }
        public int SelectedBodyStyleID { get; set; }
        public List<SelectListItem> MakesList = new List<SelectListItem>();
        public List<SelectListItem> BodyStylesList = new List<SelectListItem>();
        public List<ModelViewModel> ViewModels { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace CarDealershipAPI.Models.ViewModels
{
    public class AddEditVehicleViewModel
    {
        public List<SelectListItem> Makes = new List<SelectListItem>();
        public List<SelectListItem> BodyStyles = new List<SelectListItem>();
        public List<SelectListItem> Transmissions = new List<SelectListItem>();
        public List<SelectListItem> Colors = new List<SelectListItem>();
        public List<SelectListItem> Interiors = new List<SelectListItem>();
        public List<SelectListItem> Types = new List<SelectListItem>();
        public int VehicleID { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public int BodyStyleID { get; set; }
        public int TransmissionID { get; set; }
        public int ColorID { get; set; }
        public int InteriorID { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string Vin { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalePrice { get; set; }
        public string Description { get; set; }
        public string PicturePath { get; set; }
        public string Type { get; set; }
        public HttpPostedFileBase UploadedFile { get; set; }
        public bool FeatureVehicle { get; set; } = false;
        public string ViewModelType { get; set; }
    }
}
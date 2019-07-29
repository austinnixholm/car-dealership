using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealershipAPI.Models.Sales
{
    public class PurchaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        [Required]
        public string City { get; set; }
        public string State { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public decimal PurchasePrice { get; set; }
        public int PurchaseTypeID { get; set; }
        public List<SelectListItem> StateAbbreviations { get; set; }
        public List<SelectListItem> PurchaseTypes { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipAPI.Models.Sales
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public decimal PurchasePrice { get; set; }
        public string PurchaseType { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
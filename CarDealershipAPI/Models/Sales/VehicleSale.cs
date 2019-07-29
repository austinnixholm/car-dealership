using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipAPI.Models.Sales
{
    public class VehicleSale
    {
        public int VehicleSaleID { get; set; }
        public int StaffID { get; set; }
        public DateTime DateSold { get; set; }
        public decimal AmountSoldFor { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipAPI.Models.Reports
{
    public class InventoryReport
    {
        public int VehicleYear { get; set; }
        public int ModelID { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public int VehicleCount { get; set; }
        public decimal StockValue { get; set; }
    }
}
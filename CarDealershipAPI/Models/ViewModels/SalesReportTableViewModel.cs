using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipAPI.Models.ViewModels
{
    public class SalesReportTableViewModel
    {
        public string UserName { get; set; }
        public decimal TotalSalesAmount { get; set; }
        public int TotalVehicles { get; set; }
    }
}
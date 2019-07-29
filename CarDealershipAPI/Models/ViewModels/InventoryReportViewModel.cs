using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarDealershipAPI.Models.Reports;

namespace CarDealershipAPI.Models.ViewModels
{
    public class InventoryReportViewModel
    {
        public List<InventoryReport> UsedVehicleReports = new List<InventoryReport>();
        public List<InventoryReport> NewVehicleReports = new List<InventoryReport>();
    }
}
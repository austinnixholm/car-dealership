using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealershipAPI.Models.ViewModels
{
    public class SaleReportsViewModel
    {
        public int SelectedStaffID { get; set; }
        public List<SelectListItem> Users { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealershipAPI.Models.Staff;

namespace CarDealershipAPI.Models.ViewModels
{
    public class AddEditUserViewModel
    {
        public StaffMember User { get; set; }
        public string ConfirmPassword { get; set; }
        public string ViewModelType { get; set; }
        public List<SelectListItem> Roles = new List<SelectListItem>();
    }
}
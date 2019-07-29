using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarDealershipAPI.Models.Staff;

namespace CarDealershipAPI.Models.ViewModels
{
    public class UserViewModel
    {
        public StaffMember User { get; set; }
        public string Role { get; set; }
    }
}
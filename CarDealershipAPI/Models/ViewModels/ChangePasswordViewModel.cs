using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipAPI.Models.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
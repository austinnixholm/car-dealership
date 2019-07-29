using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarDealershipAPI.Models.Site;

namespace CarDealershipAPI.Models.ViewModels
{
    public class SpecialViewModel
    {
        public List<Special> Specials = new List<Special>();
        public Special NewSpecial { get; set; }
    }
}
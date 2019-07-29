using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipAPI.Models.VehicleModels
{
    public class Model
    {
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public int MakeID { get; set; }
        public int BodyStyleID { get; set; }

        public DateTime DateAdded { get; set; }
        public int StaffId { get; set; }
    }
}
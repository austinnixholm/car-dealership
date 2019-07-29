using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealershipAPI.Models.VehicleModels;

namespace CarDealershipAPI.Models.Interfaces
{
    public interface IInteriorRepository
    {
        List<Interior> GetAll();
        Interior Get(int interiorID);
    }
}

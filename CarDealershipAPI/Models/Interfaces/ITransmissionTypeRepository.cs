using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealershipAPI.Models.VehicleModels;

namespace CarDealershipAPI.Models.Interfaces
{
    public interface ITransmissionTypeRepository
    {
        List<Transmission> GetAll();
        Transmission Get(int transmissionTypeID);
        int GetID(string transmissionName);
    }
}

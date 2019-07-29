using System;
using System.Collections.Generic;
using System.Linq;
using CarDealershipAPI.Models.Interfaces;
using CarDealershipAPI.Models.VehicleModels;

namespace CarDealershipAPI.Data.Repositories.Mock
{
    public class MockTransmissionTypeRepository : ITransmissionTypeRepository
    {
        private List<Transmission> _types = new List<Transmission>()
        {
            new Transmission() 
            {
                TransmissionID = 1,
                TransmissionName = Enum.GetName(typeof(TransmissionTypes), TransmissionTypes.Manual)
            },
            new Transmission()
            {
                TransmissionID = 2,
                TransmissionName = Enum.GetName(typeof(TransmissionTypes), TransmissionTypes.Automatic)
            },
            new Transmission()
            {
                TransmissionID = 3,
                TransmissionName = Enum.GetName(typeof(TransmissionTypes), TransmissionTypes.Hybrid)
            },
            new Transmission()
            {
                TransmissionID = 4,
                TransmissionName = Enum.GetName(typeof(TransmissionTypes), TransmissionTypes.Electric)
            }
        };

        public List<Transmission> GetAll()
        {
            return _types;
        }

        public Transmission Get(int transmissionTypeID)
        {
            return _types.FirstOrDefault(t => t.TransmissionID.Equals(transmissionTypeID));
        }

        public int GetID(string transmissionName)
        {
            Transmission transmission =
                _types.FirstOrDefault(t => t.TransmissionName.ToLower().Equals(transmissionName.ToLower()));
            if (transmission == null) return 1;
            return transmission.TransmissionID;
        }
    }
}
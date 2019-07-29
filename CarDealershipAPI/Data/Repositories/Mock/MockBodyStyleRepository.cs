using System;
using System.Collections.Generic;
using System.Linq;
using CarDealershipAPI.Models.Interfaces;
using CarDealershipAPI.Models.VehicleModels;

namespace CarDealershipAPI.Data.Repositories.Mock
{
    public class MockBodyStyleRepository : IBodyStyleRepository
    {
        private List<BodyStyle> _bodyStyles = new List<BodyStyle>()
        {
            new BodyStyle()
            {
                BodyStyleID = 1,
                Style = Enum.GetName(typeof(BodyStyles), BodyStyles.Sedan)
            },
            new BodyStyle()
            {
                BodyStyleID = 2,
                Style = Enum.GetName(typeof(BodyStyles), BodyStyles.SUV)
            },
            new BodyStyle()
            {
                BodyStyleID = 3,
                Style = Enum.GetName(typeof(BodyStyles), BodyStyles.Hatchback)
            },
            new BodyStyle()
            {
                BodyStyleID = 4,
                Style = Enum.GetName(typeof(BodyStyles), BodyStyles.Coupe)
            },
            new BodyStyle()
            {
                BodyStyleID = 5,
                Style = Enum.GetName(typeof(BodyStyles), BodyStyles.Crossover)
            },
            new BodyStyle()
            {
                BodyStyleID = 6,
                Style = Enum.GetName(typeof(BodyStyles), BodyStyles.Convertible)
            },
            new BodyStyle()
            {
                BodyStyleID = 7,
                Style = Enum.GetName(typeof(BodyStyles), BodyStyles.Pickup)
            },
            new BodyStyle()
            {
                BodyStyleID = 8,
                Style = Enum.GetName(typeof(BodyStyles), BodyStyles.Station_Wagon)
            },
        };
            public List<BodyStyle> GetAll()
        {
            return _bodyStyles;
        }

        public BodyStyle Get(int bodyStyleID)
        {
            return _bodyStyles.FirstOrDefault(b => b.BodyStyleID.Equals(bodyStyleID));
        }
        public BodyStyle GetByName(string style)
        {
            return GetAll().FirstOrDefault(b => b.Style.ToLower().Equals(style.ToLower()));
        }
    }
}
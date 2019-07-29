using System.Collections.Generic;
using System.Linq;
using CarDealershipAPI.Models.Interfaces;
using CarDealershipAPI.Models.VehicleModels;

namespace CarDealershipAPI.Data.Repositories.Mock
{
    public class MockColorRepository : IColorRepository
    {
        private List<Color> _colors = new List<Color>()
        {
            new Color()
            {
                ColorID = 1,
                ColorName = "White"
            },
            new Color()
            {
                ColorID = 2,
                ColorName = "Red"
            },
            new Color()
            {
                ColorID = 3,
                ColorName = "Green"
            },
            new Color()
            {
                ColorID = 4,
                ColorName = "Blue"
            },
            new Color()
            {
                ColorID = 5,
                ColorName = "Black"
            },
            new Color()
            {
                ColorID = 6,
                ColorName = "Gray"
            },
            new Color()
            {
                ColorID = 7,
                ColorName = "Silver"
            },
            new Color()
            {
                ColorID = 8,
                ColorName = "Yellow"
            },
            new Color()
            {
                ColorID = 9,
                ColorName = "Orange"
            },
        };

        public List<Color> GetAll()
        {
            return _colors;
        }

        public Color Get(int colorID)
        {
            return _colors.FirstOrDefault(c => c.ColorID.Equals(colorID));
        }

        public int GetID(string colorName)
        {
            Color color = _colors.FirstOrDefault(c => c.ColorName.ToLower().Equals(colorName.ToLower()));
            if (color == null) return 1;
            return color.ColorID;
        }
    }
}
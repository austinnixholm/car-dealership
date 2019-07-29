using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealershipAPI.Models.Sales;

namespace CarDealershipAPI.Models.Interfaces
{
    public interface IStateRepository
    {
        List<State> GetAll();
        State GetByAbbreviation(string stateAbbreviation);
    }
}

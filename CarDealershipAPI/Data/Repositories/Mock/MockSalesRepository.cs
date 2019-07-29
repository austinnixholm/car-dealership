using System;
using System.Collections.Generic;
using CarDealershipAPI.Models.Interfaces;
using CarDealershipAPI.Models.Sales;

namespace CarDealershipAPI.Data.Repositories.Mock
{
    public class MockSalesRepository : ISalesRepository
    {
        private List<VehicleSale> _sales = new List<VehicleSale>()
        {
            new VehicleSale()
            {
                StaffID = 1,
                DateSold = DateTime.Parse("2018-05-04"),
                AmountSoldFor = 15750M
            },
            new VehicleSale()
            {
                StaffID = 2,
                DateSold = DateTime.Parse("2019-05-08"),
                AmountSoldFor = 7750M
            },
            new VehicleSale()
            {
                StaffID = 1,
                DateSold = DateTime.Parse("2019-07-06"),
                AmountSoldFor = 29200M
            },
        };

        public List<VehicleSale> GetAll()
        {
            return _sales;
        }

        public void AddSale(VehicleSale sale)
        {
            _sales.Add(sale);
        }
    }
}
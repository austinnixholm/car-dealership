using System.Collections.Generic;
using System.Linq;
using CarDealershipAPI.Models.Interfaces;
using CarDealershipAPI.Models.Sales;

namespace CarDealershipAPI.Data.Repositories.Mock
{
    public class MockPurchaseTypeRepository : IPurchaseTypeRepository
    {
        private List<PurchaseType> _purchaseTypes = new List<PurchaseType>()
        {
            new PurchaseType()
            {
                PurchaseTypeID = 1,
                PurchaseTypeName = "Dealer Finance"
            },
            new PurchaseType()
            {
                PurchaseTypeID = 2,
                PurchaseTypeName = "Bank Finance"
            },
            new PurchaseType()
            {
                PurchaseTypeID = 3,
                PurchaseTypeName = "Cash"
            }
        };

        public List<PurchaseType> GetAll()
        {
            return _purchaseTypes;
        }

        public PurchaseType GetById(int purchaseTypeID)
        {
            return _purchaseTypes.FirstOrDefault(p => p.PurchaseTypeID.Equals(purchaseTypeID));
        }
    }
}
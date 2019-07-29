using System.Collections.Generic;
using System.Linq;
using CarDealershipAPI.Models.Interfaces;
using CarDealershipAPI.Models.Sales;

namespace CarDealershipAPI.Data.Repositories.Mock
{
    public class MockPurchaseRepository : IPurchaseRepository
    {
        private List<Purchase> _purchases = new List<Purchase>();

        public List<Purchase> GetAll()
        {
            return _purchases;
        }

        public Purchase GetById(int purchaseID)
        {
            return _purchases.FirstOrDefault(p => p.PurchaseID.Equals(purchaseID));
        }

        public void AddPurchase(Purchase purchase)
        {
            purchase.PurchaseID = _purchases.Count > 0 ? _purchases.Max(p => p.PurchaseID) + 1 : 1;
        }

        public void EditPurchase(Purchase purchase)
        {
            Purchase old = GetById(purchase.PurchaseID);
            if (old == null) return;
            old.Name = purchase.Name;
            old.PhoneNumber = purchase.PhoneNumber;
            old.Email = purchase.Email;
            old.Street1 = purchase.Street1;
            old.Street2 = purchase.Street2;
            old.City = purchase.City;
            old.State = purchase.State;
            old.ZipCode = purchase.ZipCode;
            old.PurchasePrice = purchase.PurchasePrice;
            old.PurchaseType = purchase.PurchaseType;
            old.PurchaseDate = purchase.PurchaseDate;
        }

        public void DeletePurchase(int purchaseID)
        {
            _purchases.RemoveAll(p => p.PurchaseID.Equals(purchaseID));
        }
    }
}
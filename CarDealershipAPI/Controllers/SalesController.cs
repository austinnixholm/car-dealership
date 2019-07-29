using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealershipAPI.Logic;
using CarDealershipAPI.Models.Sales;
using CarDealershipAPI.Models.ViewModels;

namespace CarDealershipAPI.Controllers
{
    [Authorize(Roles = "Admin, Sales")]
    public class SalesController : Controller
    {
        /// <summary>
        /// Loads the shared inventory view page as the 'Sales' type.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            InventoryViewModel model = new InventoryViewModel()
            {
                InventoryType = "Sales"
            };
            return View(model);
        }

        /// <summary>
        /// Loads up the Purchase form view page.
        /// Contains a vehicle view model with data generated from the inputted vehicle ID.
        /// </summary>
        /// <param name="vehicleID">The vehicle ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Purchase(int vehicleID)
        {
            VehicleViewModel model = Manager.GenerateViewModelById(vehicleID);
            if (model == null) return RedirectToAction("Index", "Sales");
            model.PurchaseModel = new PurchaseModel();
            model.PurchaseModel.StateAbbreviations = Manager.GetStatesDropdown();
            model.PurchaseModel.PurchaseTypes = Manager.GetPurchaseTypesDropdown();
            return View(model);
        }

        /// <summary>
        /// Handles validation for the purchase form view page.
        /// 
        /// </summary>
        /// <param name="model">The model containing purchase data.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Purchase(VehicleViewModel model)
        {
            bool valid = true;
            VehicleViewModel vm = Manager.GenerateViewModelById(model.Vehicle.VehicleID);
            model.Model = vm.Model;
            model.Make = vm.Make;
            model.Vehicle = vm.Vehicle;
            model.PurchaseModel.StateAbbreviations = Manager.GetStatesDropdown();
            model.PurchaseModel.PurchaseTypes = Manager.GetPurchaseTypesDropdown();
            valid = ModelState.IsValid;
            if (model.PurchaseModel.ZipCode.ToString().Length != 5)
            {
                ModelState.AddModelError("", "Zipcode must be 5 digits.");
                valid = false;
            }
            if (model.PurchaseModel.PurchasePrice < (model.Vehicle.SalePrice * 0.95M))
            {
                ModelState.AddModelError("", "Purchase price cannot be less than 95% of sales price.");
                valid = false;
            }
            if (model.PurchaseModel.PurchasePrice > model.Vehicle.MSRP)
            {
                ModelState.AddModelError("", "Purchase price cannot be more than the MSRP.");
                valid = false;
            }
            if (string.IsNullOrEmpty(model.PurchaseModel.Email) && string.IsNullOrEmpty(model.PurchaseModel.Phone))
            {
                ModelState.AddModelError("", "Purchase must include either a valid phone # or email.");
                valid = false;
            }
            else
            {
                if (!string.IsNullOrEmpty(model.PurchaseModel.Email))
                {
                    if (!Manager.IsValidEmail(model.PurchaseModel.Email))
                    {
                        ModelState.AddModelError("", "Invalid email address.");
                        valid = false;
                    }
                }
                if (!string.IsNullOrEmpty(model.PurchaseModel.Phone))
                {
                    if (Manager.ParsePhoneNumber(model.PurchaseModel.Phone).ToString().Length < 10)
                    {
                        ModelState.AddModelError("", "Invalid phone number input.");
                        valid = false;
                    }
                }
            }
            if (!valid)
            {
                model.Make = Manager.MakeRepository.GetById(model.Vehicle.MakeID);
                model.Model = Manager.ModelRepository.GetById(model.Vehicle.ModelID);
                model.BodyStyle = Manager.BodyStyleRepository.Get(model.Model.BodyStyleID);
                model.Interior = Manager.InteriorRepository.Get(model.Vehicle.InteriorID);
                return View(model);
            }
            model.Vehicle.Sold = true;
            Manager.VehicleRepository.EditVehicle(model.Vehicle);
            Purchase purchase = new Purchase();

            purchase.Name = model.PurchaseModel.Name;
            purchase.Email = model.PurchaseModel.Email;
            purchase.City = model.PurchaseModel.City;
            purchase.PhoneNumber = model.PurchaseModel.Phone;
            purchase.PurchasePrice = model.PurchaseModel.PurchasePrice;
            purchase.Street1 = model.PurchaseModel.Street1;
            purchase.Street2 = model.PurchaseModel.Street2;
            purchase.ZipCode = model.PurchaseModel.ZipCode;
            purchase.State = Manager.StateRepository.GetByAbbreviation(model.PurchaseModel.State).StateName;
            purchase.PurchaseType = Manager.PurchaseTypeRepository.GetById(model.PurchaseModel.PurchaseTypeID)
                .PurchaseTypeName;
            purchase.PurchaseDate = DateTime.Today;
            Manager.PurchaseRepository.AddPurchase(purchase);
            Manager.SalesRepository.AddSale(new VehicleSale()
            {
                AmountSoldFor = purchase.PurchasePrice,
                DateSold = DateTime.Today,
                StaffID = Manager.CurrentUser.StaffID,
            });
            return RedirectToAction("Index", "Sales");
        }

        
    }

}
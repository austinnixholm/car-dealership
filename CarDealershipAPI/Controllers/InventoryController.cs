using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealershipAPI.Logic;
using CarDealershipAPI.Models;
using CarDealershipAPI.Models.VehicleModels;
using CarDealershipAPI.Models.ViewModels;

namespace CarDealershipAPI.Controllers
{
    [AllowAnonymous]
    public class InventoryController : Controller
    {
        /// <summary>
        /// Loads the shared inventory view page as the 'Used' type.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UsedInventory()
        {
            InventoryViewModel model = new InventoryViewModel()
            {
                InventoryType = "Used"
            };
            return View(model);
        }

        /// <summary>
        /// Loads the shared inventory view page as the 'New' type.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult NewInventory()
        {
            InventoryViewModel model = new InventoryViewModel()
            {
                InventoryType = "New"
            };
            return View(model);
        }

        /// <summary>
        /// Generates a vehicle view model based on the vehicleID inputted.
        /// Loads the vehicle view page containing the generated model.
        /// </summary>
        /// <param name="vehicleID">The vehicle ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Vehicle(int vehicleID)
        {
            VehicleViewModel model = Manager.GenerateViewModelById(vehicleID);
            if (model == null) return RedirectToAction("Index", "Home");
            return View(model);
        }



    }
}
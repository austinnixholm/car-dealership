using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealershipAPI.Logic;
using CarDealershipAPI.Models;
using CarDealershipAPI.Models.Customer;
using CarDealershipAPI.Models.Site;
using CarDealershipAPI.Models.VehicleModels;
using CarDealershipAPI.Models.ViewModels;

namespace CarDealershipAPI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        /// <summary>
        /// The home index. Loads and displays the top 8 featured vehicles in the repository.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            List<VehicleViewModel> vehicleViewModels = new List<VehicleViewModel>(8);
            foreach (Vehicle v in Manager.VehicleRepository.GetAll())
            {
                if (vehicleViewModels.Count >= vehicleViewModels.Capacity) break;
                if (v.Featured && !v.Sold)
                {
                    VehicleViewModel model = new VehicleViewModel();
                    model.Vehicle = v;
                    model.Make = Manager.MakeRepository.GetById(v.MakeID);
                    model.Model = Manager.ModelRepository.GetById(v.ModelID);
                    vehicleViewModels.Add(model);
                }
            }
            HomeIndexViewModel viewModel = new HomeIndexViewModel();
            viewModel.Vehicles = vehicleViewModels;
            List<Special> specials = Manager.SpecialRepository.GetAll();
            viewModel.Special = specials.ElementAt(new Random(Guid.NewGuid().GetHashCode()).Next(1, specials.Count - 1));
            return View(viewModel);
        }

        /// <summary>
        /// Loads the specials view containing a list of Specials from the repository.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Specials()
        {
            List<Special> model = Manager.SpecialRepository.GetAll();
            return View(model);
        }

        /// <summary>
        /// Contact us form page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Contact()
        {
            return View(new Contact());
        }

        /// <summary>
        /// Handles validation for the "Contact Us" form, and submits the contact request to the db.
        /// </summary>
        /// <param name="model">The Contact model from the form</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Contact(Contact model)
        {
            bool valid = ModelState.IsValid;
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("", "Please enter a valid name.");
                valid = false;
            }
            if (string.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError("", "Please enter a valid e-mail.");
                valid = false;
            }
            if (string.IsNullOrEmpty(model.PhoneNumber))
            {
                ModelState.AddModelError("", "Please enter a valid phone number.");
                valid = false;
            }
            if (string.IsNullOrEmpty(model.Message))
            {
                ModelState.AddModelError("", "Please enter a message.");
                valid = false;
            }
            if (!valid) return View(model);
            
            Manager.ContactRepository.AddContact(model);
            return RedirectToAction("Index", "Home");
        }
    }
}
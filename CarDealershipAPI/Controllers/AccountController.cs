using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealershipAPI.Logic;
using CarDealershipAPI.Models.Staff;
using CarDealershipAPI.Models.ViewModels;

namespace CarDealershipAPI.Controllers
{
    [Authorize(Roles="Admin, Sales, Disabled")]
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View(new ChangePasswordViewModel());
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            bool valid = true;
            if (string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("", "No password was entered.");
                valid = false;
            }
            else
            {
                if (string.IsNullOrEmpty(model.ConfirmPassword))
                {
                    ModelState.AddModelError("", "Please confirm your password.");
                    valid = false;
                }
                else
                {
                    if (!model.Password.Equals(model.ConfirmPassword))
                    {
                        ModelState.AddModelError("", "Password confirmation does not match the entered password.");
                        valid = false;
                    }
                }
            }
            if (!valid)
            {
                return View(new ChangePasswordViewModel());
            }

            StaffMember user = Manager.StaffRepository.GetById(Manager.CurrentUser.StaffID);
            user.Password = model.Password;
            Manager.StaffRepository.EditStaffMember(user);
            return RedirectToAction("Index", "Home");
        }
    }
}
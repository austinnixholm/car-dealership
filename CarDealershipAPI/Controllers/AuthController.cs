using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using CarDealershipAPI.CustomLibraries;
using CarDealershipAPI.Logic;
using CarDealershipAPI.Models;
using CarDealershipAPI.Models.Auth;
using CarDealershipAPI.Models.Staff;

namespace CarDealershipAPI.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginModel());
        }

        /// <summary>
        /// Handles authentication for users logging in.
        /// </summary>
        /// <param name="model">The model containing form data</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid) return View(model);

            //Grab all the users
            List<StaffMember> users = Manager.StaffRepository.GetAll();

            //Get the repository user that matches the e-mail entered
            StaffMember repoUser = users.FirstOrDefault(u => u.Email.ToLower().Equals(model.Email.ToLower()));
            bool userExists = repoUser != null;
            //Check if the user exists
            if (!userExists) return View(model);

            //Grab the password from the user with the matching e-mail
            var getPassword = users.Where(u => u.Email.ToLower().Equals(model.Email.ToLower()))
                .Select(u => u.Password);
            var materializePassword = getPassword.ToList();
            var password = materializePassword[0]; //no encryption for now (no register page)

            //Check for the password to match case specific
            if (model.Password.Equals(password))
            {
                var username = repoUser.Name;
                string roleName = Manager.StaffRoleRepository.GetById(repoUser.StaffRoleID).RoleName;

                //Submit a new claim containing the user's name & staff role
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, roleName),
                }, "ApplicationCookie");
                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);
                Manager.CurrentUser = repoUser;
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid email or password.");
            return View(model);
        }


        /// <summary>
        /// Signs the current logged in user from the Owin authentication.
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Manager.CurrentUser = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
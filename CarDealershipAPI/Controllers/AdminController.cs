using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using CarDealershipAPI.Logic;
using CarDealershipAPI.Models.Site;
using CarDealershipAPI.Models.Staff;
using CarDealershipAPI.Models.VehicleModels;
using CarDealershipAPI.Models.ViewModels;

namespace CarDealershipAPI.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Vehicles()
        {
            InventoryViewModel model = new InventoryViewModel()
            {
                InventoryType = "Admin"
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult AddVehicle()
        {
            AddEditVehicleViewModel viewModel = new AddEditVehicleViewModel();
            viewModel.ViewModelType = "Add";
            SetSelectListItems(viewModel);
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddVehicle(AddEditVehicleViewModel model)
        {
            //todo fix the image uploads??
            SetAddEditVehicleResponse(model, out bool valid);
            if (!valid)
            {
                SetSelectListItems(model);
                model.ViewModelType = "Add";
                return View(model);
            }
            SubmitAddEditVehicleViewModel(model, "Add");
            return RedirectToAction("EditVehicle", "Admin", model);
        }

        [HttpGet]
        public ActionResult EditVehicle(int vehicleID)
        {
            AddEditVehicleViewModel model = new AddEditVehicleViewModel();
            Vehicle vehicle = Manager.VehicleRepository.Get(vehicleID);
            model.VehicleID = vehicleID;
            model.ViewModelType = "Edit";
            SetSelectListItems(model);
            model.FeatureVehicle = vehicle.Featured;
            model.PicturePath = vehicle.PicturePath;
            model.ModelID = vehicle.ModelID;
            model.MakeID = vehicle.MakeID;
            model.BodyStyleID = Manager.BodyStyleRepository.GetByName(vehicle.BodyStyle).BodyStyleID;
            model.ColorID = Manager.ColorRepository.GetID(vehicle.Color);
            model.Vin = vehicle.VIN;
            model.InteriorID = vehicle.InteriorID;
            model.BodyStyleID = Manager.ModelRepository.GetById(vehicle.ModelID).BodyStyleID;
            model.Year = vehicle.Year;
            model.SalePrice = vehicle.SalePrice;
            model.MSRP = vehicle.MSRP;
            model.Type = vehicle.Category;
            model.Description = vehicle.Description;
            model.Mileage = vehicle.Mileage;
            model.TransmissionID = Manager.TransmissionTypeRepository.GetID(vehicle.Transmission);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditVehicle(AddEditVehicleViewModel model)
        {
            SetAddEditVehicleResponse(model, out bool valid);
            if (!valid)
            {
                SetSelectListItems(model);
                model.ViewModelType = "Edit";
                return RedirectToAction("EditVehicle", "Admin", model);
            }
            SubmitAddEditVehicleViewModel(model, "Edit");
            return RedirectToAction("Vehicles", "Admin");
        }

        [HttpGet]
        public ActionResult Users()
        {
            List<UserViewModel> model = new List<UserViewModel>();
            List<StaffMember> staff = Manager.StaffRepository.GetAll();
            foreach (StaffMember member in staff)
            {
                model.Add(new UserViewModel()
                {
                    User = member,
                    Role = Manager.StaffRoleRepository.GetById(member.StaffRoleID).RoleName
                });
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            AddEditUserViewModel viewModel = new AddEditUserViewModel();
            viewModel.ViewModelType = "Add";
            viewModel.User = new StaffMember();
            viewModel.Roles = Manager.GenerateStaffRoleList();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddUser(AddEditUserViewModel model)
        {
            SetAddEditUserResponse(model, out bool valid);
            if (!valid)
            {
                model.Roles = Manager.GenerateStaffRoleList();
                model.ViewModelType = "Add";
                return View(model);
            }
            Manager.StaffRepository.AddStaffMember(model.User);
            return RedirectToAction("Users", "Admin");
        }

        [HttpGet]
        public ActionResult EditUser(int userID)
        {
            StaffMember user = Manager.StaffRepository.GetById(userID);
            if (user == null) return RedirectToAction("Users", "Admin");
            AddEditUserViewModel viewModel = new AddEditUserViewModel();
            viewModel.ViewModelType = "Edit";
            viewModel.Roles = Manager.GenerateStaffRoleList();
            viewModel.User = user;
            viewModel.User.Password = string.Empty;
            viewModel.ConfirmPassword = string.Empty;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditUser(AddEditUserViewModel model)
        {
            SetAddEditUserResponse(model, out bool valid);
            if (!valid)
            {
                model.Roles = Manager.GenerateStaffRoleList();
                model.ViewModelType = "Edit";
                model.User.Password = string.Empty;
                model.ConfirmPassword = string.Empty;
                return View(model);
            }
            Manager.StaffRepository.EditStaffMember(model.User);
            return RedirectToAction("Users", "Admin");
        }

        [HttpGet]
        public ActionResult Makes()
        {
            List<MakeViewModel> model = Manager.GenerateMakeVMList();
            MakeListViewModel viewModel = new MakeListViewModel();
            viewModel.ViewModels = model;
            viewModel.NewMake = new Make();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Makes(MakeListViewModel model)
        {
            if (string.IsNullOrEmpty(model.NewMake.MakeName))
            {
                ModelState.AddModelError("", "Make must have a valid make name.");
                model.ViewModels = Manager.GenerateMakeVMList();
                return View(model);
            }
            Make make = new Make();
            make.MakeName = model.NewMake.MakeName;
            make.DateAdded = DateTime.Today;
            make.StaffId = Manager.CurrentUser.StaffID;
            Manager.MakeRepository.AddMake(make);
            model.NewMake = new Make();
            model.ViewModels = Manager.GenerateMakeVMList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Models()
        {
            List<ModelViewModel> model = Manager.GenerateModelVMList();
            ModelListViewModel viewModel = new ModelListViewModel();
            viewModel.NewModel = new Model();
            viewModel.ViewModels = model;
            viewModel.MakesList = Manager.GenerateMakeList();
            viewModel.BodyStylesList = Manager.GenerateBodyStyleList();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Models(ModelListViewModel model)
        {
            if (string.IsNullOrEmpty(model.NewModel.ModelName))
            {
                ModelState.AddModelError("", "Model must have a valid model name.");
                model.ViewModels = Manager.GenerateModelVMList();
                model.MakesList = Manager.GenerateMakeList();
                model.BodyStylesList = Manager.GenerateBodyStyleList();
                return View(model);
            }
            Model newModel = new Model();
            newModel.MakeID = model.SelectedMakeID;
            newModel.BodyStyleID = model.SelectedBodyStyleID;
            newModel.ModelName = model.NewModel.ModelName;
            newModel.StaffId = Manager.CurrentUser.StaffID;
            newModel.DateAdded = DateTime.Today;
            Manager.ModelRepository.AddModel(newModel);
            model.NewModel = new Model();
            model.MakesList = Manager.GenerateMakeList();
            model.ViewModels = Manager.GenerateModelVMList();
            model.BodyStylesList = Manager.GenerateBodyStyleList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Reports()
        {
            return View();
        }

        [HttpGet]
        public ActionResult InventoryReports()
        {
            InventoryReportViewModel viewModel = new InventoryReportViewModel();
            viewModel.NewVehicleReports = InventoryReportHandler.GenerateInventoryReports("New");
            viewModel.UsedVehicleReports = InventoryReportHandler.GenerateInventoryReports("Used");
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult SalesReports()
        {
            SaleReportsViewModel viewModel = new SaleReportsViewModel();
            viewModel.Users = Manager.GenerateUsersList();
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult DeleteSpecial(int specialID)
        {
            Manager.SpecialRepository.DeleteSpecial(specialID);
            return RedirectToAction("Specials", "Admin");
        }

        [HttpGet]
        public ActionResult Specials()
        {
            SpecialViewModel model = new SpecialViewModel();
            List<Special> specials = Manager.SpecialRepository.GetAll();
            model.Specials = specials;
            model.NewSpecial = new Special();
            return View(model);
        }

        [HttpPost]
        public ActionResult Specials(SpecialViewModel model)
        {
            bool valid = ModelState.IsValid;
            if (string.IsNullOrEmpty(model.NewSpecial.SpecialTitle))
            {
                ModelState.AddModelError("", "Special must have a title.");
                valid = false;
            }

            if (string.IsNullOrEmpty(model.NewSpecial.SpecialDescription))
            {
                ModelState.AddModelError("", "Special must have a description.");
                valid = false;
            }
            if (!valid)
            {
                return RedirectToAction("Specials", "Admin");
            }
            Manager.SpecialRepository.AddSpecial(model.NewSpecial);
            List<Special> specials = Manager.SpecialRepository.GetAll();
            model.Specials = specials;
            model.NewSpecial = new Special();
            return RedirectToAction("Specials", "Admin", model);
        }

        private void SubmitAddEditVehicleViewModel(AddEditVehicleViewModel viewModel, string type)
        {
            Vehicle vehicle = new Vehicle();
            if (type.ToLower().Equals("edit"))
                vehicle.VehicleID = viewModel.VehicleID;
            vehicle.StaffID = Manager.CurrentUser.StaffID;
            vehicle.MakeID = viewModel.MakeID;
            vehicle.ModelID = viewModel.ModelID;
            vehicle.InteriorID = viewModel.InteriorID;
            vehicle.BodyStyle = Manager.BodyStyleRepository.Get(viewModel.BodyStyleID).Style;
            vehicle.Category = viewModel.Type;
            vehicle.Description = viewModel.Description;
            vehicle.SalePrice = viewModel.SalePrice;
            vehicle.MSRP = viewModel.MSRP;
            vehicle.Mileage = viewModel.Mileage;
            vehicle.Year = viewModel.Year;
            vehicle.VIN = viewModel.Vin;
            vehicle.Featured = viewModel.FeatureVehicle;
            if (type.ToLower().Equals("edit"))
            {
                if (!string.IsNullOrEmpty(vehicle.PicturePath))
                {
                    try { System.IO.File.Delete(vehicle.PicturePath); } catch (Exception e) { }
                }
            }
            vehicle.PicturePath = viewModel.PicturePath;
            vehicle.Transmission = Manager.TransmissionTypeRepository.Get(viewModel.TransmissionID).TransmissionName;
            vehicle.Color = Manager.ColorRepository.Get(viewModel.ColorID).ColorName;
            if (type.ToLower().Equals("add"))
                viewModel.VehicleID = Manager.VehicleRepository.AddVehicle(vehicle);
            else if (type.ToLower().Equals("edit"))
                Manager.VehicleRepository.EditVehicle(vehicle);
        }

        private void SetAddEditVehicleResponse(AddEditVehicleViewModel model, out bool valid)
        {
            const int newMileageMax = 1000;
            const int minimumYear = 2000;
            valid = true;
            if (!string.IsNullOrEmpty(model.Type) && model.Mileage >= 0)
            {
                if (model.Type.ToLower().Equals("new") && model.Mileage > newMileageMax)
                {
                    ModelState.AddModelError("", "New vehicles cannot have a mileage over " + newMileageMax + ".");
                    valid = false;
                }
                if (model.Type.ToLower().Equals("used") && model.Mileage <= newMileageMax)
                {
                    ModelState.AddModelError("", "Used vehicles must have a mileage greater than" + newMileageMax + ".");
                    valid = false;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(model.Type))
                {
                    ModelState.AddModelError("", "Vehicle must have a type (new/used)");
                }

                if (model.Mileage < 0)
                {
                    ModelState.AddModelError("", "Vehicle must have a mileage of 0 or higher.");
                }
            }
            if (string.IsNullOrEmpty(model.Vin))
            {
                ModelState.AddModelError("", "Vehicle must have a valid VIN #.");
                valid = false;
            }
            if (model.MSRP <= 0)
            {
                ModelState.AddModelError("", "Vehicle MSRP must be a positive number greater than 0.");
                valid = false;
            }
            if (model.SalePrice <= 0 || model.SalePrice > model.MSRP)
            {
                if (model.SalePrice <= 0)
                    ModelState.AddModelError("", "Vehicle sale price must be a positive number greater than 0.");
                else
                    ModelState.AddModelError("", "Vehicle sale price cannot be greater than MSRP.");
                valid = false;
            }
            if (string.IsNullOrEmpty(model.Description))
            {
                ModelState.AddModelError("", "Vehicle must have a description.");
                valid = false;
            }

            int latestYear = (DateTime.Today.Year + 1);
            if (model.Year < minimumYear || model.Year > latestYear)
            {
                ModelState.AddModelError("", "Vehicle year must be between " + minimumYear + " and " + latestYear + ".");
                valid = false;
            }
            if (model.UploadedFile != null && model.UploadedFile.ContentLength > 0)
            {
                if (!string.IsNullOrEmpty(model.UploadedFile.FileName))
                {
                    string path = Path.Combine(Server.MapPath("~/Content/images"),
                        Path.GetFileName(model.UploadedFile.FileName));

                    model.UploadedFile.SaveAs(path);
                    model.PicturePath = "/Content/images/" + model.UploadedFile.FileName;
                }
                else
                {
                    ModelState.AddModelError("", "Uploaded image had an invalid file name.");
                    valid = false;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(model.PicturePath))
                {
                    ModelState.AddModelError("", "Vehicle must have an image.");
                    valid = false;
                }
            }
        }

        private void SetAddEditUserResponse(AddEditUserViewModel model, out bool valid)
        {
            valid = true;
            if (string.IsNullOrEmpty(model.User.Name))
            {
                ModelState.AddModelError("", "User must have a valid name.");
                valid = false;
            }

            if (string.IsNullOrEmpty(model.User.Email))
            {
                ModelState.AddModelError("", "User must have an e-mail.");
                valid = false;
            }
            else
            {
                if (!Manager.IsValidEmail(model.User.Email))
                {
                    ModelState.AddModelError("", "User must have a valid e-mail address.");
                    valid = false;
                }
            }

            if (string.IsNullOrEmpty(model.User.Password))
            {
                ModelState.AddModelError("", "User must have a password.");
                valid = false;
            }
            else
            {
                if (!string.IsNullOrEmpty(model.ConfirmPassword))
                {
                    if (!model.ConfirmPassword.Equals(model.User.Password))
                    {
                        ModelState.AddModelError("", "Password confirmation is invalid.");
                        valid = false;
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please confirm the user's password.");
                    valid = false;
                }
            }
        }

        private void SetSelectListItems(AddEditVehicleViewModel viewModel)
        {
            viewModel.Makes = Manager.GenerateMakeList();
            viewModel.Types = Manager.GenerateTypeList();
            viewModel.BodyStyles = Manager.GenerateBodyStyleList();
            viewModel.Transmissions = Manager.GenerateTransmissionTypeList();
            viewModel.Colors = Manager.GenerateColorList();
            viewModel.Interiors = Manager.GenerateInteriorList();
        }
    }
}
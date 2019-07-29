using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using CarDealershipAPI.Models.Interfaces;
using CarDealershipAPI.Models.Sales;
using CarDealershipAPI.Models.Staff;
using CarDealershipAPI.Models.VehicleModels;
using CarDealershipAPI.Models.ViewModels;

namespace CarDealershipAPI.Logic
{
    public static class Manager
    {
        public static readonly IStaffMemberRepository StaffRepository = RepositoryFactory.GrabStaffRepository();
        public static readonly IStaffRoleRepository StaffRoleRepository = RepositoryFactory.GrabStaffRoleRepository();
        public static readonly IVehicleRepository VehicleRepository = RepositoryFactory.GrabVehicleRepository();
        public static readonly IModelRepository ModelRepository = RepositoryFactory.GrabModelRepository();
        public static readonly IMakeRepository MakeRepository = RepositoryFactory.GrabMakeRepository();
        public static readonly ISpecialRepository SpecialRepository = RepositoryFactory.GrabSpecialRepository();
        public static readonly IStateRepository StateRepository = RepositoryFactory.GrabStateRepository();
        public static readonly IPurchaseTypeRepository PurchaseTypeRepository =
            RepositoryFactory.GrabPurchaseTypeRepository();
        public static readonly IPurchaseRepository PurchaseRepository = RepositoryFactory.GrabPurchaseRepository();
        public static readonly IBodyStyleRepository BodyStyleRepository = RepositoryFactory.GrabBodyStyleRepository();
        public static readonly ITransmissionTypeRepository TransmissionTypeRepository =
            RepositoryFactory.GrabTransmissionTypeRepository();
        public static readonly IColorRepository ColorRepository = RepositoryFactory.GrabColorRepository();
        public static readonly IInteriorRepository InteriorRepository = RepositoryFactory.GrabInteriorRepository();
        public static readonly ISalesRepository SalesRepository = RepositoryFactory.GrabSalesRepository();
        public static readonly IContactRepository ContactRepository = RepositoryFactory.GrabContactRepository();

        public static StaffMember CurrentUser = null;

        public static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["DealershipADO"].ConnectionString;

        /// <summary>
        /// Populates data from a vehicle in the database into a VehicleViewModel, based on a vehicle ID
        /// </summary>
        /// <param name="vehicleID">The vehicle ID</param>
        /// <returns>A generate vehicle view model</returns>
        public static VehicleViewModel GenerateViewModelById(int vehicleID)
        {
            VehicleViewModel model = new VehicleViewModel();
            Vehicle vehicle = VehicleRepository.Get(vehicleID);
            if (vehicle == null) return null;
            model.Vehicle = vehicle;
            model.Make = MakeRepository.GetById(vehicle.MakeID);
            model.Model = ModelRepository.GetById(vehicle.ModelID);
            model.BodyStyle = BodyStyleRepository.Get(model.Model.BodyStyleID);
            model.Interior = InteriorRepository.Get(vehicle.InteriorID);
            return model;
        }

        /// <summary>
        /// Checks if a string can be parsed as a DateTime object.
        /// </summary>
        /// <param name="date">The date to check</param>
        /// <returns>True if string can be parsed as date</returns>
        public static bool CanParseAsDate(string date)
        {
            string trimmed = date.Replace("-", "");
            return (int.TryParse(trimmed, out int value) && value.ToString().Length == 8);
        }

        /// <summary>
        /// Checks if a string is a valid e-mail address
        /// </summary>
        /// <param name="email">The e-mail to check</param>
        /// <returns>True if valid e-mail</returns>
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Converts an entered phone number to just its digits.
        /// </summary>
        /// <param name="phoneNumber">The entered phone number</param>
        /// <returns>The trimmed phone number</returns>
        public static long ParsePhoneNumber(string phoneNumber)
        {
            string trimmed = phoneNumber.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
            return long.Parse(trimmed);
        }

        /// <summary>
        /// Generates a list of ModelViewModel's from the repository.
        /// </summary>
        /// <returns>The generated list</returns>
        public static List<ModelViewModel> GenerateModelVMList()
        {
            List<ModelViewModel> viewModels = new List<ModelViewModel>();
            List<Model> models = ModelRepository.GetAll();
            foreach (Model model in models)
            {
                viewModels.Add(new ModelViewModel()
                {
                    Model = model,
                    Make = MakeRepository.GetById(model.MakeID).MakeName,
                    BodyStyle = BodyStyleRepository.Get(model.BodyStyleID).Style,
                    StaffMemberEmail = StaffRepository.GetById(model.StaffId).Email
                });
            }

            return viewModels;
        }

        /// <summary>
        /// Generates a list of MakeViewModel's from the repository.
        /// </summary>
        /// <returns>The generated list</returns>
        public static List<MakeViewModel> GenerateMakeVMList()
        {
            List<MakeViewModel> model = new List<MakeViewModel>();
            List<Make> makes = MakeRepository.GetAll();
            foreach (Make make in makes)
            {
                model.Add(new MakeViewModel()
                {
                    Make = make,
                    StaffMemberEmail = StaffRepository.GetById(make.StaffId).Email
                });
            }

            return model;
        }

        /// <summary>
        /// Generates a list of SelectListItem's containing data from users in the repository.
        /// </summary>
        /// <returns>The generated list</returns>
        public static List<SelectListItem> GenerateUsersList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<StaffMember> users = StaffRepository.GetAll();
            items.Add(new SelectListItem()
            {
                Text = "- All -",
                Value = "All"
            });
            foreach (StaffMember user in users)
            {
                items.Add(new SelectListItem()
                {
                    Text = user.Name,
                    Value = user.StaffID + ""
                });
            }

            return items;
        }

        /// <summary>
        /// Generates a list of SelectListItem's containing data from makes in the repository.
        /// </summary>
        /// <returns>The generated list</returns>
        public static List<SelectListItem> GenerateMakeList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<Make> makes = MakeRepository.GetAll();
            foreach (Make m in makes)
            {
                items.Add(new SelectListItem()
                {
                    Text = m.MakeName,
                    Value = m.MakeID + ""
                });
            }

            return items;
        }

        /// <summary>
        /// Generates a list of SelectListItem's containing the two possible categories for a vehicle.
        /// </summary>
        /// <returns>The generated list</returns>
        public static List<SelectListItem> GenerateTypeList()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "New",
                    Value = "New"
                },
                new SelectListItem()
                {
                    Text = "Used",
                    Value = "Used"
                }
            };
        }

        /// <summary>
        /// Generates a list of SelectListItem's containing data from body styles in the repository.
        /// </summary>
        /// <returns>The generated list</returns>
        public static List<SelectListItem> GenerateBodyStyleList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<BodyStyle> bodyStyles = BodyStyleRepository.GetAll();
            foreach (BodyStyle s in bodyStyles)
            {
                items.Add(new SelectListItem()
                {
                    Text = s.Style,
                    Value = s.BodyStyleID + ""
                });
            }

            return items;
        }

        /// <summary>
        /// Generates a list of SelectListItem's containing data from transmission types in the repository.
        /// </summary>
        /// <returns>The generated list</returns>
        public static List<SelectListItem> GenerateTransmissionTypeList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<Transmission> transmissionTypes = TransmissionTypeRepository.GetAll();
            foreach (Transmission s in transmissionTypes)
            {
                items.Add(new SelectListItem()
                {
                    Text = s.TransmissionName,
                    Value = s.TransmissionID + ""
                });
            }

            return items;
        }

        /// <summary>
        /// Generates a list of SelectListItem's containing data from colors in the repository.
        /// </summary>
        /// <returns>The generated list</returns>
        public static List<SelectListItem> GenerateColorList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<Color> colors = ColorRepository.GetAll();
            foreach (Color c in colors)
            {
                items.Add(new SelectListItem()
                {
                    Text = c.ColorName,
                    Value = c.ColorID + ""
                });
            }

            return items;
        }

        /// <summary>
        /// Generates a list of SelectListItem's containing data from interior types in the repository.
        /// </summary>
        /// <returns>The generated list</returns>
        public static List<SelectListItem> GenerateInteriorList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<Interior> interiors = InteriorRepository.GetAll();
            foreach (Interior i in interiors)
            {
                items.Add(new SelectListItem()
                {
                    Text = i.InteriorName,
                    Value = i.InteriorID + ""
                });
            }

            return items;
        }

        /// <summary>
        /// Generates a list of SelectListItem's containing data from staff roles in the repository.
        /// </summary>
        /// <returns>The generated list</returns>
        public static List<SelectListItem> GenerateStaffRoleList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<StaffRole> staffRoles = StaffRoleRepository.GetAll();
            foreach (StaffRole role in staffRoles)
            {
                items.Add(new SelectListItem()
                {
                    Text = role.RoleName,
                    Value = role.StaffRoleID + ""
                });
            }

            return items;
        }

        /// <summary>
        /// Generates a list of SelectListItem's containing data from states in the repository.
        /// </summary>
        /// <returns>The generated list</returns>
        public static List<SelectListItem> GetStatesDropdown()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            List<string> stateAbbreviations =
                StateRepository.GetAll().Select(s => s.StateAbbreviation).ToList();
            foreach (string s in stateAbbreviations)
            {
                list.Add(new SelectListItem()
                {
                    Text = s,
                    Value = s
                });
            }

            return list;
        }

        /// <summary>
        /// Generates a list of SelectListItem's containing data from purchase types in the repository.
        /// </summary>
        /// <returns>The generated list</returns>
        public static List<SelectListItem> GetPurchaseTypesDropdown()
        {
            List<PurchaseType> purchaseTypes = PurchaseTypeRepository.GetAll();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (PurchaseType type in purchaseTypes)
            {
                list.Add(new SelectListItem()
                {
                    Text = type.PurchaseTypeName,
                    Value = "" + type.PurchaseTypeID
                });
            }

            return list;
        }
    }
}
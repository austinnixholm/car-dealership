using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CarDealershipAPI.Logic;
using CarDealershipAPI.Models;
using CarDealershipAPI.Models.VehicleModels;
using CarDealershipAPI.Models.ViewModels;

namespace CarDealershipAPI.Controllers
{
    [AllowAnonymous]
    public class InventoryAPIController : ApiController
    {
        /// <summary>
        /// Handles an inventory search. Filters out different search terms specified within the parameters.
        /// </summary>
        /// <param name="inventoryType">The inventory type (used/new/admin/sales)</param>
        /// <param name="minPrice">The min price for the vehicle</param>
        /// <param name="maxPrice">The amx price for the vehicle</param>
        /// <param name="minYear">The min year for the vehicle</param>
        /// <param name="maxYear">The max year for the vehicle</param>
        /// <param name="searchTerm">The search term (make model year)</param>
        /// <returns>A response containing the filtered vehicles</returns>
        [Route("inventory/search/{inventoryType}/{minPrice}/{maxPrice}/{minYear}/{maxYear}/{searchTerm}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult NewInventory(string inventoryType, decimal minPrice, decimal maxPrice, int minYear, int maxYear,
            string searchTerm)
        {
            List<VehicleViewModel> model = new List<VehicleViewModel>();
            List<Vehicle> vehicles = Manager.VehicleRepository.GetAll();
            foreach (Vehicle v in vehicles)
            {
                if (v.Sold)
                    continue;
                const int defaultValue = 0;
                if (searchTerm.ToLower().Equals("none")) searchTerm = string.Empty;
                Make make = Manager.MakeRepository.GetById(v.MakeID);
                Model vehicleModel = Manager.ModelRepository.GetById(v.ModelID);
                Interior interior = Manager.InteriorRepository.Get(v.InteriorID);
                BodyStyle bodyStyle = Manager.BodyStyleRepository.Get(vehicleModel.BodyStyleID);
                int.TryParse(searchTerm, out int parsedYear);
                bool searchForYear = parsedYear != defaultValue;
                bool checkPrice = !(minPrice.Equals(defaultValue) && maxPrice.Equals(defaultValue)) ||
                                  (minPrice.Equals(defaultValue) && !maxPrice.Equals(defaultValue)) ||
                                  (!minPrice.Equals(defaultValue) && maxPrice.Equals(defaultValue));
                bool checkYear = !((minYear.Equals(defaultValue) && maxYear.Equals(defaultValue))) ||
                                 ((minYear.Equals(defaultValue) && !maxYear.Equals(defaultValue))) ||
                                 (!minYear.Equals(defaultValue) && maxYear.Equals(defaultValue));
                if (!inventoryType.ToLower().Equals("sales") && !inventoryType.ToLower().Equals("admin"))
                {
                    if (!v.Category.ToLower().Equals(inventoryType.ToLower())) continue;
                }
                if (searchForYear)
                {
                    if (!v.Year.Equals(parsedYear)) continue;
                }
                if (checkPrice)
                {
                    if (maxPrice.Equals(defaultValue) && !minPrice.Equals(defaultValue))
                    {
                        if (v.MSRP < minPrice) continue;
                    }
                    else if (!(v.MSRP >= minPrice && v.MSRP <= maxPrice)) continue;
                }
                if (checkYear)
                {
                    if (maxYear.Equals(defaultValue) && !minYear.Equals(defaultValue))
                    {
                        if (v.Year < minYear) continue;
                    } else if (!(v.Year >= minYear && v.Year <= maxYear)) continue;
                }
                if (!string.IsNullOrEmpty(searchTerm) && !searchForYear)
                {
                    string makeModel = make.MakeName + " " + vehicleModel.ModelName;
                    if (!makeModel.ToLower().Contains(searchTerm.ToLower())) continue;
                }
                model.Add(new VehicleViewModel()
                {
                    Make = make,
                    Model = vehicleModel,
                    Vehicle = v,
                    Interior = interior,
                    BodyStyle = bodyStyle
                });
            }
            return Ok(model);
        }

        /// <summary>
        /// Grabs all the available vehicle models associated with a make.
        /// </summary>
        /// <param name="make">The make name</param>
        /// <returns>A list of found models</returns>
        [Route("inventory/models/{Make}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetModelsForMake(string make)
        {
            int makeID = Manager.MakeRepository.GetMakeId(make);
            if (makeID < 0) return NotFound();
            List<Model> models = Manager.ModelRepository.GetAllByMake(makeID);
            if (models.Count <= 0) return NotFound();
            return Ok(models);
        }

        /// <summary>
        /// Deletes a vehicle within the inventory.
        /// </summary>
        /// <param name="id">The vehicle ID</param>
        /// <returns></returns>
        [Route("inventory/vehicles/delete/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteVehicle(int id)
        {
            if (Manager.VehicleRepository.Get(id) == null) return NotFound();
            Manager.VehicleRepository.DeleteVehicle(id);
            return Ok();
        }
    }
}
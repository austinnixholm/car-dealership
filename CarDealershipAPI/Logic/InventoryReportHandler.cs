using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarDealershipAPI.Models.Reports;
using CarDealershipAPI.Models.VehicleModels;

namespace CarDealershipAPI.Logic
{
    public class InventoryReportHandler
    {
        /// <summary>
        /// Generates a list of InventoryReports from the database, based on the category of the vehicle.
        /// Loads a list of a specific category vehicle, containing data of all individual types,
        /// such as the same model/year.
        /// </summary>
        /// <param name="category">The vehicle category</param>
        /// <returns>List of InventoryReports</returns>
        public static List<InventoryReport> GenerateInventoryReports(string category)
        {
            List<InventoryReport> reports = new List<InventoryReport>();

            // Get all the vehicles in the database
            List<Vehicle> vehicles = Manager.VehicleRepository.GetAll();
            foreach (Vehicle v in vehicles)
            {
                if (v.Sold) continue; // Ignore any vehicle that is sold
                if (!v.Category.ToLower().Equals(category.ToLower())) continue; // Ignore any vehicle without a matching category
                // Try to find an existing InventoryReport from the current reports list, and the vehicle's model ID
                InventoryReport reportForModel = ReportForModel(reports, v.ModelID);
                if (reportForModel != null)
                {
                    // If the report exists, check if the report has a matching year for that model.
                    if (reportForModel.VehicleYear.Equals(v.Year))
                        UpdateReport(v, reportForModel); // Update the report with this vehicle's info
                    else
                        AddReportToList(reports, v); // Otherwise, add a new report to the list.
                }
                else // If no report exists for this vehicle model, add a new one.
                    AddReportToList(reports, v);
            }
            return reports;
        }

        /// <summary>
        /// Updates an existing InventoryReport object with data from a vehicle.
        /// </summary>
        /// <param name="v">The vehicle</param>
        /// <param name="report">The existing InventoryReport</param>
        private static void UpdateReport(Vehicle v, InventoryReport report)
        {
            report.StockValue += v.MSRP;
            report.VehicleCount++;
        }

        /// <summary>
        /// Adds a new InventoryReport to the list.
        /// </summary>
        /// <param name="list">The list of reports</param>
        /// <param name="v">The vehicle</param>
        private static void AddReportToList(List<InventoryReport> list, Vehicle v)
        {
            list.Add(new InventoryReport()
            {
                ModelID = v.ModelID,
                StockValue = v.MSRP,
                VehicleCount = 1,
                VehicleYear = v.Year,
                MakeName = Manager.MakeRepository.GetById(v.MakeID).MakeName,
                ModelName = Manager.ModelRepository.GetById(v.ModelID).ModelName
            });
        }

        /// <summary>
        /// Finds the first InventoryReport in a list with the matching model ID
        /// </summary>
        /// <param name="reports">The reports list</param>
        /// <param name="modelID">The model ID to match</param>
        /// <returns>The found inventory report</returns>
        private static InventoryReport ReportForModel(List<InventoryReport> reports, int modelID)
        {
            foreach (InventoryReport report in reports)
            {
                if (report.ModelID.Equals(modelID)) return report;
            }

            return null;
        }
    }
}
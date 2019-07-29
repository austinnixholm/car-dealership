using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CarDealershipAPI.Logic;
using CarDealershipAPI.Models.Sales;
using CarDealershipAPI.Models.VehicleModels;
using CarDealershipAPI.Models.ViewModels;


namespace CarDealershipAPI.Controllers
{
    public class SalesAPIController : ApiController
    {
        /// <summary>
        /// Handles vehicle sale searches within the repository.
        /// Parses and compares entered dates with vehicle sales within the database,
        /// compiles a list and returns it.
        ///
        /// Date must be in format MM-dd-yyyy
        /// 
        /// </summary>
        /// <param name="staffID">The staff ID filter</param>
        /// <param name="fromDate">The from date</param>
        /// <param name="toDate">The to date</param>
        /// <returns>A list of found vehicle sales</returns>
        [Route("sales/search/{staffID}/{fromDate}/{toDate}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchSales(string staffID, string fromDate, string toDate)
        {
            List<SalesReportTableViewModel> list = new List<SalesReportTableViewModel>();
            List<VehicleSale> sales = Manager.SalesRepository.GetAll();
            List<int> staffIdsChecked = new List<int>();
            foreach (VehicleSale sale in sales)
            {
                bool noFromDate = fromDate.ToLower().Equals("none") || !Manager.CanParseAsDate(fromDate), noToDate = toDate.ToLower().Equals("none") || !Manager.CanParseAsDate(toDate);
                DateTime from = noFromDate ? default(DateTime) : DateTime.Parse(fromDate);
                DateTime to = noToDate ? default(DateTime) : DateTime.Parse(toDate);
                bool checkFromDate = from != default(DateTime);
                bool checkToDate = to != default(DateTime);
                bool checkStaff = staffID.ToLower() != "all";
                if (staffIdsChecked.Contains(sale.StaffID)) continue;
                if (checkStaff)
                {
                    int id = int.Parse(staffID);
                    if (sale.StaffID != id) 
                        continue;
                }
                if (checkFromDate && checkToDate)
                {
                    if (sale.DateSold.Ticks < from.Ticks || sale.DateSold.Ticks > to.Ticks)
                        continue;
                } else if (checkFromDate)
                {
                    if (sale.DateSold.Ticks < from.Ticks)
                        continue;
                } else if (checkToDate)
                {
                    if (sale.DateSold.Ticks > to.Ticks)
                        continue;
                }
                list.Add(new SalesReportTableViewModel()
                {
                    UserName = Manager.StaffRepository.GetById(sale.StaffID).Name,
                    TotalSalesAmount = (from VehicleSale s in sales
                                        where s.StaffID.Equals(sale.StaffID)
                                        select s).Sum(s=>s.AmountSoldFor),
                    TotalVehicles = sales.Count(s=>s.StaffID.Equals(sale.StaffID))
                });
                staffIdsChecked.Add(sale.StaffID);

            }
            return Ok(list);
        }
    }
}
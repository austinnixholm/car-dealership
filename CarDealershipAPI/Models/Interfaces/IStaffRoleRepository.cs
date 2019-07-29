using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealershipAPI.Models.Staff;

namespace CarDealershipAPI.Models.Interfaces
{
    public interface IStaffRoleRepository
    {
        List<StaffRole> GetAll();
        StaffRole GetById(int staffRoleID);
    }
}

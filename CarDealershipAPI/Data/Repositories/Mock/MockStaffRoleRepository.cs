using System;
using System.Collections.Generic;
using System.Linq;
using CarDealershipAPI.Models.Interfaces;
using CarDealershipAPI.Models.Staff;

namespace CarDealershipAPI.Data.Repositories.Mock
{
    public class MockStaffRoleRepository : IStaffRoleRepository
    {
        private List<StaffRole> _roles = new List<StaffRole>()
        {
            new StaffRole()
            {
                StaffRoleID = 1,
                RoleName = "Sales"
            },
            new StaffRole()
            {
                StaffRoleID = 2,
                RoleName = "Admin"
            },
            new StaffRole()
            {
                StaffRoleID = 3,
                RoleName = "Disabled"
            }
        };

        public List<StaffRole> GetAll()
        {
            return _roles;
        }

        public StaffRole GetById(int staffRoleID)
        {
            return _roles.FirstOrDefault(r => r.StaffRoleID.Equals(staffRoleID));
        }

    }
}
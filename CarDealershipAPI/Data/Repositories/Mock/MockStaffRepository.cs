using System.Collections.Generic;
using System.Linq;
using CarDealershipAPI.Models.Interfaces;
using CarDealershipAPI.Models.Staff;

namespace CarDealershipAPI.Data.Repositories.Mock
{
    public class MockStaffRepository : IStaffMemberRepository
    {
        private List<StaffMember> _staff = new List<StaffMember>()
        {
            new StaffMember()
            {
                StaffID = 1,
                StaffRoleID = 1, // sales
                Email = "sample@email.com",
                Name = "John Doe",
                Password = "123"
            }, 
            new StaffMember()
            {
                StaffID = 2,
                StaffRoleID = 2,
                Email = "admin@email.com",
                Name = "Admin User",
                Password = "1234"
            }
        };

        public List<StaffMember> GetAll()
        {
            return _staff;
        }

        public StaffMember GetById(int staffID)
        {
            return _staff.FirstOrDefault(s => s.StaffID.Equals(staffID));
        }

        public void AddStaffMember(StaffMember staffMember)
        {
            staffMember.StaffID = _staff.Max(s => s.StaffID) + 1;
            _staff.Add(staffMember);
        }

        public void EditStaffMember(StaffMember staffMember)
        {
            StaffMember old = _staff.FirstOrDefault(s => s.StaffID.Equals(staffMember.StaffID));
            if (old == null) return;
            old.Name = staffMember.Name;
            old.Email = staffMember.Email;
            old.StaffRoleID = staffMember.StaffRoleID;
            old.Password = staffMember.Password;
        }
    }
}
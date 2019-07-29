using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealershipAPI.Models.Staff;

namespace CarDealershipAPI.Models.Interfaces
{
    public interface IStaffMemberRepository
    {
        List<StaffMember> GetAll();
        StaffMember GetById(int staffID);
        void AddStaffMember(StaffMember staffMember);
        void EditStaffMember(StaffMember staffMember);
    }
}

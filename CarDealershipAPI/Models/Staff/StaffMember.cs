using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealershipAPI.Models.Staff
{
    public class StaffMember
    {
        [Key]
        public int StaffID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public int StaffRoleID { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
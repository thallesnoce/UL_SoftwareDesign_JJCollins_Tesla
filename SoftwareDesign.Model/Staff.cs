using System;

namespace SoftwareDesign.Model
{
    public class Staff : User
    {
        public int StaffId { get; set; }
        public Boolean IsActive { get; set; }
        public EnumRoleType RoleType { get; set; }
    }
}
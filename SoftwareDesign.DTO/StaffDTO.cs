using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.DTO
{
    public class StaffDTO : UserDTO
    {
        public int StaffId { get; set; }
        public bool IsActive { get; set; }
    }
}
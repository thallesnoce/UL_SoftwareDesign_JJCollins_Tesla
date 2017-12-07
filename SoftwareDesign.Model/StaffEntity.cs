using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.Entities
{
    public class StaffEntity : UserEntity
    {
        public int StaffId { get; set; }
        public bool IsActive { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    public class RolePrivilege
    { 
        public int RoleId { get; set; }
        public int PrivilegeId { get; set; }


        public bool? IsActive { get; set; }

        public virtual Role Role { get; set; }
        public virtual Privilege Privilege { get; set; }
    }
}

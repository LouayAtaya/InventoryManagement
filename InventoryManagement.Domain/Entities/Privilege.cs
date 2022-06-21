using InventoryManagement.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Domain.Entities
{
    public class Privilege: Auditor
    {
        public String Name { get; set; }
        public String Description { get; set; }

        public virtual ICollection<RolePrivilege> RolePrivileges { get; set; }

    }
}

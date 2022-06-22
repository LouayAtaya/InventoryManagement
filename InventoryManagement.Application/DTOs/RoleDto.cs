using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class RoleDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public virtual ICollection<RolePrivilege> RolePrivileges { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? DeActivatedAt { get; set; }
        public int? DeActivatedBy { get; set; }
    }
}

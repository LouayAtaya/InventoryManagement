using InventoryManagement.Domain.Entities.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace InventoryManagement.Domain.Entities
{
    public class Role: IdentityRole<int>
    {

        public String Description { get; set; }

        [DefaultValue(true)]
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? DeActivatedAt { get; set; }
        public int? DeActivatedBy { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<RoleClaim> RoleClaims { get; set; }
        public virtual ICollection<RolePrivilege> RolePrivileges { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    public class UserRole: IdentityUserRole<int>
    {
        
        public bool? IsActive { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}

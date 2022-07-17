using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    public class RoleClaim: IdentityRoleClaim<int>
    {
        public virtual Role Role { get; set; }
    }
}

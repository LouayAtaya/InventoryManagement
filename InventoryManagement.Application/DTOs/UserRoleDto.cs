using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class UserRoleDto : IEntityDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public bool? IsActive { get; set; }
    }
}

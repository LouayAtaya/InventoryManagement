using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class UserRoleForCreationDto : IEntityDto
    {
        public int RoleId { get; set; }

        public bool? IsActive { get; set; } 
    }
}

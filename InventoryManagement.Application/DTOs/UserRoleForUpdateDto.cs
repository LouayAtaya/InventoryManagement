using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class UserRoleForUpdateDto : IEntityDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public bool IsActive { get; set; } = true;
    }
}

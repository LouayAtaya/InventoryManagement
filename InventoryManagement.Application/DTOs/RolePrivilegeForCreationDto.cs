using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class RolePrivilegeForCreationDto : IEntityDto
    {
        public int PrivilegeId { get; set; }

        public bool? IsActive { get; set; }

    }
}

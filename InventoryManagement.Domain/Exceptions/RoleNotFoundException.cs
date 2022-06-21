using InventoryManagement.Domain.Exceptions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Exceptions
{
    public class RoleNotFoundException : ResourceNotFoundException
    {
        public RoleNotFoundException(int roleId)
            : base($"The Role with the identifier {roleId} was not found.")
        {

        }
    }
}

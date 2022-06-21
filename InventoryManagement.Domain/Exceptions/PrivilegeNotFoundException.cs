using InventoryManagement.Domain.Exceptions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Exceptions
{
    public class PrivilegeNotFoundException : ResourceNotFoundException
    {
        public PrivilegeNotFoundException(int privilegeId)
            : base($"The Privilege with the identifier {privilegeId} was not found.")
        {

        }
    }
}

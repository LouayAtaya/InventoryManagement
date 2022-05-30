using InventoryManagement.Domain.Exceptions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Exceptions
{
    public class ItemOperationNotFoundException : ResourceNotFoundException
    {
        public ItemOperationNotFoundException(int itemOperationId)
            : base($"The Item Operation with the identifier {itemOperationId} was not found.")
        {
            //        : base($"The account with the identifier {accountId} does not belong to the owner with the identifier {ownerId}")

        }
    }
}

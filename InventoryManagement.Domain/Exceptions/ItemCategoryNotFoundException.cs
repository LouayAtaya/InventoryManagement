using InventoryManagement.Domain.Exceptions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Exceptions
{
    public class ItemCategoryNotFoundException : ResourceNotFoundException
    {
        public ItemCategoryNotFoundException(int itemCategoryId)
            : base($"The ItemCategory with the identifier {itemCategoryId} was not found.")
        {
            //        : base($"The account with the identifier {accountId} does not belong to the owner with the identifier {ownerId}")

        }
    }
}

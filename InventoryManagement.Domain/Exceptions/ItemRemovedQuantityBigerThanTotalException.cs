using InventoryManagement.Domain.Exceptions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Exceptions
{
    public class ItemRemovedQuantityBigerThanTotalException: BadRequestException
    {
        public ItemRemovedQuantityBigerThanTotalException()
            : base($"We Can not apply this Item Operation, as Total Quantity is less that the affected quantity ")
        {
            //        : base($"The account with the identifier {accountId} does not belong to the owner with the identifier {ownerId}")

        }
    }
}

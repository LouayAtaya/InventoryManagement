using InventoryManagement.Domain.Exceptions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Exceptions
{
    public class ItemNotExistInWarehouseException:ResourceNotFoundException
    {
        public ItemNotExistInWarehouseException(int warehouseId)
            : base($"The Item doen't exist in the selected warehouse with the identifier {warehouseId}")
        {
            //        : base($"The account with the identifier {accountId} does not belong to the owner with the identifier {ownerId}")

        }
}
}

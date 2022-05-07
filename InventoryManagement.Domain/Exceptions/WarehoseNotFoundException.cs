using InventoryManagement.Domain.Exceptions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Exceptions
{
    public class WarehoseNotFoundException : ResourceNotFoundException
    {
        public WarehoseNotFoundException(int warehouseId) 
            : base($"The Warehouse with the identifier {warehouseId} was not found.")
        {
        }
    }
}

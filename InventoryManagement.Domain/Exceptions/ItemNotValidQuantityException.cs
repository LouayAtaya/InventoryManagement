using InventoryManagement.Domain.Exceptions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Exceptions
{
    public class ItemNotValidQuantityException : BadRequestException
    {
        public ItemNotValidQuantityException()
            : base($"Item total quantity range error, the maxQuantity can not be less than minQuantity")
        {

        }
    }
}


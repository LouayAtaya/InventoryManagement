using InventoryManagement.Domain.Exceptions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Exceptions
{
    public class ItemNotValidPriceRangeException : BadRequestException
    {
        public ItemNotValidPriceRangeException()
            : base($"Item Price range error, the maxPrice can not be less than minPrice")
        {

        }
    }
}
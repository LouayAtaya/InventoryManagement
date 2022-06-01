using InventoryManagement.Domain.Exceptions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Exceptions
{
    public class ItemQunatityErrorException: BadRequestException
    {
        public ItemQunatityErrorException()
            : base($"Item Qunaity mustn't be less than 0 ")
        {
            //        : base($"The account with the identifier {accountId} does not belong to the owner with the identifier {ownerId}")

        }
    }
}

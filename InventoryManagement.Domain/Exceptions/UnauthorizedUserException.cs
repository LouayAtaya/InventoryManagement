using InventoryManagement.Domain.Exceptions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Exceptions
{
    public class UnauthorizedUserException: UnauthorizedException
    {
        public UnauthorizedUserException()
            : base($"Un Authorized Access, The User was not found.")
        {

        }
    }
}

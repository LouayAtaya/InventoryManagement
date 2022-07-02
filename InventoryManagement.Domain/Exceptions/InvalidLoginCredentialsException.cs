using InventoryManagement.Domain.Exceptions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Exceptions
{
    public class InvalidLoginCredentialsException : UnauthorizedException
    {
        public InvalidLoginCredentialsException()
            : base($"Invalid Login Credentials! Username or password is incorrect ")
        {
            //        : base($"The account with the identifier {accountId} does not belong to the owner with the identifier {ownerId}")

        }
    }
}

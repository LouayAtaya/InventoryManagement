using InventoryManagement.Domain.Exceptions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Exceptions
{
    public class UserNotFoundException : ResourceNotFoundException
    {
        public UserNotFoundException(int userId)
            : base($"The User with the identifier {userId} was not found.")
        {

        }

    }
}

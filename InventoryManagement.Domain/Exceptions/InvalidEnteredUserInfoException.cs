using InventoryManagement.Domain.Exceptions.Abstractions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Exceptions
{
    public class InvalidEnteredUserInfoException : BadRequestException
    {
        
        public InvalidEnteredUserInfoException(IEnumerable<IdentityError> identityErrors)
            : base($"Item Price range error, the maxPrice can not be less than minPrice")
        {
            this.ValidationErrors = identityErrors;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Exceptions.Abstractions
{
    public abstract class ResourceNotFoundException: Exception
    {
        public int StatusCode { get;  } = (int)HttpStatusCode.NotFound;

        protected ResourceNotFoundException(String message)
            : base(message)
        {
        }
    }
}

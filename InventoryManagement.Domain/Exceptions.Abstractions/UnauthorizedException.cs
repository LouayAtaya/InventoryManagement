using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Exceptions.Abstractions
{
    public abstract class UnauthorizedException : Exception
    {
        public int StatusCode { get; } = (int)HttpStatusCode.Unauthorized;

        protected UnauthorizedException(String message)
            : base(message)
        {
        }
    }
}

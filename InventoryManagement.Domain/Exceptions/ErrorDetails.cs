using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Exceptions
{
    public class ErrorDetails
    {
        public DateTime timestamp { get; set; } = DateTime.Now;
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string details { get; set; }
        public object validationErrors { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

    }
}

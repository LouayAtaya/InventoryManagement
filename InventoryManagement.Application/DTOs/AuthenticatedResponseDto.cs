using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class AuthenticatedResponseDto: IEntityDto
    {
        public string Token { get; set; }

    }
}

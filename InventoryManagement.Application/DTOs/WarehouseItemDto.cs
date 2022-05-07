using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class WarehouseItemDto : IEntityDto
    {
        public int WarehouseId { get; set; }
        public String WarehouseName { get; set; }
        public int Quantity { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class SaleOrderItemForCreationDto: IEntityDto
    {
        public int ItemId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int? SubTotal { get; set; }
    }
}

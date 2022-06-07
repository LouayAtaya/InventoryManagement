using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class SaleOrderItemDto: IEntityDto
    {
        public int Id { get; set; }
        public int ItemId { get; set; }

        public string ItemCode { get; set; }

        public string ItemName { get; set; }

        public int price { get; set; }
        public int Quantity { get; set; }
        public int SubTotal { get; set; }
    }
}

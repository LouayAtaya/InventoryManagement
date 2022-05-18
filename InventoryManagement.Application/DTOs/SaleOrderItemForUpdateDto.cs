using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class SaleOrderItemForUpdateDto:IEntityDto
    {
        public int? Id { get; set; }

        public int ItemId { get; set; }
        public int SaleOrderId { get; set; }

        public int price { get; set; }
        public int Quantity { get; set; }
        public int? SubTotal { get; set; }

    }
}

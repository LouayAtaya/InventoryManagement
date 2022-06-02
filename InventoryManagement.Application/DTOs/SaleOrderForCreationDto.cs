using InventoryManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class SaleOrderForCreationDto:IEntityDto
    {
        public SaleOrderForCreationDto()
        {
        }

        public int CustomerId { get; set; }

        public int WarehouseId { get; set; }
        public SaleOrderStatus SaleOrderStatus { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot be loner than 500 characters")]
        public String Description { get; set; }

        public int? TotalAmount { get; set; }

        public int? TotalOrderPrice { get; set; }

        [Required(ErrorMessage = "it should be at least one Sale Order row")]
        public virtual ICollection<SaleOrderItemForCreationDto> SaleOrderItems { get; set; }

        public bool? IsActive { get; set; } = true;

    }
}

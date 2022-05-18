using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class SaleOrderForUpdateDto
    {
        public SaleOrderForUpdateDto()
        {
            SaleOrderItems = new List<SaleOrderItemForUpdateDto>();
        }

        public int? Id { get; set; }

        public int CustomerId { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot be loner then 500 characters")]
        public String Description { get; set; }

        public int? TotalAmount { get; set; }

        public int? TotalOrderPrice { get; set; }

        public virtual ICollection<SaleOrderItemForUpdateDto> SaleOrderItems { get; set; }

        public bool? IsActive { get; set; } = true;
    }
}

using InventoryManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class ItemOperationForCreationDto: IEntityDto
    {
        public int ItemId { get; set; }
        public int WarehouseId { get; set; }

        public int? PreviousQuantity { get; set; }

        [Required(ErrorMessage = "AffectedQuantity is required")]
        public int? AffectedQuantity { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot be loner than 500 characters")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Item Operation Type is required")]
        public ItemOperationType ItemOperationType { get; set; }

        public bool? IsActive { get; set; } = true;

    }
}

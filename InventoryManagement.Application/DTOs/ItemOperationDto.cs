using InventoryManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class ItemOperationDto
    {
        public int Id { get; set; }

        public int ItemId { get; set; }
        public string ItemName { get; set; }

        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }

        public int PreviousQuantity { get; set; }

        public int AffectedQuantity { get; set; }

        public string Description { get; set; }

        public ItemOperationType ItemOperationType { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? DeActivatedAt { get; set; }
        public int? DeActivatedBy { get; set; }

    }
}

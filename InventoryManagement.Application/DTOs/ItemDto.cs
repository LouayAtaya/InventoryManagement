using InventoryManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    public class ItemDto : IEntityDto
    {
        public int Id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Inroduction { get; set; }
        public int Price { get; set; }
        public int TotalQuantity { get; set; }
        public ItemType ItemType { get; set; }

        public int ItemCategoryId { get; set; }
        public string ItemCategoryName { get; set; }

        public virtual ICollection<ItemImageDto> ItemImages { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? DeActivatedAt { get; set; }
        public int? DeActivatedBy { get; set; }

    }
}

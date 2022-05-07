using InventoryManagement.Domain.Entities.Base;
using InventoryManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InventoryManagement.Domain.Entities
{
    
    public class Item : Auditor
    {
        public String Code { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Inroduction { get; set; }
        public int Price { get; set; }
        public int TotalQuantity { get; set; }
        public ItemType ItemType { get; set; }

        public int ItemCategoryId { get; set; }
        public virtual ItemCategory ItemCategory { get; set; }
        public virtual ICollection<WarehouseItem> WarehouseItems { get; set; }
        public virtual ICollection<ItemImage> ItemImages { get; set; }
        [NotMapped]
        public int? LocationId { get; set; }
        [NotMapped]
        public Location Location { get; set; }
    }
}

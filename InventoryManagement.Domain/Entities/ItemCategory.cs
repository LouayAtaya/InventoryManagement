using InventoryManagement.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InventoryManagement.Domain.Entities
{
    public class ItemCategory:Auditor
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public String Image { get; set; }

        public int? ParentCategoryId { get; set; }
        public virtual ItemCategory ParentCategory {get; set; }
        public virtual List<ItemCategory>  ChildCategories { get; set; }
        [NotMapped]
        public int CategoryTypeId { get; set; }
        [NotMapped]
        public ItemCategoryType CategoryType { get; set; }
        public virtual ICollection<Item> Items { get; set; }

    }
}

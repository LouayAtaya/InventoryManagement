using InventoryManagement.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Domain.Entities
{
    public class ItemImage:BaseEntity
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public String Url { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

    }
}

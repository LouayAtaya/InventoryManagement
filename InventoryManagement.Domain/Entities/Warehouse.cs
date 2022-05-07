using InventoryManagement.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InventoryManagement.Domain.Entities
{
    public class Warehouse:Auditor
    {
        public String Name { get; set; }
        public String Description { get; set; }

        public virtual ICollection<WarehouseItem> WarehouseItems { get; set; }
        [NotMapped]
        public Location Location { get; set; }


    }
}

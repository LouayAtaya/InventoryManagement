using InventoryManagement.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Domain.Entities
{
    public class WarehouseItem
    {
        public WarehouseItem()
        {

        }

        public WarehouseItem(int itemId,int warehouseId, int quantity)
        {
            this.ItemId = itemId;
            this.WarehouseId = warehouseId;
            this.Quantity = quantity;
        }

        public int ItemId { get; set; }
        public int WarehouseId { get; set; }

        public int Quantity { get; set; }

        public Item Item { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}

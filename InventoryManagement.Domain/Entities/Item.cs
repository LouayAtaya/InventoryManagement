using InventoryManagement.Domain.Entities.Base;
using InventoryManagement.Domain.Enums;
using InventoryManagement.Domain.Exceptions;
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

        public int MinPrice { get; set; }

        public int Price { get; set; }
        public int TotalQuantity { get; set; }
        public ItemType ItemType { get; set; }

        public int ItemCategoryId { get; set; }
        public virtual ItemCategory ItemCategory { get; set; }
        public virtual ICollection<WarehouseItem> WarehouseItems { get; set; }
        public virtual ICollection<ItemImage> ItemImages { get; set; }
        public virtual ICollection<SaleOrderItem> SaleOrderItems { get; set; }
        public virtual ICollection<ItemOperation> ItemOperations { get; set; }


        [NotMapped]
        public int? LocationId { get; set; }
        [NotMapped]
        public Location Location { get; set; }


        public void CalculateTotalQuantity()
        {
            this.TotalQuantity = 0;

            if (this.WarehouseItems != null && this.WarehouseItems.Count > 0)
            {
                foreach (var warehouseItem in this.WarehouseItems)
                {
                    this.TotalQuantity = this.TotalQuantity + warehouseItem.Quantity;
                }
            }
        }

        public void AddNewQuantity(int warehouseId,int quantity)
        {
            bool itemExistInWarehouse = false;
            foreach(WarehouseItem warehouseItem in WarehouseItems)
            {
                if (warehouseItem.WarehouseId == warehouseId)
                {
                    itemExistInWarehouse = true;
                    warehouseItem.Quantity += quantity;
                    break;
                }
            }

            if (!itemExistInWarehouse)
            {
                this.WarehouseItems.Add(new WarehouseItem(this.Id,warehouseId,quantity));
            }
            this.TotalQuantity += quantity;
        }

        public void RemoveQuantity(int warehouseId, int quantity)
        {
            if (this.TotalQuantity < quantity)
                throw new ItemRemovedQuantityBigerThanTotalException();

            bool itemExistInWarehouse = false;
            foreach (WarehouseItem warehouseItem in WarehouseItems)
            {
                if (warehouseItem.WarehouseId == warehouseId)
                {
                    itemExistInWarehouse = true;

                    if (warehouseItem.Quantity < quantity)
                        throw new ItemRemovedQuantityBigerThanTotalException();

                    warehouseItem.Quantity -= quantity;
                    break;
                }
            }

            if (!itemExistInWarehouse)
                throw new ItemNotExistInWarehouseException(warehouseId);

            this.TotalQuantity -= quantity;
        }
    }
}

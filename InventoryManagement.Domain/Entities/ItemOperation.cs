using InventoryManagement.Domain.Entities.Base;
using InventoryManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    public class ItemOperation: Auditor
    {
        public int ItemId { get; set; }

        public int WarehouseId { get; set; }

        public int PreviousQuantity { get; set; }

        public int AffectedQuantity { get; set; }

        public string Description { get; set; }

        public ItemOperationType ItemOperationType { get; set; }

        public virtual Item Item { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        [NotMapped]
        public int IsReturnOperation { get; set; }
        [NotMapped]
        public int RmrId { get; set; }

        [NotMapped]
        public bool IsSaleOperation { get; set; }
        [NotMapped]
        public int SaleInvoiceId { get; set; }

    }
}

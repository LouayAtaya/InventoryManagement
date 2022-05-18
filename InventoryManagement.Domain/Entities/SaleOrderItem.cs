using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    public class SaleOrderItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int SaleOrderId { get; set; }

        [NotMapped]
        public int UnitId { get; set; }

        public int price { get; set; }
        public int Quantity { get; set; }
        public int SubTotal { get; set; }

        public virtual Item Item { get; set; }
        public virtual SaleOrder SaleOrder { get; set; }



        public void CalculateSubTotal()
        {
            this.SubTotal = this.Quantity * this.price;
        }

        


    }
}

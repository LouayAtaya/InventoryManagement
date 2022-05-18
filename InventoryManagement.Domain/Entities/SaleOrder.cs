using InventoryManagement.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    public class SaleOrder:Auditor
    {
        public int CustomerId { get; set; }

        public String Description { get; set; }

        public int TotalAmount { get; set; }

        [NotMapped]
        public int ShipToLocation { get; set; }

        [NotMapped]
        public int ShippingPrice { get; set; }

        public int TotalOrderPrice { get; set; }

        public virtual Account Customer { get; set; }
        public virtual ICollection<SaleOrderItem> SaleOrderItems { get; set; }

        public void  CalculateTotalOrderPrice()
        {
            this.TotalAmount = 0;
            this.TotalOrderPrice = 0;
            foreach (var saleOrderItem in SaleOrderItems)
            {
                saleOrderItem.CalculateSubTotal();
                this.TotalAmount += saleOrderItem.SubTotal;
            }

            //calculate additional values and add them to total amount
            this.TotalOrderPrice += this.TotalAmount;
        }

        

    }
}

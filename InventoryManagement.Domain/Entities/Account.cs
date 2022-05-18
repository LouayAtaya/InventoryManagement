using InventoryManagement.Domain.Entities.Base;
using InventoryManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    public class Account:Auditor
    {
        public string AccountCode { get; set; }
        public AccountType AccountType { get; set; }

        public double Amount { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        [NotMapped]
        public int Address { get; set; }

        [NotMapped]
        public string Phone { get; set; }

        [NotMapped]
        public string Email { get; set; }

        public virtual ICollection<SaleOrder> SaleOrders { get; set; }
    }
}

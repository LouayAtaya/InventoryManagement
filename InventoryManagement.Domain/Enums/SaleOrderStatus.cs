using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Enums
{
    public enum SaleOrderStatus:byte
    {
        Incomplet,
        Pending,
        Approved,
        Rejected
    }
}

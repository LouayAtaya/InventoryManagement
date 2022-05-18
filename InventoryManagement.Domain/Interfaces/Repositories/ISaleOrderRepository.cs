using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Interfaces.Repositories
{
    public interface ISaleOrderRepository : IRepositoryBase<SaleOrder>
    {
        Task<IEnumerable<SaleOrder>> getAllSaleOrdersAsync();
        Task<SaleOrder> GetSaleOrderByIdAsync(int saleOrderId);
        Task<SaleOrder> GetSaleOrdertWithDetailsAsync(int saleOrderId);
    }
}

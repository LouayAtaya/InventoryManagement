using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Interfaces.Repositories;
using InventoryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class SaleOrderRepository: RepositoryBase<SaleOrder>, ISaleOrderRepository
    {
        public SaleOrderRepository(InventoryManagementContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<SaleOrder>> getAllSaleOrdersAsync()
        {
            return await FindAll()
                .Include(s => s.Customer)
                .Include(s => s.Warehouse)
                .ToListAsync();
        }

        public async Task<SaleOrder> GetSaleOrderByIdAsync(int saleOrderId)
        {
            return await FindByCondition(s => s.Id == saleOrderId).SingleOrDefaultAsync();
        }

        public async Task<SaleOrder> GetSaleOrdertWithDetailsAsync(int saleOrderId)
        {
            return await FindByCondition(s => s.Id == saleOrderId)
                .Include(s => s.Customer)
                .Include(s => s.Warehouse)
                .Include(s=>s.SaleOrderItems)
                .ThenInclude(si => si.Item)
                .SingleOrDefaultAsync();
        }
    }
}

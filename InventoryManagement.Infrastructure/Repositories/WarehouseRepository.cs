
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Interfaces.Repositories;
using InventoryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class WarehouseRepository:RepositoryBase<Warehouse>,IWarehouseRepository
    {
        public WarehouseRepository(InventoryManagementContext dbContext):base(dbContext)
        {

        }

        public async Task<IEnumerable<Warehouse>> GetAllWarehousesAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Warehouse> GetWarehouseByIdAsync(int warehouseId)
        {
            return await FindByCondition(w => w.Id == warehouseId).SingleOrDefaultAsync(); 
        }
    }
}

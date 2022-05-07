
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
    public class ItemRepository: RepositoryBase<Item>,IItemRepository
    {
        public ItemRepository(InventoryManagementContext dbContext):base(dbContext)
        {
        }

        public async Task<IEnumerable<Item>> getAllItemsAsync()
        {
            return await FindAll()
                .Include(i => i.ItemCategory)
                .ToListAsync();
        }

        public async Task<Item> GetItemByIdAsync(int itemId)
        {
            return await FindByCondition(i => i.Id == itemId)
                .Include(i => i.ItemCategory)
                .Include(i=>i.ItemImages)
                .Include(i => i.WarehouseItems)
                .ThenInclude(i => i.Warehouse).SingleOrDefaultAsync();  
        }

        public async Task<Item> GetItemWithDetailsAsync(int itemId)
        {
            return await FindByCondition(i => i.Id == itemId)
            .Include(i => i.ItemCategory)
            .Include(i => i.ItemImages)
            .Include(i => i.WarehouseItems)
            .ThenInclude(i => i.Warehouse)
            .FirstOrDefaultAsync();
         
        }

    }
}

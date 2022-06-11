using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Interfaces.Repositories;
using InventoryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class ItemOperationRepository: RepositoryBase<ItemOperation>, IItemOperationRepository
    {
        public ItemOperationRepository(InventoryManagementContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ItemOperation>> getAllItemOperations()
        {
            return await FindAll()
                    .ToListAsync();
        }

        public async Task<IEnumerable<ItemOperation>> GetItemOperationsByItemAsync(int itemId)
        {
            return await FindByCondition(i => i.ItemId == itemId)
                .Include(i=>i.Warehouse)
                .OrderByDescending(i=>i.CreatedAt)
                .ToListAsync();
        }

        public async Task<ItemOperation> GetItemOperationByIdAsync(int id)
        {
            return await FindByCondition(i => i.Id == id)
                .SingleOrDefaultAsync();
        }
    }
}

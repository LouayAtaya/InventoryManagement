
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
    public class ItemCategoryRepository : RepositoryBase<ItemCategory>, IItemCategoryRepository
    {
        public ItemCategoryRepository(InventoryManagementContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<ItemCategory>> GetAllItemCategoriesAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<ItemCategory> GetItemCategoryByIdAsync(int itemCategoryId)
        {
            return await FindByCondition(c => c.Id == itemCategoryId).SingleOrDefaultAsync();
        }

    }
}

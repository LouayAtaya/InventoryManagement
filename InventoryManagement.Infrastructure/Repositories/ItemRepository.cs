
using InventoryManagement.Application.Helpers;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Entities.Parameters;
using InventoryManagement.Domain.Interfaces.Helpers;
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
        private ISortHelper<Item> _sortHelper;

        public ItemRepository(InventoryManagementContext dbContext, ISortHelper<Item> sortHelper) :base(dbContext)
        {
            _sortHelper = sortHelper;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await FindAll()
                .Include(i => i.ItemCategory)
                .Include(i => i.ItemImages)
                .ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(ItemParameters itemParameters)
        {
            var items = FindAll()
                          .Include(i => i.ItemCategory)
                          .Include(i => i.ItemImages)
                          .Where(i => (!itemParameters.ItemCategoryId.HasValue || i.ItemCategoryId == itemParameters.ItemCategoryId)
                                        && ((!itemParameters.MaxPrice.HasValue && i.Price >= itemParameters.MinPrice) || (i.Price >= itemParameters.MinPrice && i.Price <= itemParameters.MaxPrice))
                                        && ((!itemParameters.MaxQuantity.HasValue && i.TotalQuantity >= itemParameters.MinQuantity) || (i.TotalQuantity >= itemParameters.MinQuantity && i.TotalQuantity <= itemParameters.MaxQuantity))
                                        && (!itemParameters.IsActive.HasValue || i.IsActive == itemParameters.IsActive)
                                        && (!itemParameters.ItemType.HasValue || i.ItemType == itemParameters.ItemType));

            this.SearchItems(ref items,itemParameters.SearchTerm);

            var sortedItems = _sortHelper.ApplySort(items, itemParameters.OrderBy);

            return await PagedList<Item>.ToPagedListAsync(sortedItems,itemParameters.PageNumber,itemParameters.PageSize);
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

        private void SearchItems(ref IQueryable<Item> items, string searchTerm)
        {
            if (!items.Any() || string.IsNullOrWhiteSpace(searchTerm))
                return;

            items = items.Where(i => i.Name.ToLower().Contains(searchTerm.Trim().ToLower())
                                || i.Description.ToLower().Contains(searchTerm.Trim().ToLower()));
        }

    }
}

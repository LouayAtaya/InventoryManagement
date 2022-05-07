using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Interfaces.Repositories
{
    public interface IItemCategoryRepository:IRepositoryBase<ItemCategory>
    {
        Task<IEnumerable<ItemCategory>> GetAllItemCategoriesAsync();
        Task<ItemCategory> GetItemCategoryByIdAsync(int itemCategoryId);
        

    }
}

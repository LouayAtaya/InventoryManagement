using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Interfaces.Repositories
{
    public interface IItemRepository: IRepositoryBase<Item>
    {
        Task<IEnumerable<Item>> getAllItemsAsync();
        Task<Item> GetItemByIdAsync(int itemId);
        Task<Item> GetItemWithDetailsAsync(int itemId);
        

    }
}

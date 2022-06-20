using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Entities.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Interfaces.Repositories
{
    public interface IItemRepository: IRepositoryBase<Item>
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();

        Task<IEnumerable<Item>> GetItemsAsync(ItemParameters itemParameters);

        Task<Item> GetItemByIdAsync(int itemId);
        Task<Item> GetItemWithDetailsAsync(int itemId);
        

    }
}

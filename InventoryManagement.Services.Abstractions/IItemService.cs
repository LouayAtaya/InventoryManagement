using InventoryManagement.Application.DTOs;
using InventoryManagement.Domain.Entities.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services.Abstractions
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetAllItemsAsync();

        Task<IEnumerable<ItemDto>> GetItemsAsync(ItemParameters itemParameters);

        Task<ItemDetailsDto> GetItemByIdAsync(int itemId);
        Task<ItemDto> CreateItemAsync(ItemForCreationDto item);
        Task UpdateItemAsync(int itemId, ItemForUpdateDto item);
        Task DeleteItemAsync(int itemId);
    }
}

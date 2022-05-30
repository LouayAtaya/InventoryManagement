using InventoryManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services.Abstractions
{
    public interface IItemOperationService
    {
        Task<IEnumerable<ItemOperationDto>> GetAllItemOperationsAsync();

        Task<ItemOperationDto> GetItemOperationsByIdAsync(int id);

        Task<IEnumerable<ItemOperationDto>>  GetItemOperationsByItemAsync(int itemId);

        Task<ItemOperationDto> CreateItemOperationAsync(ItemOperationForCreationDto itemOperation);

        Task UpdateItemOperationAsync(int itemOperationId, ItemOperationForUpdateDto itemOperation);
        Task DeleteItemOperationAsync(int itemOperationId);
    }
}

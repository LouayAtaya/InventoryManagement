using InventoryManagement.Application.DTOs;
using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services.Abstractions
{
    public interface IItemCategoryService
    {
        Task<IEnumerable<ItemCategoryDto>> GetAllItemCategoriesAsync();
        Task<ItemCategoryDto> GetItemCategoryByIdAsync(int itemCategoryId);
        Task<ItemCategoryDto> CreateItemCategoryAsync(ItemCategoryForCreationDto itemCategory);
        Task UpdateItemCategoryAsync(int itemCategoryId, ItemCategoryForUpdateDto itemCategory);
        Task DeleteItemCategoryAsync(int itemCategoryId);
    }
}

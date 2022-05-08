using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Exceptions;
using InventoryManagement.Domain.Interfaces.Repositories;
using InventoryManagement.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services
{
    internal class ItemCategoryService : IItemCategoryService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public ItemCategoryService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this._repositoryWrapper = repositoryWrapper;
            _mapper = mapper;

        }

        public async Task<IEnumerable<ItemCategoryDto>> GetAllItemCategoriesAsync()
        {
            var itemCategories = await this._repositoryWrapper.ItemCategory.GetAllItemCategoriesAsync();

            var itemCategoryDto = _mapper.Map<IEnumerable<ItemCategoryDto>>(itemCategories);
            return itemCategoryDto;
        }

        public async Task<ItemCategoryDto> GetItemCategoryByIdAsync(int itemCategoryId)
        {
            var itemCategory = await this._repositoryWrapper.ItemCategory.GetItemCategoryByIdAsync(itemCategoryId);

            if (itemCategory is null)
                throw new ItemCategoryNotFoundException(itemCategoryId);

            var itemCategoryDto = this._mapper.Map<ItemCategoryDto>(itemCategory);
            return itemCategoryDto;
        }

        public async Task<ItemCategoryDto> CreateItemCategoryAsync(ItemCategoryForCreationDto itemCategoryForCreationDto)
        {
            var itemCategory = _mapper.Map<ItemCategory>(itemCategoryForCreationDto);

            this._repositoryWrapper.ItemCategory.Create(itemCategory);

            await this._repositoryWrapper.SaveAsync();

            return _mapper.Map<ItemCategoryDto>(itemCategory);
        }

        public async Task UpdateItemCategoryAsync(int itemCategoryId, ItemCategoryForUpdateDto itemCategoryForUpdateDto)
        {
            var itemCategory = await this._repositoryWrapper.ItemCategory.GetItemCategoryByIdAsync(itemCategoryId);
            if (itemCategory is null)
                throw new ItemCategoryNotFoundException(itemCategoryId);
          
            //deactivate subCategories if parent deactivated
            if (!itemCategoryForUpdateDto.IsActive.HasValue || !itemCategoryForUpdateDto.IsActive.Value)
            {
                foreach(var childItemCategory in itemCategoryForUpdateDto.ChildCategories)
                {
                    childItemCategory.IsActive = false;
                }
            }

            _mapper.Map(itemCategoryForUpdateDto, itemCategory);

            //this._repositoryWrapper.ItemCategory.Update(itemCategory);

            await this._repositoryWrapper.SaveAsync();

        }

        public async Task DeleteItemCategoryAsync(int itemCategoryId)
        {
            var itemCategory = await this._repositoryWrapper.ItemCategory.GetItemCategoryByIdAsync(itemCategoryId);

            if(itemCategory is null)
                throw new ItemCategoryNotFoundException(itemCategoryId);

            this._repositoryWrapper.ItemCategory.Delete(itemCategory);

            await this._repositoryWrapper.SaveAsync();
        }
        
    }
}

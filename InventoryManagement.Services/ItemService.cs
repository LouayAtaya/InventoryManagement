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
    internal class ItemService:IItemService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public ItemService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this._repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemDto>> GetAllItemsAsync()
        {
            var items= await this._repositoryWrapper.Item.getAllItemsAsync();
            List<ItemDto> itemsDto= _mapper.Map<List<ItemDto>>(items);
            return itemsDto;
        }

        public async Task<ItemDetailsDto> GetItemByIdAsync(int itemId)
        {
            var item=await this._repositoryWrapper.Item.GetItemByIdAsync(itemId);
            if (item == null)
                throw new ItemNotFoundException(itemId);

            return this._mapper.Map<ItemDetailsDto>(item);
        }

        public async Task<ItemDto> CreateItemAsync(ItemForCreationDto itemForCreationDto)
        {
            var item = _mapper.Map<Item>(itemForCreationDto);

            //Calculate Item Total Quantity
            item.CalculateTotalQuantity();

            this._repositoryWrapper.Item.Create(item);

            await this._repositoryWrapper.SaveAsync();

            return this._mapper.Map<ItemDto>(item);
        }

        public async Task UpdateItemAsync(int itemId, ItemForUpdateDto itemForUpdateDto)
        {
            var item = await this._repositoryWrapper.Item.GetItemByIdAsync(itemId);
            if (item == null)
                throw new ItemNotFoundException(itemId);

            this._mapper.Map(itemForUpdateDto, item);

            //this._repositoryWrapper.Item.Update(item);
            await this._repositoryWrapper.SaveAsync();
        }

        public async Task DeleteItemAsync(int itemId)
        {
            var item = await this._repositoryWrapper.Item.GetItemByIdAsync(itemId);
            if (item == null)
                throw new ItemNotFoundException(itemId);

            this._repositoryWrapper.Item.Delete(item);

            await this._repositoryWrapper.SaveAsync();
        } 
    }
}

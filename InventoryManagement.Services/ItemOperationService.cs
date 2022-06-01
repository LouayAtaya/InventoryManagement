using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Enums;
using InventoryManagement.Domain.Exceptions;
using InventoryManagement.Domain.Interfaces.Repositories;
using InventoryManagement.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services
{
    public class ItemOperationService : IItemOperationService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public ItemOperationService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this._repositoryWrapper = repositoryWrapper;
            _mapper = mapper;

        }

        public async Task<IEnumerable<ItemOperationDto>> GetAllItemOperationsAsync()
        {
            var itemOperations=await this._repositoryWrapper.ItemOperation.getAllItemOperations();

            List<ItemOperationDto> itemOperationsDto = _mapper.Map<List<ItemOperationDto>>(itemOperations);
            return itemOperationsDto;
        }

        public async Task<ItemOperationDto> GetItemOperationsByIdAsync(int id)
        {
            var itemOperation = await this._repositoryWrapper.ItemOperation.GetItemOperationByIdAsync(id);
            if (itemOperation == null)
                throw new ItemOperationNotFoundException(id);

            ItemOperationDto itemOperationDto = _mapper.Map<ItemOperationDto>(itemOperation);
            return itemOperationDto;
        }

        public async Task<IEnumerable<ItemOperationDto>> GetItemOperationsByItemAsync(int itemId)
        {
            var itemOperations = await this._repositoryWrapper.ItemOperation.GetItemOperationsByItemAsync(itemId);

            List<ItemOperationDto> itemOperationsDto = _mapper.Map<List<ItemOperationDto>>(itemOperations);
            return itemOperationsDto;
        }

        public async Task<ItemOperationDto> CreateItemOperationAsync(ItemOperationForCreationDto itemOperationForCreation)
        {
            var itemOperation = this._mapper.Map<ItemOperation>(itemOperationForCreation);

            if (itemOperation.AffectedQuantity < 0)
                throw new ItemQunatityErrorException();

            //get Item
            var item = await this._repositoryWrapper.Item.GetItemByIdAsync(itemOperation.ItemId);
            if (item == null)
                throw new ItemNotFoundException(itemOperation.ItemId);

            //get Item
            var warehouse = await this._repositoryWrapper.Warehouse.GetWarehouseByIdAsync(itemOperation.WarehouseId);
            if (warehouse == null)
                throw new WarehoseNotFoundException(itemOperation.WarehouseId);

            //set current quantity before update
            itemOperation.PreviousQuantity = item.TotalQuantity;

            switch (itemOperation.ItemOperationType)
            {
                case ItemOperationType.Return:
                case ItemOperationType.Addition:
                    item.AddNewQuantity(itemOperation.WarehouseId, itemOperation.AffectedQuantity);
                    break;
                case ItemOperationType.Lost:
                case ItemOperationType.Exit:
                    item.RemoveQuantity(itemOperation.WarehouseId, itemOperation.AffectedQuantity);
                    break;
                case ItemOperationType.Transfer:
                    break;
                default:
                    throw new ItemNotFoundException(itemOperation.ItemId);
            }

            this._repositoryWrapper.ItemOperation.Create(itemOperation);
            await this._repositoryWrapper.SaveAsync();
            return this._mapper.Map<ItemOperationDto>(itemOperation);
        }

        public async Task UpdateItemOperationAsync(int itemOperationId, ItemOperationForUpdateDto itemOperationForUpdate)
        {
            var itemOperation= await  this._repositoryWrapper.ItemOperation.GetItemOperationByIdAsync(itemOperationId);

            if (itemOperation == null)
                throw new ItemOperationNotFoundException(itemOperationId);

            this._mapper.Map(itemOperationForUpdate, itemOperation);

            await this._repositoryWrapper.SaveAsync();
        }

        public async Task DeleteItemOperationAsync(int itemOperationId)
        {
            var itemOperation = await this._repositoryWrapper.ItemOperation.GetItemOperationByIdAsync(itemOperationId);
            if (itemOperation == null)
                throw new ItemOperationNotFoundException(itemOperationId);

            this._repositoryWrapper.ItemOperation.Delete(itemOperation);

            await this._repositoryWrapper.SaveAsync();
        }

    }
}

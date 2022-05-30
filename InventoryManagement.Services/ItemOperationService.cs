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

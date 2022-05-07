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
    internal class WarehouseService : IWarehouseService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public WarehouseService(IRepositoryWrapper repositoryWrapper,IMapper mapper)
        {
            this._repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WarehouseDto>> GetAllWarehousesAsync()
        {
            var warehouses = await _repositoryWrapper.Warehouse.GetAllWarehousesAsync();

            var warehousesDto = _mapper.Map<IEnumerable<WarehouseDto>>(warehouses);
            return warehousesDto;
        }

        public async Task<WarehouseDto> GetWarehouseByIdAsync(int warehouseId)
        {
            var warehouse = await _repositoryWrapper.Warehouse.GetWarehouseByIdAsync(warehouseId);

            if (warehouse is null)
                throw new WarehoseNotFoundException(warehouseId);

            var warehousesDto = _mapper.Map<WarehouseDto>(warehouse);
            return warehousesDto;
        }

        public async Task<WarehouseDto> CreateWarehouseAsync(WarehouseForCreationDto warehouseForCreation)
        {
            Warehouse warehouse = _mapper.Map<Warehouse>(warehouseForCreation);

            this._repositoryWrapper.Warehouse.Create(warehouse);

            await this._repositoryWrapper.SaveAsync();

            return this._mapper.Map<WarehouseDto>(warehouse);
        }

        public async Task UpdateWarehouseAsync(int warehouseId, WarehouseForUpdateDto warehouseForUpdateDto)
        {
            var warehouse= await this._repositoryWrapper.Warehouse.GetWarehouseByIdAsync(warehouseId);
            if(warehouse is null)
                throw new WarehoseNotFoundException(warehouseId);
            
            _mapper.Map(warehouseForUpdateDto, warehouse);

            this._repositoryWrapper.Warehouse.Update(warehouse);

            await this._repositoryWrapper.SaveAsync();

        }

        public async Task DeleteWarehouseAsync(int warehouseId)
        {
            var warehouse =await this._repositoryWrapper.Warehouse.GetWarehouseByIdAsync(warehouseId);

            if(warehouse is null)
                throw new WarehoseNotFoundException(warehouseId);

            this._repositoryWrapper.Warehouse.Delete(warehouse);

            await this._repositoryWrapper.SaveAsync();
        }

    }
}

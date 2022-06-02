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
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services
{
    public class SaleOrderService : ISaleOrderService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        private readonly IServiceManager _serviceManager;

        public SaleOrderService(IRepositoryWrapper repositoryWrapper, IMapper mapper, IServiceManager serviceManager)
        {
            this._repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _serviceManager = serviceManager;

        }

        public async Task<IEnumerable<SaleOrderDto>> GetAllSaleOrdersAsync()
        {
            var saleOrders = await this._repositoryWrapper.SaleOrder.getAllSaleOrdersAsync();
            List<SaleOrderDto> saleOrdersDto = _mapper.Map<List<SaleOrderDto>>(saleOrders);
            return saleOrdersDto;
        }

        public async Task<SaleOrderDto> GetSaleOrderByIdAsync(int saleOrderId)
        {
            var saleOrder = await this._repositoryWrapper.SaleOrder.GetSaleOrdertWithDetailsAsync(saleOrderId);
            if (saleOrder == null)
                throw new SaleOrderNotFoundException(saleOrderId);

            return this._mapper.Map<SaleOrderDto>(saleOrder);
        }

        public async Task<SaleOrderDto> CreateSaleOrderAsync(SaleOrderForCreationDto saleOrderForCreation)
        {
            var saleOrder = _mapper.Map<SaleOrder>(saleOrderForCreation);

            //Calculate SaleOrder Total Quantity
            saleOrder.CalculateTotalOrderPrice();

            saleOrder.SaleOrderStatus = SaleOrderStatus.Pending;

            this._repositoryWrapper.SaleOrder.Create(saleOrder);

            await this._repositoryWrapper.SaveAsync();

            return this._mapper.Map<SaleOrderDto>(saleOrder);
        }

        public async Task UpdateSaleOrderAsync(int saleOrderId, SaleOrderForUpdateDto saleOrderForUpdateDto)
        {
            var saleOrder = await this._repositoryWrapper.SaleOrder.GetSaleOrdertWithDetailsAsync(saleOrderId);
            if (saleOrder == null)
                throw new SaleOrderNotFoundException(saleOrderId);

            
            this._mapper.Map(saleOrderForUpdateDto, saleOrder);

            //Calculate SaleOrder Total Quantity
            saleOrder.CalculateTotalOrderPrice();

            await this._repositoryWrapper.SaveAsync();
        }

        public async Task UpdateSaleOrderStatusAsync(int saleOrderId, SaleOrderStatus saleOrderStatus)
        {
            var saleOrder = await this._repositoryWrapper.SaleOrder.GetSaleOrdertWithDetailsAsync(saleOrderId);
            if (saleOrder == null)
                throw new SaleOrderNotFoundException(saleOrderId);

            saleOrder.SaleOrderStatus = saleOrderStatus;

            //if Approved: Create An items operation for all involoved items in SaleOrder
            if (saleOrderStatus == SaleOrderStatus.Approved)
            {

                ItemOperationForCreationDto itemOperationForCreation = null;
                ItemOperationDto itemOperation = null;
                foreach (var saleOrderItem in saleOrder.SaleOrderItems)
                {
                    itemOperationForCreation = new ItemOperationForCreationDto()
                    {
                        ItemId = saleOrderItem.ItemId,
                        WarehouseId=saleOrder.WarehouseId,
                        AffectedQuantity = saleOrderItem.Quantity,
                        Description = "Sale Order #"+saleOrder.Id,
                        ItemOperationType = ItemOperationType.Exit,
                        IsActive = true
                    };

                    itemOperation = await this._serviceManager.ItemOperationService.CreateItemOperationAsync(itemOperationForCreation);
                }
            }

            await this._repositoryWrapper.SaveAsync();
        }

        public async Task DeleteSaleOrderAsync(int saleOrderId)
        {
            var saleOrder = await this._repositoryWrapper.SaleOrder.GetSaleOrderByIdAsync(saleOrderId);
            if (saleOrder == null)
                throw new SaleOrderNotFoundException(saleOrderId);

            this._repositoryWrapper.SaleOrder.Delete(saleOrder);

            await this._repositoryWrapper.SaveAsync();
        }
        
    }
}

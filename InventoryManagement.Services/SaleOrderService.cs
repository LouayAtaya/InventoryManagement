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
    public class SaleOrderService : ISaleOrderService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public SaleOrderService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this._repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
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

using InventoryManagement.Application.DTOs;
using InventoryManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services.Abstractions
{
    public interface ISaleOrderService
    {
        Task<IEnumerable<SaleOrderDto>> GetAllSaleOrdersAsync();
        Task<SaleOrderDto> GetSaleOrderByIdAsync(int saleOrderId);
        Task<SaleOrderDto> CreateSaleOrderAsync(SaleOrderForCreationDto saleOrder);
        Task UpdateSaleOrderAsync(int saleOrderId, SaleOrderForUpdateDto saleOrder);
        Task UpdateSaleOrderStatusAsync(int saleOrderId,SaleOrderStatus saleOrderStatus);
        Task DeleteSaleOrderAsync(int saleOrderId);
    }
}

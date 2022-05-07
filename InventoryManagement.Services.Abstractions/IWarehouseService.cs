using InventoryManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services.Abstractions
{
    public interface IWarehouseService
    {
        Task<IEnumerable<WarehouseDto>> GetAllWarehousesAsync();
        Task<WarehouseDto> GetWarehouseByIdAsync(int warehouseId);
        Task<WarehouseDto> CreateWarehouseAsync(WarehouseForCreationDto warehouse);
        Task UpdateWarehouseAsync(int warehouseId, WarehouseForUpdateDto warehouse);
        Task DeleteWarehouseAsync(int warehouseId);
        

    }
}

using InventoryManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services.Abstractions
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllRolesAsync();

        Task<RoleDto> GetRoleByIdAsync(int RoleId);

        Task<RoleDto> CreateRoleAsync(RoleForCreationDto Role);
        Task UpdateRoleAsync(int RoleId, RoleForUpdateDto Role);
        Task DeleteRoleAsync(int RoleId);
    }
}

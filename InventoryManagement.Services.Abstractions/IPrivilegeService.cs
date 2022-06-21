using InventoryManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services.Abstractions
{
    public interface IPrivilegeService
    {
        Task<IEnumerable<PrivilegeDto>> GetAllPrivilegesAsync();

        Task<PrivilegeDto> GetPrivilegeByIdAsync(int PrivilegeId);

        Task<PrivilegeDto> CreatePrivilegeAsync(PrivilegeForCreationDto Privilege);
        Task UpdatePrivilegeAsync(int PrivilegeId, PrivilegeForUpdateDto Privilege);
        Task DeletePrivilegeAsync(int PrivilegeId);
    }
}

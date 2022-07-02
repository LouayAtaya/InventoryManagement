using InventoryManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services.Abstractions
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();

        Task<UserDto> GetUserByIdAsync(int UserId);
        Task<IEnumerable<RoleDto>> GetRolesByUserAsync(int userId);
        Task<AuthenticatedResponseDto> Login(LoginUserDto loginUser);

        Task<UserDto> CreateUserAsync(UserForCreationDto User);
        Task UpdateUserAsync(int UserId, UserForUpdateDto User);
        Task DeleteUserAsync(int UserId);
    }
}

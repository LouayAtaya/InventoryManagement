using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Interfaces.Repositories;
using InventoryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(InventoryManagementContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await FindAll()
                .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await FindByCondition(u => u.Id == userId)
                            .Include(u => u.Member)
                            .Include(u => u.UserRoles)
                            .ThenInclude(ur => ur.Role)
                            .SingleOrDefaultAsync();
        }

        public async Task<User> GetUserByNameAndPassword(string username, string password)
        {
            return await FindByCondition(u => u.Username == username && u.Password==password)
                            .Include(u => u.UserRoles)
                            .ThenInclude(ur => ur.Role)
                            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Role>> GetRolesByUserAsync(int userId)
        {
            return await FindByCondition(u => u.Id == userId)
                            .Include(u => u.UserRoles)
                            .SelectMany(u=>u.UserRoles.Select(x=>x.Role))
                            .ToListAsync();

        }

    }
}

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
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(InventoryManagementContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await FindAll()
                .ToListAsync();
        }

        public async Task<Role> GetRoleByIdAsync(int roleId)
        {
            return await FindByCondition(r => r.Id == roleId)
                .Include(r => r.RolePrivileges)
                .ThenInclude(rp => rp.Privilege)
                .SingleOrDefaultAsync();
        }
       
    }
}

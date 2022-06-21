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
    public class PrivilegeRepository : RepositoryBase<Privilege>, IPrivilegeRepository
    {
        public PrivilegeRepository(InventoryManagementContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Privilege>> GetAllPrivilegesAsync()
        {
            return await FindAll()
                        .ToListAsync();
        }

        public async Task<Privilege> GetPrivilegeByIdAsync(int privilegeId)
        {
            return await FindByCondition(p => p.Id == privilegeId)
                           .SingleOrDefaultAsync();
        }

    }
}
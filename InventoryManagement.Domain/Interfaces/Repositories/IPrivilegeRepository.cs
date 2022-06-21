using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Interfaces.Repositories
{
    public interface IPrivilegeRepository : IRepositoryBase<Privilege>
    {
        Task<IEnumerable<Privilege>> GetAllPrivilegesAsync();

        Task<Privilege> GetPrivilegeByIdAsync(int userId);

    }
}

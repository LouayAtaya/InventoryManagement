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
    public class AccountRepository : RepositoryBase<Account>,IAccountRepository
    {
        public AccountRepository(InventoryManagementContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Account>> getAllAccountsAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Account> GetAccountByIdAsync(int accountId)
        {
            return await FindByCondition(a => a.Id == accountId).SingleOrDefaultAsync();
        }

        public async Task<Account> GetAccountWithDetailsAsync(int accountId)
        {
            return await FindByCondition(a => a.Id == accountId).SingleOrDefaultAsync();
        }

    }
}

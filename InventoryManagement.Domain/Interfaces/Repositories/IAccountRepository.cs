using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Interfaces.Repositories
{
    public interface IAccountRepository:IRepositoryBase<Account>
    {
        Task<IEnumerable<Account>> getAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(int accountId);
        Task<Account> GetAccountWithDetailsAsync(int accountId);
    }
}

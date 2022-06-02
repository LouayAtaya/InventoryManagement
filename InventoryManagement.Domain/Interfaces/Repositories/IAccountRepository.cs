using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Enums;
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
        Task<IEnumerable<Account>> GetAccountsByTypeAsync(AccountType accountType);
        Task<Account> GetAccountByIdAsync(int accountId);
        Task<Account> GetAccountWithDetailsAsync(int accountId);
    }
}

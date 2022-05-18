using InventoryManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services.Abstractions
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDto>> GetAllAccountsAsync();
        Task<AccountDetailDto> GetAccountByIdAsync(int accountId);
        Task<AccountDto> CreateAccountAsync(AccountForCreationDto account);
        Task UpdateAccountAsync(int accountId, AccountForUpdateDto account);
        Task DeleteAccountAsync(int accountId);
    }
}

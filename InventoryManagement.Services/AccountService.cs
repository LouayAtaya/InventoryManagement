using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Exceptions;
using InventoryManagement.Domain.Interfaces.Repositories;
using InventoryManagement.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public AccountService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this._repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountDto>> GetAllAccountsAsync()
        {
            var accounts = await this._repositoryWrapper.Account.getAllAccountsAsync();
            List<AccountDto> accountsDto = _mapper.Map<List<AccountDto>>(accounts);
            return accountsDto;
        }

        public async Task<AccountDetailDto> GetAccountByIdAsync(int accountId)
        {
            var account = await this._repositoryWrapper.Account.GetAccountByIdAsync(accountId);
            if (account == null)
                throw new AccountNotFoundException(accountId);

            return this._mapper.Map<AccountDetailDto>(account);
        }

        public async Task<AccountDto> CreateAccountAsync(AccountForCreationDto accountForCreationDto)
        {
            var account = _mapper.Map<Account>(accountForCreationDto);

            //Calculate Account Total Quantity

            this._repositoryWrapper.Account.Create(account);

            await this._repositoryWrapper.SaveAsync();

            return this._mapper.Map<AccountDto>(account);
        }

        public async Task UpdateAccountAsync(int accountId, AccountForUpdateDto accountForUpdateDto)
        {
            var account = await this._repositoryWrapper.Account.GetAccountByIdAsync(accountId);
            if (account == null)
                throw new AccountNotFoundException(accountId);

            this._mapper.Map(accountForUpdateDto, account);

            //Calculate Account Total Quantity

            await this._repositoryWrapper.SaveAsync();
        }

        public async Task DeleteAccountAsync(int accountId)
        {
            var account = await this._repositoryWrapper.Account.GetAccountByIdAsync(accountId);
            if (account == null)
                throw new AccountNotFoundException(accountId);

            this._repositoryWrapper.Account.Delete(account);
            this._repositoryWrapper.Account.Delete(account);

            await this._repositoryWrapper.SaveAsync();
        }
        
    }
}

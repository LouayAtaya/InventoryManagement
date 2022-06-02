using InventoryManagement.API.ActionFilters;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Domain.Enums;
using InventoryManagement.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AccountsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/<AccountsController>
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await this._serviceManager.AccountService.GetAllAccountsAsync();

            return Ok(accounts);
        }

        // GET api/<AccountsController>/5
        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetAccountById(int accountId)
        {
            var account = await this._serviceManager.AccountService.GetAccountByIdAsync(accountId);

            return Ok(account);
        }

        // GET: api/<AccountsController>/type/0
        [HttpGet("type/{accountType}")]
        public async Task<IActionResult> GetAccounts(AccountType accountType)
        {
            var accounts = await this._serviceManager.AccountService.GetAccountsByTypeAsync(accountType);

            return Ok(accounts);
        }

        // POST api/<AccountsController>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateAccount([FromBody] AccountForCreationDto accountForCreationDto)
        {
            var account = await this._serviceManager.AccountService.CreateAccountAsync(accountForCreationDto);

            return CreatedAtAction("GetAccountById", new { accountId = account.Id }, account);
        }

        // PUT api/<AccountsController>/5
        [HttpPut("{accountId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Put(int accountId, [FromBody] AccountForUpdateDto accountForUpdateDto)
        {
            await this._serviceManager.AccountService.UpdateAccountAsync(accountId, accountForUpdateDto);

            return Ok();
        }

        // DELETE api/<AccountsController>/5
        [HttpDelete("{accountId}")]
        public async Task<IActionResult> Delete(int accountId)
        {
            await this._serviceManager.AccountService.DeleteAccountAsync(accountId);

            return Ok();
        }
    }
}

using InventoryManagement.API.ActionFilters;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivilegesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PrivilegesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/<PrivilegesController>
        [HttpGet]
        public async Task<IActionResult> GetPrivileges()
        {
            var privileges = await this._serviceManager.PrivilegeService.GetAllPrivilegesAsync();

            return Ok(privileges);
        }

        // GET api/<PrivilegesController>/5
        [HttpGet("{privilegeId}")]
        public async Task<IActionResult> GetPrivilegeById(int privilegeId)
        {
            var privilege = await this._serviceManager.PrivilegeService.GetPrivilegeByIdAsync(privilegeId);

            return Ok(privilege);
        }

        // POST api/<PrivilegesController>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreatePrivilege([FromBody] PrivilegeForCreationDto privilegeForCreationDto)
        {
            var privilege = await this._serviceManager.PrivilegeService.CreatePrivilegeAsync(privilegeForCreationDto);

            return CreatedAtAction("GetPrivilegeById", new { privilegeId = privilege.Id }, privilege);
        }

        // PUT api/<PrivilegesController>/5
        [HttpPut("{privilegeId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Put(int privilegeId, [FromBody] PrivilegeForUpdateDto privilegeForUpdateDto)
        {
            await this._serviceManager.PrivilegeService.UpdatePrivilegeAsync(privilegeId, privilegeForUpdateDto);

            return Ok();
        }

        // DELETE api/<PrivilegesController>/5
        [HttpDelete("{privilegeId}")]
        public async Task<IActionResult> Delete(int privilegeId)
        {
            await this._serviceManager.PrivilegeService.DeletePrivilegeAsync(privilegeId);

            return Ok();
        }

    }
}

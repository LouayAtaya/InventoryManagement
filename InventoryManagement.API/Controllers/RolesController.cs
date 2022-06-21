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
    public class RolesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public RolesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await this._serviceManager.RoleService.GetAllRolesAsync();

            return Ok(roles);
        }

        // GET api/<RolesController>/5
        [HttpGet("{roleId}")]
        public async Task<IActionResult> GetRoleById(int roleId)
        {
            var role = await this._serviceManager.RoleService.GetRoleByIdAsync(roleId);

            return Ok(role);
        }

        // POST api/<RolesController>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateRole([FromBody] RoleForCreationDto roleForCreationDto)
        {
            var role = await this._serviceManager.RoleService.CreateRoleAsync(roleForCreationDto);

            return CreatedAtAction("GetRoleById", new { roleId = role.Id }, role);
        }

        // PUT api/<RolesController>/5
        [HttpPut("{roleId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Put(int roleId, [FromBody] RoleForUpdateDto RoleForUpdateDto)
        {
            await this._serviceManager.RoleService.UpdateRoleAsync(roleId, RoleForUpdateDto);

            return Ok();
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{roleId}")]
        public async Task<IActionResult> Delete(int roleId)
        {
            await this._serviceManager.RoleService.DeleteRoleAsync(roleId);

            return Ok();
        }

    }
}

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
    public class ItemOperationsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ItemOperationsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/<ItemOperationsController>
        [HttpGet]
        public async Task<IActionResult> GetItemOperations()
        {
            var itemOperations = await this._serviceManager.ItemOperationService.GetAllItemOperationsAsync();

            return Ok(itemOperations);
        }

        // GET api/<ItemOperationsController>/5
        [HttpGet("{itemOperationId}")]
        public async Task<IActionResult> GetItemOperationById(int itemOperationId)
        {
            var itemOperation = await this._serviceManager.ItemOperationService.GetItemOperationsByIdAsync(itemOperationId);

            return Ok(itemOperation);
        }

        // GET api/<ItemOperationsController>/item/5
        [HttpGet("item/{itemId}")]
        public async Task<IActionResult> GetItemOperationByItem(int itemId)
        {
            var itemOperations = await this._serviceManager.ItemOperationService.GetItemOperationsByItemAsync(itemId);

            return Ok(itemOperations);
        }

        // POST api/<ItemOperationsController>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateItemOperation([FromBody] ItemOperationForCreationDto itemOperationForCreation)
        {
            var itemOperation = await this._serviceManager.ItemOperationService.CreateItemOperationAsync(itemOperationForCreation);

            return CreatedAtAction("GetItemOperationById", new { itemOperationId = itemOperation.Id }, itemOperation);
        }

        // PUT api/<ItemOperationsController>/5
        [HttpPut("{itemOperationId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateItemOperation(int itemOperationId, [FromBody] ItemOperationForUpdateDto itemOperationForUpdate)
        {
            await this._serviceManager.ItemOperationService.UpdateItemOperationAsync(itemOperationId, itemOperationForUpdate);

            return Ok();
        }

        // DELETE api/<ItemOperationsController>/5
        [HttpDelete("{itemOperationId}")]
        public async Task<IActionResult> Delete(int itemOperationId)
        {
            await this._serviceManager.ItemOperationService.DeleteItemOperationAsync(itemOperationId);

            return Ok();
        }
    }
}

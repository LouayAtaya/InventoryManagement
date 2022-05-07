using AutoMapper;
using InventoryManagement.API.ActionFilters;
using InventoryManagement.Application.Contracts;
using InventoryManagement.Application.DTOs;
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
    public class ItemsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        

        public ItemsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/<ItemsController>
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var items= await this._serviceManager.ItemService.GetAllItemsAsync();

            return Ok(items);
        }

        // GET api/<ItemsController>/5
        [HttpGet("{itemId}")]
        public async Task<IActionResult> GetItemById(int itemId)
        {
            var item= await this._serviceManager.ItemService.GetItemByIdAsync(itemId);

            return Ok(item);
        }

        // POST api/<ItemsController>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateItem([FromBody] ItemForCreationDto itemForCreationDto)
        {
            var item= await this._serviceManager.ItemService.CreateItemAsync(itemForCreationDto);
            
            return CreatedAtAction("GetItemById", new { itemId = item.Id }, item);
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{itemId}")]
        public async Task<IActionResult> Put(int itemId, [FromBody] ItemForUpdateDto itemForUpdateDto)
        {
            await this._serviceManager.ItemService.UpdateItemAsync(itemId, itemForUpdateDto);

            return Ok();
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{itemId}")]
        public async Task<IActionResult> Delete(int itemId)
        {
            await this._serviceManager.ItemService.DeleteItemAsync(itemId);

            return Ok();
        }
    }
}

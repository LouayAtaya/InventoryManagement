using AutoMapper;
using InventoryManagement.API.ActionFilters;
using InventoryManagement.Application.Contracts;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _config;
        private string _fileFolderPath;

        public ItemsController(IServiceManager serviceManager, IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _config = configuration;
            _fileFolderPath = _config["ItemFileUpload"];
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
        [HttpPost, DisableRequestSizeLimit]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateItem([FromForm] ItemForCreationDto itemForCreationDto)
        {

            if (itemForCreationDto.ItemImages != null && itemForCreationDto.ItemImages.Count() > 0)
            {
                var itemImagesCount= itemForCreationDto.ItemImages.Count();
                if (itemForCreationDto.filesOfImages== null || itemForCreationDto.filesOfImages.Count()!= itemImagesCount)
                {
                    throw new Exception();
                }

                for(int i=0; i<itemImagesCount;i++)
                {
                    var fileDbPath = await this._serviceManager.FileManagementService.UploadFile(itemForCreationDto.filesOfImages.ElementAt(i), this._fileFolderPath);
                    itemForCreationDto.ItemImages.ElementAt(i).Url = fileDbPath;
                }
                
            }

            var item = await this._serviceManager.ItemService.CreateItemAsync(itemForCreationDto);
            
            return CreatedAtAction("GetItemById", new { itemId = item.Id }, item);
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{itemId}")]
        public async Task<IActionResult> Put(int itemId, [FromForm] ItemForUpdateDto itemForUpdateDto)
        {
            if (itemForUpdateDto.ItemImages != null && itemForUpdateDto.ItemImages.Count() > 0)
            {
                var itemImagesCount = itemForUpdateDto.ItemImages.Count();
                if (itemForUpdateDto.filesOfImages == null || itemForUpdateDto.filesOfImages.Count() != itemImagesCount)
                {
                    throw new Exception();
                }

                for (int i = 0; i < itemImagesCount; i++)
                {
                    var fileDbPath = await this._serviceManager.FileManagementService.UploadFile(itemForUpdateDto.filesOfImages.ElementAt(i), this._fileFolderPath);
                    itemForUpdateDto.ItemImages.ElementAt(i).Url = fileDbPath;
                }

            }

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

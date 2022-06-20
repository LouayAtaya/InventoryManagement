using AutoMapper;
using InventoryManagement.API.ActionFilters;
using InventoryManagement.Application.Contracts;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCategoriesController : ControllerBase
    {
        private readonly IServiceManager serviceManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private string _fileFolderPath;

        public ItemCategoriesController(IServiceManager serviceManager, ILoggerManager loggerManager, IMapper mapper, IConfiguration configuration)
        {
            this.serviceManager = serviceManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
            _config = configuration;
            _fileFolderPath = _config["CategoryFileUpload"];

        }

        // GET: api/<ItemCategoriesController>
        [HttpGet]
        public async Task<IActionResult> GetItemCategories()
        {
            var itemCategories = await this.serviceManager.ItemCategoryService.GetAllItemCategoriesAsync();

            return Ok(itemCategories);
        }

        // GET api/<ItemCategoriesController>/5
        [HttpGet("{itemCategoryId}")]
        public async Task<IActionResult> GetItemCategoryById(int itemCategoryId)
        {
            var itemCategory = await this.serviceManager.ItemCategoryService.GetItemCategoryByIdAsync(itemCategoryId);

            return Ok(itemCategory);
        }

        // POST api/<ItemCategoriesController>
        [HttpPost, DisableRequestSizeLimit]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateItemCategoryAsync([FromForm] ItemCategoryForCreationDto itemCategoryForCreationDto)
        {
            if(itemCategoryForCreationDto.ImageFile != null)
            {
                var fileDbPath = await this.serviceManager.FileManagementService.UploadFile(itemCategoryForCreationDto.ImageFile, this._fileFolderPath);
                itemCategoryForCreationDto.Image = fileDbPath;
            }

            var itemCategoryDto = await this.serviceManager.ItemCategoryService.CreateItemCategoryAsync(itemCategoryForCreationDto);

            #region Method 2
            /*var formCollection = await Request.ReadFormAsync();
            var itemCategoryString = formCollection["itemCategory"];
            var itemCategoryForCreationDto = JsonConvert.DeserializeObject<ItemCategoryForCreationDto>(itemCategoryString);

            var formFiles = formCollection.Files;

            List<String> paths = await this.serviceManager.FileManagementService.uploadFiles(formFiles);

            */
            #endregion
            return CreatedAtAction("GetItemCategoryById", new { itemCategoryId = itemCategoryDto.Id }, itemCategoryDto);
        }

        // PUT api/<ItemCategoriesController>/5
        [HttpPut("{itemCategoryId}"), DisableRequestSizeLimit]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateItemCategory(int itemCategoryId, [FromForm] ItemCategoryForUpdateDto itemCategoryForUpdateDto)
        {
            if (itemCategoryForUpdateDto.ImageFile != null)
            {
                var fileDbPath = await this.serviceManager.FileManagementService.UploadFile(itemCategoryForUpdateDto.ImageFile, this._fileFolderPath);
                itemCategoryForUpdateDto.Image = fileDbPath;
            }

            await this.serviceManager.ItemCategoryService.UpdateItemCategoryAsync(itemCategoryId, itemCategoryForUpdateDto);

            return Ok();
        }

        // DELETE api/<ItemCategoriesController>/5
        [HttpDelete("{itemCategoryId}")]
        public async Task<IActionResult> DeleteItemCategory(int itemCategoryId)
        {
            await this.serviceManager.ItemCategoryService.DeleteItemCategoryAsync(itemCategoryId);
            return Ok();
        }
    }
}

using AutoMapper;
using InventoryManagement.API.ActionFilters;
using InventoryManagement.Application.Contracts;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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

        public ItemCategoriesController(IServiceManager serviceManager, ILoggerManager loggerManager, IMapper mapper)
        {
            this.serviceManager = serviceManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
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
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateItemCategoryAsync([FromBody] ItemCategoryForCreationDto itemCategoryForCreationDto)
        {
            var itemCategoryDto = await this.serviceManager.ItemCategoryService.CreateItemCategoryAsync(itemCategoryForCreationDto);

            return CreatedAtAction("GetItemCategoryById", new { itemCategoryId = itemCategoryDto.Id }, itemCategoryDto);
        }

        // POST api/<ItemCategoriesController>
        [HttpPost("CreateItemCategoryWithFilesAsync"), DisableRequestSizeLimit]
        public async Task<IActionResult> CreateItemCategoryWithFilesAsync()
        {
            var formCollection = await Request.ReadFormAsync();
            var itemCategoryString = formCollection["itemCategory"];
            var itemCategoryForCreationDto = JsonConvert.DeserializeObject<ItemCategoryForCreationDto>(itemCategoryString);
            
            var formFiles = formCollection.Files;

            List<String> paths = await this.serviceManager.FileManagementService.uploadFiles(formFiles);

            var itemCategoryDto = await this.serviceManager.ItemCategoryService.CreateItemCategoryAsync(itemCategoryForCreationDto);

            return CreatedAtAction("GetItemCategoryById", new { itemCategoryId = itemCategoryDto.Id }, itemCategoryDto);
        }

        // POST api/<ItemCategoriesController>
        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFiles()
        {
            var formCollection = await Request.ReadFormAsync();
            var itemCategoryString = formCollection["itemCategory"];
            var itemCategory = JsonConvert.DeserializeObject<ItemCategoryForCreationDto>(itemCategoryString);

            var formFiles = formCollection.Files;

            List<String> paths=await this.serviceManager.FileManagementService.uploadFiles(formFiles);

            return Ok(paths);

            #region MyRegion
            /*try
                {
                    var formCollection = await Request.ReadFormAsync();

                    var itemCategoryString = formCollection["itemCategory"];
                    var itemCategory = JsonConvert.DeserializeObject<ItemCategoryForCreationDto>(itemCategoryString);


                    var file = formCollection.Files.First();
                    //var folderName = _config["CategoryFileUpload"];
                    var folderName = Path.Combine("Resources", "Images\\Categories");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        return Ok(new { dbPath });
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex}");
                }*/ 
            #endregion
        }

        // PUT api/<ItemCategoriesController>/5
        [HttpPut("{itemCategoryId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateItemCategory(int itemCategoryId, [FromBody] ItemCategoryForUpdateDto itemCategoryForUpdateDto)
        {
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

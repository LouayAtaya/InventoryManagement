using AutoMapper;
using InventoryManagement.API.ActionFilters;
using InventoryManagement.Application.Contracts;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Exceptions;
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
    public class WarehousesController : ControllerBase
    {
        private readonly IServiceManager serviceManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public WarehousesController(IServiceManager serviceManager, ILoggerManager loggerManager, IMapper mapper)
        {
            this.serviceManager = serviceManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        // GET: api/<WarehouseController>
        [HttpGet]
        public async Task<IActionResult> GetWarehouses()
        {
            var warehouses=await this.serviceManager.WarehouseService.GetAllWarehousesAsync();

            return Ok(warehouses);
        }

        // GET api/<WarehouseController>/5
        [HttpGet("{warehouseId}")]
        public async Task<IActionResult> GetWarehouseById(int warehouseId)
        {
            var warehouse = await this.serviceManager.WarehouseService.GetWarehouseByIdAsync(warehouseId);

            return Ok(warehouse);
        }

        // POST api/<WarehouseController>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateWarehouse([FromBody] WarehouseForCreationDto warehouseForCreationDto)
        {
            

            var warehoseDto=await this.serviceManager.WarehouseService.CreateWarehouseAsync(warehouseForCreationDto);

            return CreatedAtAction("GetWarehouseById", new { warehouseId = warehoseDto.Id },warehoseDto);
        }

        // PUT api/<WarehouseController>/5
        [HttpPut("{warehouseId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateWarehouse(int warehouseId, [FromBody] WarehouseForUpdateDto warehouseForUpdateDto)
        {
            await this.serviceManager.WarehouseService.UpdateWarehouseAsync(warehouseId, warehouseForUpdateDto);

            return Ok();
        }

        // DELETE api/<WarehouseController>/5
        [HttpDelete("{warehouseId}")]
        public async Task<IActionResult> DeleteWarehouse(int warehouseId)
        {
            await this.serviceManager.WarehouseService.DeleteWarehouseAsync(warehouseId);
            return Ok();
        }
    }
}

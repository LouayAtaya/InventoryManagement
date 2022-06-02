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
    public class SaleOrdersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public SaleOrdersController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/<SaleOrdersController>
        [HttpGet]
        public async Task<IActionResult> GetSaleOrders()
        {
            var saleOrders = await this._serviceManager.SaleOrderService.GetAllSaleOrdersAsync();

            return Ok(saleOrders);
        }

        // GET api/<SaleOrdersController>/5
        [HttpGet("{saleOrderId}")]
        public async Task<IActionResult> GetSaleOrderById(int saleOrderId)
        {
            var saleOrder = await this._serviceManager.SaleOrderService.GetSaleOrderByIdAsync(saleOrderId);

            return Ok(saleOrder);
        }

        // POST api/<SaleOrdersController>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateSaleOrder([FromBody] SaleOrderForCreationDto saleOrderForCreationDto)
        {
            var saleOrder = await this._serviceManager.SaleOrderService.CreateSaleOrderAsync(saleOrderForCreationDto);

            return CreatedAtAction("GetSaleOrderById", new { saleOrderId = saleOrder.Id }, saleOrder);
        }

        // PUT api/<SaleOrdersController>/5
        [HttpPut("{saleOrderId}")]
        public async Task<IActionResult> UpdateSaleOrder(int saleOrderId, [FromBody] SaleOrderForUpdateDto saleOrderForUpdateDto)
        {
            await this._serviceManager.SaleOrderService.UpdateSaleOrderAsync(saleOrderId, saleOrderForUpdateDto);

            return Ok();
        }

        // PUT api/<SaleOrdersController>/5
        [HttpPut("{saleOrderId}/status/{saleOrderStatus}")]
        public async Task<IActionResult> UpdateSaleOrderStatus(int saleOrderId, SaleOrderStatus saleOrderStatus)
        {
            await this._serviceManager.SaleOrderService.UpdateSaleOrderStatusAsync(saleOrderId, saleOrderStatus);

            return Ok();
        }

        // DELETE api/<SaleOrdersController>/5
        [HttpDelete("{saleOrderId}")]
        public async Task<IActionResult> Delete(int saleOrderId)
        {
            await this._serviceManager.SaleOrderService.DeleteSaleOrderAsync(saleOrderId);

            return Ok();
        }
    }
}

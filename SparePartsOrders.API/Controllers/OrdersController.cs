using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SparePartsOrders.API.Models;
using SparePartsOrders.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsOrders.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersService _ordersService;

        public OrdersController(OrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get() =>
            await _ordersService.GetAsync();

        [HttpGet("{api/received-orders}")]
        public async Task<ActionResult<List<Order>>> GetReceivedAsync() =>
            await _ordersService.GetReceivedAsync();

        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> Put(string id, Order updateOrder)
        {
            var order = await _ordersService.GetAsync(id);

            if(order == null)
            {
                return NotFound();
            }

            await _ordersService.UpdateAsync(id, updateOrder);

            return updateOrder;
        }
    }
}

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
    }
}

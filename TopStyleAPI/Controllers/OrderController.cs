using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Domain.DTO;

namespace TopStyleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersOrders()
        {
            var result = await _orderService.GetUsersOrders();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderPlacementDTO orderDetails)
        {
            await _orderService.CreateOrder(orderDetails);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteOrder(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> AddProductToOrder(OrderAddProductDTO info)
        {
            await _orderService.AddProductToOrder(info);
            return Ok();
        }

    }
}

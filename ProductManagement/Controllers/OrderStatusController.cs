using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.IService;
using ProductManagement.Models;
using ProductManagement.Pag;
using ProductManagement.Service;

namespace ProductManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/OrderStatus")]
    public class OrderStatusController : ControllerBase
    {
        private readonly IOrderStatusService _statusService;
        public OrderStatusController(IOrderStatusService orderStatusService)
        {
            _statusService = orderStatusService;
        }
        [Authorize(Roles = "Admin")]

        //Order_Status
        [HttpPost("AddStatus")]
        public IActionResult AddOrderStatus(Order_status status)
        {
            var res = _statusService.AddOrderStatus(status);
            return Ok(res);
        }
        [Authorize(Roles = "Seller")]
        [HttpPut("UpdateStatus/{id}")]
        public IActionResult UpdateStatus(int id, Order_status status)
        {
            var res = _statusService.UpdateOrderStatus(id, status);
            return Ok(res);
        }
        [Authorize]
        [HttpGet("ListOrderStatus")]
        public IActionResult ListStatus([FromQuery] Pagination pagination)
        {
            var res = _statusService.GetAllOrderStatus(pagination);
            return Ok(res);
        }
        [Authorize]
        [HttpGet("GetOrderStatus/{id}")]
        public IActionResult GetStatus(int id)
        {
            var res = _statusService.GetOrderStatusById(id);
            return Ok(res);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteStatus/{id}")]
        public IActionResult DeleteStatus(int id)
        {
            var res = _statusService.DeleteOrderStatus(id);
            return Ok(res);
        }
    }
}

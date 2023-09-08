using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.IService;
using ProductManagement.Models;
using ProductManagement.Pag;
using ProductManagement.Service;
using System;
using System.Data;
using System.Net.Mail;

namespace ProductManagement.Controllers
{
    [ApiController]
    [Route("api/Order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly AppDbContext DbContext;
        public OrderController(IOrderService orderService, AppDbContext appDbContext)
        {
            _orderService = orderService;
            DbContext = appDbContext;
        }

        //Order
        [Authorize(Roles = "User")]
        [HttpPost("AddOrder")]
        public IActionResult AddOrder(Order order)
        {
            var res = _orderService.AddOrder(order);
            return Ok(res);
        }
        [Authorize(Roles = "Seller")]
        [HttpPut("UpdateOrderForSeller/{id}")]
        public IActionResult UpdateOrder(int id, Order order)
        {
            var res = _orderService.UpdateOrderForSeller(id, order);
            return Ok(res);
        }
        [Authorize(Roles = "Shipper")]
        [HttpPut("UpdateOrderForShip/{id}")]
        public IActionResult UpdateOrderForShip(int id, Order order)
        {
            var res = _orderService.UpdateOrderForShip(id, order);
            return Ok(res);
        }
        [HttpGet("ListOrder")]
        public IActionResult ListOrder([FromQuery] Pagination pagination)
        {
            var res = _orderService.GetAllOrder(pagination);
            return Ok(res);
        }
        [HttpGet("GetOrder/{id}")]
        public IActionResult GetOrder(int id)
        {
            var res = _orderService.GetOrderById(id);
            return Ok(res);
        }
        [Authorize(Roles = "Seller")]
        [HttpDelete("DeleteOrder/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var res = _orderService.DeleteOrder(id);
            return Ok(res);
        }
    }
}

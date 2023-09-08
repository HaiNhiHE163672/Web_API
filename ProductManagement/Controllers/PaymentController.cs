using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.IService;
using ProductManagement.Models;
using ProductManagement.PaymentOnline.MoMo.Request;
using ProductManagement.Service;

namespace ProductManagement.Controllers
{
    
    [ApiController]
    [Route("api/Payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [Authorize(Roles = "Admin")]
        //Payment
        [HttpPost("AddPayment")]
        public IActionResult AddPayment(Payment payment)
        {
            var res = _paymentService.AddPayment(payment);
            return Ok(res);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdatePayment/{id}")]
        public IActionResult UpdatePayment(int id, Payment payment)
        {
            var res = _paymentService.UpdatePayment(id, payment);
            return Ok(res);
        }
        [Authorize]
        [HttpGet("ListPayment")]
        public IActionResult ListPayment()
        {
            var res = _paymentService.GetAllPayments();
            return Ok(res);
        }
        [Authorize]
        [HttpGet("GetPayment/{id}")]
        public IActionResult GetPayment(int id)
        {
            var res = _paymentService.GetPaymentById(id);
            return Ok(res);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeletePayment/{id}")]
        public IActionResult DeletePayment(int id)
        {
            var res = _paymentService.DeletePayment(id);
            return Ok(res);
        }

    }
}

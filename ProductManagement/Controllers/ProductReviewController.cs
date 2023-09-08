using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.IService;
using ProductManagement.Models;
using ProductManagement.Service;

namespace ProductManagement.Controllers
{
    [Authorize(Roles = "User")]
    [ApiController]
    [Route("api/ProductReview")]
    public class ProductReviewController : ControllerBase
    {
        private readonly IProductReviewService _productReviewService;
        public ProductReviewController(IProductReviewService productReviewService)
        {
            _productReviewService = productReviewService;
        }
        //ProductReview
        [HttpPost("AddReview")]
        public IActionResult AddReview(Product_review product_Review)
        {
            var res = _productReviewService.AddProductReview(product_Review);
            return Ok(res);
        }
    }
}

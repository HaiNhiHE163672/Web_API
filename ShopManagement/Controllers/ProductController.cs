using Microsoft.AspNetCore.Mvc;
using ShopManagement.Interface;
using ShopManagement.Models;
using ShopManagement.Service;

namespace ShopManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController()
        {
            productService = new ProductService();
        }
        [HttpPost]
        public IActionResult MuaSanPham(ProductDetail productDetail)
        {
            var res = productService.MuaSanPham(productDetail);
            return Ok(res);
        }
    }
}

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
        public IActionResult MuaSanPham(int productId, int quantity, int sizeId, int? colorId = null, int? designId = null)
        {
            var res = productService.MuaSanPham(productId, quantity, sizeId, colorId, designId);
            return Ok(res);
        }
        [HttpPut("CapNhatSoLuong")]
        public IActionResult CapNhatSoLuong(int productId, int quantity, int sizeId, int? colorId = null, int? designId = null)
        {
            var res = productService.CapNhatSoLuong(productId, quantity, sizeId, colorId, designId);
            return Ok(res);
        }
        [HttpGet]
        public IActionResult DsSanPham([FromQuery] Pagination pagination)
        {
            var res = productService.DsSanPham(pagination);
            return Ok(res);
        }
    }
}

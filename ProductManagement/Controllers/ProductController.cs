using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.IService;
using ProductManagement.Models;
using ProductManagement.Pag;
using ProductManagement.Service;
using System.Data;

namespace ProductManagement.Controllers
{
    [Authorize(Roles = "Seller")]
    [ApiController]
    [Route("api/Product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;

        }

        //Product
        [HttpPost("AddProduct")]
        public IActionResult AddProduct(Product product)
        {
            var res = _productService.AddProduct(product);
            return Ok(res);
        }
        [HttpPut("UpdateProduct/{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            var res = _productService.UpdateProduct(id, product);
            return Ok(res);
        }
        [AllowAnonymous]
        [HttpGet("ListProduct")]
        public IActionResult ListProduct([FromQuery] Pagination pagination)
        {
            var res = _productService.GetAll(pagination);
            return Ok(res);
        }
        [AllowAnonymous]
        [HttpGet("GetProduct/{id}")]
        public IActionResult GetProduct(int id)
        {
            var res = _productService.GetProductById(id);
            return Ok(res);
        }
        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var res = _productService.DeleteProduct(id);
            return Ok(res);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.IService;
using ProductManagement.Models;
using ProductManagement.Service;
using System.Data;

namespace ProductManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/ProductType")]
    public class ProductTypeController :ControllerBase
    {
        private readonly IProductTypeService _productTypeService;
        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        //Product Type
        [HttpPost("AddProductType")]
        public IActionResult AddProductType(Product_type product_Type)
        {
            var res = _productTypeService.AddProductType(product_Type);
            return Ok(res);
        }
        [HttpPut("UpdateProductType/{id}")]
        public IActionResult UpdateProductType(int id, Product_type product_Type)
        {
            var res = _productTypeService.UpdateProductType(id, product_Type);
            return Ok(res);
        }
        [HttpGet("ListProductType")]
        public IActionResult ListProductType()
        {
            var res = _productTypeService.GetProduct_Types();
            return Ok(res);
        }
        [HttpGet("GetProductType/{id}")]
        public IActionResult GetProductType(int id)
        {
            var res = _productTypeService.GetProductType(id);
            return Ok(res);
        }
    }
}

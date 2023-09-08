using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductManagement.Models;
using ProductManagement.Pag;

namespace ProductManagement.IService
{
    public interface IProductService
    {
        public Product AddProduct(Product product);
        public Product UpdateProduct(int id,Product product);
        public Product GetProductById(int id);
        public PageResult<Product> GetAll(Pagination pagination);
        public string DeleteProduct(int id);
    }
}

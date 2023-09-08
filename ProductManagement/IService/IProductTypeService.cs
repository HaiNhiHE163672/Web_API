using ProductManagement.Models;

namespace ProductManagement.IService
{
    public interface IProductTypeService
    {
        public Product_type AddProductType(Product_type type);
        public Product_type UpdateProductType(int id, Product_type type);
        public List<Product_type> GetProduct_Types();
        public Product_type GetProductType(int id);
        public string DeleteProductType(int id);
    }
}

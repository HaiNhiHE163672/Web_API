using Microsoft.EntityFrameworkCore;
using ProductManagement.IService;
using ProductManagement.Models;

namespace ProductManagement.Service
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly AppDbContext DbContext;
        public ProductTypeService(AppDbContext appDbContext)
        {
            DbContext = appDbContext;
        }
        public Product_type AddProductType(Product_type type)
        {
            type.Created_at = DateTime.Now;
            DbContext.Add(type);
            DbContext.SaveChanges();
            return type;
        }
        public List<Product> Search(string name)
        {
            if(DbContext.product_Types.Any(x => x.Name_product_type.Contains(name)))
            {
                var list = DbContext.products.Include(x => x.Product_Type).Include(x => x.Product_Images).Where(x => x.Product_Type.Name_product_type.Contains(name)).ToList();
                return list;
            }
            else
            {
                throw new Exception("Not have product type exist");
            }
        }

        public string DeleteProductType(int id)
        {
            if (DbContext.product_Types.Any(x => x.Product_TypeId == id))
            {
                var type = DbContext.product_Types.Find(id);
                DbContext.Remove(type);
                DbContext.SaveChanges();
                var products = DbContext.products.Where(x => x.Product_TypeId == id).ToList();
                foreach (var product in products)
                {
                    var review = DbContext.product_Reviews.Where(x => x.ProductId == product.ProductId).ToList();
                    DbContext.RemoveRange(review);
                    DbContext.SaveChanges();
                    var images = DbContext.product_Images.Where(x => x.ProductId == product.ProductId).ToList();
                    DbContext.RemoveRange(images);
                    DbContext.SaveChanges();
                    var dsdetail = DbContext.orders_detail.Where(x => x.ProductId == product.ProductId).ToList();
                    DbContext.RemoveRange(dsdetail);
                    DbContext.SaveChanges();

                }

                DbContext.RemoveRange(products);
                DbContext.SaveChanges();
                var orders = DbContext.orders.Include(x => x.Order_Details).ToList();
                foreach (var order in orders)
                {
                    double actual = 0;
                    foreach (var detail in order.Order_Details)
                    {
                        if (DbContext.products.Any(x => x.ProductId == detail.ProductId))
                        {
                            detail.OrderId = order.OrderId;
                            var p = DbContext.products.FirstOrDefault(x => x.ProductId == detail.ProductId);
                            actual += detail.Price_total - detail.Price_total * p.Discount / 100;
                        }
                        else
                        {
                            throw new Exception("Product not exist!");
                        }
                    }
                    order.Orginal_Price = DbContext.orders_detail.Where(x => x.OrderId == order.OrderId).Sum(x => x.Price_total);
                    order.Actual_Price = actual;
                    DbContext.Update(order);
                    DbContext.SaveChanges();
                }
                
                return "Delete 1 ProductType successfull";
            }
            else
            {
                return "Product Type not exist";
            }
        }

        public Product_type GetProductType(int id)
        {
            if(DbContext.product_Types.Any(x => x.Product_TypeId == id))
            {
                var type = DbContext.product_Types.Find(id);
                return type;
            }
            else
            {
                throw new Exception("Product Type not exist");
            }
        }

        public List<Product_type> GetProduct_Types()
        {
            return DbContext.product_Types.ToList();
        }

        public Product_type UpdateProductType(int id, Product_type type)
        {
            if (DbContext.product_Types.Any(x => x.Product_TypeId == id))
            {
                var pt = DbContext.product_Types.Find(id);
                pt.Name_product_type = type.Name_product_type;
                pt.Image_type_product = type.Image_type_product;
                pt.Updated_at = DateTime.Now;
                DbContext.Update(pt);
                DbContext.SaveChanges();
                return pt;
            }
            else
            {
                throw new Exception("Product Type not exist");
            }
        }
    }
}

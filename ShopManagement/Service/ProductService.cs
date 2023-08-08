using ShopManagement.Interface;
using ShopManagement.Models;

namespace ShopManagement.Service
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext DbContext;
        public ProductService()
        {
            DbContext = new AppDbContext();
        }
        public string MuaSanPham(ProductDetail productDetail)
        {
            if(DbContext.ProductDetails.Any(x => x.ProductDetailId == productDetail.ProductDetailId))
            {
                var sp = DbContext.ProductDetails.Find(productDetail.ProductDetailId);
                if(sp.Quantity == 0)
                {
                    return "Sản phẩm hết hàng";
                }
                else if (sp.Quantity < productDetail.Quantity)
                {
                    return "Sản phẩm không đủ số lượng";
                }
                else
                {
                    sp.Quantity -= productDetail.Quantity;
                    DbContext.Update(sp);
                    DbContext.SaveChanges();
                    return "Mua hàng thành công";
                }
            }
            else
            {
                return "Sản phẩm không tồn tại. Vui lòng kiểm tra lại sản phẩm ID!";
            }
        }
    }
}

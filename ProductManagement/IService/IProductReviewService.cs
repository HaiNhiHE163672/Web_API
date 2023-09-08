using ProductManagement.Models;

namespace ProductManagement.IService
{
    public interface IProductReviewService
    {
        public Product_review AddProductReview(Product_review product_Review);
        public Product_review UpdateProductReview(Product_review product_Review);
        public string DeleteReview(int id);
        public List<Product_review> GetProductReviews(int id);
        public List<Product_review> AllReview();
    }
}

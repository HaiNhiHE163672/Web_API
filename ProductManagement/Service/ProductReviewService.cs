using Microsoft.EntityFrameworkCore;
using ProductManagement.IService;
using ProductManagement.Models;

namespace ProductManagement.Service
{
    public class ProductReviewService : IProductReviewService
    {
        private readonly AppDbContext DbContext;
        public ProductReviewService(AppDbContext appDbContext)
        {
            DbContext = appDbContext;
        }
        public Product_review AddProductReview(Product_review product_Review)
        {
            var userLs = DbContext.orders.Include(x => x.Order_Details).Where(x => x.Order_StatusId == 6 && x.Order_Details.Any(x => x.ProductId == product_Review.ProductId)).ToList();
            if(userLs.Count > 0)
            {
                foreach (var user in userLs)
                {
                    if (product_Review.UserId == user.UserId)
                    {
                        DbContext.Add(product_Review);
                        DbContext.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("User not reviewed");
                    }
                }
                return product_Review;
            }
            else
            {
                throw new Exception("User did not buy this product!");
            }
            
            
        }

        public List<Product_review> AllReview()
        {
            throw new NotImplementedException();
        }

        public string DeleteReview(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product_review> GetProductReviews(int id)
        {
            throw new NotImplementedException();
        }

        public Product_review UpdateProductReview(Product_review product_Review)
        {
            if(DbContext.product_Reviews.Any(x => x.Product_ReviewId == product_Review.Product_ReviewId && x.UserId == product_Review.UserId))
            {
                var review = DbContext.product_Reviews.Find(product_Review.Product_ReviewId);
                review.Content_rated = product_Review.Content_rated;
                review.Updated_at = DateTime.Now;
                review.Point_evaluation = product_Review.Point_evaluation;
                review.Content_seen = product_Review.Content_seen;
                DbContext.product_Reviews.Update(review);
                DbContext.SaveChanges();
                return review;
            }
            else
            {
                throw new Exception("Post review not exist!");
            }
        }
    }
}

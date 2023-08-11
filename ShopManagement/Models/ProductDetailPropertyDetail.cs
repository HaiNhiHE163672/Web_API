namespace ShopManagement.Models
{
    public class ProductDetailPropertyDetail
    {
        public int ProductDetailPropertyDetailId { get; set; }

        public int ProductDetailId { get; set; }

        public int PropertyDetailId { get; set; }

        public int ProductId { get; set; }

        public virtual Product? Product { get; set; }

        public virtual ProductDetail ProductDetail { get; set; }

        public virtual PropertyDetail? PropertyDetail { get; set; }

    }
}

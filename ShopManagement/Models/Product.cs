namespace ShopManagement.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public virtual ICollection<ProductDetailPropertyDetail> ProductDetailPropertyDetails { get; set; } 

        public virtual ICollection<Property> Properties { get; set; }
    }
}

namespace ShopManagement.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public virtual List<ProductDetailPropertyDetail> ProductDetailPropertyDetails { get; set; } 

        public virtual List<Property>? Properties { get; set; }
    }
}

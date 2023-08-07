namespace Products.Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public List<ProductDetailPropertyDetails> ProductDetailPropertyDetails { get; set; }
    }
}

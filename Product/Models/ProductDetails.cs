namespace Products.Models
{
    public class ProductDetails
    {
        public int ProductDetailId { get; set; }
        public string ProductPropertyName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float ShellPrice { get; set; }
        public int ParentId { get; set; }
        public List<ProductDetailPropertyDetails> ProductDetailPropertyDetails { get; set; }
    }
}

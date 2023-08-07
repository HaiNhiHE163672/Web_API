namespace Products.Models
{
    public class ProductDetailPropertyDetails
    {
        public int ProductDetailPropertyDetailId { get; set; }
        public int ProductDetailId { get; set; }
        public int PropertyDetailId { get; set; }
        public int ProductId { get; set; }
        public ProductDetails ProductDetails { get; set; }
        public PropertyDetails PropertyDetails { get; set; }
        public Products Products { get; set; }

    }
}

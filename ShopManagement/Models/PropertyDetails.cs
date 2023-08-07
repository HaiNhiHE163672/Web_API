namespace Products.Models
{
    public class PropertyDetails
    {
        public int PropertyDetailId { get; set; }
        public int PropertyId { get; set; }
        public string PropertyDetailCode { get; set; }
        public string PropertyDetailDetail { get; set;}
        public Properties Properties { get; set; }
        public List<ProductDetailPropertyDetails> ProductDetailPropertyDetails { get; set; }
    }
}

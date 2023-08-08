namespace ShopManagement.Models
{
    public class PropertyDetail
    {
        public int PropertyDetailId { get; set; }

        public int PropertyId { get; set; }

        public string PropertyDetailCode { get; set; }

        public string PropertyDetailDetail { get; set; }

        public virtual List<ProductDetailPropertyDetail> ProductDetailPropertyDetails { get; set; }

        public virtual Property Property { get; set; }
    }
}

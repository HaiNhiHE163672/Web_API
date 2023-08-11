namespace ShopManagement.Models
{
    public class ProductDetail
    {
        public int ProductDetailId { get; set; }

        public string ProductDetailName { get; set; } = null!;

        public int Quantity { get; set; }

        public double Price { get; set; }

        public double? ShellPrice { get; set; }

        public int? ParentId { get; set; }

        public virtual List<ProductDetailPropertyDetail>? ProductDetailPropertyDetails { get; set; }
    }
}

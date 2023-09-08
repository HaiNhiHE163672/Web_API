namespace ProductManagement.Models
{
    public class Product_type
    {
        public int Product_TypeId { get; set; }
        public string Name_product_type { get; set; }
        public string Image_type_product { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public List<Product>? Products { get; set;}
    }
}

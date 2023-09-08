namespace ProductManagement.Models
{
    public class Product_image
    {
        public int Product_ImageId { get; set; }
        public string Title { get; set; }
        public string Image_product { get; set; }
        public int ProductId { get; set; }
        public int Status { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get;set; }
        public Product? Product { get; set; }
    }
}

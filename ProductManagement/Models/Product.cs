namespace ProductManagement.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int Product_TypeId { get; set; }
        public string Name_product { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string? Avartar_image_product { get; set; }
        public string Title { get; set; }
        public int Discount { get; set; }
        public int Status { get; set; }
        public int? number_of_views { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime? Update_at { get; set;}
        public int UserId { get; set; }
        public Product_type? Product_Type { get; set; }
        public List<Product_image> Product_Images { get; set; }
        public List<Product_review>? Product_Reviews { get; set; }
        public List<Order_detail>? Order_Details { get; set; }
    }
}

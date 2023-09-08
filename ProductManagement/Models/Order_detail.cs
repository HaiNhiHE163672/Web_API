namespace ProductManagement.Models
{
    public class Order_detail
    {
        public int Order_DetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set;}
        public double Price_total { get; set; }
        public int Quantity { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}

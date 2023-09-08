namespace ProductManagement.Models
{
    public class Order_status
    {
        public int Order_StatusId { get; set; }
        public string Status_name { get; set; }
        public List<Order>? Orders { get; set; }
    }
}

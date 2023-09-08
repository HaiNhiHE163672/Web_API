namespace ProductManagement.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string Payment_method { get; set; }
        public int Status { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public List<Order>? Orders { get; set; }
    }
}

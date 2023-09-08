using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public double Orginal_Price { get; set; }
        public double Actual_Price { get; set; }
        public string? Full_name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int Order_StatusId { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public Payment? Payment { get; set; }
        public User? User { get; set; }
        public Order_status? Order_Status { get; set; }
        public List<Order_detail> Order_Details { get; set; }
    }
}

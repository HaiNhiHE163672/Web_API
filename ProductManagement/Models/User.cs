namespace ProductManagement.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? User_name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int AccountId { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get;set; }
        public Account? Account { get; set; }
        public List<Order>? Orders { get; set; }
        public List<Product_review>? Product_Reviews { get; set; }
    }
}

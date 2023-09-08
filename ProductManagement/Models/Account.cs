using Microsoft.Identity.Client;

namespace ProductManagement.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string User_name { get; set; }
        public string? Avartar { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public int DecentralizationId { get; set; }
        public string? ResetPasswordToken { get; set; }
        public DateTime? ResetPasswordTokenExpiry { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get;set; }
        public Decentralization Decentralization { get; set; }
        public User User { get; set; }
    }
}

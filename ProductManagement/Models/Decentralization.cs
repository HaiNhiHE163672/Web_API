namespace ProductManagement.Models
{
    public class Decentralization
    {
        public int DecentralizationId { get; set; }
        public string Authorrity_name { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime? Update_at { get; set;}
        public List<Account> Accounts { get; set; }
    }
}

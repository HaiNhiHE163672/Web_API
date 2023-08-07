namespace Products.Models
{
    public class Properties
    {
        public int PropertyId { get; set; }
        public int ProductId { get; set; }
        public string PropertyName { get; set; }
        public int PropertySort { get; set; }
        public Products Products { get; set; }
    }
}

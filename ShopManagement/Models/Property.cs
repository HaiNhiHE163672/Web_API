namespace ShopManagement.Models
{
    public class Property
    {
        public int PropertyId { get; set; }

        public int ProductId { get; set; }

        public string PropertyName { get; set; }

        public int PropertySort { get; set; }

        public virtual Product Product { get; set; }

        public virtual List<PropertyDetail> PropertyDetails { get; set; }
    }
}

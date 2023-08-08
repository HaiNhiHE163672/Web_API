using Microsoft.EntityFrameworkCore;
using ShopManagement.Models;

namespace ShopManagement
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductDetail> ProductDetails { get; set; }

        public virtual DbSet<ProductDetailPropertyDetail> ProductDetailPropertyDetails { get; set; }

        public virtual DbSet<Property> Properties { get; set; }

        public virtual DbSet<PropertyDetail> PropertyDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Server=DESKTOP-GM3477H;uid=nhinth;pwd=123456789;database=ShopManagement;TrustServerCertificate=True;");

    }
}

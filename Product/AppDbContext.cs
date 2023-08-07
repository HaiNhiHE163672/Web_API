using Microsoft.EntityFrameworkCore;

namespace Products
{
    public class AppDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
    }
}

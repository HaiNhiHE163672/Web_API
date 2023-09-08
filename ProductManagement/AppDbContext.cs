using Microsoft.EntityFrameworkCore;
using ProductManagement.Models;

namespace ProductManagement
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> accounts { get; set; }
        public DbSet<Product> products { get;set; }
        public DbSet<Decentralization> decentralizations { get; set; }
        public DbSet<Product_image> product_Images { get; set; }
        public DbSet<Product_review> product_Reviews { get; set; } 
        public DbSet<Product_type> product_Types { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Order_detail> orders_detail { get; set; }
        public DbSet<Order_status> order_Statuses { get; set; }
        public DbSet<Payment> payment { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public AppDbContext() { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connect = "Server =DESKTOP-GM3477H;uid=nhinth;pwd=123456789; Database = ProductManagemt; TrustServerCertificate=True;";
        //    optionsBuilder.UseSqlServer(connect);
        //}

    }
}

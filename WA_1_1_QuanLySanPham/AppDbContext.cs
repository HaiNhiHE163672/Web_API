using Microsoft.EntityFrameworkCore;
using WA_1_1_QuanLySanPham.Models;

namespace WA_1_1_QuanLySanPham
{
    public class AppDbContext : DbContext
    {
        public DbSet<LoaiSanPham> LoaiSanPham { get; set; }
        public DbSet<SanPham> SanPham { get; set; } 
        public DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connect = "Server =DESKTOP-GM3477H;uid=nhinth;pwd=123456789; Database = QuanLySanPham; TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connect);
        }
    }
}

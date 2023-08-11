using ShopManagement.Models;

namespace ShopManagement.Interface
{
    public interface IProductService
    {
        public string MuaSanPham(int id, int sl, int tt1, int? tt2 = null, int? tt3 = null);
        public string CapNhatSoLuong(int id, int sl, int tt1, int? tt2 = null, int? tt3 = null);
        public PageResult<ProductDetail> DsSanPham(Pagination pagination);
    }
}

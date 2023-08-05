using WA_1_1_QuanLySanPham.Models;

namespace WA_1_1_QuanLySanPham.Interface
{
    public interface IHoaDonServices
    {
        HoaDon ThemHoaDon(HoaDon hoaDon);
        void XoaHoaDon(int hoaDonID);
        string MaGiaoDich();
        HoaDon SuaHoaDon(int hoaDonID, HoaDon hoaDon);
        LoaiSanPham ThemLoaiSanPham(LoaiSanPham loaiSanPham);
    }
}

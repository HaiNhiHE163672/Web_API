using WA_1_1_QuanLySanPham.Models;

namespace WA_1_1_QuanLySanPham.Interface
{
    public interface IHoaDonServices
    {
        public List<HoaDon> LocDsHoaDon(string? search = null,int? nam = null, int? thang = null, DateTime? tuNgay = null, DateTime? denNgay = null, double? tu = null, double? den = null);
        public List<HoaDon> DsHoaDonTheoThoiGian();
        HoaDon ThemHoaDon(HoaDon hoaDon);
        void XoaHoaDon(int hoaDonID);
        string MaGiaoDich();
        HoaDon SuaHoaDon(int hoaDonID, HoaDon hoaDon);
        LoaiSanPham ThemLoaiSanPham(LoaiSanPham loaiSanPham);
    }
}

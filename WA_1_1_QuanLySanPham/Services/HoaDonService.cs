using Microsoft.EntityFrameworkCore;
using WA_1_1_QuanLySanPham.Interface;
using WA_1_1_QuanLySanPham.Models;

namespace WA_1_1_QuanLySanPham.Services
{
    public class HoaDonService : IHoaDonServices
    {
        private readonly AppDbContext DbContext;
        public HoaDonService()
        {
            DbContext = new AppDbContext();
        }
        public HoaDon SuaHoaDon(int hoaDonID, HoaDon hoaDon)
        {
            if (DbContext.HoaDon.Any(x => x.HoaDonId == hoaDonID))
            {
                if (hoaDon.ChiTietHoaDons == null || hoaDon.ChiTietHoaDons.Count() == 0)
                {
                    var list = DbContext.ChiTietHoaDon.Where(x => x.HoaDonId == hoaDon.HoaDonId).ToList();
                    DbContext.RemoveRange(list);
                    DbContext.SaveChanges();
                }
                else
                {
                    var listHT = DbContext.ChiTietHoaDon.Where(x => x.HoaDonId == hoaDon.HoaDonId).ToList();
                    var listDel = new List<ChiTietHoaDon>();
                    foreach (var chiTiet in listHT)
                    {
                        if (!hoaDon.ChiTietHoaDons.Any(x => x.ChiTietHoaDonId == chiTiet.ChiTietHoaDonId))
                        {
                            listDel.Add(chiTiet);
                        }
                        else
                        {
                            var chiTietMoi = hoaDon.ChiTietHoaDons.FirstOrDefault(x => x.ChiTietHoaDonId == chiTiet.ChiTietHoaDonId);
                            chiTiet.SanPhamId = chiTietMoi.SanPhamId;
                            chiTiet.SoLuong = chiTietMoi.SoLuong;
                            chiTiet.DVT = chiTietMoi.DVT;
                            var sanPham = DbContext.SanPham.FirstOrDefault(z => z.SanPhamId == chiTietMoi.SanPhamId);
                            chiTiet.ThanhTien = sanPham.GiaThanh * chiTietMoi.SoLuong;
                            DbContext.Update(chiTiet);
                            DbContext.SaveChanges();
                        }
                    }
                    DbContext.RemoveRange(listDel);
                    DbContext.SaveChanges();
                    foreach (var chiTiet in hoaDon.ChiTietHoaDons)
                    {
                        if (!listHT.Any(x => x.ChiTietHoaDonId == chiTiet.ChiTietHoaDonId))
                        {
                            chiTiet.HoaDonId = hoaDon.HoaDonId;
                            var sanPham = DbContext.SanPham.FirstOrDefault(x => x.SanPhamId == chiTiet.SanPhamId);
                            chiTiet.ThanhTien = sanPham.GiaThanh * chiTiet.SoLuong;
                            DbContext.Add(chiTiet);
                            DbContext.SaveChanges();
                        }
                    }
                }
                hoaDon.TongTien = DbContext.ChiTietHoaDon.Where(x => x.HoaDonId == hoaDon.HoaDonId).Sum(x => x.ThanhTien);
                hoaDon.HoaDonId = hoaDonID;
                hoaDon.ThoiGianCapNhat = DateTime.Now;
                hoaDon.ChiTietHoaDons = null;
                DbContext.Update(hoaDon);
                DbContext.SaveChanges();
                return hoaDon;
            }
            else
            {
                throw new Exception("Hóa đơn không tồn tại!");
            }
            
           
        }
        public string MaGiaoDich()
        {
            var res = DateTime.Now.ToString("yyyyMMdd") + "_";
            var index = DbContext.HoaDon.Count(x => x.ThoiGianTao.Date == DateTime.Now.Date);
            if(index > 0)
            {
                int tmp = index + 1;
                if(tmp < 10)
                {
                   return res + "00" + tmp.ToString();
                }
                else if(tmp < 100)
                {
                   return res + "0" + tmp.ToString();
                }
                else
                {
                   return res + tmp.ToString();
                }
            }
            else
            {
                return res + "001";
            }

        }
        public HoaDon ThemHoaDon(HoaDon hoaDon)
        {
            hoaDon.ThoiGianTao = DateTime.Now;
            hoaDon.MaGiaoDich = MaGiaoDich();
            var list = hoaDon.ChiTietHoaDons;
            hoaDon.ChiTietHoaDons = null;
            DbContext.Add(hoaDon);
            DbContext.SaveChanges();
            foreach (var chitiet in list)
            {
                if (DbContext.SanPham.Any(x => x.SanPhamId == chitiet.SanPhamId))
                {
                    chitiet.HoaDonId = hoaDon.HoaDonId;
                    var sanPham = DbContext.SanPham.FirstOrDefault(x => x.SanPhamId == chitiet.SanPhamId);
                    chitiet.ThanhTien = chitiet.SoLuong * sanPham.GiaThanh;
                    DbContext.Add(chitiet);
                    DbContext.SaveChanges();

                }
                else
                {
                    throw new Exception("Sản phẩm không tồn tại. Vui lòng kiểm tra lại!");
                }

            }
            hoaDon.TongTien = list.Sum(x => x.ThanhTien);
            DbContext.Update(hoaDon);
            DbContext.SaveChanges();
            return hoaDon;

        }

        public void XoaHoaDon(int hoaDonID)
        {
            if(DbContext.HoaDon.Any(x => x.HoaDonId == hoaDonID))
            {
                var HoaDon = DbContext.HoaDon.Find(hoaDonID);
                DbContext.Remove(HoaDon);
                DbContext.SaveChanges();
                var list = DbContext.ChiTietHoaDon.Where(x => x.HoaDonId == hoaDonID).ToList();
                DbContext.RemoveRange(list);
                DbContext.SaveChanges();
            }
        }

        public LoaiSanPham ThemLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            DbContext.LoaiSanPham.Add(loaiSanPham);
            DbContext.SaveChanges();
            return loaiSanPham;
        }

        public PageResult<HoaDon> DsHoaDonTheoThoiGian(Pagination pagination)
        {
            var list = DbContext.HoaDon.Include(x => x.ChiTietHoaDons).OrderByDescending(x => x.ThoiGianTao).ToList();
            var res = PageResult<HoaDon>.ToPageResult(pagination, list);
            pagination.TotalCount = list.Count();
            return new PageResult<HoaDon>(pagination, res);
        }

        public PageResult<HoaDon> LocDsHoaDon(Pagination pagination, string? search = null, int? nam = null, int? thang = null, DateTime? tuNgay = null, DateTime? denNgay = null, double? tu = null, double? den = null)
        {
            var list = DbContext.HoaDon.Include(x => x.ChiTietHoaDons).ToList();
            if(search != null)
            {
                list = list.Where(x => x.MaGiaoDich.Contains(search) || x.TenHoaDon.Contains(search)).ToList();
            }
            if (nam.HasValue)
            {
                list = list.Where(x => x.ThoiGianTao.Year == nam).ToList();
            }
            if(thang.HasValue)
            {
                list = list.Where(x => x.ThoiGianTao.Month == thang).ToList();
            }
            if(tuNgay.HasValue)
            {
                list = list.Where(x => x.ThoiGianTao.Date >= tuNgay.Value.Date).ToList();
            }
            if(denNgay.HasValue)
            {
                list = list.Where(x => x.ThoiGianTao.Date <= denNgay.Value.Date).ToList();
            }
            if(tu.HasValue)
            {
                list = list.Where(x => x.TongTien >= tu).ToList();
            }
            if(den.HasValue)
            {
                list = list.Where(x => x.TongTien <= den).ToList();
            }
            var res = PageResult<HoaDon>.ToPageResult(pagination, list);
            pagination.TotalCount = list.Count();
            return new PageResult<HoaDon>(pagination, res);
        }
    }
}

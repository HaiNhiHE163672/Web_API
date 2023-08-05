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
    }
}

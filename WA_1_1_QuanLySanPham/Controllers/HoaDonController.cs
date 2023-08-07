using Microsoft.AspNetCore.Mvc;
using WA_1_1_QuanLySanPham.Interface;
using WA_1_1_QuanLySanPham.Models;
using WA_1_1_QuanLySanPham.Services;

namespace WA_1_1_QuanLySanPham.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HoaDonController : ControllerBase
    {
        private readonly IHoaDonServices hoaDonController;
        public HoaDonController()
        {
            hoaDonController = new HoaDonService();
        }
        [HttpGet]
        public IActionResult DsHoaDonTheoTG([FromQuery] Pagination pagination)
        {
            var res = hoaDonController.DsHoaDonTheoThoiGian(pagination);
            return Ok(res);
        }
        [HttpGet("LocDsHoaDon")]
        public IActionResult DsHoaDonTheoNgay(Pagination pagination, string? search = null, int? nam = null, int? thang = null, DateTime? tuNgay = null, DateTime? denNgay = null, double? tu = null, double? den = null)
        {
            var res = hoaDonController.LocDsHoaDon(pagination, search, nam,thang,tuNgay,denNgay,tu,den);
            return Ok(res);
        }

        [HttpPost]
        public IActionResult ThemHoaDon([FromBody] HoaDon hoaDon)
        {
            var res = hoaDonController.ThemHoaDon(hoaDon);
            return Ok(res);
        }
        //public IActionResult ThemLoaiSanPham([FromBody] LoaiSanPham loaiSanPham)
        //{
        //    var res = hoaDonController.ThemLoaiSanPham(loaiSanPham);
        //    return Ok(res);
        //}
        [HttpPut("{id}")]
        public IActionResult SuaHoaDon(int id, HoaDon hoaDon)
        {
            var res = hoaDonController.SuaHoaDon(id, hoaDon);
            return Ok(res);
        }
        [HttpDelete("{hoaDonID}")]
        public IActionResult XoaHoaDon(int hoaDonID)
        {
            hoaDonController.XoaHoaDon(hoaDonID);
            return Ok();
        }

    }
}

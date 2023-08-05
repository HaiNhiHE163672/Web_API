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

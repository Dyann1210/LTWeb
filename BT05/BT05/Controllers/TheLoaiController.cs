using BT05.Models;
using Microsoft.AspNetCore.Mvc;

namespace BT05.Controllers
{
    public class TheLoaiController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Ngay = "Ngày 28";
            ViewBag.Thang = "Tháng 2";
            ViewData["Nam"] = "Nam 2024";
            return View();
        }
        public IActionResult Index2()
        {
            var theloai = new TheLoaiViewmodel
            {
                Id = 1,
                Name = "Trinh Thám "
            };
            return View(theloai);
        } }
}

using Microsoft.AspNetCore.Mvc;

namespace Bai03_31_8_24.Controllers
{
    public class NhomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

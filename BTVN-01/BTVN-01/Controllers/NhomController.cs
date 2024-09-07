using Microsoft.AspNetCore.Mvc;

namespace BTVN_01.Controllers
{
    public class NhomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

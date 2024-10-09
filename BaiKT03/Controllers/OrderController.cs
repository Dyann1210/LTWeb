using BaiKT03.Data;
using BaiKT03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BaiKT03.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;
        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index1()
        {
            IEnumerable<Order> order = _db.Order.Include("Supplier").ToList();
            return View(order);
        }
        [HttpGet]
        public IActionResult Upsert(int id)
        {
            Order order = new Order();
            IEnumerable<SelectListItem> dsorder = _db.Order.Select(
            item => new SelectListItem
            {
                Value = item.Id.ToString(),
                Text = item.Name
            });

            ViewBag.DSOrder = dsorder;
            if (id == 0)
            // Create / Insert
            {
                return View(order);
            }
            else // Edit / Update
            {
                order = _db.Order.Include("Supplier").FirstOrDefault(sp => sp.Id == id);
                return View(order);
            }

        }
        [HttpPost]
        public IActionResult Upsert(Order order)
        {
            if (ModelState.IsValid)
            {
                if (order.Id == 0)
                {
                    _db.Order.Add(order);
                }
                else
                {
                    _db.Order.Update(order);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var order = _db.Order.FirstOrDefault(sp => sp.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            _db.Order.Remove(order);
            _db.SaveChanges();
            return Json(new { success = true });
        }
    }
}


using BaiKT03.Data;
using BaiKT03.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiKT03.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SupplierController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var supplier = _db.Supplier.ToList();
            ViewBag.supplier = supplier;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _db.Supplier.Add(supplier);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var supplier = _db.Supplier.Find(id);
            return View(supplier);
        }

        [HttpPost]
        public IActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng TheLoai
                _db.Supplier.Update(supplier);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var supplier = _db.Supplier.Find(id);
            return View(supplier);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var supplier = _db.Supplier.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }
            _db.Supplier.Remove(supplier);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var supplier = _db.Supplier.Find(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        [HttpPost]
        public IActionResult DetailsConfirm(int Id)
        {
            var supplier = _db.Supplier.Find(Id);
            if (supplier == null)
            {
                return NotFound();
            }
            return RedirectToAction("Details", new { id = Id });
        }

        [HttpGet]
        public IActionResult Search(String searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var supplier = _db.Supplier.
                Where(tl => tl.Name.Contains(searchString)).ToList();
                ViewBag.SearchString = searchString;
                ViewBag.Supplier = supplier;
            }
            else
            {
                var supplier = _db.Supplier.ToList();
                ViewBag.Supplier = supplier;
            }
            return View("Index");
        }

    }
}


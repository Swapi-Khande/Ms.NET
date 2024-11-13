using Book_Store_App.Data;
using Book_Store_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store_App.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> categoriesList = _db.Categories.ToList();
            return View(categoriesList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category ct)
        {
            if (ct.Name == ct.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display order and name can not be same.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(ct);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? dataFromDb = _db.Categories.Find(id);
            if (dataFromDb == null)
            {
                return NotFound();
            }
            return View(dataFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category ct)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(ct);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? dataFromDb = _db.Categories.Find(id);
            if (dataFromDb == null)
            {
                return NotFound();
            }
            return View(dataFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? dataFromDb = _db.Categories.Find(id);
            if (dataFromDb == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(dataFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

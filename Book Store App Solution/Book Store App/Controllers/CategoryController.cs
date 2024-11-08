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
    }
}

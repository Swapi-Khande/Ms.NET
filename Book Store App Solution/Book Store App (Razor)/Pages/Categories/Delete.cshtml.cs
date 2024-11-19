using Book_Store_App__Razor_.Data;
using Book_Store_App__Razor_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book_Store_App__Razor_.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id == null || id == 0)
            {
                return;
            }
            Category = _db.Categories.Find(id);
        }
        public IActionResult OnPost()
        {
            Category? dataFromDb = _db.Categories.Find(Category.Id);
            if (dataFromDb == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(dataFromDb);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully !!";
            return RedirectToPage("Index");
        }
    }
}

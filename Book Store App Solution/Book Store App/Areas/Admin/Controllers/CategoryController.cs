using App.DataAccess.Data;
using App.DataAccess.Repository.IRepository;
using App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        //private readonly ApplicationDbContext _db;
        //private readonly ICategoryRepository _categoryRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            //_db = db;
            //_categoryRepo = db;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //List<Category> categoriesList = _db.Categories.ToList();
            //List<Category> categoriesList = _categoryRepo.GetAll().ToList();
            List<Category> categoriesList = _unitOfWork.Category.GetAll().ToList();

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
                TempData["error"] = "Display order and name can not be same. !!";
            }
            if (ModelState.IsValid)
            {
                //_db.Categories.Add(ct);
                //_db.SaveChanges();

                //_categoryRepo.Add(ct);
                //_categoryRepo.SaveToDb();

                _unitOfWork.Category.Add(ct);
                _unitOfWork.SaveToDb();

                TempData["success"] = "Category added successfully !!";
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
            //Category? dataFromDb = _db.Categories.Find(id);
            //Category? dataFromDb = _categoryRepo.Get(u => u.Id == id);
            Category? dataFromDb = _unitOfWork.Category.Get(u => u.Id == id);
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
                //_db.Categories.Update(ct);
                //_db.SaveChanges();

                //_categoryRepo.Update(ct);
                //_categoryRepo.SaveToDb();

                _unitOfWork.Category.Update(ct);
                _unitOfWork.SaveToDb();

                TempData["success"] = "Category updated successfully !!";
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
            //Category? dataFromDb = _db.Categories.Find(id);
            //Category? dataFromDb = _categoryRepo.Get(u => u.Id == id);
            Category? dataFromDb = _unitOfWork.Category.Get(u => u.Id == id);
            if (dataFromDb == null)
            {
                return NotFound();
            }
            return View(dataFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            //Category? dataFromDb = _db.Categories.Find(id);
            //Category? dataFromDb = _categoryRepo.Get(u => u.Id == id);
            Category? dataFromDb = _unitOfWork.Category.Get(u => u.Id == id);

            if (dataFromDb == null)
            {
                return NotFound();
            }

            //_db.Categories.Remove(dataFromDb);
            //_db.SaveChanges();

            //_categoryRepo.Remove(dataFromDb);
            //_categoryRepo.SaveToDb();

            _unitOfWork.Category.Remove(dataFromDb);
            _unitOfWork.SaveToDb();

            TempData["success"] = "Category deleted successfully !!";
            return RedirectToAction("Index");
        }
    }
}

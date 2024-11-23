using App.DataAccess.Repository.IRepository;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Book_Store_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
            //private readonly ApplicationDbContext _db;
            //private readonly ICategoryRepository _categoryRepo;
            private readonly IUnitOfWork _unitOfWork;

            public ProductController(IUnitOfWork unitOfWork)
            {
                //_db = db;
                //_categoryRepo = db;
                _unitOfWork = unitOfWork;
            }
            public IActionResult Index()
            {
                List<Product> productsList = _unitOfWork.Product.GetAll().ToList();
                return View(productsList);
            }

            public IActionResult Create()
            {
                IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            //ViewBag.CategoryList = CategoryList;
            ViewData["CategoryList"] = CategoryList;
            return View();
            }
            [HttpPost]
            public IActionResult Create(Product ct)
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Product.Add(ct);
                    _unitOfWork.SaveToDb();

                    TempData["success"] = "Product added successfully !!";
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
                Product? dataFromDb = _unitOfWork.Product.Get(u => u.Id == id);
                if (dataFromDb == null)
                {
                    return NotFound();
                }
                return View(dataFromDb);
            }
            [HttpPost]
            public IActionResult Edit(Product ct)
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Product.Update(ct);
                    _unitOfWork.SaveToDb();

                    TempData["success"] = "Product updated successfully !!";
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
                Product? dataFromDb = _unitOfWork.Product.Get(u => u.Id == id);
                if (dataFromDb == null)
                {
                    return NotFound();
                }
                return View(dataFromDb);
            }
            [HttpPost, ActionName("Delete")]
            public IActionResult DeletePOST(int? id)
            {
                Product? dataFromDb = _unitOfWork.Product.Get(u => u.Id == id);

                if (dataFromDb == null)
                {
                    return NotFound();
                }

                _unitOfWork.Product.Remove(dataFromDb);
                _unitOfWork.SaveToDb();

                TempData["success"] = "Product deleted successfully !!";
                return RedirectToAction("Index");
            }
        }
}

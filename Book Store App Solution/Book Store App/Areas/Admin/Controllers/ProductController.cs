using App.DataAccess.Repository.IRepository;
using App.Models;
using App.Models.ViewModels;
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

            public IActionResult Upsert(int? id)
            {
                //ViewBag.CategoryList = CategoryList;
                //ViewData["CategoryList"] = CategoryList;
                ProductVM productVm = new ProductVM()
                {
                    CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }),
                    Product = new Product()
                };
                if( id==null || id == 0)
                {
                    //CREATE LOGIC
                    return View(productVm);
                }
                else
                {
                    //UPDATE LOGIC
                    productVm.Product = _unitOfWork.Product.Get(i => i.Id == id);
                    return View(productVm);
                }
             }
            [HttpPost]
            public IActionResult Upsert(ProductVM ct, IFormFile? file)
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Product.Add(ct.Product);
                    _unitOfWork.SaveToDb();

                    TempData["success"] = "Product added successfully !!";
                    return RedirectToAction("Index");
                }
                else
                {
                    ct.CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    });
                    return View(ct);
                }
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

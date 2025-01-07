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
            private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
            {
                //_db = db;
                //_categoryRepo = db;
                _unitOfWork = unitOfWork;
                _webHostEnvironment = webHostEnvironment;
        }
            public IActionResult Index()
            {
                List<Product> productsList = _unitOfWork.Product.GetAll(includeProps: "Category").ToList();
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
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    if (file != null)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string productPath = Path.Combine(wwwRootPath, @"images\product");

                        if (!string.IsNullOrEmpty(ct.Product.ImageUrl))
                        {
                            //Delete old image
                            var oldImagePath = Path.Combine(wwwRootPath, ct.Product.ImageUrl.TrimStart('\\'));

                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }

                        using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        ct.Product.ImageUrl = @"\images\product\" + fileName;
                    }

                    if (ct.Product.Id == 0)
                    {
                        _unitOfWork.Product.Add(ct.Product);
                    }
                    else
                    {
                         _unitOfWork.Product.Update(ct.Product);
                    }

                    _unitOfWork.SaveToDb();
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
            //public IActionResult Delete(int? id)
            //{
            //    if (id == null || id == 0)
            //    {
            //        return NotFound();
            //    }
            //    Product? dataFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            //    if (dataFromDb == null)
            //    {
            //        return NotFound();
            //    }
            //    return View(dataFromDb);
            //}
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

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> productsList = _unitOfWork.Product.GetAll(includeProps: "Category").ToList();
            return Json( new { data = productsList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.Product.Get(u => u.Id == id);

            if (productToBeDeleted == null)
            {
                return Json( new { success = false, message = "Error while deleting ..." });
            }

            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, productToBeDeleted.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Product.Remove(productToBeDeleted);
            _unitOfWork.SaveToDb();

            return Json(new { success = true, message = "Product Deleted Successfully ..." });
        }

        #endregion
    }
}

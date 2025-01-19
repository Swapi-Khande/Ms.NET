using Microsoft.AspNetCore.Mvc;

namespace MicroservicesApp.Services.CartAPI.Controllers
{
    public class CartAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index (int id, ProductsStorage productsStorage)
        {
            var product = productsStorage.TryGetById(id);
            if (product == null)
                return View("NotFound", id);
            return View(product); 
        }
    }
}

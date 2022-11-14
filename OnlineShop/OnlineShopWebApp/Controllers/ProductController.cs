using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        public readonly ProductsStorage produtStorage;
        public ProductController()
        {
            produtStorage = new ProductsStorage();
        }
        public IActionResult Index (int id)
        {
            var product = produtStorage.TryGetById(id);
            if (product == null)
                return View("NotFound", id);
            return View(product); 
        }
    }
}

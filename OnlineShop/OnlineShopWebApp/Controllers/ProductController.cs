using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsStorage productsStorage;

        public ProductController(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }

        public IActionResult Index (int id)
        {
            var product = productsStorage.TryGetById(id);
            if (product == null)
                return View("NotFound", id);
            return View(product); 
        }
    }
}

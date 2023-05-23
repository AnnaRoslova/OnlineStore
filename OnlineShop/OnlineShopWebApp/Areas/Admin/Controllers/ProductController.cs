using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsStorage productsStorage;

        public ProductController(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }
        public ActionResult Index()
        {
            var products = productsStorage.GetProducts();
            return View(products);
        }
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productsStorage.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int productId)
        {
            var product = productsStorage?.TryGetById(productId);
            productsStorage.ProductDelete(product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var product = productsStorage.TryGetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productsStorage.Update(product);
            return RedirectToAction(nameof(Index));
        }
    }
}

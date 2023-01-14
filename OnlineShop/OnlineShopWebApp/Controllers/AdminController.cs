using OnlineShopWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsStorage productsStorage;

        public AdminController(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }

        public ActionResult Orders()
        {
            return View();
        }
        public ActionResult Users()
        {
            return View();
        }

        public ActionResult Roles()
        {
            return View();
        }

        public ActionResult Products()
        {
            var products = productsStorage.GetProducts();
            return View(products);
        }
        public IActionResult AddProduct()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productsStorage.AddProduct(product);
            return RedirectToAction("Products");
        }
        public IActionResult ProductDelete(int productId)
        {
            var product = productsStorage?.TryGetById(productId);
            productsStorage.ProductDelete(product);
            return RedirectToAction("Products");
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
            return RedirectToAction("Products");
        }
    }
}

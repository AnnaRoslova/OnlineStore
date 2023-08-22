using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsStorage productsStorage;

        public ProductController(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }

        public IActionResult Index(Guid id)
        {
            var product = productsStorage.TryGetById(id);
            if (product == null)
                return View("NotFound", id);
            return View(product);
        }
    }
}

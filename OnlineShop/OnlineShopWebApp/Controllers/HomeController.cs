using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using OnlineShop.Db;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly ICartsRepository cartsRepository;
        private readonly User user;

        public HomeController(IProductsStorage productsStorage, ICartsRepository cartsRepository, User user)
        {
            this.productsStorage = productsStorage;
            this.cartsRepository = cartsRepository;
            this.user = user;
        }
        [HttpPost]
        public IActionResult Search(string request)
        {
            var productSearch = productsStorage.SearchName(request);
            if (productSearch.Count == 0)
                return RedirectToAction("Index", "Home");
            return View("index", productSearch);
        }
        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetBuUserId(user.UserId);
            ViewBag.productCount = cart?.Amount;
            var products = productsStorage.GetProducts();
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    Cost = product.Cost,
                    Name = product.Name,
                    Description = product.Description,
                    Color = product.Color,
                    Compound = product.Compound,
                    Manufactured = product.Manufactured,
                    ImagePath = product.ImagePath
                };
                productsViewModels.Add(productViewModel);
            }
            return View(productsViewModels);
        }
    }
}
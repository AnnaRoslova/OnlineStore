using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly ICartsRepository cartsRepository;

        public HomeController(IProductsStorage productsStorage, ICartsRepository cartsRepository)
        {
            this.productsStorage = productsStorage;
            this.cartsRepository = cartsRepository;
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
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);

            var cartViewModel = Mapping.ToCartItemViewModel(cart);

            ViewBag.productCount = cartViewModel?.Amount;

            var products = productsStorage.GetProducts();

            var productsViewModels = new List<ProductViewModel>();

            foreach (var product in products)
            {
                productsViewModels.Add(Mapping.ToProductViewModel(product));
            }
            return View(productsViewModels);
        }
    }
}
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetBuUserId(user.UserId);
            ViewBag.productCount = cart?.Amount;
            var products = productsStorage.GetProducts();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

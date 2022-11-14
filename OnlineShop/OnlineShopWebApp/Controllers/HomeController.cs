using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        public readonly ProductsStorage produtStorage;
        public HomeController()
        {
            produtStorage = new ProductsStorage();
        }

        public IActionResult Index()
        {
            var products = produtStorage.GetProducts();
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

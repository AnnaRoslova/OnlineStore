using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        public readonly ProductStorage produtStorage;
        public HomeController()
        {
            produtStorage = new ProductStorage();
        }

        public string Index()
        {
            var products = produtStorage.GetProducts();
            var result = "";
            foreach (var produrt in products)
            {
                result += produrt+"\n\n";
            }
            return result;
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

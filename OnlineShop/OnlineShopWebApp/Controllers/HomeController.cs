using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private List<Product> products = new List<Product>()
        {
            new Product(1399,"Шлейка", "Шлейка маленьких собак", "Черный", "Кожа", "Аркон"),
            new Product(2459,"Лежанка", "Лежанка для кошек", "Бежевый", "Холофайбер", "LeRo"),
            new Product(699,"Адресник", "Адресник на ошейник для животных", "Черный", "Нержавеющая сталь", "-"),
        };
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string Index()
        {
            var result = "";
            foreach (var produrt in products)
            {
                result += produrt.Id + "\n" + produrt.Name+ "\n" + produrt.Cost + "р"+ "\n"+"\n";
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

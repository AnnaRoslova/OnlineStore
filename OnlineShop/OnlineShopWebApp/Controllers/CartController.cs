using Microsoft.AspNetCore.Mvc;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        public readonly ProductsStorage produtStorage;
        public CartController()
        {
            produtStorage = new ProductsStorage();
        }
        public IActionResult Index()
        {
            var cart = CartsRepository.TryGetBuUserId(Canstants.UserId);
            return View(cart);
        }
        public IActionResult Add (int productid)
        {
            var product = produtStorage.TryGetById(productid);
            CartsRepository.Add(product, Canstants.UserId);
            return RedirectToAction("Index"); 
        }
    }
}

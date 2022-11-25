using Microsoft.AspNetCore.Mvc;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        readonly User user;
        public CartController(User user)
        {
            this.user = user;
        }
        public IActionResult Index()
        {
            var cart = CartsRepository.TryGetBuUserId(user.UserId);
            return View(cart);
        }
        public IActionResult Add (int productid, ProductsStorage productsStorage)
        {
            var product = productsStorage.TryGetById(productid);
            CartsRepository.Add(product, user.UserId);
            return RedirectToAction("Index"); 
        }
    }
}

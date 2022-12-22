using Microsoft.AspNetCore.Mvc;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        readonly User user;
        private readonly IProductsStorage productsStorage;
        private readonly ICartsRepository cartsInMemoryRepository;

        public CartController(IProductsStorage productsStorage, User user, ICartsRepository cartsInMemoryRepository)
        {
            this.productsStorage = productsStorage;
            this.user = user;
            this.cartsInMemoryRepository = cartsInMemoryRepository;
        }
        public IActionResult Index()
        {   
            var cart = cartsInMemoryRepository.TryGetBuUserId(user.UserId);
            return View(cart);
        }
        public IActionResult Add (int productid)
        {
            var product = productsStorage.TryGetById(productid);
            cartsInMemoryRepository.Add(product, user.UserId);
            return RedirectToAction("Index"); 
        }
        public IActionResult DecreaseAmount(int productid)
        {
            cartsInMemoryRepository.DecreaseAmount(productid, user.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear(User user)
        {
            cartsInMemoryRepository.Clear(user.UserId);
            return RedirectToAction("Index");
        }
    }
}

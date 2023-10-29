using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

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
            var cart = cartsInMemoryRepository.TryGetByUserId(user.UserId);
            return View(Mapping.ToCartItemViewModel(cart));
        }
        public IActionResult Add(Guid productid)
        {
            var product = productsStorage.TryGetById(productid);
            cartsInMemoryRepository.Add(product, user.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult DecreaseAmount(Guid productid)
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

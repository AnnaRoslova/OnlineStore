using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using OnlineShop.Db.Models;
using Microsoft.AspNetCore.Authorization;

namespace OnlineShopWebApp.Controllers
{
    [Area("User")]
    [Authorize]
    public class CartController : Controller
    {
        readonly User user;
        private readonly IProductsStorage productsStorage;
        private readonly ICartsRepository cartsInMemoryRepository;

        public CartController(IProductsStorage productsStorage,ICartsRepository cartsInMemoryRepository)
        {
            this.productsStorage = productsStorage;
            this.cartsInMemoryRepository = cartsInMemoryRepository;
        }
        public IActionResult Index()
        {
            var cart = cartsInMemoryRepository.TryGetByUserId(Constants.UserId);
            return View(Mapping.ToCartItemViewModel(cart));
        }
        public IActionResult Add(Guid productid)
        {
            var product = productsStorage.TryGetById(productid);
            cartsInMemoryRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult DecreaseAmount(Guid productid)
        {
            cartsInMemoryRepository.DecreaseAmount(productid, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear(User user)
        {
            cartsInMemoryRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}

using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
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
            var cart = cartsInMemoryRepository.TryGetBuUserId(user.UserId);
            return View(cart);
        }
        public IActionResult Add(Guid productid)
        {
            var product = productsStorage.TryGetById(productid);
            var productViewModel = new ProductViewModel
            {
                Color = product.Color,
                Name = product.Name,
                Description = product.Description,
                Compound = product.Compound,
                Cost = product.Cost,
                Id = product.Id,
                ImagePath = product.ImagePath,
                Manufactured = product.Manufactured
            };
            cartsInMemoryRepository.Add(productViewModel, user.UserId);
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

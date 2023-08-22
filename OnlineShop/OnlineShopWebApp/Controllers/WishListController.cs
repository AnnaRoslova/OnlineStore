using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

namespace OnlineShopWebApp.Controllers
{
    public class WishListController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly IWishListRepository wishListInMemoryRepository;
        private readonly User user;

        public WishListController(IProductsStorage productsStorage, User user, IWishListRepository wishListInMemoryRepository = null)
        {
            this.productsStorage = productsStorage;
            this.user = user;
            this.wishListInMemoryRepository = wishListInMemoryRepository;
        }

        public IActionResult Index()
        {
            var Wishlist = wishListInMemoryRepository.TryGetBuUserId(user.UserId);
            return View(Wishlist);
        }
        public IActionResult Add(Guid productid)
        {
            var product = productsStorage.TryGetById(productid);
            //wishListInMemoryRepository.Add(product, user.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear(User user)
        {
            wishListInMemoryRepository.Clear(user.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid productid)
        {
            wishListInMemoryRepository.Delete(productid, user.UserId);
            return RedirectToAction("Index");
        }
    }
}

using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Area("User")]
    public class WishListController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly IWishListRepository wishListInMemoryRepository;
        private readonly User user;

        public WishListController(IProductsStorage productsStorage, User user, IWishListRepository wishListInMemoryRepository)
        {
            this.productsStorage = productsStorage;
            this.user = user;
            this.wishListInMemoryRepository = wishListInMemoryRepository;
        }

        public IActionResult Index()
        {
            var wishlist = wishListInMemoryRepository.TryGetByUserId(user.UserId);
            var wishListToModel = new WishListViewModel
            {
                Id = wishlist.Id,
                UserId = user.UserId,
                productsWishList = Mapping.productViewModels(wishlist.productsWishList)
            };
            return View(wishListToModel);
        }
        public IActionResult Add(Guid productid)
        {
            var product = productsStorage.TryGetById(productid);
            wishListInMemoryRepository.Add(product, user.UserId);
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

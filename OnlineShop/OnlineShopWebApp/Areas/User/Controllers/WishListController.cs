using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Area("User")]
    [Authorize]
    public class WishListController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly IWishListRepository wishListInMemoryRepository;
        //private readonly User user;

        public WishListController(IProductsStorage productsStorage,IWishListRepository wishListInMemoryRepository)
        {
            this.productsStorage = productsStorage;
            this.wishListInMemoryRepository = wishListInMemoryRepository;
        }

        public IActionResult Index()
        {
            var wishlist = wishListInMemoryRepository.TryGetByUserId(Constants.UserId);
            var wishListToModel = new WishListViewModel
            {
                Id = wishlist.Id,
                UserId = User.Identity.Name,
                productsWishList = Mapping.productViewModels(wishlist.productsWishList)
            };
            return View(wishListToModel);
        }
        public IActionResult Add(Guid productid)
        {
            var product = productsStorage.TryGetById(productid);
            wishListInMemoryRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            wishListInMemoryRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid productid)
        {
            wishListInMemoryRepository.Delete(productid, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}

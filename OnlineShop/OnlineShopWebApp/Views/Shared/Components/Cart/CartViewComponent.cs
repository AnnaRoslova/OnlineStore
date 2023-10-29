using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{

    public class CartViewComponent : ViewComponent
    {

        private readonly ICartsRepository cartsRepository;
        private readonly User user;

        public CartViewComponent(ICartsRepository cartsRepository, User user = null)
        {
            this.cartsRepository = cartsRepository;
            this.user = user;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartsRepository.TryGetByUserId(user.UserId);
            var cartViewModel = Mapping.ToCartItemViewModel(cart);
            var productCounts = cartViewModel?.Amount??0;

            return View("Cart", productCounts);
        }
    }
}

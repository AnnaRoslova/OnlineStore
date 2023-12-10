using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{

    public class CartViewComponent : ViewComponent
    {

        private readonly ICartsRepository cartsRepository;

        public CartViewComponent(ICartsRepository cartsRepository)
        {
            this.cartsRepository = cartsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartsRepository.TryGetByUserId(User.Identity.Name);
            var cartViewModel = Mapping.ToCartItemViewModel(cart);
            var productCounts = cartViewModel?.Amount??0;

            return View("Cart", productCounts);
        }
    }
}

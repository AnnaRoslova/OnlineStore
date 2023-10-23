using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

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

            var cart = cartsRepository.TryGetBuUserId(user.UserId);
            var productCounts = cart?.Amount??0;

            return View("Cart", productCounts);
        }
    }
}

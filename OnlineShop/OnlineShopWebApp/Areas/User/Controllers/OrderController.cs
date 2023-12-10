using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Area("User")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsInMemoryRepository;
        private readonly IOrdersRepository ordersRepository;

        public OrderController(ICartsRepository cartsInMemoryRepository, IOrdersRepository ordersInMemoryRepository)
        {
            this.cartsInMemoryRepository = cartsInMemoryRepository;
            this.ordersRepository = ordersInMemoryRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buy(UserDeliveryInfoViewModel userDeliveryInfo)
        {
            var existingcart = cartsInMemoryRepository.TryGetByUserId(Constants.UserId);
            var order = new Order
            {
                User = Mapping.ToUserDeliveryInfo(userDeliveryInfo),
                Items = existingcart.Items,
            };
            ordersRepository.Add(order);
            cartsInMemoryRepository.Clear(Constants.UserId);
            return View();
        }
    }
}

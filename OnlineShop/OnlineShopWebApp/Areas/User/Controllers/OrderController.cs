using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Area("User")]
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
        public IActionResult Buy(User user, UserDeliveryInfoViewModel userDeliveryInfo)
        {
            var existingcart = cartsInMemoryRepository.TryGetByUserId(user.UserId);
            var order = new Order
            {
                User = Mapping.ToUserDeliveryInfo(userDeliveryInfo),
                Items = existingcart.Items,
            };
            ordersRepository.Add(order);
            cartsInMemoryRepository.Clear(user.UserId);
            return View();
        }
    }
}

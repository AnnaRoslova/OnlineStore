using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
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
        public IActionResult Buy(User user, UserDeliveryInfo userDeliveryInfo)
        {
            var existingcart = cartsInMemoryRepository.TryGetBuUserId(user.UserId);
            var order = new Order
            {
                User = userDeliveryInfo,
                Items = existingcart.Items
            };
            ordersRepository.Add(order);
            cartsInMemoryRepository.Clear(user.UserId);
            return View();
        }
    }
}

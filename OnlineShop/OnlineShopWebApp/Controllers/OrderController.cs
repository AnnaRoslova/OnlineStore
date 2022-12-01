using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult Buy(User user)
        {
            var existingcart = cartsInMemoryRepository.TryGetBuUserId(user.UserId);
            ordersRepository.Add(existingcart);
            cartsInMemoryRepository.Clear(user.UserId);
            return View();
        }
    }
}

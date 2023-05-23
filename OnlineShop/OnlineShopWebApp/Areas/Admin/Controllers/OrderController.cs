using Microsoft.AspNetCore.Mvc;
using System;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {

        private readonly IOrdersRepository ordersRepository;
        public OrderController(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }
        public ActionResult Index()
        {
            var newOrders = ordersRepository.GetOrders();
            return View(newOrders);
        }
        public IActionResult Detail(Guid orderId)
        {
            var order = ordersRepository.TryGetByOrderId(orderId);
            return View("Detail", order);
        }

        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatuses statuses)
        {
            ordersRepository.UpdateOrderStatus(orderId, statuses);
            return RedirectToAction(nameof(Index));
        }
    }
}

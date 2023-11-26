using Microsoft.AspNetCore.Mvc;
using System;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;

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
            if (newOrders == null)
            {
                return View();
            }
            var orderViewModels = Mapping.ToOrderViewModels(newOrders);
            return View(orderViewModels);
        }
        public IActionResult Detail(Guid orderId)
        {
            var order = ordersRepository.TryGetByOrderId(orderId);
            var orderViewModel = Mapping.ToOrderViewModel(order);
            return View("Detail", orderViewModel);
        }

        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatuses status)
        {
            ordersRepository.UpdateOrderStatus(orderId, status);
            return RedirectToAction(nameof(Index));
        }
    }
}

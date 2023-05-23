using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models;
namespace OnlineShopWebApp
{
    public interface IOrdersRepository
    {
        void Add(Order order);
        List<Order> GetOrders();
        Order TryGetByOrderId(Guid orderId);
        void UpdateOrderStatus(Guid orderId, OrderStatuses NewStatus);
    }
}
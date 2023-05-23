using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class OrdersInMemoryRepository : IOrdersRepository
    {
        private List<Order> orders = new List<Order>();
        public void Add(Order order)
        {
            orders.Add(order);
        }
        public List<Order> GetOrders()
        {
            return orders;
        }

        public Order TryGetByOrderId(Guid orderId)
        {
            return orders.FirstOrDefault(x => x.Id == orderId);
        }

        public void UpdateOrderStatus(Guid orderId, OrderStatuses NewStatus)
        {

            var order = TryGetByOrderId(orderId);
            if(order != null)
            {
                order.Statuses = NewStatus;
            }
        }
    }
}

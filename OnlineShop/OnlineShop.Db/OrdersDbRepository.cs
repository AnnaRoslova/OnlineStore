using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class OrdersDbRepository : IOrdersRepository
    {
        private readonly DatabaseContext _databaseContext;

        public OrdersDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public void Add(Order order)
        {
            _databaseContext.Orders.Add(order);
            _databaseContext.SaveChanges();
        }
        public List<Order> GetOrders()
        {
            var orders = _databaseContext.Orders.Include(x=>x.Items).ThenInclude(x=>x.Product).Include(x=>x.User).ToList();
            return orders;
        }

        public Order TryGetByOrderId(Guid orderId)
        {
            return _databaseContext.Orders.Include(x=>x.Items).ThenInclude(x=>x.Product).Include(x=>x.User).FirstOrDefault(x => x.Id == orderId);
        }
        public void UpdateOrderStatus(Guid orderId, OrderStatuses NewStatus)
        {

            var order = TryGetByOrderId(orderId);
            if (order != null)
            {
                order.Status = NewStatus;
                _databaseContext.SaveChanges();
            }
        }
    }
}
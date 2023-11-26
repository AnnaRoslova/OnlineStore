using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class Order
    {
        public Guid Id { get; set; }
        public UserDeliveryInfo User { get; set; }

        public List<CartItem> Items { get; set; }

        public DateTime CreateDateTime { get; set; } 

        public OrderStatuses Status { get; set; }

        public Order()
        {
            Status = OrderStatuses.Created;
            CreateDateTime = DateTime.Now;
        }

    }
}

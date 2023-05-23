using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public UserDeliveryInfo User { get; set; }

        public List<CartItem> Items { get; set; }

        public DateTime CreateDateTime { get; set; } 

        public OrderStatuses Statuses { get; set; }
        public decimal Cost
        {
            get
            {
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }

        public Order()
        {
            Id = Guid.NewGuid();
            CreateDateTime = DateTime.Now;
            Statuses = OrderStatuses.Created;
        }
    }
}

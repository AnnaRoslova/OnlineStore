using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models
{
    public class WishList
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }

        public List<Product> productsWishList { get; set; }
    }
}

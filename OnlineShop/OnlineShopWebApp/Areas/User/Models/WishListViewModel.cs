using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class WishListViewModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }

        public List<ProductViewModel> productsWishList { get; set; }
    }
}

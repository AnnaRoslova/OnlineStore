using System;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IWishListRepository
    {
        void Add(ProductViewModel product, string userid);
        void Clear(string userid);
        void Delete(Guid productid, string userid);
        WishList TryGetBuUserId(string userId);
    }
}
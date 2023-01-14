using System;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IWishListRepository
    {
        void Add(Product product, string userid);
        void Clear(string userid);
        void Delete(int productid, string userid);
        WishList TryGetBuUserId(string userId);
    }
}
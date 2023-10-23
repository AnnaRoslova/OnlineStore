using OnlineShop.Db;
using System;

namespace OnlineShopWebApp
{
    public interface ICartsRepository
    {
        void Add(Product product, string userid);
        Cart TryGetBuUserId(string userId);
        void DecreaseAmount(Guid productid, string userId);
        void Clear(string userId);
    }
}
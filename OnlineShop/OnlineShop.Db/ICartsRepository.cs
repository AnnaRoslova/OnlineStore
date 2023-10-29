using OnlineShop.Db;
using System;

namespace OnlineShopWebApp
{
    public interface ICartsRepository
    {
        void Add(Product product, string userid);
        Cart TryGetByUserId(string userId);
        void DecreaseAmount(Guid productid, string userId);
        void Clear(string userId);
    }
}
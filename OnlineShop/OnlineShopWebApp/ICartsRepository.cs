using System;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface ICartsRepository
    {
        void Add(ProductViewModel product, string userid);
        Cart TryGetBuUserId(string userId);
        void DecreaseAmount(Guid productid, string userId);
        void Clear(string userId);
    }
}
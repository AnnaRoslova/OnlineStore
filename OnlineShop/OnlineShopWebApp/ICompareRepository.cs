using System;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface ICompareRepository
    {
        void Add(ProductViewModel product, string userid);
        Compare TryGetBuUserId(string userId);
        void Clear(string userId);
        void Delete(Guid productid, string userId);
    }
}
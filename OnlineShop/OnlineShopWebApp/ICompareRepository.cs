using System;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface ICompareRepository
    {
        void Add(Product product, string userid);
        Compare TryGetBuUserId(string userId);
        void Clear(string userId);
        void Delete(int productid, string userId);
    }
}
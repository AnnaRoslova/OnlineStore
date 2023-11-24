using System;

namespace OnlineShop.Db
{
    public interface ICompareRepository
    {
        void Add(Product product, string userid);
        Compare TryGetBuUserId(string userId);
        void Clear(string userId);
        void Delete(Guid productid, string userId);
    }
}
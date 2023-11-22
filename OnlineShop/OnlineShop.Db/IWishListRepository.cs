using System;

namespace OnlineShop.Db
{
    public interface IWishListRepository
    {
        void Add(Product product, string userid);
        void Clear(string userid);
        void Delete(Guid productid, string userid);
        WishList TryGetByUserId(string userId);
    }
}
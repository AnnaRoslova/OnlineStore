using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface ICartsRepository
    {
        void Add(Product product, string userid);
        Cart TryGetBuUserId(string userId);
        void DecreaseAmount(int productid, string userId);
        void Clear(string userId);
    }
}
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IProductsStorage
    {
        List<Product> GetProducts();
        Product TryGetById(int id);
    }
}
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IProductsStorage
    {
        void AddProduct(Product product);
        List<Product> GetProducts();
        void ProductDelete(Product product);
        Product TryGetById(int id);
        void Update(Product product);
        List<Product> SearchName(string request);
    }
}
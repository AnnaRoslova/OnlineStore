using System;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public interface IProductsStorage
    {
        void AddProduct(Product product);
        List<Product> GetProducts();
        void ProductDelete(Product product);
        Product TryGetById(Guid id);
        void Update(Product product);
        List<Product> SearchName(string request);
    }
}
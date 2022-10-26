using System.Collections.Generic;
using System.Linq;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class ProductStorage
    {
        private static List<Product> products = new List<Product>()
        {
            new Product(1399,"Шлейка", "Шлейка маленьких собак", "Черный", "Кожа", "Аркон"),
            new Product(2459,"Лежанка", "Лежанка для кошек", "Бежевый", "Холофайбер", "LeRo"),
            new Product(699,"Адресник", "Адресник на ошейник для животных", "Черный", "Нержавеющая сталь", "-"),
        };

        public List<Product> GetProducts()
        {
            return products;
        }
        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }
    }
}

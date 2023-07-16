using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class ProductsInMemoryStorage : IProductsStorage
    {
        private List<Product> products = new List<Product>()
        {
            new Product(1399,"Шлейка", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Черный", "Кожа", "Аркон", "/images/shleika.png"),
            new Product(1399,"Шлейка", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Фиолетовый", "Кожа", "Аркон", "/images/shleika.png"),
            new Product(2459,"Лежанка", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Бежевый", "Холофайбер", "LeRo", "/images/lezanka.png"),
            new Product(699,"Адресник", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Черный", "Нержавеющая сталь", "-", "/images/adressnik.png"),
            new Product (139, "Ошейник", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "В ассортименте", "Хлопок", "IMAC", "/images/osheinik.png"),
            new Product (2099, "Поилка для животных", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Голубой", "Пластик", "-", "/images/poilka.png")
        };

        public List<Product> GetProducts()
        {
            return products;
        }
        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }
       
        public void ProductDelete(Product product)
        {
            products.Remove(product);
        }
        public void Update(Product product) {
            var existingProduct = products.FirstOrDefault(x => x.Id == product.Id);
            if(existingProduct == null)
            {
                return;
            }
            existingProduct.Name = product.Name;
            existingProduct.Cost = product.Cost;
            existingProduct.Color = product.Color;
            existingProduct.Manufactured = product.Manufactured;
            existingProduct.Description = product.Description;
            existingProduct.Compound = product.Compound;
        }

        public List<Product> SearchName(string request)
        {
            var productsSearch = products.Where(s => s.Name!.ToLower().Contains(request)).ToList();
            return productsSearch;
        }
    }
}

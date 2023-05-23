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
            new Product(1399,"Шлейка", "Шлейка маленьких собак", "Черный", "Кожа", "Аркон", "/images/shleika.png"),
            new Product(1399,"Шлейка", "Шлейка маленьких собак", "Фиолетовый", "Кожа", "Аркон", "/images/shleika.png"),
            new Product(2459,"Лежанка", "Лежанка для кошек", "Бежевый", "Холофайбер", "LeRo", "/images/lezanka.png"),
            new Product(699,"Адресник", "Адресник на ошейник для животных", "Черный", "Нержавеющая сталь", "-", "/images/adressnik.png"),
            new Product (139, "Ошейник", "Ошейник для кошек", "В ассортименте", "Хлопок", "IMAC", "/images/osheinik.png"),
            new Product (2099, "Поилка для животных", "Поилка фонтан, с фильтром", "Голубой", "Пластик", "-", "/images/poilka.png")
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

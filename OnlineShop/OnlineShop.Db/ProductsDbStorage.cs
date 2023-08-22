using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Db;

namespace OnlineShopWebApp
{
    public class ProductsDbStorage : IProductsStorage
    {
        private readonly DatabaseContext databaseContext;

        public ProductsDbStorage (DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        //private List<Product> products = new List<Product>()
        //{
        //    new Product(1399,"Шлейка", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Черный", "Кожа", "Аркон", "/images/shleika.png"),
        //    new Product(1399,"Шлейка", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Фиолетовый", "Кожа", "Аркон", "/images/shleika.png"),
        //    new Product(2459,"Лежанка", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Бежевый", "Холофайбер", "LeRo", "/images/lezanka.png"),
        //    new Product(699,"Адресник", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Черный", "Нержавеющая сталь", "-", "/images/adressnik.png"),
        //    new Product (139, "Ошейник", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "В ассортименте", "Хлопок", "IMAC", "/images/osheinik.png"),
        //    new Product (2099, "Поилка для животных", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Голубой", "Пластик", "-", "/images/poilka.png")
        //};

        public List<Product> GetProducts()
        {
            return databaseContext.products.ToList();
        }
        public Product TryGetById(Guid id)
        {
            return databaseContext.products.FirstOrDefault(product => product.Id == id);
        }

        public void AddProduct(Product product)
        {
            databaseContext.products.Add(product);
            databaseContext.SaveChanges();
        }

        public void ProductDelete(Product product)
        {
            databaseContext.products.Remove(product);
            databaseContext.SaveChanges();
        }
        public void Update(Product product)
        {
            var existingProduct = databaseContext.products.FirstOrDefault(x => x.Id == product.Id);
            if (existingProduct == null)
            {
                return;
            }
            existingProduct.Name = product.Name;
            existingProduct.Cost = product.Cost;
            existingProduct.Color = product.Color;
            existingProduct.Manufactured = product.Manufactured;
            existingProduct.Description = product.Description;
            existingProduct.Compound = product.Compound;
            databaseContext.SaveChanges ();
        }

        public List<Product> SearchName(string request)
        {
            var productsSearch = databaseContext.products.Where(s => s.Name!.ToLower().Contains(request)).ToList();
            return productsSearch;
        }
    }
}

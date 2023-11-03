using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public List<Product> GetProducts()
        {
            return databaseContext.products.ToList();
        }
        public Product TryGetById(Guid id)
        {
            return databaseContext.products.Include(x=>x.CartItems).FirstOrDefault(product => product.Id == id);
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

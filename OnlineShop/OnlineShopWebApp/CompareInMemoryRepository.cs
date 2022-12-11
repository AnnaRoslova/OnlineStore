using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class CompareInMemoryRepository : ICompareRepository
    {
        private readonly List<Compare> compares = new List<Compare>();

        public Compare TryGetBuUserId(string userId)
        {
            return compares.FirstOrDefault(x => x.UserId == userId);
        }
        public void Add(Product product, string userid)
        {
            var existingCompare = TryGetBuUserId(userid);
            if (existingCompare == null)
            {
                Compare newCompare = new Compare
                {
                    Id = Guid.NewGuid(),
                    UserId = userid,
                    productsCompare = new List<Product> 
                    {
                        product
                    }

                };
                compares.Add(newCompare);
            }
            else
            {
                var existingCompareProduct = existingCompare.productsCompare.FirstOrDefault(x => x.Id == product.Id);
                if(existingCompareProduct == null)
                {
                    existingCompare.productsCompare.Add(product);
                }
            }
        }
        public void Clear(string userid)
        {
            var existingCart = TryGetBuUserId(userid);
            compares.Remove(existingCart);
        }
          public void Delete(int productid, string userid)
        {
            var existingCompare = TryGetBuUserId(userid);
            if (existingCompare == null)
            {
                return;
            }
            else
            {
                var existingCompareProduct = existingCompare?.productsCompare?.FirstOrDefault(x => x.Id == productid);
                if (existingCompareProduct == null)
                {
                    return;
                }
                else
                {
                    existingCompare.productsCompare.Remove(existingCompareProduct);
                }
             
            }
        }
       
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class CompareDbRepository : ICompareRepository
    {
        private readonly DatabaseContext dbContext;
        public CompareDbRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Compare TryGetBuUserId(string userId)
        {
            var compare = dbContext.Compares.Include(x => x.productsCompare).FirstOrDefault(x => x.UserId == userId);
            return compare;
        }
        public void Add(Product product, string userid)
        {
            var existingCompare = TryGetBuUserId(userid);
            if (existingCompare == null)
            {
                Compare newCompare = new Compare
                {
                    UserId = userid,
                    productsCompare = new List<Product>
                    {
                        product
                    }

                };
                dbContext.Compares.Add(newCompare);
                dbContext.SaveChanges();
            }
            else
            {
                var existingCompareProduct = existingCompare.productsCompare.FirstOrDefault(x => x.Id == product.Id);
                if (existingCompareProduct == null)
                {
                    existingCompare.productsCompare.Add(product);
                    dbContext.SaveChanges();
                }
            }
        }
        public void Clear(string userid)
        {
            var existingCart = TryGetBuUserId(userid);
            dbContext.Compares.Remove(existingCart);
            dbContext.SaveChanges();
        }
        public void Delete(Guid productid, string userid)
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
